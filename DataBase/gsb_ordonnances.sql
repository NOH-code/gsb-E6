-- phpMyAdmin SQL Dump
-- version 5.2.3
-- https://www.phpmyadmin.net/
--
-- Hôte : mysql:3306
-- Généré le : lun. 08 juin 2026 à 10:04
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
(1, 'PÃ©nicilline');

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
(1, 2, '1 comprimÃ© matin et soir', 7);

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
(1, 1);

-- --------------------------------------------------------

--
-- Structure de la table `MEDECIN`
--

DROP TABLE IF EXISTS `MEDECIN`;
CREATE TABLE `MEDECIN` (
  `numMedecin` int NOT NULL,
  `nom` varchar(50) NOT NULL,
  `prenom` varchar(50) NOT NULL,
  `dateNaissance` date NOT NULL,
  `numeroRPPS` char(11) NOT NULL,
  `specialite` varchar(100) NOT NULL,
  `motDePasse` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `MEDECIN`
--

INSERT INTO `MEDECIN` (`numMedecin`, `nom`, `prenom`, `dateNaissance`, `numeroRPPS`, `specialite`, `motDePasse`) VALUES
(1, 'DURAND', 'Paul', '1970-01-15', '10101010101', 'GÃ©nÃ©raliste', 'secret'),
(2, 'MARTIN', 'Claire', '1982-06-20', '20202020202', 'Cardiologue', 'secret');

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
(1, '2026-05-11 10:30:00', 1, 1);

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
  `numeroSecu` char(13) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `PATIENT`
--

INSERT INTO `PATIENT` (`numPatient`, `nom`, `prenom`, `dateNaissance`, `numeroSecu`) VALUES
(1, 'DUPONT', 'Marie', '1985-03-14', '2850314123456'),
(2, 'LEROY', 'Jean', '1960-07-22', '1600722123456'),
(3, 'Dupont', 'Lucas', '1998-03-12', '1980323456701'),
(4, 'Dupont', 'Emma', '2001-11-25', '2011123456702'),
(5, 'Martin', 'Hugo', '1987-07-04', '1870723456703'),
(6, 'Bernard', 'Chloé', '1995-01-19', '1950123456704'),
(7, 'Petit', 'Louis', '1979-09-30', '1790923456705'),
(8, 'Laurent', 'Léa', '2003-05-14', '2030523456706'),
(9, 'Roux', 'Gabriel', '1992-02-08', '1920223456707'),
(10, 'Fournier', 'Manon', '1984-12-03', '1841223456708'),
(11, 'Girard', 'Nathan', '1999-06-27', '1990623456709'),
(12, 'Blanc', 'Sarah', '1990-10-10', '1901023456710'),
(13, 'Meyer', 'Paul', '1988-02-11', '1880223456711'),
(14, 'Chevalier', 'Julie', '1993-09-05', '1930923456712'),
(15, 'Gauthier', 'Maxime', '2000-01-22', '2000123456713'),
(16, 'Mercier', 'Sophie', '1986-04-18', '1860423456714'),
(17, 'Andre', 'Alexandre', '1999-12-09', '1991223456715'),
(18, 'Barbier', 'Camille', '2004-07-30', '2040723456716'),
(19, 'Lemoine', 'Romain', '1991-03-14', '1910323456717'),
(20, 'Renard', 'Anaïs', '1997-08-21', '1970823456718'),
(21, 'Collet', 'Thomas', '1983-06-02', '1830623456719'),
(22, 'Perrot', 'Elise', '2002-11-17', '2021123456720');

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
  ADD UNIQUE KEY `numeroRPPS` (`numeroRPPS`);

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
  MODIFY `numMedecin` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT pour la table `MEDICAMENT`
--
ALTER TABLE `MEDICAMENT`
  MODIFY `codeMedicament` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT pour la table `ORDONNANCE`
--
ALTER TABLE `ORDONNANCE`
  MODIFY `numOrdonnance` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT pour la table `PATIENT`
--
ALTER TABLE `PATIENT`
  MODIFY `numPatient` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=23;

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
