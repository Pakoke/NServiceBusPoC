DROP TABLE if exists `NServiceBusPoCdb`.`Sports`;

CREATE TABLE `NServiceBusPoCdb`.`Sports` (
	`SportId` INT(4) NOT NULL,
    `SportName` VARCHAR(30) NOT NULL,
    `Description` VARCHAR(100) NOT NULL,
    PRIMARY KEY (`SportId`)
);
