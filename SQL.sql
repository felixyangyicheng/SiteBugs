DROP DATABASE IF exists Bugs;
CREATE DATABASE Bugs;


CREATE TABLE `Bugs`.`Bug` (
  `identifiant` INT NOT NULL AUTO_INCREMENT,
  `Titre` VARCHAR(45) NOT NULL,
  `date` DATE NULL,
  `bloquant` BIT NOT NULL,
  `identifiantSerevite` TINYINT UNSIGNED NOT NULL,
  PRIMARY KEY (`identifiant`),
  UNIQUE INDEX `identifiant_UNIQUE` (`identifiant` ASC));

CREATE TABLE `Bugs`.`Serevite` (
  `identifiant` TINYINT UNSIGNED NOT NULL AUTO_INCREMENT,
  `Libelle` VARCHAR(45) NOT NULL,
 
  PRIMARY KEY (`identifiant`));


ALTER TABLE `Bugs`.`Bug` 
ADD INDEX `FK_Bug_Serevite_idx` (`identifiantSerevite` ASC);


ALTER TABLE `Bugs`.`Bug` 
ADD CONSTRAINT `FK_Bugs_Serevite`
  FOREIGN KEY (`identifiantSerevite`)
  REFERENCES `Bugs`.`Serevite` (`identifiant`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;
  
  