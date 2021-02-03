USE [Epoint0]
GO
/****** Object:  StoredProcedure [dbo].[Sp_UpdateResource_Ver]    Script Date: 17/01/2017 1:59:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[Sp_UpdateResource_Ver]
	@File_ID  VARCHAR(20),
	@File_Name  NVARCHAR(200),
	@Ma_Nhom  VARCHAR(20),
	@Catalog  NVARCHAR(100),	
	@File_Type  VARCHAR(20),
	@File_Tag  VARCHAR(20),
	@Ngay_Ky DATETIME,
	@Nguoi_Ky NVARCHAR(100),
	@Duyet BIT		
AS
BEGIN
	UPDATE SYSRESOURCES_VER SET File_ID = @File_ID ,File_Name = @File_Name ,Ma_Nhom = @Ma_Nhom , Catalog = @Catalog,
							File_Type  = @File_Type, File_Tag = @File_Tag, Ngay_Ky = @Ngay_Ky,
							Nguoi_Ky = @Nguoi_Ky, Duyet = @Duyet
	WHERE File_ID = @File_ID 
END
