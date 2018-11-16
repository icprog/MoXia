@echo.服务启动......  
@echo off  
@sc create DB_Serviceend binPath= "D:\Project data\MoXia\BackSqlServer\BackSqlServer\bin\Debug\BackSqlServer.exe" DisplayName= BackSqlServer start= auto
@sc description DB_Serviceend 定时备份数据库
@sc start DB_Serviceend 
@echo off  
@echo.启动完毕！  
@pause 