# _{Hair Salon}_

#### _{Table and databases.}, {Date 02-23-2018}_

#### By _**{Hamza Naeem}**_

## Description

_{Code Review for week 3 in C# for Epicodus. The purpose is to demonstrate using databases with MySQL. }_

## Specifications

* _The User inputs to create a Stylist
* _Input: "Bob Bobbert"
* _Output: "Bob Bobbert"

* _User creates client
* _Input: "Mambo Jambo"
* _Output: "Mambo Jambo"

* _User can set client to stylist
* _Input: "Mambo Jambo" to "Bob Bobbert"
* _Output: "Bob Bobbert, Mambo Jambo"

## Setup/Installation Requirements

* _This setup requires the installation of .NET and MAMP_
* _.NET runtime_
* _git clone https://github.com/hamzilitary/Hair-Salon-Code-Review_
* _Then you can create the database_
* _Table structure for table `client`
--

CREATE TABLE `client` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `stylist` int(11) NOT NULL,
  `type` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `client`
--

INSERT INTO `client` (`id`, `name`, `stylist`, `type`) VALUES
(1, 'Rob', 1, NULL),
(4, 'Bart ', 5, NULL),
(5, 'Pumpkin', 5, NULL);

--
* _Table structure for table `stylist`
--

CREATE TABLE `stylist` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

* _Boot the MySql in MAMP_
* _Open the command and navigate to /Hair-Salon-Code-Review/HairSalon and run dotnet restore

* _Do the same but navigate to /Hair-Salon-Code-Review/HairSalon.Test

* _Run dotnet run in the command

* _Go to localhost:5000/ in your browser

__



## Technologies Used

* _HTML_
* _Bootstrap_
* _C#_
* _MAMP_
* _.NET Core 1.1
* _Razor_
* _MySql





Copyright (c) 2018 **_{Hamza Naeem}_**
