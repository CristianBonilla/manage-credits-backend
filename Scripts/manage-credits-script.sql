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
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240609041109_InitialCreate') THEN

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
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240609041109_InitialCreate') THEN

    CREATE TABLE `student` (
        `student_id` char(36) COLLATE ascii_general_ci NOT NULL,
        `document_number` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
        `firstname` varchar(50) CHARACTER SET utf8mb4 NOT NULL,
        `lastname` varchar(50) CHARACTER SET utf8mb4 NOT NULL,
        `email` varchar(100) CHARACTER SET utf8mb4 NOT NULL,
        `created_at` timestamp NOT NULL,
        `version` timestamp(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
        CONSTRAINT `PK_student` PRIMARY KEY (`student_id`)
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
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240609041109_InitialCreate') THEN

    CREATE TABLE `subject` (
        `subject_id` char(36) COLLATE ascii_general_ci NOT NULL,
        `name` varchar(100) CHARACTER SET utf8mb4 NOT NULL,
        `description` longtext CHARACTER SET utf8mb4 NULL,
        `created_at` timestamp NOT NULL,
        `version` timestamp(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
        CONSTRAINT `PK_subject` PRIMARY KEY (`subject_id`)
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
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240609041109_InitialCreate') THEN

    CREATE TABLE `teacher` (
        `teacher_id` char(36) COLLATE ascii_general_ci NOT NULL,
        `document_number` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
        `firstname` varchar(50) CHARACTER SET utf8mb4 NOT NULL,
        `lastname` varchar(50) CHARACTER SET utf8mb4 NOT NULL,
        `email` varchar(100) CHARACTER SET utf8mb4 NOT NULL,
        `profession` varchar(30) CHARACTER SET utf8mb4 NOT NULL,
        `created_at` timestamp NOT NULL,
        `version` timestamp(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
        CONSTRAINT `PK_teacher` PRIMARY KEY (`teacher_id`)
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
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240609041109_InitialCreate') THEN

    CREATE TABLE `class` (
        `class_id` char(36) COLLATE ascii_general_ci NOT NULL,
        `subject_id` char(36) COLLATE ascii_general_ci NOT NULL,
        `name` varchar(100) CHARACTER SET utf8mb4 NOT NULL,
        `description` longtext CHARACTER SET utf8mb4 NULL,
        `created_at` timestamp NOT NULL,
        `version` timestamp(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
        CONSTRAINT `PK_class` PRIMARY KEY (`class_id`),
        CONSTRAINT `FK_class_subject_subject_id` FOREIGN KEY (`subject_id`) REFERENCES `subject` (`subject_id`) ON DELETE CASCADE
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
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240609041109_InitialCreate') THEN

    CREATE TABLE `teacher_detail` (
        `teacher_detail_id` char(36) COLLATE ascii_general_ci NOT NULL,
        `teacher_id` char(36) COLLATE ascii_general_ci NOT NULL,
        `subject_id` char(36) COLLATE ascii_general_ci NOT NULL,
        `total_credits` decimal(2,1) NOT NULL,
        `created_at` timestamp NOT NULL,
        `version` timestamp(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
        CONSTRAINT `PK_teacher_detail` PRIMARY KEY (`teacher_detail_id`),
        CONSTRAINT `FK_teacher_detail_subject_subject_id` FOREIGN KEY (`subject_id`) REFERENCES `subject` (`subject_id`) ON DELETE CASCADE,
        CONSTRAINT `FK_teacher_detail_teacher_teacher_id` FOREIGN KEY (`teacher_id`) REFERENCES `teacher` (`teacher_id`) ON DELETE CASCADE
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
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240609041109_InitialCreate') THEN

    CREATE TABLE `student_detail` (
        `student_detail_id` char(36) COLLATE ascii_general_ci NOT NULL,
        `teacher_detail_id` char(36) COLLATE ascii_general_ci NOT NULL,
        `student_id` char(36) COLLATE ascii_general_ci NOT NULL,
        `class_id` char(36) COLLATE ascii_general_ci NOT NULL,
        `status` varchar(10) CHARACTER SET utf8mb4 NOT NULL,
        `created_at` timestamp NOT NULL,
        `version` timestamp(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
        CONSTRAINT `PK_student_detail` PRIMARY KEY (`student_detail_id`),
        CONSTRAINT `FK_student_detail_class_class_id` FOREIGN KEY (`class_id`) REFERENCES `class` (`class_id`) ON DELETE CASCADE,
        CONSTRAINT `FK_student_detail_student_student_id` FOREIGN KEY (`student_id`) REFERENCES `student` (`student_id`) ON DELETE CASCADE,
        CONSTRAINT `FK_student_detail_teacher_detail_teacher_detail_id` FOREIGN KEY (`teacher_detail_id`) REFERENCES `teacher_detail` (`teacher_detail_id`) ON DELETE CASCADE
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
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240609041109_InitialCreate') THEN

    INSERT INTO `student` (`student_id`, `created_at`, `document_number`, `email`, `firstname`, `lastname`)
    VALUES ('107e7e52-74fc-4589-b7d9-5f1ffc434637', TIMESTAMP '2024-03-03 02:02:02', '1109432112', 'jeison.bonilla@gmail.com', 'Jeison Andrés', 'Bonilla'),
    ('ee466b07-1d3e-4356-8d03-0067d5ba30e5', TIMESTAMP '2024-03-01 00:01:01', '1033671288', 'angela.suarez@outlook.com', 'Angela Natalia', 'Suarez');

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240609041109_InitialCreate') THEN

    INSERT INTO `subject` (`subject_id`, `created_at`, `description`, `name`)
    VALUES ('2ee9ebee-460c-4389-a50b-f0b602a2f617', TIMESTAMP '2024-01-11 01:00:01', 'Learn to identify system problems with a general, reusable, scalable and applicable solution', 'Design Patterns'),
    ('4b2d9626-0259-42a5-a98c-11019b4cf873', TIMESTAMP '2024-01-20 07:06:07', 'Discover how a Scrum Master can lead a team and keep members focused on the principles of the framework', 'Scrum Master Fundamentals'),
    ('5a5f617c-4b9b-4974-9104-bd173b107172', TIMESTAMP '2024-01-16 03:02:03', 'Learn how clean architectures work to separate concerns into different, well-defined layers, with strict rules about how they should interact with each other', 'Clean Architecture'),
    ('8a4b2308-49d0-44db-b2d5-675742d5f2fe', TIMESTAMP '2024-01-15 02:01:02', 'Learn how to apply a set of rules and best practices for software development', 'S.O.L.I.D Principles'),
    ('9748e5ff-07ba-4cb8-8617-53a785fc2ebf', TIMESTAMP '2024-01-22 09:08:09', 'Learn how to become an expert with TypeScript the JavaScript superset for strict typing', 'Development With TypeScript'),
    ('a3e42c74-8a68-4e2d-b339-caa2e89db0a7', TIMESTAMP '2024-01-23 10:09:10', 'Learn how to develop with one of the most popular and powerful frameworks, create robust applications', 'Angular Fundamentals'),
    ('e2fd4b74-7b10-446e-821e-55717899c400', TIMESTAMP '2024-01-19 06:05:06', 'Learn about the most popular tools for QA Automation, features and benefits', 'QA Automation Tools'),
    ('e9a4cce8-57b0-4693-bf22-cfec292bccc5', TIMESTAMP '2024-01-18 05:04:05', 'Learn why QA Automation is so important in the software development cycle', 'QA Automation Fundamentals'),
    ('eb8e2deb-9f48-4376-b5d0-9e5f898d6586', TIMESTAMP '2024-01-17 04:03:04', 'Learn how to implement a design methodology for rapid deployment and updating of cloud-based applications', 'Microservices Architecture'),
    ('fc560c08-aa92-44c6-9ae1-101987824877', TIMESTAMP '2024-01-21 08:07:08', 'Discover how a Scrum Master should expertly plan to maintain a fully agile team', 'Planning a scrum master');

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240609041109_InitialCreate') THEN

    INSERT INTO `teacher` (`teacher_id`, `created_at`, `document_number`, `email`, `firstname`, `lastname`, `profession`)
    VALUES ('08cd0782-93ba-4de3-b363-e7a4df2bfe7b', TIMESTAMP '2024-02-03 02:03:03', '1127789231', 'ana.suarez@outlook.com', 'Ana Camila', 'Suarez', 'QA Automation'),
    ('42318f73-c7fd-4490-9594-7c72a77bbee7', TIMESTAMP '2024-02-04 03:04:04', '1643398122', 'maria_natalia.garcia@outlook.com', 'Maria Natalia', 'Garcia', 'Scrum Master'),
    ('c774f591-750a-47f9-b283-327cdb62f627', TIMESTAMP '2024-02-05 04:05:05', '1992233120', 'carlos.herrera@gmail.com', 'Carlos Francisco', 'Herrera', 'Senior Frontend Developer'),
    ('d3e5862d-3c30-4b35-8a0d-4632572aae47', TIMESTAMP '2024-02-01 00:01:01', '1023944678', 'cristian10camilo95@gmail.com', 'Cristian Camilo', 'Bonilla', 'Senior Software Developer'),
    ('f41ed5f9-d853-4077-b6fe-9bb277bee93d', TIMESTAMP '2024-02-02 01:02:02', '1090012334', 'fernando.gutierrez@gmail.com', 'Fernando', 'Gutierrez', 'Senior Software Architect');

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240609041109_InitialCreate') THEN

    INSERT INTO `class` (`class_id`, `created_at`, `description`, `name`, `subject_id`)
    VALUES ('1a3112f6-c99a-42e7-a25e-e912bc367954', TIMESTAMP '2024-01-22 07:06:10', NULL, 'Inventory application with Angular', 'a3e42c74-8a68-4e2d-b339-caa2e89db0a7'),
    ('27344f1d-c2d4-46eb-8a70-39943856ccf7', TIMESTAMP '2024-01-21 06:05:09', NULL, 'Master the TypeScript superset', '9748e5ff-07ba-4cb8-8617-53a785fc2ebf'),
    ('39537c6a-49d9-4496-a170-6e95d517ca81', TIMESTAMP '2024-01-19 04:03:07', NULL, 'Learn about Scrum Master', '4b2d9626-0259-42a5-a98c-11019b4cf873'),
    ('4905befb-9d92-42dd-8be3-82d761339b34', TIMESTAMP '2024-01-17 02:01:05', NULL, 'Learn about QA Automation', 'e9a4cce8-57b0-4693-bf22-cfec292bccc5'),
    ('85f0c48a-7b2b-456a-95fb-8c6b827a719c', TIMESTAMP '2024-01-16 01:00:04', NULL, 'Implement microservices architecture', 'eb8e2deb-9f48-4376-b5d0-9e5f898d6586'),
    ('96437dd9-f3c7-4b11-a2a5-c59a0d5aed1c', TIMESTAMP '2024-01-13 02:01:02', 'Conozca los principios Single Reponsability Principle (SRP), Open/Closed Principle (OCP), Liskov Substitution Principle (LSP), Interface Segregation Principle (ISP) y Dependency Inversion Principle (DIP)', 'Why S.O.L.I.D Principles?', '8a4b2308-49d0-44db-b2d5-675742d5f2fe'),
    ('a9a5f58a-2b02-4a0e-bf43-88a1080c82b4', TIMESTAMP '2024-01-20 05:04:08', NULL, 'Become a Scrum Master expert', 'fc560c08-aa92-44c6-9ae1-101987824877'),
    ('b96044ee-9bb6-4733-af11-1bd8eedf8b7d', TIMESTAMP '2024-01-12 01:00:01', 'Learn how design patterns have become an object of some controversy in the programming world of late, largely due to their perceived "overuse", leading to code that can be more difficult to understand and manage', 'Why design patterns?', '2ee9ebee-460c-4389-a50b-f0b602a2f617'),
    ('c5bc16d1-1046-4b44-976a-564fc5df7d65', TIMESTAMP '2024-01-18 03:02:06', NULL, 'Learn QA Automation Tools', 'e2fd4b74-7b10-446e-821e-55717899c400'),
    ('fe4f5476-b903-4399-b4d8-d97d9d3b1c22', TIMESTAMP '2024-01-14 03:02:03', 'Learn how this domain-oriented architecture helps us solve the central problem of the domain in an effective way', 'DDD Architecture', '5a5f617c-4b9b-4974-9104-bd173b107172');

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240609041109_InitialCreate') THEN

    INSERT INTO `teacher_detail` (`teacher_detail_id`, `created_at`, `subject_id`, `teacher_id`, `total_credits`)
    VALUES ('10ed0335-ece3-4e80-9c01-28e1f1f3fe67', TIMESTAMP '2024-02-11 11:10:10', 'a3e42c74-8a68-4e2d-b339-caa2e89db0a7', 'c774f591-750a-47f9-b283-327cdb62f627', 3.0),
    ('3b34bdd2-dc7c-41a1-bd79-dc8465aa2bf1', TIMESTAMP '2024-02-05 04:03:04', 'eb8e2deb-9f48-4376-b5d0-9e5f898d6586', 'f41ed5f9-d853-4077-b6fe-9bb277bee93d', 3.0),
    ('4f098579-1bd2-4e7c-822a-9160871450de', TIMESTAMP '2024-02-08 07:06:07', '4b2d9626-0259-42a5-a98c-11019b4cf873', '42318f73-c7fd-4490-9594-7c72a77bbee7', 3.0),
    ('7240162d-4f52-425d-a4f6-54b4127e8828', TIMESTAMP '2024-02-10 09:08:09', '9748e5ff-07ba-4cb8-8617-53a785fc2ebf', 'c774f591-750a-47f9-b283-327cdb62f627', 3.0),
    ('a5794476-1317-4ebc-86b3-e9640b20a1a8', TIMESTAMP '2024-02-09 08:07:08', 'fc560c08-aa92-44c6-9ae1-101987824877', '42318f73-c7fd-4490-9594-7c72a77bbee7', 3.0),
    ('ccc8bb25-685f-404b-b53d-d446686f9cec', TIMESTAMP '2024-02-07 06:05:06', 'e2fd4b74-7b10-446e-821e-55717899c400', '08cd0782-93ba-4de3-b363-e7a4df2bfe7b', 3.0),
    ('cf98b2d3-7d9b-4ce1-996a-ed25c706b644', TIMESTAMP '2024-02-06 05:04:05', 'e9a4cce8-57b0-4693-bf22-cfec292bccc5', '08cd0782-93ba-4de3-b363-e7a4df2bfe7b', 3.0),
    ('d6e0c50c-e994-4d6b-aca0-ebc09b411aa0', TIMESTAMP '2024-02-04 03:02:03', '5a5f617c-4b9b-4974-9104-bd173b107172', 'f41ed5f9-d853-4077-b6fe-9bb277bee93d', 3.0),
    ('f79f1e3c-8974-4b38-8f9d-72e738efb046', TIMESTAMP '2024-02-03 02:01:02', '8a4b2308-49d0-44db-b2d5-675742d5f2fe', 'd3e5862d-3c30-4b35-8a0d-4632572aae47', 3.0),
    ('f87b9e01-7066-4a18-bbe5-560a9c6ddec2', TIMESTAMP '2024-02-02 01:00:01', '2ee9ebee-460c-4389-a50b-f0b602a2f617', 'd3e5862d-3c30-4b35-8a0d-4632572aae47', 3.0);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240609041109_InitialCreate') THEN

    INSERT INTO `student_detail` (`student_detail_id`, `class_id`, `created_at`, `status`, `student_id`, `teacher_detail_id`)
    VALUES ('11ab0e13-3a0a-4fd7-9f80-3dc89b181efb', 'b96044ee-9bb6-4733-af11-1bd8eedf8b7d', TIMESTAMP '2024-03-02 01:00:01', 'Pending', 'ee466b07-1d3e-4356-8d03-0067d5ba30e5', 'f87b9e01-7066-4a18-bbe5-560a9c6ddec2'),
    ('2096ecba-29db-49d6-9646-a6c3e424953f', '96437dd9-f3c7-4b11-a2a5-c59a0d5aed1c', TIMESTAMP '2024-03-03 02:01:02', 'Completed', 'ee466b07-1d3e-4356-8d03-0067d5ba30e5', 'f79f1e3c-8974-4b38-8f9d-72e738efb046'),
    ('90812e38-67ad-4207-8017-e2b09231231e', '96437dd9-f3c7-4b11-a2a5-c59a0d5aed1c', TIMESTAMP '2024-03-02 01:00:04', 'InProgress', '107e7e52-74fc-4589-b7d9-5f1ffc434637', 'f79f1e3c-8974-4b38-8f9d-72e738efb046'),
    ('eab71419-9084-4e72-9558-ce4d76f0fd30', 'b96044ee-9bb6-4733-af11-1bd8eedf8b7d', TIMESTAMP '2024-03-04 03:02:03', 'Pending', '107e7e52-74fc-4589-b7d9-5f1ffc434637', 'f87b9e01-7066-4a18-bbe5-560a9c6ddec2');

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240609041109_InitialCreate') THEN

    CREATE UNIQUE INDEX `IX_class_name` ON `class` (`name`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240609041109_InitialCreate') THEN

    CREATE INDEX `IX_class_subject_id` ON `class` (`subject_id`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240609041109_InitialCreate') THEN

    CREATE UNIQUE INDEX `IX_student_document_number_email` ON `student` (`document_number`, `email`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240609041109_InitialCreate') THEN

    CREATE INDEX `IX_student_detail_class_id` ON `student_detail` (`class_id`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240609041109_InitialCreate') THEN

    CREATE INDEX `IX_student_detail_student_id` ON `student_detail` (`student_id`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240609041109_InitialCreate') THEN

    CREATE INDEX `IX_student_detail_teacher_detail_id` ON `student_detail` (`teacher_detail_id`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240609041109_InitialCreate') THEN

    CREATE UNIQUE INDEX `IX_subject_name` ON `subject` (`name`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240609041109_InitialCreate') THEN

    CREATE UNIQUE INDEX `IX_teacher_document_number_email` ON `teacher` (`document_number`, `email`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240609041109_InitialCreate') THEN

    CREATE INDEX `IX_teacher_detail_subject_id` ON `teacher_detail` (`subject_id`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240609041109_InitialCreate') THEN

    CREATE INDEX `IX_teacher_detail_teacher_id` ON `teacher_detail` (`teacher_id`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240609041109_InitialCreate') THEN

    INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
    VALUES ('20240609041109_InitialCreate', '8.0.6');

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

COMMIT;
