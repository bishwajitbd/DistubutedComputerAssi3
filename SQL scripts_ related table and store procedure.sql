--CREATE DATABASE Person;
--drop database Person;


USE Person;
GO
IF EXISTS (SELECT TABLE_NAME FROM INFORMATION_SCHEMA.VIEWS
        WHERE TABLE_NAME = 'tblPerson')
    DROP TABLE tblPerson
GO
CREATE TABLE tblPerson
(
 Id int,
 Name nvarchar(50),
 Gender nvarchar(50),
 DateOfBirth datetime
);
GO
IF EXISTS (SELECT TABLE_NAME FROM INFORMATION_SCHEMA.VIEWS
        WHERE TABLE_NAME = 'tblUser')
    DROP TABLE tblUser
GO
CREATE TABLE tblUser
(
 Username nvarchar(50),
 Passwords nvarchar(50)
);

INSERT INTO tblPerson VALUES (1, 'Mark', 'Male', '10/10/1980');
INSERT INTO tblPerson VALUES (2, 'Mary', 'Female', '11/10/1981');
INSERT INTO tblPerson VALUES (3, 'John', 'Male', '8/10/1979');

INSERT INTO tblUser VALUES ('Mark', 'Male')
INSERT INTO tblUser VALUES ('abcd', 'eFCE')

IF OBJECT_ID ( 'spGetPerson', 'P' ) IS NOT NULL 
    DROP PROCEDURE spGetPerson;
GO
CREATE PROCEDURE spGetPerson
@Id int,
@Auth nvarchar(20)
AS
BEGIN
	IF EXISTS(SELECT Username FROM tblUser WHERE Username = @Auth)
	BEGIN
	 SELECT Id, Name, Gender, DateOfBirth
	 FROM tblPerson 
	 WHERE Id = @Id
	 END
END;
GO
IF OBJECT_ID ( 'spSavePerson', 'P' ) IS NOT NULL 
    DROP PROCEDURE spSavePerson;
GO
CREATE PROCEDURE spSavePerson
@Id int,
@Name nvarchar(50),
@Gender nvarchar(50),
@DateOfBirth DateTime,
@Auth nvarchar(20)
AS
BEGIN
	IF EXISTS(SELECT Username FROM tblUser WHERE Username = @Auth)
	BEGIN
	 INSERT INTO tblPerson
	 VALUES (@Id, @Name, @Gender, @DateOfBirth)
	END
END;
