-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Aug 02, 2022 at 09:28 PM
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
-- Database: `payroll_database`
--

-- --------------------------------------------------------

--
-- Table structure for table `employee_information`
--

CREATE TABLE `employee_information` (
  `Emp_Id` int(11) NOT NULL,
  `First_Name` varchar(255) NOT NULL,
  `Middle_Name` varchar(255) NOT NULL,
  `Last_Name` varchar(255) NOT NULL,
  `Contact_Num` varchar(11) NOT NULL,
  `Address` varchar(255) NOT NULL,
  `Email_Add` varchar(255) NOT NULL,
  `Password` varchar(255) NOT NULL,
  `Hourly_rate` int(11) NOT NULL,
  `Hrs_worked` int(11) NOT NULL,
  `Employee_Id` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `employee_information`
--

INSERT INTO `employee_information` (`Emp_Id`, `First_Name`, `Middle_Name`, `Last_Name`, `Contact_Num`, `Address`, `Email_Add`, `Password`, `Hourly_rate`, `Hrs_worked`, `Employee_Id`) VALUES
(1, 'Testing', 'Test', 'Testing', 'Test1', '09123456789', 'testing st. testing city', 'testing123', 50, 0, '1'),
(2, 'Mark', 'Delle', 'Yorky', '09221430291', 'Tracing St. Quezon City', 'markdelle@gmail.com', 'markdelle123', 48, 0, '2');

-- --------------------------------------------------------

--
-- Table structure for table `time_record`
--

CREATE TABLE `time_record` (
  `Atten_Id` int(11) NOT NULL,
  `Employee_Id` varchar(255) NOT NULL,
  `Log_Date` varchar(255) NOT NULL,
  `Time_in` varchar(255) NOT NULL,
  `Before_Status` varchar(255) NOT NULL,
  `Time_Out` varchar(255) NOT NULL,
  `After_Status` int(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `employee_information`
--
ALTER TABLE `employee_information`
  ADD PRIMARY KEY (`Emp_Id`);

--
-- Indexes for table `time_record`
--
ALTER TABLE `time_record`
  ADD PRIMARY KEY (`Atten_Id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `employee_information`
--
ALTER TABLE `employee_information`
  MODIFY `Emp_Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `time_record`
--
ALTER TABLE `time_record`
  MODIFY `Atten_Id` int(11) NOT NULL AUTO_INCREMENT;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
