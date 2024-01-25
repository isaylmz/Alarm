-- phpMyAdmin SQL Dump
-- version 5.1.1deb5ubuntu1
-- https://www.phpmyadmin.net/
--
-- Anamakine: localhost:3306
-- Üretim Zamanı: 25 Oca 2024, 13:23:34
-- Sunucu sürümü: 8.0.35-0ubuntu0.22.04.1
-- PHP Sürümü: 8.1.2-1ubuntu2.14

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Veritabanı: `igpfinal`
--
CREATE DATABASE IF NOT EXISTS `igpfinal` DEFAULT CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci;
USE `igpfinal`;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `alarm`
--

CREATE TABLE `alarm` (
  `AlarmNo` int NOT NULL,
  `AlarmAdi` varchar(45) DEFAULT NULL,
  `Zaman` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `alarmses`
--

CREATE TABLE `alarmses` (
  `No` int NOT NULL,
  `durumu` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

--
-- Tablo döküm verisi `alarmses`
--

INSERT INTO `alarmses` (`No`, `durumu`) VALUES
(1, 'kapalı');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `denetim`
--

CREATE TABLE `denetim` (
  `No` int NOT NULL,
  `durum` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

--
-- Tablo döküm verisi `denetim`
--

INSERT INTO `denetim` (`No`, `durum`) VALUES
(1, 'kapalı'),
(2, 'kapalı'),
(3, 'kapalı'),
(4, 'kapalı'),
(5, 'kapalı');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `skor`
--

CREATE TABLE `skor` (
  `SkorId` int NOT NULL,
  `DortIslem` int DEFAULT NULL,
  `Hangisi` int DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

--
-- Tablo döküm verisi `skor`
--

INSERT INTO `skor` (`SkorId`, `DortIslem`, `Hangisi`) VALUES
(1, 0, 0);

--
-- Dökümü yapılmış tablolar için indeksler
--

--
-- Tablo için indeksler `alarm`
--
ALTER TABLE `alarm`
  ADD PRIMARY KEY (`AlarmNo`);

--
-- Tablo için indeksler `alarmses`
--
ALTER TABLE `alarmses`
  ADD PRIMARY KEY (`No`);

--
-- Tablo için indeksler `denetim`
--
ALTER TABLE `denetim`
  ADD PRIMARY KEY (`No`);

--
-- Tablo için indeksler `skor`
--
ALTER TABLE `skor`
  ADD PRIMARY KEY (`SkorId`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
