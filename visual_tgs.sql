-- phpMyAdmin SQL Dump
-- version 4.9.0.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jul 01, 2019 at 05:27 AM
-- Server version: 10.3.15-MariaDB
-- PHP Version: 7.3.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `visual_tgs`
--

-- --------------------------------------------------------

--
-- Table structure for table `approvalizindosen`
--

CREATE TABLE `approvalizindosen` (
  `idApprovalIzinDosen` smallint(6) NOT NULL,
  `izinDosen` smallint(6) NOT NULL,
  `status` enum('approved','unapproved') NOT NULL,
  `tglApproval` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `approvalizindosen`
--

INSERT INTO `approvalizindosen` (`idApprovalIzinDosen`, `izinDosen`, `status`, `tglApproval`) VALUES
(1, 1, 'approved', '2001-01-01'),
(2, 2, 'approved', '2001-01-01'),
(3, 3, 'approved', '2001-01-01'),
(4, 1, 'unapproved', '2001-01-01'),
(5, 2, 'unapproved', '2001-01-01'),
(6, 3, 'unapproved', '2001-01-01'),
(7, 1, 'approved', '2001-01-01'),
(8, 1, 'unapproved', '2001-01-01'),
(9, 2, 'unapproved', '2001-01-01'),
(10, 2, 'unapproved', '2001-01-01'),
(11, 3, 'unapproved', '2001-01-01'),
(12, 3, 'unapproved', '2001-01-01'),
(13, 1, 'approved', '2001-01-01'),
(14, 2, 'unapproved', '2001-01-01'),
(15, 3, 'unapproved', '2001-01-01'),
(16, 4, 'unapproved', '2001-01-01'),
(17, 1, 'unapproved', '2001-01-01'),
(18, 2, 'unapproved', '2001-01-01'),
(19, 3, 'unapproved', '2001-01-01'),
(20, 4, 'unapproved', '2001-01-01'),
(21, 1, 'approved', '2001-01-01'),
(22, 2, 'unapproved', '2001-01-01'),
(23, 3, 'unapproved', '2001-01-01'),
(24, 4, 'unapproved', '2001-01-01'),
(25, 1, 'unapproved', '2001-01-01'),
(26, 2, 'unapproved', '2001-01-01'),
(27, 3, 'unapproved', '2001-01-01'),
(28, 4, 'unapproved', '2001-01-01');

-- --------------------------------------------------------

--
-- Table structure for table `dosen`
--

CREATE TABLE `dosen` (
  `kdDosen` char(6) NOT NULL,
  `nmDosen` varchar(75) NOT NULL,
  `gelarDepan` varchar(8) NOT NULL,
  `gelarBelakang` varchar(12) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `dosen`
--

INSERT INTO `dosen` (`kdDosen`, `nmDosen`, `gelarDepan`, `gelarBelakang`) VALUES
('DS0001', 'Suparto Dariato', '', 'M.Kom'),
('DS0002', 'Prya Widjaja', '', 'M.Kom'),
('DS0003', 'Michael Anggriawan', '', 'M.Kom'),
('DS0004', 'Anggriawan Michael', '', 'M.kom'),
('DS0005', 'Prasna Lukito', '', 'M.kom'),
('DS0006', 'Anton Kurniawan', '', 'M.kom');

-- --------------------------------------------------------

--
-- Table structure for table `izindosen`
--

CREATE TABLE `izindosen` (
  `izinDosen` smallint(6) NOT NULL,
  `kdDosen` char(6) NOT NULL,
  `kdProdi` char(3) NOT NULL,
  `idSemester` tinyint(4) NOT NULL,
  `kdMataKuliah` char(7) NOT NULL,
  `idKelas` tinyint(4) NOT NULL,
  `tglPengajuanIzin` date NOT NULL,
  `jamPengajuanIzin` time NOT NULL,
  `tglIzinMengampu` date NOT NULL,
  `jamIzinMengampu` time NOT NULL,
  `alasanIzin` varchar(250) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `izindosen`
--

INSERT INTO `izindosen` (`izinDosen`, `kdDosen`, `kdProdi`, `idSemester`, `kdMataKuliah`, `idKelas`, `tglPengajuanIzin`, `jamPengajuanIzin`, `tglIzinMengampu`, `jamIzinMengampu`, `alasanIzin`) VALUES
(1, 'DS0001', '573', 1, 'C0E5108', 2, '0000-00-00', '14:15:00', '0000-00-00', '00:00:00', 'Urusan Keluarga'),
(2, 'DS0002', '574', 2, 'C0E5109', 2, '0000-00-00', '15:10:00', '0000-00-00', '00:00:00', 'Cuti Kerja'),
(3, 'DS0003', '572', 2, 'C0E5109', 2, '0000-00-00', '17:00:00', '0000-00-00', '00:00:00', 'Liburan Keluarga'),
(4, 'DS0004', '580', 1, 'C0E5112', 2, '0000-00-00', '10:01:00', '0000-00-00', '00:00:00', 'Happy fun');

-- --------------------------------------------------------

--
-- Table structure for table `kelas`
--

CREATE TABLE `kelas` (
  `idKelas` tinyint(4) NOT NULL,
  `kelas` char(2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `kelas`
--

INSERT INTO `kelas` (`idKelas`, `kelas`) VALUES
(1, 'A1'),
(2, 'A2');

-- --------------------------------------------------------

--
-- Table structure for table `matakuliah`
--

CREATE TABLE `matakuliah` (
  `kdMataKuliah` char(7) NOT NULL,
  `mataKuliah` varchar(75) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `matakuliah`
--

INSERT INTO `matakuliah` (`kdMataKuliah`, `mataKuliah`) VALUES
('C0E5108', 'Pemograman Visual'),
('C0E5109', 'Sistem Basis Data'),
('C0E5112', 'JAVA'),
('C0E5113', 'Metode Numerik');

-- --------------------------------------------------------

--
-- Table structure for table `prodi`
--

CREATE TABLE `prodi` (
  `kdProdi` char(3) NOT NULL,
  `prodi` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `prodi`
--

INSERT INTO `prodi` (`kdProdi`, `prodi`) VALUES
('572', 'Teknik Informatika'),
('573', 'Sistem Informasi'),
('574', 'Manjemen'),
('580', 'DKV'),
('581', 'Arsitek');

-- --------------------------------------------------------

--
-- Table structure for table `semester`
--

CREATE TABLE `semester` (
  `idSemester` tinyint(4) NOT NULL,
  `semester` varchar(6) NOT NULL,
  `thnAkademik` char(9) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `semester`
--

INSERT INTO `semester` (`idSemester`, `semester`, `thnAkademik`) VALUES
(1, 'Genap', '2018'),
(2, 'Ganjil', '2018');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `approvalizindosen`
--
ALTER TABLE `approvalizindosen`
  ADD PRIMARY KEY (`idApprovalIzinDosen`),
  ADD KEY `FK_izindosen` (`izinDosen`);

--
-- Indexes for table `dosen`
--
ALTER TABLE `dosen`
  ADD PRIMARY KEY (`kdDosen`);

--
-- Indexes for table `izindosen`
--
ALTER TABLE `izindosen`
  ADD PRIMARY KEY (`izinDosen`),
  ADD KEY `izindosen_ibfk_1` (`kdDosen`),
  ADD KEY `izindosen_ibfk_2` (`kdProdi`),
  ADD KEY `izindosen_ibfk_3` (`idSemester`),
  ADD KEY `izindosen_ibfk_4` (`kdMataKuliah`),
  ADD KEY `izindosen_ibfk_5` (`idKelas`);

--
-- Indexes for table `kelas`
--
ALTER TABLE `kelas`
  ADD PRIMARY KEY (`idKelas`);

--
-- Indexes for table `matakuliah`
--
ALTER TABLE `matakuliah`
  ADD PRIMARY KEY (`kdMataKuliah`);

--
-- Indexes for table `prodi`
--
ALTER TABLE `prodi`
  ADD PRIMARY KEY (`kdProdi`);

--
-- Indexes for table `semester`
--
ALTER TABLE `semester`
  ADD PRIMARY KEY (`idSemester`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `approvalizindosen`
--
ALTER TABLE `approvalizindosen`
  MODIFY `idApprovalIzinDosen` smallint(6) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=29;

--
-- AUTO_INCREMENT for table `izindosen`
--
ALTER TABLE `izindosen`
  MODIFY `izinDosen` smallint(6) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `kelas`
--
ALTER TABLE `kelas`
  MODIFY `idKelas` tinyint(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `semester`
--
ALTER TABLE `semester`
  MODIFY `idSemester` tinyint(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `approvalizindosen`
--
ALTER TABLE `approvalizindosen`
  ADD CONSTRAINT `FK_izindosen` FOREIGN KEY (`izinDosen`) REFERENCES `izindosen` (`izinDosen`);

--
-- Constraints for table `izindosen`
--
ALTER TABLE `izindosen`
  ADD CONSTRAINT `izindosen_ibfk_1` FOREIGN KEY (`kdDosen`) REFERENCES `dosen` (`kdDosen`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `izindosen_ibfk_2` FOREIGN KEY (`kdProdi`) REFERENCES `prodi` (`kdProdi`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `izindosen_ibfk_3` FOREIGN KEY (`idSemester`) REFERENCES `semester` (`idSemester`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `izindosen_ibfk_4` FOREIGN KEY (`kdMataKuliah`) REFERENCES `matakuliah` (`kdMataKuliah`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `izindosen_ibfk_5` FOREIGN KEY (`idKelas`) REFERENCES `kelas` (`idKelas`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
