DROP TABLE if exists `NServiceBusPoCdb`.`Coaches`;

CREATE table `NServiceBusPoCdb`.`Coaches`(
	`UserId` INT NOT NULL,
	`ExperienceInYears` DOUBLE NOT NULL,
	PRIMARY KEY (`UserId`)
	);