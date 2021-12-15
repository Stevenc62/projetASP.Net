CREATE DATABASE projet_asp;

USE projet_asp;

CREATE TABLE sites(
   site_id INT AUTO_INCREMENT,
   ville VARCHAR(50) NOT NULL,
   PRIMARY KEY(site_id)
);

CREATE TABLE services(
   service_id INT AUTO_INCREMENT,
   service VARCHAR(50) NOT NULL,
   PRIMARY KEY(service_id)
);

CREATE TABLE salaries(
   salarie_id INT AUTO_INCREMENT,
   nom VARCHAR(50) NOT NULL,
   prenom VARCHAR(50) NOT NULL,
   fix VARCHAR(15) NOT NULL,
   portable VARCHAR(15) NOT NULL,
   mail VARCHAR(50) NOT NULL,
   service_id INT NOT NULL,
   site_id INT NOT NULL,
   PRIMARY KEY(salarie_id),
   FOREIGN KEY(service_id) REFERENCES services(service_id),
   FOREIGN KEY(site_id) REFERENCES sites(site_id)
);

CREATE TABLE administrateurs(
   administrateur_id INT AUTO_INCREMENT,
   pseudo VARCHAR(50) NOT NULL,
   password VARCHAR(50),
   PRIMARY KEY(administrateur_id)
);