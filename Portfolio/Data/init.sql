CREATE DATABASE IF NOT EXISTS portfolioDB;
USE portfolioDB;
CREATE USER IF NOT EXISTS devin identified by "!BassCase987";
GRANT all privileges ON *.* TO devin;

CREATE TABLE IF NOT EXISTS ContactMessages (Id int Primary Key auto_increment, FromEmail VARCHAR(50), FromName VARCHAR(50), Subject VARCHAR(50), CreatedOn datetime, Body VARCHAR(250));
INSERT INTO ContactMessages (FromEmail, FromName, CreatedOn, Subject, Body)
VALUES ('devin@gmail.com', 'Devin Freeman', now(), 'Nothingburger', 'Absolutely nothing');

CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `ProductVersion` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
) CHARACTER SET=utf8mb4;

START TRANSACTION;

ALTER DATABASE portfolioDB CHARACTER SET utf8mb4;
INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20231228042512_Initial', '8.0.0');
COMMIT;

