DROP TABLE if exists `NServiceBusPoCdb`.`Roles`;

CREATE table `NServiceBusPoCdb`.`Roles`(
	`RoleId` INT NOT NULL,
	`RoleName` VARCHAR(100) NULL,
	`RoleDescription` VARCHAR(200) NULL,
	PRIMARY KEY (`RoleId`));