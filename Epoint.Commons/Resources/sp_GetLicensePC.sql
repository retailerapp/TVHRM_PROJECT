CREATE PROC sp_GetLicensePC 
(
	@Ma_Dvcs VARCHAR(30) = ''E01'',
	@Drive_Info VARCHAR(100) = ''''
)
WITH ENCRYPTION
AS

BEGIN
				DECLARE @_Pc_Name VARCHAR(30) 				
				DECLARE @_Dvcs VARCHAR(30) 
				DECLARE @_CustID VARCHAR(30) 
				DECLARE @_Con_Server VARCHAR(100)
				DECLARE @_DataBase_Name VARCHAR(100)
				DECLARE @_ServerName VARCHAR(100)
				
				
				
				SELECT @_DataBase_Name = DB_NAME() 
				SELECT @_ServerName  = CAST(SERVERPROPERTY(''ServerName'') AS VARCHAR(100))
				SELECT @_Pc_Name = HOST_NAME()

		IF  OBJECT_ID(''TempDB..#_Temp'') IS NOT NULL
					DROP TABLE #_Temp

		SELECT *
		 FROM SYSLICSCLIENT WHERE Ma_Dvcs = @Ma_Dvcs AND PC_Name = @_Pc_Name AND Drive_Info = @Drive_Info
		
		 
		
END
