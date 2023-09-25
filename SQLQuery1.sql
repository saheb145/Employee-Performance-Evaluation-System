select *from AspNetUsers
Create PROCEDURE FetchUserDataByUserId

    @UserId varchar(max)

AS

BEGIN

    SELECT *

        

    FROM

    AspNetUsers au

   

    WHERE

        au.Email = @UserId;

END;

EXEC FetchUserDataByUserId @UserId ='saheb@gmail.com';