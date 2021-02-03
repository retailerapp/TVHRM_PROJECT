
CREATE PROC sp_Process_Dvcs
(
	@Ma_Dvcs VARCHAR(3) = ''E01'',
	@Drive_Info VARCHAR(100) = ''''
)
--WITH ENCRYPTION
AS
	--RETURN 
BEGIN
	
		
		
		BEGIN TRY
				DECLARE @_Pc_Name VARCHAR(30) 
				DECLARE @_Dvcs VARCHAR(30) 
				DECLARE @_CustID VARCHAR(30) 
				DECLARE @_Con_Server VARCHAR(100)
				DECLARE @_DataBase_Name VARCHAR(100)
				DECLARE @_Server_Name VARCHAR(100)
				
				
				
				SELECT @_DataBase_Name = DB_NAME() 
				SELECT @_Server_Name  = CAST(SERVERPROPERTY(''ServerName'') AS VARCHAR(100))
								
				SELECT @_Pc_Name = HOST_NAME()
				
				SELECT @_Dvcs = Ma_Dvcs ,@_CustID = CustID FROM SYSDMDVCS WHERE Ma_DvCs = @Ma_Dvcs

				IF  OBJECT_ID(''TempDB..#_LIS_SERVER'') IS NOT NULL
					DROP TABLE #_LIS_SERVER
					
				IF  OBJECT_ID(''TempDB..#_Temp'') IS NOT NULL
					DROP TABLE #_Temp
				
				
				
					
				SELECT *
						INTO #_LIS_SERVER
				FROM 
				OPENDATASOURCE(''SQLNCLI'',''Data Source=epoint.myftp.org;User id = hungnv ; password = P@ssw0rd@012013;'').Epoint_Customer.dbo.SYSLICS
				WHERE CustID = @_CustID	AND PC_Name = @_Pc_Name AND DataBase_Name = @_Database_Name AND Drive_Info = @Drive_Info

				
				
				IF NOT EXISTS( SELECT Ma_Dvcs FROM SYSLICSCLIENT WHERE PC_Name = @_Pc_Name AND Ma_Dvcs = @Ma_Dvcs AND CustID = @_CustID AND Server_Name = @_Server_Name AND DataBase_Name = @_DataBase_Name AND Drive_Info = @Drive_Info)
				BEGIN
						
						INSERT INTO  SYSLICSCLIENT  ( Ma_Dvcs, CustID, PC_Name, Server_Name,Database_Name, Key_Log, Key_Module, Ten_Dvcs,Drive_Info,  DateAcc, UserID, Active)
						SELECT Ma_Dvcs, CustID,@_Pc_Name, @_Server_Name,@_DataBase_Name,Key_Log, Key_Module, Ten_Dvcs,  @Drive_Info  ,GETDATE(),'''',1
							FROM SYSDMDVCS WHERE Ma_DvCs = @Ma_Dvcs
				END
				
				IF NOT EXISTS( SELECT Ma_Dvcs FROM #_LIS_SERVER WHERE PC_Name = @_Pc_Name AND Ma_Dvcs = @Ma_Dvcs AND CustID = @_CustID AND Server_Name = @_Server_Name AND DataBase_Name = @_DataBase_Name AND Drive_Info = @Drive_Info)
				BEGIN
					BEGIN TRY
						
						INSERT INTO  OPENDATASOURCE(''SQLNCLI'',
								 ''Data Source=epoint.myftp.org;User id = hungnv ; password = P@ssw0rd@012013;'').Epoint_Customer.dbo.SYSLICS
								 ( Ma_Dvcs, CustID, PC_Name ,Server_Name,Database_Name, Key_Log, Key_Module, Ten_Dvcs, DateAcc,Drive_Info, UserID, Active)
						SELECT Ma_Dvcs, CustID, PC_Name , Server_Name, Database_Name ,Key_Log, Key_Module, Ten_Dvcs, DateAcc,Drive_Info, UserID, Active
							FROM SYSLICSCLIENT WHERE Ma_DvCs = @Ma_Dvcs AND PC_Name = @_Pc_Name AND Drive_Info = @Drive_Info
					END TRY
					BEGIN CATCH 
						PRINT ''Error''
					END CATCH
					
				END
				
				
				
				SELECT *
				INTO #_Temp
				FROM 
				OPENDATASOURCE(''SQLNCLI'',
								 ''Data Source=epoint.myftp.org;User id = hungnv ; password = P@ssw0rd@012013;'').Epoint_Customer.dbo.SYSLICS
				WHERE CustID = @_CustID	
				
				
				UPDATE s1 SET s1.Active = s2.Active ,s1.DateAcc = s2.DateAcc  ,s1.SQL_TEXTRUN = s2.SQL_TEXTRUN,
								s1.Message = s2.Message
					
					FROM SYSLICSCLIENT s1
					INNER JOIN #_Temp s2 ON s1.Ma_Dvcs = s2.Ma_Dvcs AND s1.Pc_Name = s2.Pc_Name AND s1.CustID = s2. CustID AND s1.Database_Name = s2.Database_Name AND s1.Drive_Info  = s2.Drive_Info 
				
				UPDATE OPENDATASOURCE(''SQLNCLI'',
								 ''Data Source=epoint.myftp.org;User id = hungnv ; password = P@ssw0rd@012013;'').Epoint_Customer.dbo.SYSLICS
								 SET IsUpdate = 0 WHERE CustID = @_CustID AND PC_Name = @_Pc_Name AND Ma_Dvcs = @Ma_Dvcs AND CustID = @_CustID AND Server_Name = @_Server_Name AND DataBase_Name = @_DataBase_Name AND Drive_Info = @Drive_Info

		END TRY
		BEGIN CATCH 
			PRINT ''Error''
		END CATCH
END		



