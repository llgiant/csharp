--�������� ��
CREATE DATABASE BankDB
COLLATE Cyrillic_General_CI_AS

USE BankDB

--�������� �������
CREATE TABLE Clients
(ID int NOT NULL IDENTITY(1,1),
Name varchar (100),
BirthDate  DATE,
PhoneNumber varchar (4),
Address  varchar (100),
SocialNumber varchar (20)
)

--���������� �������
INSERT Clients
(Name,BirthDate,PhoneNumber,Address,SocialNumber)
VALUES
(
'�������� ������1','1991-03-08','123','�. ������','12345678901234'),
('�������� ������2','1996-04-20','456','�. ������','98765432101234'),
('�������� ������3','1995-08-04','789','�. �����','12345543211234'),
('�������� ������4','1989-02-25','012','�. �������������','12345671234567'
)