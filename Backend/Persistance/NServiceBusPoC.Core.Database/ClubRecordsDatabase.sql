DROP TABLE if exists `NServiceBusPoCdb`.`ClubRecords`;

CREATE TABLE `NServiceBusPoCdb`.`ClubRecords` (
`ParentId` INT(11) NOT NULL,
`CoachId` INT(11) NOT NULL,
`ChildId` INT(11) NOT NULL,
`ClubId` INT(11) NOT NULL,
`SportId` INT(4) NOT NULL,
`RecordCreated` DATETIME NULL,
PRIMARY KEY (`ParentId`, `ChildId`,`CoachId`, `ClubId`,`SportId`));