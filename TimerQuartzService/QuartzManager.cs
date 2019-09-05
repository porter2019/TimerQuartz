using System;
using System.Collections.Generic;
using Quartz;
using Quartz.Impl;
using Common.Logging;

namespace TimerQuartzService
{
    public class QuartzManager<T> where T : BaseJobObj
    {
        #region 变量
        private static ISchedulerFactory schedulerFactory = new StdSchedulerFactory();  //scheduler工厂
        static readonly ILog log = LogManager.GetLogger("JobLogAppender"); //日志信息
        private static String JOB_GROUP_NAME = "JOBGROUP_NAME"; //Job群组名
        private static String TRIGGER_GROUP_NAME = "TRIGGERGROUP_NAME"; //触发器群组名
        #endregion

        #region 添加，删除，修改Job方法
        /// <summary>
        /// 添加一个定时任务，使用默认的任务组名，触发器名，触发器组名 
        /// </summary>
        /// <param name="pStrJobName">任务名</param>
        /// <param name="pStrCronExpress">触发器表达式</param>
        public static void addJob(string pStrJobName, string pStrCronExpress, IDictionary<string, object> pDictionary)
        {
            try
            {
                IScheduler sched = schedulerFactory.GetScheduler();
                // 创建任务
                IJobDetail job = JobBuilder.Create<T>()
                    .WithIdentity(pStrJobName, JOB_GROUP_NAME)
                    .Build();

                // 创建触发器
                ITrigger trigger = TriggerBuilder.Create()
                    .WithIdentity(pStrJobName, TRIGGER_GROUP_NAME)
                    .WithCronSchedule(pStrCronExpress)
                    .Build();

                //给任务传参数
                foreach (KeyValuePair<string, object> kvp in pDictionary)
                {
                    job.JobDataMap.Put(kvp.Key, kvp.Value);
                }

                //IJobListener listener = new PushMsgListener();
                //IMatcher<JobKey> matcher = KeyMatcher<JobKey>.KeyEquals(job.Key);                
                //sched.ListenerManager.AddJobListener(listener, matcher);
                sched.ScheduleJob(job, trigger);
                sched.Start();
            }
            catch (Exception e)
            {
                log.Error("添加任务失败：" + e.StackTrace);
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// 移除一个任务(使用默认的任务组名，触发器名，触发器组名) 
        /// </summary>
        /// <param name="pStrJobName">任务名称</param>
        public static void RemoveJob(string pStrJobName)
        {
            try
            {
                IScheduler sched = schedulerFactory.GetScheduler();
                JobKey jobKey = new JobKey(pStrJobName);
                TriggerKey triggerKey = new TriggerKey(pStrJobName, TRIGGER_GROUP_NAME);
                sched.PauseTrigger(triggerKey);// 停止触发器
                sched.UnscheduleJob(triggerKey);// 移除触发器  
                sched.DeleteJob(jobKey);// 删除任务  
            }
            catch (Exception e)
            {
                log.Error("删除任务失败," + e.StackTrace);
                //throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// 暂停所有任务(使用默认的任务组名，触发器名，触发器组名) 
        /// </summary>
        public static void StopJob()
        {
            try
            {
                IScheduler sched = schedulerFactory.GetScheduler();
                sched.PauseAll();
                //sched.PauseTrigger(triggerKey);// 停止触发器
                //sched.UnscheduleJob(triggerKey);// 移除触发器  
                //sched.DeleteJob(jobKey);// 删除任务  
            }
            catch (Exception e)
            {
                log.Error("暂停任务失败," + e.StackTrace);
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// 暂停一个任务(使用默认的任务组名，触发器名，触发器组名) 
        /// </summary>
        /// <param name="pStrJobName">任务名称</param>
        public static void StopJob(string pStrJobName)
        {
            try
            {
                IScheduler sched = schedulerFactory.GetScheduler();
                JobKey jobKey = new JobKey(pStrJobName);
                //TriggerKey triggerKey = new TriggerKey(pStrJobName, TRIGGER_GROUP_NAME);
                sched.PauseJob(jobKey);
                //sched.PauseTrigger(triggerKey);// 停止触发器
                //sched.UnscheduleJob(triggerKey);// 移除触发器  
                //sched.DeleteJob(jobKey);// 删除任务  
            }
            catch (Exception e)
            {
                log.Error("暂停任务失败," + e.StackTrace);
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// 恢复所有任务(使用默认的任务组名，触发器名，触发器组名) 
        /// </summary>
        public static void ResumeJob()
        {
            try
            {
                IScheduler sched = schedulerFactory.GetScheduler();
                sched.ResumeAll();
            }
            catch (Exception e)
            {
                log.Error("恢复所有任务失败," + e.StackTrace);
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// 恢复一个任务(使用默认的任务组名，触发器名，触发器组名) 
        /// </summary>
        /// <param name="pStrJobName"></param>
        public static void ResumeJob(string pStrJobName)
        {
            try
            {
                IScheduler sched = schedulerFactory.GetScheduler();
                JobKey jobKey = new JobKey(pStrJobName);
                //TriggerKey triggerKey = new TriggerKey(pStrJobName, TRIGGER_GROUP_NAME);
                sched.ResumeJob(jobKey);
            }
            catch (Exception e)
            {
                log.Error("恢复任务失败," + e.StackTrace);
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// 修改一个任务的触发时间(使用默认的任务组名，触发器名，触发器组名) 
        /// </summary>
        /// <param name="pStrJobName">任务名</param>
        /// <param name="pStrCronExpress">触发器表达式</param>
        public static void ModifyJobTime(string pStrJobName, string pStrCronExpress, IDictionary<string, object> pDictionary)
        {
            try
            {
                IScheduler sched = schedulerFactory.GetScheduler();
                TriggerKey triggerKey = new TriggerKey(pStrJobName, TRIGGER_GROUP_NAME);
                ICronTrigger trigger = (ICronTrigger)sched.GetTrigger(triggerKey);
                if (trigger == null)
                {
                    return;
                }
                RemoveJob(pStrJobName);
                addJob(pStrJobName, pStrCronExpress, pDictionary);
            }
            catch (Exception e)
            {
                log.Error("修改任务失败:" + e.StackTrace);
                throw new Exception(e.Message);
            }
        }
        #endregion

        #region 启动，关闭Job
        /// <summary>
        /// 启动所有定时任务 
        /// </summary>
        public static void startJobs()
        {
            try
            {
                IScheduler sched = schedulerFactory.GetScheduler();
                sched.Start();
            }
            catch (Exception e)
            {
                log.Error("启动所有任务失败：" + e.StackTrace);
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// 关闭所有定时任务
        /// </summary>
        public static void ShutdownJobs()
        {
            try
            {
                IScheduler sched = schedulerFactory.GetScheduler();
                if (!sched.IsShutdown)
                {
                    sched.Shutdown();
                }
            }
            catch (Exception e)
            {
                log.Error("关闭任务失败:" + e.StackTrace);
                throw new Exception(e.Message);
            }
        }
        #endregion

    }
}
