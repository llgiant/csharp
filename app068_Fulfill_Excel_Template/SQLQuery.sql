--Создание бд
CREATE DATABASE BankDB
COLLATE Cyrillic_General_CI_AS

USE BankDB

--Создание таблицы
CREATE TABLE Clients
(ID int NOT NULL IDENTITY(1,1),
Name varchar (100),
BirthDate  DATE,
PhoneNumber varchar (4),
Address  varchar (100),
SocialNumber varchar (20)
)

--Заполнение таблицы
INSERT Clients
(Name,BirthDate,PhoneNumber,Address,SocialNumber)
VALUES
(
'Тестовый клиент1','1991-03-08','123','г. Баткен','12345678901234'),
('Тестовый клиент2','1996-04-20','456','г. Бишкек','98765432101234'),
('Тестовый клиент3','1995-08-04','789','г. Нарын','12345543211234'),
('Тестовый клиент4','1989-02-25','012','с. Комсомольское','12345671234567'
)