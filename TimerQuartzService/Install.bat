%SystemRoot%\Microsoft.NET\Framework\v4.0.30319\installutil.exe %~dp0TimerQuartzService.exe
Net Start TimerQuartzService
sc config TimerQuartzService start= auto
pause