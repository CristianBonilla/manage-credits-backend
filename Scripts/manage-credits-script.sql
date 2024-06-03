CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `ProductVersion` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
) CHARACTER SET=utf8mb4;

START TRANSACTION;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240603105818_InitialCreate') THEN

    ALTER DATABASE CHARACTER SET utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240603105818_InitialCreate') THEN

    CREATE TABLE `Student` (
        `StudentId` char(36) COLLATE ascii_general_ci NOT NULL DEFAULT (UUID()),
        `DocumentNumber` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
        `Firstname` varchar(50) CHARACTER SET utf8mb4 NOT NULL,
        `Lastname` varchar(50) CHARACTER SET utf8mb4 NOT NULL,
        `Email` varchar(100) CHARACTER SET utf8mb4 NOT NULL,
        `Created` timestamp NOT NULL DEFAULT (CURRENT_TIMESTAMP),
        `Version` timestamp(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
        CONSTRAINT `PK_Student` PRIMARY KEY (`StudentId`)
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240603105818_InitialCreate') THEN

    CREATE TABLE `Subject` (
        `SubjectId` char(36) COLLATE ascii_general_ci NOT NULL DEFAULT (UUID()),
        `Name` varchar(100) CHARACTER SET utf8mb4 NOT NULL,
        `Description` longtext CHARACTER SET utf8mb4 NULL,
        `Created` timestamp NOT NULL DEFAULT (CURRENT_TIMESTAMP),
        `Version` timestamp(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
        CONSTRAINT `PK_Subject` PRIMARY KEY (`SubjectId`)
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240603105818_InitialCreate') THEN

    CREATE TABLE `Teacher` (
        `TeacherId` char(36) COLLATE ascii_general_ci NOT NULL DEFAULT (UUID()),
        `DocumentNumber` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
        `Firstname` varchar(50) CHARACTER SET utf8mb4 NOT NULL,
        `Lastname` varchar(50) CHARACTER SET utf8mb4 NOT NULL,
        `Email` varchar(100) CHARACTER SET utf8mb4 NOT NULL,
        `Profession` varchar(30) CHARACTER SET utf8mb4 NOT NULL,
        `Created` timestamp NOT NULL DEFAULT (CURRENT_TIMESTAMP),
        `Version` timestamp(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
        CONSTRAINT `PK_Teacher` PRIMARY KEY (`TeacherId`)
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240603105818_InitialCreate') THEN

    CREATE TABLE `Class` (
        `ClassId` char(36) COLLATE ascii_general_ci NOT NULL DEFAULT (UUID()),
        `SubjectId` char(36) COLLATE ascii_general_ci NOT NULL,
        `Name` varchar(100) CHARACTER SET utf8mb4 NOT NULL,
        `Description` longtext CHARACTER SET utf8mb4 NULL,
        `Created` timestamp NOT NULL DEFAULT (CURRENT_TIMESTAMP),
        `Version` timestamp(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
        CONSTRAINT `PK_Class` PRIMARY KEY (`ClassId`),
        CONSTRAINT `FK_Class_Subject_SubjectId` FOREIGN KEY (`SubjectId`) REFERENCES `Subject` (`SubjectId`) ON DELETE CASCADE
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240603105818_InitialCreate') THEN

    CREATE TABLE `TeacherDetail` (
        `TeacherDetailId` char(36) COLLATE ascii_general_ci NOT NULL DEFAULT (UUID()),
        `TeacherId` char(36) COLLATE ascii_general_ci NOT NULL,
        `SubjectId` char(36) COLLATE ascii_general_ci NOT NULL,
        `TotalCredits` decimal(2,1) NOT NULL,
        `Created` timestamp NOT NULL DEFAULT (CURRENT_TIMESTAMP),
        `Version` timestamp(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
        CONSTRAINT `PK_TeacherDetail` PRIMARY KEY (`TeacherDetailId`),
        CONSTRAINT `FK_TeacherDetail_Subject_SubjectId` FOREIGN KEY (`SubjectId`) REFERENCES `Subject` (`SubjectId`) ON DELETE CASCADE,
        CONSTRAINT `FK_TeacherDetail_Teacher_TeacherId` FOREIGN KEY (`TeacherId`) REFERENCES `Teacher` (`TeacherId`) ON DELETE CASCADE
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240603105818_InitialCreate') THEN

    CREATE TABLE `StudentDetail` (
        `StudentDetailId` char(36) COLLATE ascii_general_ci NOT NULL DEFAULT (UUID()),
        `TeacherDetailId` char(36) COLLATE ascii_general_ci NOT NULL,
        `StudentId` char(36) COLLATE ascii_general_ci NOT NULL,
        `ClassId` char(36) COLLATE ascii_general_ci NOT NULL,
        `Status` varchar(10) CHARACTER SET utf8mb4 NOT NULL,
        `Created` timestamp NOT NULL DEFAULT (CURRENT_TIMESTAMP),
        `Version` timestamp(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
        CONSTRAINT `PK_StudentDetail` PRIMARY KEY (`StudentDetailId`),
        CONSTRAINT `FK_StudentDetail_Class_ClassId` FOREIGN KEY (`ClassId`) REFERENCES `Class` (`ClassId`) ON DELETE CASCADE,
        CONSTRAINT `FK_StudentDetail_Student_StudentId` FOREIGN KEY (`StudentId`) REFERENCES `Student` (`StudentId`) ON DELETE CASCADE,
        CONSTRAINT `FK_StudentDetail_TeacherDetail_TeacherDetailId` FOREIGN KEY (`TeacherDetailId`) REFERENCES `TeacherDetail` (`TeacherDetailId`) ON DELETE CASCADE
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240603105818_InitialCreate') THEN

    INSERT INTO `Student` (`StudentId`, `Created`, `DocumentNumber`, `Email`, `Firstname`, `Lastname`)
    VALUES ('107e7e52-74fc-4589-b7d9-5f1ffc434637', TIMESTAMP '2024-03-02 00:00:00', '1109432112', 'jeison.bonilla@gmail.com', 'Jeison Andrés', 'Bonilla'),
    ('ee466b07-1d3e-4356-8d03-0067d5ba30e5', TIMESTAMP '2024-03-01 00:00:00', '1033671288', 'angela.suarez@outlook.com', 'Angela Natalia', 'Suarez');

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240603105818_InitialCreate') THEN

    INSERT INTO `Subject` (`SubjectId`, `Created`, `Description`, `Name`)
    VALUES ('2ee9ebee-460c-4389-a50b-f0b602a2f617', TIMESTAMP '2024-01-11 00:00:00', 'Learn to identify system problems with a general, reusable, scalable and applicable solution', 'Design Patterns'),
    ('8a4b2308-49d0-44db-b2d5-675742d5f2fe', TIMESTAMP '2024-01-15 00:00:00', 'Learn how to apply a set of rules and best practices for software development', 'S.O.L.I.D Principles');

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240603105818_InitialCreate') THEN

    INSERT INTO `Teacher` (`TeacherId`, `Created`, `DocumentNumber`, `Email`, `Firstname`, `Lastname`, `Profession`)
    VALUES ('d3e5862d-3c30-4b35-8a0d-4632572aae47', TIMESTAMP '2024-02-01 00:00:00', '1023944678', 'cristian10camilo95@gmail.com', 'Cristian Camilo', 'Bonilla', 'Senior Software Developer');

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240603105818_InitialCreate') THEN

    INSERT INTO `Class` (`ClassId`, `Created`, `Description`, `Name`, `SubjectId`)
    VALUES ('39537c6a-49d9-4496-a170-6e95d517ca81', TIMESTAMP '2024-01-19 04:03:00', NULL, 'Interface Segregation Principle', '8a4b2308-49d0-44db-b2d5-675742d5f2fe'),
    ('4905befb-9d92-42dd-8be3-82d761339b34', TIMESTAMP '2024-01-17 02:01:00', NULL, 'Open-Closed Principle', '8a4b2308-49d0-44db-b2d5-675742d5f2fe'),
    ('85f0c48a-7b2b-456a-95fb-8c6b827a719c', TIMESTAMP '2024-01-16 01:00:00', NULL, 'Single Responsibility Principle', '8a4b2308-49d0-44db-b2d5-675742d5f2fe'),
    ('96437dd9-f3c7-4b11-a2a5-c59a0d5aed1c', TIMESTAMP '2024-01-13 02:01:00', 'Learn how to facilitate efficient solutions regarding class compositions and object structures', 'Structural Patterns', '2ee9ebee-460c-4389-a50b-f0b602a2f617'),
    ('a9a5f58a-2b02-4a0e-bf43-88a1080c82b4', TIMESTAMP '2024-01-20 05:04:00', NULL, 'Dependency Inversion Principle', '8a4b2308-49d0-44db-b2d5-675742d5f2fe'),
    ('b96044ee-9bb6-4733-af11-1bd8eedf8b7d', TIMESTAMP '2024-01-12 01:00:00', 'Learn how to provide object creation mechanisms that increase the flexibility and reuse of existing code in a way that is appropriate to the situation', 'Creational Patterns', '2ee9ebee-460c-4389-a50b-f0b602a2f617'),
    ('c5bc16d1-1046-4b44-976a-564fc5df7d65', TIMESTAMP '2024-01-18 03:02:00', NULL, 'Liskov Substitution Principle', '8a4b2308-49d0-44db-b2d5-675742d5f2fe'),
    ('fe4f5476-b903-4399-b4d8-d97d9d3b1c22', TIMESTAMP '2024-01-14 03:02:00', 'Learn to communicate objects, detect objects already present and manipulate them', 'Behavior Patterns', '2ee9ebee-460c-4389-a50b-f0b602a2f617');

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240603105818_InitialCreate') THEN

    INSERT INTO `TeacherDetail` (`TeacherDetailId`, `Created`, `SubjectId`, `TeacherId`, `TotalCredits`)
    VALUES ('f79f1e3c-8974-4b38-8f9d-72e738efb046', TIMESTAMP '2024-02-03 02:01:00', '8a4b2308-49d0-44db-b2d5-675742d5f2fe', 'd3e5862d-3c30-4b35-8a0d-4632572aae47', 3.0),
    ('f87b9e01-7066-4a18-bbe5-560a9c6ddec2', TIMESTAMP '2024-02-02 01:00:00', '2ee9ebee-460c-4389-a50b-f0b602a2f617', 'd3e5862d-3c30-4b35-8a0d-4632572aae47', 3.0);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240603105818_InitialCreate') THEN

    INSERT INTO `StudentDetail` (`StudentDetailId`, `ClassId`, `Created`, `Status`, `StudentId`, `TeacherDetailId`)
    VALUES ('11ab0e13-3a0a-4fd7-9f80-3dc89b181efb', 'b96044ee-9bb6-4733-af11-1bd8eedf8b7d', TIMESTAMP '2024-03-02 01:00:00', 'Completed', 'ee466b07-1d3e-4356-8d03-0067d5ba30e5', 'f87b9e01-7066-4a18-bbe5-560a9c6ddec2'),
    ('2096ecba-29db-49d6-9646-a6c3e424953f', '96437dd9-f3c7-4b11-a2a5-c59a0d5aed1c', TIMESTAMP '2024-03-03 02:01:00', 'Completed', 'ee466b07-1d3e-4356-8d03-0067d5ba30e5', 'f87b9e01-7066-4a18-bbe5-560a9c6ddec2'),
    ('58696965-ccef-46b8-b791-74c4f8c28f25', 'a9a5f58a-2b02-4a0e-bf43-88a1080c82b4', TIMESTAMP '2024-03-06 05:04:00', 'Pending', '107e7e52-74fc-4589-b7d9-5f1ffc434637', 'f79f1e3c-8974-4b38-8f9d-72e738efb046'),
    ('6647c961-57b7-4e04-ad8f-3213a6b85f89', '4905befb-9d92-42dd-8be3-82d761339b34', TIMESTAMP '2024-03-03 02:01:00', 'Completed', '107e7e52-74fc-4589-b7d9-5f1ffc434637', 'f79f1e3c-8974-4b38-8f9d-72e738efb046'),
    ('7f8a160f-b415-486d-bce2-af44c58af36c', 'c5bc16d1-1046-4b44-976a-564fc5df7d65', TIMESTAMP '2024-03-04 03:02:00', 'InProgress', '107e7e52-74fc-4589-b7d9-5f1ffc434637', 'f79f1e3c-8974-4b38-8f9d-72e738efb046'),
    ('90812e38-67ad-4207-8017-e2b09231231e', '85f0c48a-7b2b-456a-95fb-8c6b827a719c', TIMESTAMP '2024-03-02 01:00:00', 'InProgress', '107e7e52-74fc-4589-b7d9-5f1ffc434637', 'f79f1e3c-8974-4b38-8f9d-72e738efb046'),
    ('eab71419-9084-4e72-9558-ce4d76f0fd30', 'fe4f5476-b903-4399-b4d8-d97d9d3b1c22', TIMESTAMP '2024-03-04 03:02:00', 'Completed', 'ee466b07-1d3e-4356-8d03-0067d5ba30e5', 'f87b9e01-7066-4a18-bbe5-560a9c6ddec2'),
    ('fa2a8cc5-c7ae-4577-a981-3d4ab4a2ef1b', '39537c6a-49d9-4496-a170-6e95d517ca81', TIMESTAMP '2024-03-05 04:03:00', 'InProgress', '107e7e52-74fc-4589-b7d9-5f1ffc434637', 'f79f1e3c-8974-4b38-8f9d-72e738efb046');

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240603105818_InitialCreate') THEN

    CREATE UNIQUE INDEX `IX_Class_Name` ON `Class` (`Name`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240603105818_InitialCreate') THEN

    CREATE INDEX `IX_Class_SubjectId` ON `Class` (`SubjectId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240603105818_InitialCreate') THEN

    CREATE UNIQUE INDEX `IX_Student_DocumentNumber_Email` ON `Student` (`DocumentNumber`, `Email`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240603105818_InitialCreate') THEN

    CREATE INDEX `IX_StudentDetail_ClassId` ON `StudentDetail` (`ClassId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240603105818_InitialCreate') THEN

    CREATE INDEX `IX_StudentDetail_StudentId` ON `StudentDetail` (`StudentId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240603105818_InitialCreate') THEN

    CREATE INDEX `IX_StudentDetail_TeacherDetailId` ON `StudentDetail` (`TeacherDetailId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240603105818_InitialCreate') THEN

    CREATE UNIQUE INDEX `IX_Subject_Name` ON `Subject` (`Name`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240603105818_InitialCreate') THEN

    CREATE UNIQUE INDEX `IX_Teacher_DocumentNumber_Email` ON `Teacher` (`DocumentNumber`, `Email`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240603105818_InitialCreate') THEN

    CREATE INDEX `IX_TeacherDetail_SubjectId` ON `TeacherDetail` (`SubjectId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240603105818_InitialCreate') THEN

    CREATE INDEX `IX_TeacherDetail_TeacherId` ON `TeacherDetail` (`TeacherId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240603105818_InitialCreate') THEN

    INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
    VALUES ('20240603105818_InitialCreate', '8.0.6');

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

COMMIT;
