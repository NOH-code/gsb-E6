-- phpMyAdmin SQL Dump
-- version 5.2.3
-- https://www.phpmyadmin.net/
--
-- Hôte : mysql:3306
-- Généré le : jeu. 25 juin 2026 à 07:57
-- Version du serveur : 8.0.46
-- Version de PHP : 8.3.27

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `gsb_ordonnances`
--
CREATE DATABASE IF NOT EXISTS `gsb_ordonnances` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci;
USE `gsb_ordonnances`;

-- --------------------------------------------------------

--
-- Structure de la table `ALLERGIE`
--

DROP TABLE IF EXISTS `ALLERGIE`;
CREATE TABLE `ALLERGIE` (
  `codeAllergie` int NOT NULL,
  `libelle` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `ALLERGIE`
--

INSERT INTO `ALLERGIE` (`codeAllergie`, `libelle`) VALUES
(2, 'Aspirine'),
(3, 'Iode'),
(1, 'Penicilline');

-- --------------------------------------------------------

--
-- Structure de la table `CONTENIR`
--

DROP TABLE IF EXISTS `CONTENIR`;
CREATE TABLE `CONTENIR` (
  `numOrdonnance` int NOT NULL,
  `codeMedicament` int NOT NULL,
  `posologie` varchar(255) NOT NULL,
  `dureeJours` smallint UNSIGNED NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `CONTENIR`
--

INSERT INTO `CONTENIR` (`numOrdonnance`, `codeMedicament`, `posologie`, `dureeJours`) VALUES
(1, 1, '1 comprimÃ© 3 fois par jour', 5),
(1, 2, '1 comprimÃ© matin et soir', 7),
(2, 3, '5 X 3 cas', 10),
(4, 1, '1 mg, 1 fois /jour', 1),
(5, 2, '1 mg, 1 fois /jour', 1),
(7, 1, '5 mg, 5 fois /jour', 1),
(7, 2, '1 mg, 1 fois /jour', 1),
(7, 3, '1 mg, 1 fois /jour', 1),
(8, 3, '100 mg, 2 fois /jour', 4),
(10, 1, '10 g, 3 fois /sem.', 49),
(10, 3, '9 g, 3 fois /sem.', 21),
(12, 1, '1 mg, 1 fois /jour', 1),
(12, 3, '1 mg, 1 fois /jour', 1);

-- --------------------------------------------------------

--
-- Structure de la table `ETRE_ALLERGIQUE`
--

DROP TABLE IF EXISTS `ETRE_ALLERGIQUE`;
CREATE TABLE `ETRE_ALLERGIQUE` (
  `numPatient` int NOT NULL,
  `codeAllergie` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `ETRE_ALLERGIQUE`
--

INSERT INTO `ETRE_ALLERGIQUE` (`numPatient`, `codeAllergie`) VALUES
(1, 1),
(3, 1),
(4, 1),
(8, 1),
(15, 1),
(24, 1),
(2, 2),
(6, 2),
(8, 2),
(17, 2),
(5, 3),
(12, 3),
(20, 3),
(24, 3);

-- --------------------------------------------------------

--
-- Structure de la table `MEDECIN`
--

DROP TABLE IF EXISTS `MEDECIN`;
CREATE TABLE `MEDECIN` (
  `numMedecin` int NOT NULL,
  `nom` varchar(50) NOT NULL,
  `prenom` varchar(50) NOT NULL,
  `email` varchar(255) DEFAULT NULL,
  `dateNaissance` date NOT NULL,
  `numeroRPPS` char(11) NOT NULL,
  `specialite` varchar(100) NOT NULL,
  `motDePasse` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `MEDECIN`
--

INSERT INTO `MEDECIN` (`numMedecin`, `nom`, `prenom`, `email`, `dateNaissance`, `numeroRPPS`, `specialite`, `motDePasse`) VALUES
(1, 'DURAND', 'Paul', 'paul.durand@example.com', '1970-01-15', '10101010101', 'Generaliste', '$2a$11$ytHwx5G5lCngVmyY2hjXs.qTDIJc6lGq94KbGH6KtJZI09rwhl9EK'),
(2, 'MARTIN', 'Claire', 'claire.martin@example.com', '1982-06-20', '20202020202', 'Cardiologue', '$2a$11$Vhg1KIPRdOHXvDcxW217euageKAYp2O2sc27UKSfi798nSY/GJUWW'),
(4, 'Admin', 'Test', 'test.admin@example.com', '1980-01-01', '99999999991', 'Administration', '$2a$11$73E5cH18kkrLa38dK2v0jupGHbaFXZi.KkJGjHOyA5Uilr.XadU2q'),
(5, 'User', 'Test', 'test.user@example.com', '1990-01-01', '99999999992', 'Médecine générale', '$2a$11$ThWMZDd4CT50Ghz5w6v/z.bIMiA/Vy5w6VZGIpp36OWfKGPFiQRK.'),
(6, 'BERNARD', 'Sophie', 'sophie.bernard@example.com', '1975-04-12', '33333333331', 'Pédiatre', '$2a$11$4teb3fe102LDebiEXnGf5uxfJSSDEGRXrt9boecquaTLTau4OnFDi'),
(7, 'PETIT', 'Thomas', 'thomas.petit@example.com', '1983-09-30', '33333333332', 'Dermatologue', '$2a$11$qSIPXvl2lmY2p.IyKvjNOupS8bEgU.jAedCJl2jEbx2ep1u1nV9wa'),
(8, 'MOREAU', 'Julie', 'julie.moreau@example.com', '1979-02-18', '33333333333', 'Cardiologue', '$2a$11$hoPnflUp96wC5vbVW6g9fef5NRc8ZuT.mEp2jaNAyOeCuSqwc72zu'),
(9, 'GIRARD', 'Lucas', 'lucas.girard@example.com', '1988-11-05', '33333333334', 'Généraliste', '$2a$11$s97izMHK85kuQ7CZHxgOnuxS4EWSbbWVWOvkrB5FSOiRGDiHAnBQC');

-- --------------------------------------------------------

--
-- Structure de la table `MEDICAMENT`
--

DROP TABLE IF EXISTS `MEDICAMENT`;
CREATE TABLE `MEDICAMENT` (
  `codeMedicament` int NOT NULL,
  `nom` varchar(100) NOT NULL,
  `dosage` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `MEDICAMENT`
--

INSERT INTO `MEDICAMENT` (`codeMedicament`, `nom`, `dosage`) VALUES
(1, 'Doliprane', '500 mg'),
(2, 'Amoxicilline', '1 g'),
(3, 'Aspirine', '500 mg');

-- --------------------------------------------------------

--
-- Structure de la table `ORDONNANCE`
--

DROP TABLE IF EXISTS `ORDONNANCE`;
CREATE TABLE `ORDONNANCE` (
  `numOrdonnance` int NOT NULL,
  `dateEmission` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `numMedecin` int NOT NULL,
  `numPatient` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `ORDONNANCE`
--

INSERT INTO `ORDONNANCE` (`numOrdonnance`, `dateEmission`, `numMedecin`, `numPatient`) VALUES
(1, '2026-05-11 10:30:00', 1, 1),
(2, '2026-06-11 11:16:25', 1, 4),
(4, '2026-06-12 09:49:43', 2, 4),
(5, '2026-06-12 12:10:27', 4, 24),
(7, '2026-06-19 13:55:51', 4, 4),
(8, '2026-06-19 14:42:07', 4, 24),
(10, '2026-06-19 14:44:36', 4, 24),
(12, '2026-06-19 15:52:02', 4, 6);

-- --------------------------------------------------------

--
-- Structure de la table `PATIENT`
--

DROP TABLE IF EXISTS `PATIENT`;
CREATE TABLE `PATIENT` (
  `numPatient` int NOT NULL,
  `nom` varchar(50) NOT NULL,
  `prenom` varchar(50) NOT NULL,
  `dateNaissance` date NOT NULL,
  `numeroSecu` char(13) NOT NULL,
  `poids` decimal(5,2) DEFAULT NULL,
  `taille` decimal(5,2) DEFAULT NULL,
  `sexe` tinyint(1) DEFAULT NULL,
  `pathologie` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `PATIENT`
--

INSERT INTO `PATIENT` (`numPatient`, `nom`, `prenom`, `dateNaissance`, `numeroSecu`, `poids`, `taille`, `sexe`, `pathologie`) VALUES
(1, 'DUPONT', 'Marie', '1985-03-14', '2850314123456', 62.00, 165.00, 0, 'Hypertension'),
(2, 'LEROY', 'Jean', '1960-07-22', '1600722123456', 81.50, 178.00, 1, 'Diabète type 2'),
(3, 'Dupont', 'Lucas', '1998-03-12', '1980323456701', 75.00, 180.00, 1, 'Asthme'),
(4, 'Dupont', 'Emmy', '2001-11-25', '2011123456702', 62.00, 1.64, 0, ''),
(5, 'Martin', 'Hugo', '1987-07-04', '1870723456703', 88.00, 182.00, 1, 'Aucune'),
(6, 'Bernard', 'Chloé', '1995-01-19', '1950123456704', 60.50, 170.00, 0, 'Allergie saisonnière'),
(7, 'Petit', 'Louis', '1979-09-30', '1790923456705', 79.00, 176.00, 1, 'Cholestérol'),
(8, 'Laurent', 'Léa', '2003-05-14', '2030523456706', 55.00, 162.00, 0, 'Asthme'),
(9, 'Roux', 'Gabriel', '1992-02-08', '1920223456707', 84.00, 185.00, 1, 'Aucune'),
(10, 'Fournier', 'Manon', '1984-12-03', '1841223456708', 63.00, 167.00, 0, 'Hypothyroïdie'),
(11, 'Girard', 'Nathan', '1999-06-27', '1990623456709', 77.00, 179.00, 1, 'Migraine'),
(12, 'Blanc', 'Sarah', '1990-10-10', '1901023456710', 59.00, 164.00, 0, 'Anémie'),
(13, 'Meyer', 'Paul', '1988-02-11', '1880223456711', 90.00, 183.00, 1, 'Hypertension'),
(14, 'Chevalier', 'Julie', '1993-09-05', '1930923456712', 61.00, 169.00, 0, 'Aucune'),
(15, 'Gauthier', 'Maxime', '2000-01-22', '2000123456713', 73.00, 174.00, 1, 'Asthme'),
(16, 'Mercier', 'Sophie', '1986-04-18', '1860423456714', 57.50, 166.00, 0, 'Eczéma'),
(17, 'Andre', 'Alexandre', '1999-12-09', '1991223456715', 82.00, 181.00, 1, 'Diabète type 1'),
(18, 'Barbier', 'Camille', '2004-07-30', '2040723456716', 56.00, 163.00, 0, 'Aucune'),
(19, 'Lemoine', 'Romain', '1991-03-14', '1910323456717', 78.00, 177.00, 1, 'Cholestérol'),
(20, 'Renard', 'Anaïs', '1997-08-21', '1970823456718', 60.00, 171.00, 0, 'Migraine'),
(21, 'Collet', 'Thomas', '1983-06-02', '1830623456719', 85.00, 184.00, 1, 'Hypertension'),
(22, 'Perrot', 'Elise', '2002-11-17', '2021123456720', 54.00, 160.00, 0, 'Anémie'),
(24, 'LEJUIF', 'Josselyn', '1992-11-26', '1921164758925', 76.00, 12.00, 1, 'CdD');

--
-- Index pour les tables déchargées
--

--
-- Index pour la table `ALLERGIE`
--
ALTER TABLE `ALLERGIE`
  ADD PRIMARY KEY (`codeAllergie`),
  ADD UNIQUE KEY `libelle` (`libelle`);

--
-- Index pour la table `CONTENIR`
--
ALTER TABLE `CONTENIR`
  ADD PRIMARY KEY (`numOrdonnance`,`codeMedicament`),
  ADD KEY `fk_contenir_medicament` (`codeMedicament`);

--
-- Index pour la table `ETRE_ALLERGIQUE`
--
ALTER TABLE `ETRE_ALLERGIQUE`
  ADD PRIMARY KEY (`numPatient`,`codeAllergie`),
  ADD KEY `fk_allergique_allergie` (`codeAllergie`);

--
-- Index pour la table `MEDECIN`
--
ALTER TABLE `MEDECIN`
  ADD PRIMARY KEY (`numMedecin`),
  ADD UNIQUE KEY `numeroRPPS` (`numeroRPPS`),
  ADD UNIQUE KEY `email` (`email`);

--
-- Index pour la table `MEDICAMENT`
--
ALTER TABLE `MEDICAMENT`
  ADD PRIMARY KEY (`codeMedicament`);

--
-- Index pour la table `ORDONNANCE`
--
ALTER TABLE `ORDONNANCE`
  ADD PRIMARY KEY (`numOrdonnance`),
  ADD KEY `fk_ordonnance_medecin` (`numMedecin`),
  ADD KEY `fk_ordonnance_patient` (`numPatient`);

--
-- Index pour la table `PATIENT`
--
ALTER TABLE `PATIENT`
  ADD PRIMARY KEY (`numPatient`),
  ADD UNIQUE KEY `numeroSecu` (`numeroSecu`);

--
-- AUTO_INCREMENT pour les tables déchargées
--

--
-- AUTO_INCREMENT pour la table `ALLERGIE`
--
ALTER TABLE `ALLERGIE`
  MODIFY `codeAllergie` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT pour la table `MEDECIN`
--
ALTER TABLE `MEDECIN`
  MODIFY `numMedecin` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT pour la table `MEDICAMENT`
--
ALTER TABLE `MEDICAMENT`
  MODIFY `codeMedicament` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT pour la table `ORDONNANCE`
--
ALTER TABLE `ORDONNANCE`
  MODIFY `numOrdonnance` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT pour la table `PATIENT`
--
ALTER TABLE `PATIENT`
  MODIFY `numPatient` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=27;

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `CONTENIR`
--
ALTER TABLE `CONTENIR`
  ADD CONSTRAINT `fk_contenir_medicament` FOREIGN KEY (`codeMedicament`) REFERENCES `MEDICAMENT` (`codeMedicament`) ON DELETE RESTRICT ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_contenir_ordonnance` FOREIGN KEY (`numOrdonnance`) REFERENCES `ORDONNANCE` (`numOrdonnance`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Contraintes pour la table `ETRE_ALLERGIQUE`
--
ALTER TABLE `ETRE_ALLERGIQUE`
  ADD CONSTRAINT `fk_allergique_allergie` FOREIGN KEY (`codeAllergie`) REFERENCES `ALLERGIE` (`codeAllergie`) ON DELETE RESTRICT ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_allergique_patient` FOREIGN KEY (`numPatient`) REFERENCES `PATIENT` (`numPatient`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Contraintes pour la table `ORDONNANCE`
--
ALTER TABLE `ORDONNANCE`
  ADD CONSTRAINT `fk_ordonnance_medecin` FOREIGN KEY (`numMedecin`) REFERENCES `MEDECIN` (`numMedecin`) ON DELETE RESTRICT ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_ordonnance_patient` FOREIGN KEY (`numPatient`) REFERENCES `PATIENT` (`numPatient`) ON DELETE RESTRICT ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
