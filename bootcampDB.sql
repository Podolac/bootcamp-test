-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Oct 12, 2023 at 09:43 PM
-- Server version: 10.4.22-MariaDB
-- PHP Version: 8.1.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `bootcamp`
--

-- --------------------------------------------------------

--
-- Table structure for table `applicants`
--

CREATE TABLE `applicants` (
  `Id` int(11) NOT NULL,
  `FirstName` varchar(20) NOT NULL,
  `LastName` varchar(20) NOT NULL,
  `PhoneNumber` varchar(20) NOT NULL,
  `Email` varchar(50) NOT NULL,
  `Country` varchar(50) NOT NULL,
  `State` varchar(50) DEFAULT NULL,
  `City` varchar(50) NOT NULL,
  `JobListingId` int(11) NOT NULL,
  `AddressLine1` varchar(100) NOT NULL DEFAULT '',
  `AddressLine2` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `applicants`
--

INSERT INTO `applicants` (`Id`, `FirstName`, `LastName`, `PhoneNumber`, `Email`, `Country`, `State`, `City`, `JobListingId`, `AddressLine1`, `AddressLine2`) VALUES
(1, 'Joe', 'Doe', '0745168376', 'joedoe@gmail.com', 'Romania', '', 'Baia Mare', 1, 'Str. Bucovinei', ''),
(2, 'Alice', 'Smith', '0876543210', 'alicesmith@example.com', 'United States', 'California', 'Los Angeles', 1, '123 Main Street', 'Apt 4B'),
(3, 'John', 'Smith', '1234567890', 'johnsmith@example.com', 'United States', 'New York', 'New York', 1, '456 Oak Avenue', 'Unit 7'),
(4, 'Sarah', 'Johnson', '9876543210', 'sarahjohnson@example.com', 'United States', 'Texas', 'Houston', 2, '789 Elm Street', ''),
(5, 'David', 'Wilson', '5551234567', 'davidwilson@example.com', 'United States', 'Florida', 'Miami', 3, '321 Pine Road', 'Apt 3C'),
(6, 'Emily', 'Brown', '4445556666', 'emilybrown@example.com', 'United States', 'California', 'San Francisco', 4, '567 Cedar Lane', ''),
(7, 'Matthias', 'Müller', '+49123456789', 'matthiasmuller@example.com', 'Germany', 'Bavaria', 'Munich', 1, 'Hauptstraße 123', ''),
(8, 'Isabella', 'Rossi', '+390123456789', 'isabellarossi@example.com', 'Italy', 'Lazio', 'Rome', 2, 'Via Roma 456', 'Apt 2B'),
(9, 'Pierre', 'Dubois', '+33123456789', 'pierredubois@example.com', 'France', 'Île-de-France', 'Paris', 3, 'Rue de la Seine 321', ''),
(10, 'Elena', 'Ivanova', '+749912345678', 'elenai@example.com', 'Russia', 'Moscow Oblast', 'Moscow', 4, 'Ulitsa Pushkina 123', 'Apartment 4C'),
(12, 'Ana', 'Muresan', '0772684621', 'Ana@gmail.com', 'Romania', '', 'Cluj-Napoca', 5, 'Blv. Republici', ''),
(13, 'Joe', 'Montana', '0711354621', 'joe@gmail.com', 'Romania', '', 'Cluj-Napoca', 5, 'Str. Vlad Tepes', ''),
(14, 'Catalin', 'Iuga', '0717286421', 'catalin@gmail.com', 'Romania', '', 'Satu Mare', 5, 'Blv. Independentei', ''),
(15, 'Rares', 'Chiuzbaian', '0711354621', 'rares@gmail.com', 'Romania', '', 'Bucuresti', 6, 'Blv. Traian', ''),
(16, 'Norbert', 'Covaks', '0717458621', 'Norbert@gmail.com', 'Romania', '', 'Constanta', 6, 'Str. Luminisului', '');

-- --------------------------------------------------------

--
-- Table structure for table `employers`
--

CREATE TABLE `employers` (
  `Id` int(11) NOT NULL,
  `Name` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `employers`
--

INSERT INTO `employers` (`Id`, `Name`) VALUES
(1, 'ddroidd'),
(2, 'IBM');

-- --------------------------------------------------------

--
-- Table structure for table `joblistings`
--

CREATE TABLE `joblistings` (
  `Id` int(11) NOT NULL,
  `Name` varchar(100) NOT NULL,
  `Description` varchar(1000) NOT NULL,
  `EmployerId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `joblistings`
--

INSERT INTO `joblistings` (`Id`, `Name`, `Description`, `EmployerId`) VALUES
(1, 'Bootcamp', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 1),
(2, 'Internship', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 1),
(3, 'Senior Software Engeneer', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 2),
(4, 'Junior Software Engeneer', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 2),
(5, 'QA Engeneer', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit', 1),
(6, 'Internship', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit', 2);

-- --------------------------------------------------------

--
-- Table structure for table `__efmigrationshistory`
--

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20231012144945_InitialMigration', '7.0.12'),
('20231012171452_firstMigration', '7.0.12');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `applicants`
--
ALTER TABLE `applicants`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_Applicants_JobListingId` (`JobListingId`);

--
-- Indexes for table `employers`
--
ALTER TABLE `employers`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `joblistings`
--
ALTER TABLE `joblistings`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_JobListings_EmployerId` (`EmployerId`);

--
-- Indexes for table `__efmigrationshistory`
--
ALTER TABLE `__efmigrationshistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `applicants`
--
ALTER TABLE `applicants`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;

--
-- AUTO_INCREMENT for table `employers`
--
ALTER TABLE `employers`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `joblistings`
--
ALTER TABLE `joblistings`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `applicants`
--
ALTER TABLE `applicants`
  ADD CONSTRAINT `FK_Applicants_JobListings_JobListingId` FOREIGN KEY (`JobListingId`) REFERENCES `joblistings` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `joblistings`
--
ALTER TABLE `joblistings`
  ADD CONSTRAINT `FK_JobListings_Employers_EmployerId` FOREIGN KEY (`EmployerId`) REFERENCES `employers` (`Id`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
