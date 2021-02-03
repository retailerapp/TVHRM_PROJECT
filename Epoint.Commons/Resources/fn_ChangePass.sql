
	--EXEC(''ALTER TABLE SYSMEMBER ADD CheckPass VARBINARY(MAX)'')

	EXEC(''UPDATE SYSMEMBER SET CheckPass = dbo.fn_Encrypt(Password)'')

	


