-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jun 01, 2023 at 07:57 PM
-- Server version: 10.4.24-MariaDB
-- PHP Version: 8.1.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `boardinghouse`
--

-- --------------------------------------------------------

--
-- Table structure for table `account`
--

CREATE TABLE `account` (
  `account_ID` int(11) NOT NULL,
  `username` varchar(100) NOT NULL,
  `password` longtext NOT NULL,
  `token` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `account`
--

INSERT INTO `account` (`account_ID`, `username`, `password`, `token`) VALUES
(2, 'adminuser', '$2b$10$48NWZ8gsSA6xopj0jZmpzutjDRpprNcWXhmm0PHnksvhusSpAGrsC', 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VybmFtZSI6ImFkbWludXNlciIsImlhdCI6MTY4NTYyODg2OX0.nDH5BRnp72Jmz3OAq58cGHU3WsKW-nBydOVaOeHjJJY'),
(4, 'leo', '$2b$10$PeW3PtUcNakylPuIbcGthukfCIksh90sTypza8uoSUvDumw9W27T6', 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VybmFtZSI6ImxlbyIsImlhdCI6MTY4NTYyOTA1Mn0.Iupd4ZqLJ4Y3vOVvXDZyH1vs1HGkdx1JaqnbjEaVjuQ');

-- --------------------------------------------------------

--
-- Table structure for table `monthly_payment`
--

CREATE TABLE `monthly_payment` (
  `PAYMENT_ID` int(11) NOT NULL,
  `STUDENT_ID` int(11) DEFAULT NULL,
  `PAYMENT` decimal(11,0) NOT NULL,
  `DATE` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `monthly_payment`
--

INSERT INTO `monthly_payment` (`PAYMENT_ID`, `STUDENT_ID`, `PAYMENT`, `DATE`) VALUES
(6, 9, '1000', 2023),
(7, 7, '2000', 2023);

-- --------------------------------------------------------

--
-- Table structure for table `reservation`
--

CREATE TABLE `reservation` (
  `RESERVATION_ID` int(11) NOT NULL,
  `STUDENT_NAME` varchar(100) NOT NULL,
  `RESERVATION_DATE` date NOT NULL,
  `ADVANCE_PAYMENT` decimal(11,0) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `reservation`
--

INSERT INTO `reservation` (`RESERVATION_ID`, `STUDENT_NAME`, `RESERVATION_DATE`, `ADVANCE_PAYMENT`) VALUES
(0, 'Danica C. C', '2023-05-09', '2000'),
(0, 'Justine Alc', '2023-11-07', '1000');

-- --------------------------------------------------------

--
-- Table structure for table `room_information`
--

CREATE TABLE `room_information` (
  `ROOM_ID` int(11) NOT NULL,
  `ROOM_NUMBER` int(11) NOT NULL,
  `OCCUPANCY` int(10) NOT NULL,
  `AVAILABLE` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `room_information`
--

INSERT INTO `room_information` (`ROOM_ID`, `ROOM_NUMBER`, `OCCUPANCY`, `AVAILABLE`) VALUES
(1, 2, 3, 1),
(2, 5, 4, 4),
(3, 3, 2, 2),
(4, 1, 3, 1),
(5, 1, 2, 2);

-- --------------------------------------------------------

--
-- Table structure for table `room_type`
--

CREATE TABLE `room_type` (
  `TYPE_ID` int(11) NOT NULL,
  `ROOM_TYPE` int(10) NOT NULL,
  `ROOM_PRICE` decimal(10,0) NOT NULL,
  `ROOM_DESCRIPTION` varchar(100) NOT NULL,
  `CAPACITY` int(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `student_information`
--

CREATE TABLE `student_information` (
  `STUDENT_ID` int(11) NOT NULL,
  `STUDENT_FIRST_NAME` varchar(100) NOT NULL,
  `STUDENT_MIDDLE_NAME` varchar(100) NOT NULL,
  `STUDENT_LAST_NAME` varchar(100) NOT NULL,
  `BIRTHDATE` date NOT NULL,
  `AGE` int(11) NOT NULL,
  `GENDER` varchar(2) NOT NULL,
  `ADDRESS` varchar(100) NOT NULL,
  `CONTACT_NUMBER` varchar(27) NOT NULL,
  `EMAIL_ADDRESS` varchar(100) NOT NULL,
  `PARENT_NAME` varchar(100) NOT NULL,
  `PARENT_ADDRESS` varchar(100) NOT NULL,
  `PARENT_CONTACT_NUMBER` varchar(27) NOT NULL,
  `ROOM_ID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `student_information`
--

INSERT INTO `student_information` (`STUDENT_ID`, `STUDENT_FIRST_NAME`, `STUDENT_MIDDLE_NAME`, `STUDENT_LAST_NAME`, `BIRTHDATE`, `AGE`, `GENDER`, `ADDRESS`, `CONTACT_NUMBER`, `EMAIL_ADDRESS`, `PARENT_NAME`, `PARENT_ADDRESS`, `PARENT_CONTACT_NUMBER`, `ROOM_ID`) VALUES
(3, 'NIca Mae', 'Bernales', 'Mendoza', '2004-05-08', 17, 'Fe', 'Basak San Juan, Southern Leyte', '09923718921', 'nica@gmail.com', 'Frantoy B. Mendoza', 'Basak San Juan Southern Leyte', '09123612462', 2),
(7, 'Ralph', 'Balic', 'Medilo', '1990-01-03', 43, 'Ma', 'San  Jose, San Juan Southern Leyte', 'fddsfsd', 'ralphm@gmail.com', 'Rolly B. Medilo', 'Basak San Juan, Southern Leyte', '09361123012', 3),
(9, 'Michael', 'Calas', 'Balic', '2004-01-03', 19, 'Ma', 'Garrido San Juan Southern Leyte', '09924617385', 'michael@gmail.com', 'Mark C. Balic', 'Garrido San Juan Southern Leyte', '09923482752', 12),
(12, 'NIca Mae', 'Bernales', 'Mendoza', '2004-05-08', 17, 'Fe', 'Basak San Juan, Southern Leyte', '09923718921', 'nica@gmail.com', 'Frantoy B. Mendoza', 'Basak San Juan Southern Leyte', '09123612462', 2),
(13, 'Kyle Andrei', 'Lagarde', 'Tomada', '0000-00-00', 22, 'Ma', 'San Jose San Juan, Southern Leyte', '09923645178', 'kylet@gmail.com', 'Andrew C. Tomada', 'Garrido San Juan, Southern Leyte', '09135263890', 3),
(14, 'NIca Mae', 'Bernales', 'Mendoza', '2004-08-05', 17, 'Fe', 'Basak San Juan, Southern Leyte', '09923718921', 'nica@gmail.com', 'Frantoy B. Mendoza', 'Basak San Juan Southern Leyte', '09123612462', 1),
(19, 'dbmytng', 'bftndtm', 'xbfrht', '0000-00-00', 0, '', '', '', '', '', '', '', 1);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `account`
--
ALTER TABLE `account`
  ADD PRIMARY KEY (`account_ID`);

--
-- Indexes for table `monthly_payment`
--
ALTER TABLE `monthly_payment`
  ADD PRIMARY KEY (`PAYMENT_ID`);

--
-- Indexes for table `room_information`
--
ALTER TABLE `room_information`
  ADD PRIMARY KEY (`ROOM_ID`);

--
-- Indexes for table `student_information`
--
ALTER TABLE `student_information`
  ADD PRIMARY KEY (`STUDENT_ID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `account`
--
ALTER TABLE `account`
  MODIFY `account_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `monthly_payment`
--
ALTER TABLE `monthly_payment`
  MODIFY `PAYMENT_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `room_information`
--
ALTER TABLE `room_information`
  MODIFY `ROOM_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT for table `student_information`
--
ALTER TABLE `student_information`
  MODIFY `STUDENT_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
