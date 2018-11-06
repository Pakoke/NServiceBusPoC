DROP TABLE IF EXISTS `NServiceBusPoCdb`.`Clubs`;

CREATE TABLE `NServiceBusPoCdb`.`Clubs` (
  `ClubId` int(11) NOT NULL,
  `ClubName` varchar(45) NOT NULL,
  `Location` varchar(200) DEFAULT NULL,
  `LimitDateChild` int(11) NOT NULL,
  `Contact` varchar(15) DEFAULT NULL,
  `NumberOfCoach` int(11) NOT NULL,
  PRIMARY KEY (`ClubId`),
  UNIQUE KEY `ClubName_Location_UNIQUE` (`ClubName`,`Location`)
);


INSERT INTO `NServiceBusPoCdb`.`Clubs`
(`ClubId`,
`ClubName`,
`Location`,
`LimitDateChild`,
`Contact`,
`NumberOfCoach`)
VALUES
(0,
'Avon',
'The Clubhouse, Station Road, Bristol, Avon, BS34 6HW',
10,
'01454888069',
3);
