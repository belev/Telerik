-- Create the same table in MySQL and partition it by date (1990, 2000, 2010). 
-- Fill 1 000 000 log entries. Compare the searching speed in all partitions (random dates) to certain partition (e.g. year 1995).

CREATE SCHEMA performance-db;

USE performance-db;

CREATE TABLE Logs(
	LogId int NOT NULL AUTO_INCREMENT,
	LogDate datetime,
	LogText nvarchar(100),
	CONSTRAINT PK_Logs_LogId PRIMARY KEY(LogId, LogDate)
) PARTITION BY RANGE(YEAR(LogDate))(
	PARTITION p0 VALUES LESS THAN (1990),
    PARTITION p1 VALUES LESS THAN (2000),
	PARTITION p2 VALUES LESS THAN (2010),
	PARTITION p3 VALUES LESS THAN MAXVALUE
);
-- EXPLAIN PARTITIONS SELECT * FROM Logs;

-- Logs filling
DELIMITER $$
CREATE PROCEDURE InsertRandomLogs(IN NumRows INT)
    BEGIN
        DECLARE i INT;
        SET i = 1;
        START TRANSACTION;
        WHILE i <= NumRows DO
            INSERT INTO `logs`(`Message`, `PublishDate`)
            VALUES (conv(floor(rand() * 99999999999999), 20, 36), FROM_UNIXTIME(RAND() * 2147483647));
            SET i = i + 1;
        END WHILE;
        COMMIT;
    END$$
DELIMITER ;

CALL InsertRandomLogs(1000000);

-- Searching results
SELECT COUNT(*) FROM Logs PARTITION (p0);
SELECT COUNT(*) FROM Logs PARTITION (p1);
SELECT COUNT(*) FROM Logs PARTITION (p2);
SELECT COUNT(*) FROM Logs PARTITION (p3);

RESET QUERY CACHE;
SELECT COUNT(*) FROM Logs WHERE YEAR(PublishDate) <= 1990;

RESET QUERY CACHE;
SELECT COUNT(*) FROM Logs WHERE YEAR(PublishDate) <= 2000;

RESET QUERY CACHE;
SELECT COUNT(*) FROM Logs WHERE YEAR(PublishDate) <= 2010;

RESET QUERY CACHE;
SELECT COUNT(*) FROM Logs WHERE YEAR(PublishDate) > 1900;