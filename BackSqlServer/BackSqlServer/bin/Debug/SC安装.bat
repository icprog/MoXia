@echo.��������......  
@echo off  
@sc create DB_Serviceend binPath= "D:\Project data\MoXia\BackSqlServer\BackSqlServer\bin\Debug\BackSqlServer.exe" DisplayName= BackSqlServer start= auto
@sc description DB_Serviceend ��ʱ�������ݿ�
@sc start DB_Serviceend 
@echo off  
@echo.������ϣ�  
@pause 