
CREATE FUNCTION [dbo].[fn_Encrypt]
(
	@Password NVARCHAR(MAX)
)
RETURNS VARBINARY(MAX)
WITH ENCRYPTION
AS
BEGIN

	DECLARE @_MyPass NVARCHAR(20)

	SET @_MyPass = ''E'' + ''P'' + ''O'' + ''I''  + ''T''
	RETURN EncryptByPassPhrase(@_MyPass, @Password)

END
