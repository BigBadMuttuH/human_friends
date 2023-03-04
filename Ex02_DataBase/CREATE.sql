CREATE DATABASE human_friend;
use human_friend;

CREATE TABLE `pets_breed` (
	id INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
  breed CHAR(50) NOT NULL UNIQUE
);

CREATE TABLE `pack_animals_breed` (
	id INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
  breed CHAR(50) NOT NULL UNIQUE
);

CREATE TABLE `pets` (
	`id` INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
  `breed` INT,
  `name` CHAR(100) NOT NULL,
  `birthday` DATE NOT NULL,
  `is_female` BOOL,
  `executable_commands` TEXT,
  CONSTRAINT fk_pets_breed_id FOREIGN KEY (breed) REFERENCES `pets_breed`(id)
);

CREATE TABLE `pack_animals` (
	`id` INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
  `breed` INT,
  `name` CHAR(100) NOT NULL,
  `birthday` DATE NOT NULL,
  `is_female` BOOL,
  `executable_commands` TEXT,
  CONSTRAINT fk_pack_animals_breed_id FOREIGN KEY (breed) REFERENCES `pack_animals_breed`(id)
);


CREATE VIEW `animals` AS
	SELECT pets_breed.breed AS breed, name, birthday, is_female, executable_commands
  FROM pets JOIN pets_breed ON (pets.breed = pets_breed.id)
  UNION ALL
  SELECT pack_animals_breed.breed AS breed, name, birthday, is_female, executable_commands
  FROM pack_animals JOIN pack_animals_breed ON (pack_animals.breed = pack_animals_breed.id)
  ORDER BY birthday DESC;
