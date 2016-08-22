%SystemRoot%\Microsoft.NET\Framework\v4.0.30319\installutil.exe C:\Workspaces\TimerQuartz\TimerQuartzService\bin\Debug\TimerQuartzService.exe
Net Start TimerQuartzService
sc config TimerQuartzService start= auto
pause