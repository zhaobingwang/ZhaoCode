CREATE PROCEDURE UpdateUser
    @namePrefix AS NVARCHAR(10) ,
    @isDel AS TINYINT
AS
    BEGIN
        UPDATE  dbo.Users
        SET     NickName = @namePrefix + NickName ,
                IsDelete = @isDel
        WHERE   Province_Id = 1;
    END;