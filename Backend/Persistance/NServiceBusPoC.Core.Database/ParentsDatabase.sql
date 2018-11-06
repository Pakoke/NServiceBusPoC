DROP TABLE if exists `NServiceBusPoCdb`.`Parents`;

CREATE table `NServiceBusPoCdb`.`Parents`(
	`UserId` INT NOT NULL,
	`AccountNumber` VARCHAR(100) NULL,
	PRIMARY KEY (`UserId`));