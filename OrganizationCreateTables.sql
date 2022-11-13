DROP TABLE IF EXISTS EmployeeGroups;
DROP TABLE IF EXISTS Groups;
DROP TABLE IF EXISTS Employees;

CREATE TABLE Employees (
	Id		 INT IDENTITY(1, 1) NOT NULL CONSTRAINT PK_EmployeeId PRIMARY KEY,
	FullName VARCHAR(100) NOT NULL,
	Email	 VARCHAR(100) NOT NULL
);

GO
CREATE TABLE Groups (
	Id	 INT IDENTITY(1, 1) NOT NULL CONSTRAINT PK_GroupId PRIMARY KEY,
	Name VARCHAR(100) NOT NULL 
);

GO
CREATE TABLE EmployeeGroups (
	Id INT IDENTITY(1, 1) NOT NULL CONSTRAINT PK_EmployeeGroups PRIMARY KEY,
	EmployeeId INT,
	GroupId INT,
	CONSTRAINT FK_EmployeeGroups_Employees_Id
		FOREIGN KEY (EmployeeId) REFERENCES Employees (Id) ON DELETE CASCADE,
	CONSTRAINT FK_EmployeeGroups_Groups_Id
		FOREIGN KEY (GroupId) REFERENCES Groups (Id) ON DELETE CASCADE
);

GO
INSERT INTO Groups VALUES 
('��������������'), 
('�����������'), 
('���������'), 
('����������');

INSERT INTO Employees VALUES
('����� ������ ����������', 'andrelomov25@gmail.com'),
('��������� ����� ����������', 'andre-lomov25@mail.ru'),
('���������� ����� ���������', 'ya@lomov-1.ru'),
('��������� ������ ��������', 'andrew-lomov25@mail.ru'),
('������� ������ ���������', 'andrelomov25@mail.ru'),
('�������� ������ ������������', 'andreilomlom25@gmail.com')

INSERT INTO EmployeeGroups VALUES
(1, 1),
(1, 2),
(2, 2),
(3, 3),
(4, 3),
(4, 4),
(5, 1),
(6, 3)