DROP TABLE if exists `NServiceBusPoCdb`.`AppConfiguration`;

CREATE table `NServiceBusPoCdb`.`AppConfiguration`(
	`ConfigurationId` INT NOT NULL,
	`Name` VARCHAR(45) NOT NULL,
	`Value` VARCHAR(200) NOT NULL,
	`Description` VARCHAR(200) NOT NULL,
	PRIMARY KEY (`ConfigurationId`)
	);
	
INSERT INTO NServiceBusPoCdb.AppConfiguration
VALUES (0, 'SMTPUser','noreplymyNServiceBusPoC@gmail.com','User of the Email server account');

INSERT INTO NServiceBusPoCdb.AppConfiguration
VALUES (1, 'SMTPPassword','Broadgate.Tower0NServiceBusPoC','User of the Email server account');

INSERT INTO NServiceBusPoCdb.AppConfiguration
VALUES (2, 'SMTPHostName','smtp.gmail.com','SMTP Server Host Name');

INSERT INTO NServiceBusPoCdb.AppConfiguration
VALUES (3, 'EmailAddress','noreplymyNServiceBusPoC@gmail.com','User of the Email server account');

INSERT INTO NServiceBusPoCdb.AppConfiguration
VALUES (4, 'EmailConfirmationBodyLocation','F:/Windows/Trabajos/NServiceBusPoC/Backend/Persistance/NServiceBusPoC.Core.Database/EmailTemplateConfirmation.html','Body of the email that the app use to send the confirmation email');

INSERT INTO NServiceBusPoCdb.AppConfiguration
VALUES (5, 'EmailConfirmationSubject','Confirmation Registration on NServiceBusPoC','Subject on the confirmation user email from NServiceBusPoC');

INSERT INTO NServiceBusPoCdb.AppConfiguration
VALUES (6, 'MinutesValidRegisterLink','120,0','Minutes to expire the link');