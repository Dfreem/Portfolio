
-- DROP USER IF EXISTS devin; 
CREATE DATABASE IF NOT EXISTS portfolioDB;
USE portfolioDB;
CREATE USER IF NOT EXISTS devin identified by "!BassCase987";
GRANT all privileges ON *.* TO devin;

 
CREATE TABLE IF NOT EXISTS ContactMessages (Id int Primary Key auto_increment, FromEmail VARCHAR(50), FromName VARCHAR(50), Subject VARCHAR(50), CreatedOn datetime, Body VARCHAR(250));
INSERT INTO ContactMessages (FromEmail, FromName, CreatedOn, Subject, Body)
VALUES ('devin@gmail.com', 'Devin Freeman', now(), 'Nothingburger', 'Absolutely nothing');