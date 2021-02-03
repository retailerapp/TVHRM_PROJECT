

CREATE FUNCTION [dbo].[fn_Decrypt]
(
	@CheckPass VARBINARY(MAX)
)
RETURNS NVARCHAR(MAX)
WITH ENCRYPTION
AS
BEGIN

	DECLARE @_MyPass NVARCHAR(20)

	SET @_MyPass = ''E'' + ''P'' + ''O'' + ''I''  + ''T''

	RETURN CONVERT(NVARCHAR(MAX), DecryptByPassPhrase(@_MyPass, @CheckPass))

END
