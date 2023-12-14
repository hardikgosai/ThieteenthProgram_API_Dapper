Create Database GETRIEmployeeDapper

Use GETRIEmployeeDapper

CREATE TABLE Employee
(
EmpId int primary key identity(1,1),
EmpName varchar(50),
EmpAge int,
EmpGender varchar(50),
EmpAddress varchar(50),
EmpContactNo varchar(50)
)

Select * from Employee


CREATE PROCEDURE [dbo].[EmployeeDetails]
AS
BEGIN
	SELECT * FROM Employee
END



CREATE PROCEDURE [dbo].[GetEmployeeByID]
(
@EmpId int
)
AS
BEGIN
	SELECT * FROM Employee WHERE EmpId = @EmpId
END


CREATE PROCEDURE [dbo].[AddNewEmpDetails]
(
	@EmpName VARCHAR(50),
	@EmpAge INT,
	@EmpGender VARCHAR(50),
	@EmpAddress VARCHAR(50),
	@EmpContactNo VARCHAR(50)
)
AS
BEGIN
	INSERT INTO Employee (EmpName, EmpAge, EmpGender, EmpAddress, EmpContactNo)
	VALUES(@EmpName, @EmpAge, @EmpGender, @EmpAddress, @EmpContactNo)
END


CREATE PROCEDURE [dbo].[UpdateNewEmpDetails]
(
	@EmpId INT,
	@EmpName VARCHAR(50),
	@EmpAge INT,
	@EmpGender VARCHAR(50),
	@EmpAddress VARCHAR(50),
	@EmpContactNo VARCHAR(50)
)
AS
BEGIN
	UPDATE Employee 
	SET 
	EmpName = @EmpName, 
	EmpAge = @EmpAge, 
	EmpGender = @EmpGender, 
	EmpAddress = @EmpAddress, 
	EmpContactNo = @EmpContactNo
	WHERE EmpId = @EmpId
END


CREATE PROCEDURE [dbo].[DeleteEmpDetails]
(
	@EmpId INT
)
AS
BEGIN
	DELETE FROM Employee
	WHERE EmpId = @EmpId
END