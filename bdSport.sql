DROP DATABASE IF EXISTS bdSport;
CREATE DATABASE bdSport;
USE bdSport;

-- Table Sport
CREATE TABLE Sport (
    id INT NOT NULL AUTO_INCREMENT,
    nomSport VARCHAR(50) NOT NULL,
    PRIMARY KEY(id)
) ENGINE=InnoDB;

-- Table Sportif
CREATE TABLE Sportif (
    id INT NOT NULL AUTO_INCREMENT,
    nom VARCHAR(30),
    prenom VARCHAR(30),
    dateNais DATE,
    rue VARCHAR(50),
    codePostal VARCHAR(5),
    ville VARCHAR(50),
    niveauExperience INT,
    PRIMARY KEY (id)
) ENGINE=InnoDB;

-- Table Utilisateur
CREATE TABLE Utilisateur (
    id INT AUTO_INCREMENT PRIMARY KEY,
    login VARCHAR(50),
    motDePasse VARCHAR(50)
) ENGINE=InnoDB;

-- Table Participe
CREATE TABLE Participe (
    idSportif INT NOT NULL,
    idSport INT NOT NULL,
    PRIMARY KEY (idSportif, idSport),
    FOREIGN KEY (idSportif) REFERENCES Sportif(id) ON DELETE CASCADE,
    FOREIGN KEY (idSport) REFERENCES Sport(id) ON DELETE CASCADE
) ENGINE=InnoDB;

-- Données initiales pour Sport
INSERT INTO Sport (id, nomSport) VALUES
(1, 'Natation'),
(2, 'Judo'),
(3, 'Tenis'),
(4, 'FootBall');

-- Données initiales pour Sportif
INSERT INTO Sportif (id, nom, prenom, dateNais, rue, codePostal, ville, niveauExperience) VALUES
(1, 'Davolio', 'Jeanne', '2003-06-15', '5 rue de la poste', '63000', 'Clermont-Ferrand', 3),
(2, 'Dupont', 'Emma', '2006-11-22', '32 place de l''Hôtel de Ville', '63200', 'Riom', 3),
(3, 'Martin', 'Julien', '2002-03-09', '254 avenue Berthelot', '63500', 'Issoire', 2),
(4, 'Durand', 'Alice', '2004-07-18', '1 place de Jaude', '63000', 'Clermont-Ferrand', 1),
(5, 'Bernard', 'Maxime', '2005-01-30', '15 rue des pinsons', '63200', 'Riom', 1),
(6, 'Dupuy', 'Laura', '2003-09-05', '23 boulevard Central', '63500', 'Issoire', 3),
(7, 'Peacock', 'Pierre', '2007-10-01', '23 Impasse des Fleurs', '63000', 'Clermont-Ferrand', 1),
(8, 'Buchanan', 'Alban', '2007-05-12', '3 rue des tilleuls', '63200', 'Riom', 1),
(9, 'Petit', 'Antoine', '2005-02-12', '7 rue de la paix', '63000', 'Clermont-Ferrand', 4),
(10, 'Merle', 'Louis', '2004-01-30', '3 avenue de la république', '63000', 'Clermont-Ferrand', 3),
(11, 'Arquizan', 'Lucie', '2005-02-15', '3 boulevard Berthelot', '63000', 'Clermont-Ferrand', 1);

-- Données initiales pour Participe
INSERT INTO Participe VALUES
(1,2),(1,3),(1,4),
(2,1),(2,2),
(3,4),
(4,3),
(5,1),
(6,2),(6,3),
(7,4),
(8,1),
(9,3),
(10,2),(10,4),
(11,1),(11,3);

-- Utilisateur de test
INSERT INTO Utilisateur (login, motDePasse) VALUES ('a', 'a');

-- Procédures stockées
DELIMITER //

CREATE PROCEDURE ListeSports()
BEGIN
    SELECT id, nomSport FROM Sport ORDER BY nomSport;
END //

CREATE PROCEDURE InsererSport(IN p_nom VARCHAR(50))
BEGIN
    INSERT INTO Sport (nomSport) VALUES (p_nom);
END //

CREATE PROCEDURE ModifierSport(IN p_id INT, IN p_nom VARCHAR(50))
BEGIN
    UPDATE Sport SET nomSport = p_nom WHERE id = p_id;
END //

CREATE PROCEDURE SupprimerSport(IN p_id INT)
BEGIN
    DELETE FROM Sport WHERE id = p_id;
END //

CREATE PROCEDURE ToutSelectionner()
BEGIN
    SELECT s.id, s.nom, s.prenom, s.dateNais, s.rue, s.codePostal, s.ville, s.niveauExperience,sp.nomSport
    FROM Sportif s
    LEFT JOIN Participe p ON s.id = p.idSportif
    LEFT JOIN Sport sp ON p.idSport = sp.id
    GROUP BY s.id;
END //

DELIMITER ;
