%安装服务% 
%SystemRoot%\Microsoft.NET\Framework\v4.0.30319\installutil.exe  C:\Users\Administrator\Desktop\WindowsService1\WindowsService1\bin\Debug\WindowsService1.exe

%安装服务后，并自动启动服务%
Net Start Service1


%设置开机启动%
sc config Service1 start= auto

pause