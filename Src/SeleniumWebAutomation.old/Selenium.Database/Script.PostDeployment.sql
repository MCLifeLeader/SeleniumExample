/*
Post-Deployment Script Template                     
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.      
 Use SQLCMD syntax to include a file in the post-deployment script.         
 Example:      :r .\myfile.sql                        
 Use SQLCMD syntax to reference a variable in the post-deployment script.      
 Example:      :setvar TableName MyTable                     
               SELECT * FROM [$(TableName)]               
--------------------------------------------------------------------------------------
*/

DECLARE @itemCount AS INT

BEGIN TRAN
IF (SELECT COUNT(Id) AS Id FROM [dbo].[Configuration] WHERE [Key] = 'WebUrlMbCarey') = 0
BEGIN
   INSERT INTO [dbo].[Configuration] ([Key],[Value],[Note]) VALUES ('WebUrlMbCarey','https://www.mbcarey.com/','Michael Carey''s ePortfolio website.')
END

IF (SELECT COUNT(Id) AS Id FROM [dbo].[Configuration] WHERE [Key] = 'UserContext') = 0
BEGIN
   INSERT INTO [dbo].[Configuration] ([Key],[Value],[Note]) VALUES ('UserContext','{"userName": "","password": ""}','UserContext Details.')
END

COMMIT TRAN