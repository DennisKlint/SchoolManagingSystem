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

USE SchoolDatabase
MERGE INTO Student AS Target
USING (VALUES
	(1, 'Bob'),
	(2, 'Steve'),
	(3, 'Kalle')
)
AS Source (Id, Name)
ON Target.Id = Source.Id
WHEN NOT MATCHED BY TARGET THEN
INSERT (Name)
VALUES (Name);

