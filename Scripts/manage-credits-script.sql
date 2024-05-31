CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL,
    PRIMARY KEY (`MigrationId`)
);

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240531093906_InitialCreate')
BEGIN
    CREATE DATABASE IF NOT EXISTS `dbo`
END;

START TRANSACTION;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240531093906_InitialCreate')
BEGIN
    CREATE TABLE `Student` (
        `StudentId` char(36) NOT NULL DEFAULT UUID(),
        `DocumentNumber` varchar(255) NOT NULL,
        `Firstname` varchar(50) NOT NULL,
        `Lastname` varchar(50) NOT NULL,
        `Email` varchar(100) NOT NULL,
        `Created` datetime NOT NULL DEFAULT UTC_TIMESTAMP(),
        `Version` longblob NOT NULL,
        PRIMARY KEY (`StudentId`)
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240531093906_InitialCreate')
BEGIN
    CREATE TABLE `Subject` (
        `SubjectId` char(36) NOT NULL DEFAULT UUID(),
        `Name` varchar(100) NOT NULL,
        `Description` longtext NULL,
        `Created` datetime NOT NULL DEFAULT UTC_TIMESTAMP(),
        `Version` longblob NOT NULL,
        PRIMARY KEY (`SubjectId`)
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240531093906_InitialCreate')
BEGIN
    CREATE TABLE `Teacher` (
        `TeacherId` char(36) NOT NULL DEFAULT UUID(),
        `DocumentNumber` varchar(255) NOT NULL,
        `Firstname` varchar(50) NOT NULL,
        `Lastname` varchar(50) NOT NULL,
        `Email` varchar(100) NOT NULL,
        `Profession` varchar(30) NOT NULL,
        `Created` datetime NOT NULL DEFAULT UTC_TIMESTAMP(),
        `Version` longblob NOT NULL,
        PRIMARY KEY (`TeacherId`)
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240531093906_InitialCreate')
BEGIN
    CREATE TABLE `Class` (
        `ClassId` char(36) NOT NULL DEFAULT UUID(),
        `SubjectId` char(36) NOT NULL,
        `Name` varchar(100) NOT NULL,
        `Description` longtext NULL,
        `Created` datetime NOT NULL DEFAULT UTC_TIMESTAMP(),
        `Version` longblob NOT NULL,
        PRIMARY KEY (`ClassId`),
        CONSTRAINT `FK_Class_Subject_ClassId` FOREIGN KEY (`ClassId`) REFERENCES `Subject` (`SubjectId`) ON DELETE CASCADE
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240531093906_InitialCreate')
BEGIN
    CREATE TABLE `TeacherDetail` (
        `TeacherDetailId` char(36) NOT NULL DEFAULT UUID(),
        `TeacherId` char(36) NOT NULL,
        `SubjectId` char(36) NOT NULL,
        `TotalCredits` decimal(2,1) NOT NULL,
        `Created` datetime NOT NULL DEFAULT UTC_TIMESTAMP(),
        `Version` longblob NOT NULL,
        PRIMARY KEY (`TeacherDetailId`),
        CONSTRAINT `FK_TeacherDetail_Subject_SubjectId` FOREIGN KEY (`SubjectId`) REFERENCES `Subject` (`SubjectId`) ON DELETE CASCADE,
        CONSTRAINT `FK_TeacherDetail_Teacher_TeacherId` FOREIGN KEY (`TeacherId`) REFERENCES `Teacher` (`TeacherId`) ON DELETE CASCADE
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240531093906_InitialCreate')
BEGIN
    CREATE TABLE `StudentDetail` (
        `StudentDetailId` char(36) NOT NULL DEFAULT UUID(),
        `TeacherDetailId` char(36) NOT NULL,
        `StudentId` char(36) NOT NULL,
        `ClassId` char(36) NOT NULL,
        `Status` varchar(10) NOT NULL,
        `Created` datetime NOT NULL DEFAULT UTC_TIMESTAMP(),
        `Version` longblob NOT NULL,
        PRIMARY KEY (`StudentDetailId`),
        CONSTRAINT `FK_StudentDetail_Class_ClassId` FOREIGN KEY (`ClassId`) REFERENCES `Class` (`ClassId`) ON DELETE CASCADE,
        CONSTRAINT `FK_StudentDetail_Student_StudentId` FOREIGN KEY (`StudentId`) REFERENCES `Student` (`StudentId`) ON DELETE CASCADE,
        CONSTRAINT `FK_StudentDetail_TeacherDetail_TeacherDetailId` FOREIGN KEY (`TeacherDetailId`) REFERENCES `TeacherDetail` (`TeacherDetailId`) ON DELETE CASCADE
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240531093906_InitialCreate')
BEGIN
    INSERT INTO `dbo`.`Class` (`ClassId`, `Created`, `Description`, `Name`, `SubjectId`)
    VALUES ('39537c6a-49d9-4496-a170-6e95d517ca81', TIMESTAMP '2024-01-19 04:03:00.000', NULL, 'Interface Segregation Principle', '8a4b2308-49d0-44db-b2d5-675742d5f2fe');
    INSERT INTO `dbo`.`Class` (`ClassId`, `Created`, `Description`, `Name`, `SubjectId`)
    VALUES ('4905befb-9d92-42dd-8be3-82d761339b34', TIMESTAMP '2024-01-17 02:01:00.000', NULL, 'Open-Closed Principle', '8a4b2308-49d0-44db-b2d5-675742d5f2fe');
    INSERT INTO `dbo`.`Class` (`ClassId`, `Created`, `Description`, `Name`, `SubjectId`)
    VALUES ('85f0c48a-7b2b-456a-95fb-8c6b827a719c', TIMESTAMP '2024-01-16 01:00:00.000', NULL, 'Single Responsibility Principle', '8a4b2308-49d0-44db-b2d5-675742d5f2fe');
    INSERT INTO `dbo`.`Class` (`ClassId`, `Created`, `Description`, `Name`, `SubjectId`)
    VALUES ('96437dd9-f3c7-4b11-a2a5-c59a0d5aed1c', TIMESTAMP '2024-01-13 02:01:00.000', 'Learn how to facilitate efficient solutions regarding class compositions and object structures', 'Structural Patterns', '2ee9ebee-460c-4389-a50b-f0b602a2f617');
    INSERT INTO `dbo`.`Class` (`ClassId`, `Created`, `Description`, `Name`, `SubjectId`)
    VALUES ('a9a5f58a-2b02-4a0e-bf43-88a1080c82b4', TIMESTAMP '2024-01-20 05:04:00.000', NULL, 'Dependency Inversion Principle', '8a4b2308-49d0-44db-b2d5-675742d5f2fe');
    INSERT INTO `dbo`.`Class` (`ClassId`, `Created`, `Description`, `Name`, `SubjectId`)
    VALUES ('b96044ee-9bb6-4733-af11-1bd8eedf8b7d', TIMESTAMP '2024-01-12 01:00:00.000', 'Learn how to provide object creation mechanisms that increase the flexibility and reuse of existing code in a way that is appropriate to the situation', 'Creational Patterns', '2ee9ebee-460c-4389-a50b-f0b602a2f617');
    INSERT INTO `dbo`.`Class` (`ClassId`, `Created`, `Description`, `Name`, `SubjectId`)
    VALUES ('c5bc16d1-1046-4b44-976a-564fc5df7d65', TIMESTAMP '2024-01-18 03:02:00.000', NULL, 'Liskov Substitution Principle', '8a4b2308-49d0-44db-b2d5-675742d5f2fe');
    INSERT INTO `dbo`.`Class` (`ClassId`, `Created`, `Description`, `Name`, `SubjectId`)
    VALUES ('fe4f5476-b903-4399-b4d8-d97d9d3b1c22', TIMESTAMP '2024-01-14 03:02:00.000', 'Learn to communicate objects, detect objects already present and manipulate them', 'Behavior Patterns', '2ee9ebee-460c-4389-a50b-f0b602a2f617');
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240531093906_InitialCreate')
BEGIN
    INSERT INTO `dbo`.`Student` (`StudentId`, `Created`, `DocumentNumber`, `Email`, `Firstname`, `Lastname`)
    VALUES ('107e7e52-74fc-4589-b7d9-5f1ffc434637', TIMESTAMP '2024-03-02 00:00:00.000', '1109432112', 'jeison.bonilla@gmail.com', 'Jeison Andrés', 'Bonilla');
    INSERT INTO `dbo`.`Student` (`StudentId`, `Created`, `DocumentNumber`, `Email`, `Firstname`, `Lastname`)
    VALUES ('ee466b07-1d3e-4356-8d03-0067d5ba30e5', TIMESTAMP '2024-03-01 00:00:00.000', '1033671288', 'angela.suarez@outlook.com', 'Angela Natalia', 'Suarez');
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240531093906_InitialCreate')
BEGIN
    INSERT INTO `dbo`.`Subject` (`SubjectId`, `Created`, `Description`, `Name`)
    VALUES ('2ee9ebee-460c-4389-a50b-f0b602a2f617', TIMESTAMP '2024-01-11 00:00:00.000', 'Learn to identify system problems with a general, reusable, scalable and applicable solution', 'Design Patterns');
    INSERT INTO `dbo`.`Subject` (`SubjectId`, `Created`, `Description`, `Name`)
    VALUES ('8a4b2308-49d0-44db-b2d5-675742d5f2fe', TIMESTAMP '2024-01-15 00:00:00.000', 'Learn how to apply a set of rules and best practices for software development', 'S.O.L.I.D Principles');
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240531093906_InitialCreate')
BEGIN
    INSERT INTO `dbo`.`Teacher` (`TeacherId`, `Created`, `DocumentNumber`, `Email`, `Firstname`, `Lastname`, `Profession`)
    VALUES ('d3e5862d-3c30-4b35-8a0d-4632572aae47', TIMESTAMP '2024-02-01 00:00:00.000', '1023944678', 'cristian10camilo95@gmail.com', 'Cristian Camilo', 'Bonilla', 'Senior Software Developer');
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240531093906_InitialCreate')
BEGIN
    INSERT INTO `dbo`.`TeacherDetail` (`TeacherDetailId`, `Created`, `SubjectId`, `TeacherId`, `TotalCredits`)
    VALUES ('f79f1e3c-8974-4b38-8f9d-72e738efb046', TIMESTAMP '2024-02-03 02:01:00.000', '8a4b2308-49d0-44db-b2d5-675742d5f2fe', 'd3e5862d-3c30-4b35-8a0d-4632572aae47', 3.0);
    INSERT INTO `dbo`.`TeacherDetail` (`TeacherDetailId`, `Created`, `SubjectId`, `TeacherId`, `TotalCredits`)
    VALUES ('f87b9e01-7066-4a18-bbe5-560a9c6ddec2', TIMESTAMP '2024-02-02 01:00:00.000', '2ee9ebee-460c-4389-a50b-f0b602a2f617', 'd3e5862d-3c30-4b35-8a0d-4632572aae47', 3.0);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240531093906_InitialCreate')
BEGIN
    INSERT INTO `dbo`.`StudentDetail` (`StudentDetailId`, `ClassId`, `Created`, `Status`, `StudentId`, `TeacherDetailId`)
    VALUES ('11ab0e13-3a0a-4fd7-9f80-3dc89b181efb', 'b96044ee-9bb6-4733-af11-1bd8eedf8b7d', TIMESTAMP '2024-03-02 01:00:00.000', 'Completed', '00000000-0000-0000-0000-000000000000', 'f87b9e01-7066-4a18-bbe5-560a9c6ddec2');
    INSERT INTO `dbo`.`StudentDetail` (`StudentDetailId`, `ClassId`, `Created`, `Status`, `StudentId`, `TeacherDetailId`)
    VALUES ('2096ecba-29db-49d6-9646-a6c3e424953f', '96437dd9-f3c7-4b11-a2a5-c59a0d5aed1c', TIMESTAMP '2024-03-03 02:01:00.000', 'Completed', '00000000-0000-0000-0000-000000000000', 'f87b9e01-7066-4a18-bbe5-560a9c6ddec2');
    INSERT INTO `dbo`.`StudentDetail` (`StudentDetailId`, `ClassId`, `Created`, `Status`, `StudentId`, `TeacherDetailId`)
    VALUES ('58696965-ccef-46b8-b791-74c4f8c28f25', 'a9a5f58a-2b02-4a0e-bf43-88a1080c82b4', TIMESTAMP '2024-03-06 05:04:00.000', 'Pending', '00000000-0000-0000-0000-000000000000', 'f79f1e3c-8974-4b38-8f9d-72e738efb046');
    INSERT INTO `dbo`.`StudentDetail` (`StudentDetailId`, `ClassId`, `Created`, `Status`, `StudentId`, `TeacherDetailId`)
    VALUES ('6647c961-57b7-4e04-ad8f-3213a6b85f89', '4905befb-9d92-42dd-8be3-82d761339b34', TIMESTAMP '2024-03-03 02:01:00.000', 'Completed', '00000000-0000-0000-0000-000000000000', 'f79f1e3c-8974-4b38-8f9d-72e738efb046');
    INSERT INTO `dbo`.`StudentDetail` (`StudentDetailId`, `ClassId`, `Created`, `Status`, `StudentId`, `TeacherDetailId`)
    VALUES ('7f8a160f-b415-486d-bce2-af44c58af36c', 'c5bc16d1-1046-4b44-976a-564fc5df7d65', TIMESTAMP '2024-03-04 03:02:00.000', 'InProgress', '00000000-0000-0000-0000-000000000000', 'f79f1e3c-8974-4b38-8f9d-72e738efb046');
    INSERT INTO `dbo`.`StudentDetail` (`StudentDetailId`, `ClassId`, `Created`, `Status`, `StudentId`, `TeacherDetailId`)
    VALUES ('90812e38-67ad-4207-8017-e2b09231231e', '85f0c48a-7b2b-456a-95fb-8c6b827a719c', TIMESTAMP '2024-03-02 01:00:00.000', 'InProgress', '00000000-0000-0000-0000-000000000000', 'f79f1e3c-8974-4b38-8f9d-72e738efb046');
    INSERT INTO `dbo`.`StudentDetail` (`StudentDetailId`, `ClassId`, `Created`, `Status`, `StudentId`, `TeacherDetailId`)
    VALUES ('eab71419-9084-4e72-9558-ce4d76f0fd30', 'fe4f5476-b903-4399-b4d8-d97d9d3b1c22', TIMESTAMP '2024-03-04 03:02:00.000', 'Completed', '00000000-0000-0000-0000-000000000000', 'f87b9e01-7066-4a18-bbe5-560a9c6ddec2');
    INSERT INTO `dbo`.`StudentDetail` (`StudentDetailId`, `ClassId`, `Created`, `Status`, `StudentId`, `TeacherDetailId`)
    VALUES ('fa2a8cc5-c7ae-4577-a981-3d4ab4a2ef1b', '39537c6a-49d9-4496-a170-6e95d517ca81', TIMESTAMP '2024-03-05 04:03:00.000', 'InProgress', '00000000-0000-0000-0000-000000000000', 'f79f1e3c-8974-4b38-8f9d-72e738efb046');
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240531093906_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX `IX_Class_Name` ON `dbo`.`Class` (`Name`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240531093906_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX `IX_Student_DocumentNumber_Email` ON `dbo`.`Student` (`DocumentNumber`, `Email`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240531093906_InitialCreate')
BEGIN
    CREATE INDEX `IX_StudentDetail_ClassId` ON `dbo`.`StudentDetail` (`ClassId`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240531093906_InitialCreate')
BEGIN
    CREATE INDEX `IX_StudentDetail_StudentId` ON `dbo`.`StudentDetail` (`StudentId`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240531093906_InitialCreate')
BEGIN
    CREATE INDEX `IX_StudentDetail_TeacherDetailId` ON `dbo`.`StudentDetail` (`TeacherDetailId`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240531093906_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX `IX_Subject_Name` ON `dbo`.`Subject` (`Name`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240531093906_InitialCreate')
BEGIN
    CREATE UNIQUE INDEX `IX_Teacher_DocumentNumber_Email` ON `dbo`.`Teacher` (`DocumentNumber`, `Email`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240531093906_InitialCreate')
BEGIN
    CREATE INDEX `IX_TeacherDetail_SubjectId` ON `dbo`.`TeacherDetail` (`SubjectId`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240531093906_InitialCreate')
BEGIN
    CREATE INDEX `IX_TeacherDetail_TeacherId` ON `dbo`.`TeacherDetail` (`TeacherId`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240531093906_InitialCreate')
BEGIN
    INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
    VALUES ('20240531093906_InitialCreate', '8.0.6');
END;

COMMIT;

