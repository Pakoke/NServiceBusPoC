DROP TABLE if exists `NServiceBusPoCdb`.`Users`;

CREATE TABLE `NServiceBusPoCdb`.`Users` (
  `UserId` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(30) NULL,
  `Surname` VARCHAR(50) NULL,
  `SecondName` VARCHAR(50) NULL,
  `SecondSurname` VARCHAR(50) NULL,
  `Password` VARCHAR(30) NOT NULL,
  `Enabled` TINYINT NOT NULL,
  `RoleId` INT NOT NULL,
  `Email` VARCHAR(50) NOT NULL,
  `Street` VARCHAR(50) NOT NULL,
  `Country` VARCHAR(50) NOT NULL,
  `Nationality` VARCHAR(50) NOT NULL,
  `DNI` VARCHAR(50) NOT NULL,
  `SocialNumber` VARCHAR(50) NOT NULL,
  `BirthDate` DATETIME NOT NULL,
  UNIQUE INDEX `Id_UNIQUE` (`UserId` ASC),
  PRIMARY KEY (`RoleId`, `Email`));