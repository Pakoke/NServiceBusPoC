DROP TABLE if exists `NServiceBusPoCdb`.`Childs`;

CREATE table `NServiceBusPoCdb`.`Childs`(
	`UserId` INT NOT NULL,
	`BirthDate` DATETIME NOT NULL,
	PRIMARY KEY (`UserId`)
	);