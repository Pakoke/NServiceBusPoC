DROP TABLE if exists `NServiceBusPoCdb`.`EmailConfirmations`;

CREATE table `NServiceBusPoCdb`.`EmailConfirmations`(
	`Email` VARCHAR(50) NOT NULL,
	`RoleId` INT NOT NULL,
	`CreatedDate` DATETIME NOT NULL,
	`ExpirationDate` DATETIME NOT NULL,
	`GuidUrl` VARCHAR(100) NOT NULL,
	`Consumed` BOOL NOT NULL DEFAULT 0,
	PRIMARY KEY (`Email`,`RoleId`,`GuidUrl`)
    );