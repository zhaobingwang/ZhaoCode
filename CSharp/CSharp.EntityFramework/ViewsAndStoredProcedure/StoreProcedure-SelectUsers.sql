CREATE PROCEDURE SelectUsers
@provinceName AS  NVARCHAR(10)
AS
BEGIN
	SELECT ProvinceName,NickName,RegTime,IsDelete
	FROM dbo.Users
	JOIN dbo.Provinces ON dbo.Users.Province_Id=dbo.Provinces.Id
	WHERE ProvinceName=@provinceName
END
