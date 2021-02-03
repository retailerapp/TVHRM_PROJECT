
CREATE PROC sp_Process_DvcsPC
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
				
				
				
			
				
				
				IF NOT EXISTS( SELECT Ma_Dvcs FROM SYSLICSCLIENT WHERE PC_Name = @_Pc_Name AND Ma_Dvcs = @Ma_Dvcs AND CustID = @_CustID AND Server_Name = @_Server_Name AND DataBase_Name = @_DataBase_Name AND Drive_Info = @Drive_Info)
				BEGIN
						
						INSERT INTO  SYSLICSCLIENT  ( Ma_Dvcs, CustID, PC_Name, Server_Name,Database_Name, Key_Log, Key_Module, Ten_Dvcs,Drive_Info,  DateAcc, UserID, Active)
						SELECT Ma_Dvcs, CustID,@_Pc_Name, @_Server_Name,@_DataBase_Name,Key_Log, Key_Module, Ten_Dvcs,  @Drive_Info  ,GETDATE(),'''',1
							FROM SYSDMDVCS WHERE Ma_DvCs = @Ma_Dvcs
				END
				
				
				
			
			
		END TRY
		BEGIN CATCH 
			PRINT ''Error''
		END CATCH
END		



