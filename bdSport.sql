DROP DATABASE IF EXISTS bdSport;
CREATE DATABASE IF NOT EXISTS bdSport;
USE bdSport;

CREATE TABLE IF NOT EXISTS Sport 
(
    id INT AUTO_INCREMENT,
    nomSport VARCHAR(50),
    PRIMARY KEY(id)
) ENGINE=InnoDB;

CREATE TABLE IF NOT EXISTS Sportif
(
    id INT NOT NULL AUTO_INCREMENT,
    nom VARCHAR(30),
    prenom VARCHAR(30),
    dateNais DATE,
    codePostal VARCHAR(5),
    ville VARCHAR(50),
    rue VARCHAR(50),
    niveauExperience INT,
    idSport INT,
    PRIMARY KEY (id),
    FOREIGN KEY (idSport) REFERENCES Sport(id)
) ENGINE=InnoDB;

CREATE TABLE IF NOT EXISTS Utilisateur (
    id INT AUTO_INCREMENT PRIMARY KEY,
    login VARCHAR(50),
    motDePasse VARCHAR(255) NOT NULL 
);

INSERT INTO Sport (id, nomSport)
VALUES 
(1,'Natation'),
(2,'Judo'),
(3,'Tennis'),
(4,'Football');

INSERT INTO Sportif (nom, prenom, dateNais, rue, codePostal, ville, niveauExperience, idSport) VALUES
('Davolio', 'Jeanne', '2003-06-15', '5 rue de la poste', '63000','Clermont-Ferrand', 3, 3),
('Dupont', 'Emma', '2006-11-22', '32 place de l''Hôtel de Ville', '63200','Riom', 3, 1),
('Martin', 'Julien', '2002-03-09', '254 avenue Berthelot','63500','Issoire', 2, 4),
('Durand', 'Alice', '2004-07-18','1 place de Jaude', '63000','Clermont-Ferrand', 1, 3),
('Bernard', 'Maxime', '2005-01-30', '15 rue des pinsons', '63200', 'Riom', 1, 2),
('Dupuy', 'Laura', '2003-09-05', '23 boulevard Central', '63500', 'Issoire', 3, 4),
('Peacock', 'Pierre','2007-10-01','23 Impasse des Fleurs', '63000', 'Clermont-Ferrand', 1, 4),
('Buchanan', 'Alban','2007-05-12', '3 rue des tilleuls', '63200', 'Riom', 1, 4),
('Petit', 'Antoine', '2005-02-12', '7 rue de la paix', '63000', 'Clermont-Ferrand', 4, 3),
('Merle', 'Louis','2004-01-30', '3 avenue de la république', '63000', 'Clermont-Ferrand', 3, 2),
('Arquizan', 'Lucie', '2005-02-15','3 boulevard Berthelot', '63000', 'Clermont-Ferrand', 1, 1);

-- Exemple : stocker un compte admin (mot de passe haché côté application recommandé)
INSERT INTO Utilisateur (login, motDePasse) VALUES ('admin', 'admin'); 

DELIMITER $$
CREATE PROCEDURE ToutSelectionner()
BEGIN
    SELECT s.id, s.nom, s.prenom, s.dateNais, s.rue, s.codePostal, s.ville, s.niveauExperience, sp.nomSport
    FROM Sportif s
    INNER JOIN Sport sp ON s.idSport = sp.id;
END $$
DELIMITER ;