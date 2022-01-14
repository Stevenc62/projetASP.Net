CREATE DATABASE projet_asp;

USE projet_asp;

CREATE TABLE services(
   service_id INT AUTO_INCREMENT,
   service VARCHAR(50) NOT NULL,
   PRIMARY KEY(service_id)
);

INSERT INTO services (service)
   VALUES 
   ('Administratif'),
   ('Production')
;

CREATE TABLE sites(
   site_id INT AUTO_INCREMENT,
   ville VARCHAR(50) NOT NULL,
   PRIMARY KEY(site_id)
);

INSERT INTO sites (ville)
   VALUES 
   ('Lille'),
   ('Paris'),
   ('Toulouse'),
   ('Nice'),
   ('Nantes')
;

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

INSERT INTO salaries (nom, prenom, fix, portable, mail, service_id, site_id)
   VALUES 
   ('Teller', 'Steven', '0383259035', '0639678314', 'teller.steven@gmail.com', 1, 2),
   ('Campbell', 'Tom', '0384574682', '0745618962', 'tom.campbell@hotmail.fr', 2, 1)
;

CREATE TABLE administrateurs(
   administrateur_id INT AUTO_INCREMENT,
   login VARCHAR(50) NOT NULL,
   password VARCHAR(50),
   PRIMARY KEY(administrateur_id)
);

INSERT INTO administrateurs (login, password)
   VALUES 
   ('admin', 'adminaccess1')
;