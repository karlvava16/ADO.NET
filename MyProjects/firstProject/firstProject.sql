
go
create database TouristAgency
go

Use TouristAgency


CREATE TABLE Employees (
    ID INT PRIMARY KEY,
    FirstName NVARCHAR(MAX),
    LastName NVARCHAR(MAX),
	Position NVARCHAR(MAX),
	PhoneNumber VARCHAR(20),
	Email VARCHAR(MAX),
    Salary DECIMAL(10, 2)
)

Use TouristAgency

-- Вставка данных для директора
INSERT INTO Employees (ID, FirstName, LastName, Position, PhoneNumber, Email, Salary)
VALUES
(1, 'John', 'Doe', 'Director', '+1 (555) 123-4567', 'john.doe@company.com', 120000.00);

-- Вставка данных для бухгалтера
INSERT INTO Employees (ID, FirstName, LastName, Position, PhoneNumber, Email, Salary)
VALUES
(2, 'Alice', 'Smith', 'Accountant', '+1 (555) 987-6543', 'alice.smith@company.com', 90000.00);

-- Вставка данных для менеджера 1
INSERT INTO Employees (ID, FirstName, LastName, Position, PhoneNumber, Email, Salary)
VALUES
(3, 'Bob', 'Johnson', 'Manager', '+1 (555) 234-5678', 'bob.johnson@company.com', 75000.00);

-- Вставка данных для менеджера 2
INSERT INTO Employees (ID, FirstName, LastName, Position, PhoneNumber, Email, Salary)
VALUES
(4, 'Emily', 'Williams', 'Manager', '+1 (555) 876-5432', 'emily.williams@company.com', 72000.00);

-- Вставка данных для менеджера 3
INSERT INTO Employees (ID, FirstName, LastName, Position, PhoneNumber, Email, Salary)
VALUES
(5, 'Michael', 'Jones', 'Manager', '+1 (555) 345-6789', 'michael.jones@company.com', 70000.00);



use TouristAgency

CREATE TABLE Сountries
(
	ID INT PRIMARY KEY,
	CountryName NVARCHAR(MAX) NOT NULL,
	CountryCode VARCHAR(4) NOT NULL,
)


USE TouristAgency



-- Вставка первых 20 стран по алфавиту
INSERT INTO Сountries (ID, CountryName, CountryCode)
VALUES
(1, 'Afghanistan', 'AFG'),
(2, 'Albania', 'ALB'),
(3, 'Algeria', 'DZA'),
(4, 'Andorra', 'AND'),
(5, 'Angola', 'AGO'),
(6, 'Antigua and Barbuda', 'ATG'),
(7, 'Argentina', 'ARG'),
(8, 'Armenia', 'ARM'),
(9, 'Australia', 'AUS'),
(10, 'Austria', 'AUT'),
(11, 'Azerbaijan', 'AZE'),
(12, 'Bahamas', 'BHS'),
(13, 'Bahrain', 'BHR'),
(14, 'Bangladesh', 'BGD'),
(15, 'Barbados', 'BRB'),
(16, 'Belarus', 'BLR'),
(17, 'Belgium', 'BEL'),
(18, 'Belize', 'BLZ'),
(19, 'Benin', 'BEN'),
(20, 'Bhutan', 'BTN');


USE TouristAgency;

-- Вставка следующих 20 стран по алфавиту
INSERT INTO Сountries (ID, CountryName, CountryCode)
VALUES
(21, 'Bolivia', 'BOL'),
(22, 'Bosnia and Herzegovina', 'BIH'),
(23, 'Botswana', 'BWA'),
(24, 'Brazil', 'BRA'),
(25, 'Brunei', 'BRN'),
(26, 'Bulgaria', 'BGR'),
(27, 'Burkina Faso', 'BFA'),
(28, 'Burundi', 'BDI'),
(29, 'Cabo Verde', 'CPV'),
(30, 'Cambodia', 'KHM'),
(31, 'Cameroon', 'CMR'),
(32, 'Canada', 'CAN'),
(33, 'Central African Republic', 'CAF'),
(34, 'Chad', 'TCD'),
(35, 'Chile', 'CHL'),
(36, 'China', 'CHN'),
(37, 'Colombia', 'COL'),
(38, 'Comoros', 'COM'),
(39, 'Congo', 'COG'),
(40, 'Costa Rica', 'CRI');

USE TouristAgency;

-- Вставка следующих 20 стран по алфавиту
INSERT INTO Сountries (ID, CountryName, CountryCode)
VALUES
(41, 'Côte d''Ivoire', 'CIV'),
(42, 'Croatia', 'HRV'),
(43, 'Cuba', 'CUB'),
(44, 'Cyprus', 'CYP'),
(45, 'Czech Republic', 'CZE'),
(46, 'Denmark', 'DNK'),
(47, 'Djibouti', 'DJI'),
(48, 'Dominica', 'DMA'),
(49, 'Dominican Republic', 'DOM'),
(50, 'Ecuador', 'ECU'),
(51, 'Egypt', 'EGY'),
(52, 'El Salvador', 'SLV'),
(53, 'Equatorial Guinea', 'GNQ'),
(54, 'Eritrea', 'ERI'),
(55, 'Estonia', 'EST'),
(56, 'Eswatini', 'SWZ'),
(57, 'Ethiopia', 'ETH'),
(58, 'Fiji', 'FJI'),
(59, 'Finland', 'FIN'),
(60, 'France', 'FRA');

USE TouristAgency;

-- Вставка следующих 20 стран по алфавиту
INSERT INTO Сountries (ID, CountryName, CountryCode)
VALUES
(61, 'Gabon', 'GAB'),
(62, 'Gambia', 'GMB'),
(63, 'Georgia', 'GEO'),
(64, 'Germany', 'DEU'),
(65, 'Ghana', 'GHA'),
(66, 'Greece', 'GRC'),
(67, 'Grenada', 'GRD'),
(68, 'Guatemala', 'GTM'),
(69, 'Guinea', 'GIN'),
(70, 'Guinea-Bissau', 'GNB'),
(71, 'Guyana', 'GUY'),
(72, 'Haiti', 'HTI'),
(73, 'Honduras', 'HND'),
(74, 'Hungary', 'HUN'),
(75, 'Iceland', 'ISL'),
(76, 'India', 'IND'),
(77, 'Indonesia', 'IDN'),
(78, 'Iran', 'IRN'),
(79, 'Iraq', 'IRQ'),
(80, 'Ireland', 'IRL');

USE TouristAgency;

-- Вставка следующих 20 стран по алфавиту
INSERT INTO Сountries (ID, CountryName, CountryCode)
VALUES
(81, 'Israel', 'ISR'),
(82, 'Italy', 'ITA'),
(83, 'Jamaica', 'JAM'),
(84, 'Japan', 'JPN'),
(85, 'Jordan', 'JOR'),
(86, 'Kazakhstan', 'KAZ'),
(87, 'Kenya', 'KEN'),
(88, 'Kiribati', 'KIR'),
(89, 'Korea (North)', 'PRK'),
(90, 'Korea (South)', 'KOR'),
(91, 'Kuwait', 'KWT'),
(92, 'Kyrgyzstan', 'KGZ'),
(93, 'Laos', 'LAO'),
(94, 'Latvia', 'LVA'),
(95, 'Lebanon', 'LBN'),
(96, 'Lesotho', 'LSO'),
(97, 'Liberia', 'LBR'),
(98, 'Libya', 'LBY'),
(99, 'Liechtenstein', 'LIE'),
(100, 'Lithuania', 'LTU');

USE TouristAgency;

-- Вставка следующих 20 стран по алфавиту
INSERT INTO Сountries (ID, CountryName, CountryCode)
VALUES
(101, 'Luxembourg', 'LUX'),
(102, 'Madagascar', 'MDG'),
(103, 'Malawi', 'MWI'),
(104, 'Malaysia', 'MYS'),
(105, 'Maldives', 'MDV'),
(106, 'Mali', 'MLI'),
(107, 'Malta', 'MLT'),
(108, 'Marshall Islands', 'MHL'),
(109, 'Mauritania', 'MRT'),
(110, 'Mauritius', 'MUS'),
(111, 'Mexico', 'MEX'),
(112, 'Micronesia', 'FSM'),
(113, 'Moldova', 'MDA'),
(114, 'Monaco', 'MCO'),
(115, 'Mongolia', 'MNG'),
(116, 'Montenegro', 'MNE'),
(117, 'Morocco', 'MAR'),
(118, 'Mozambique', 'MOZ'),
(119, 'Myanmar', 'MMR'),
(120, 'Namibia', 'NAM');

USE TouristAgency;

-- Вставка следующих 20 стран по алфавиту
INSERT INTO Сountries (ID, CountryName, CountryCode)
VALUES
(121, 'Nauru', 'NRU'),
(122, 'Nepal', 'NPL'),
(123, 'Netherlands', 'NLD'),
(124, 'New Zealand', 'NZL'),
(125, 'Nicaragua', 'NIC'),
(126, 'Niger', 'NER'),
(127, 'Nigeria', 'NGA'),
(128, 'North Macedonia', 'MKD'),
(129, 'Norway', 'NOR'),
(130, 'Oman', 'OMN'),
(131, 'Pakistan', 'PAK'),
(132, 'Palau', 'PLW'),
(133, 'Panama', 'PAN'),
(134, 'Papua New Guinea', 'PNG'),
(135, 'Paraguay', 'PRY'),
(136, 'Peru', 'PER'),
(137, 'Philippines', 'PHL'),
(138, 'Poland', 'POL'),
(139, 'Portugal', 'PRT'),
(140, 'Qatar', 'QAT');

USE TouristAgency;

-- Вставка следующих 20 стран по алфавиту
INSERT INTO Сountries (ID, CountryName, CountryCode)
VALUES
(141, 'Romania', 'ROU'),
(142, 'Russia', 'RUS'),
(143, 'Rwanda', 'RWA'),
(144, 'Saint Kitts and Nevis', 'KNA'),
(145, 'Saint Lucia', 'LCA'),
(146, 'Saint Vincent and the Grenadines', 'VCT'),
(147, 'Samoa', 'WSM'),
(148, 'San Marino', 'SMR'),
(149, 'Sao Tome and Principe', 'STP'),
(150, 'Saudi Arabia', 'SAU'),
(151, 'Senegal', 'SEN'),
(152, 'Serbia', 'SRB'),
(153, 'Seychelles', 'SYC'),
(154, 'Sierra Leone', 'SLE'),
(155, 'Singapore', 'SGP'),
(156, 'Slovakia', 'SVK'),
(157, 'Slovenia', 'SVN'),
(158, 'Solomon Islands', 'SLB'),
(159, 'Somalia', 'SOM'),
(160, 'South Africa', 'ZAF');



USE TouristAgency;

-- Вставка следующих 20 стран по алфавиту
INSERT INTO Сountries (ID, CountryName, CountryCode)
VALUES
(161, 'South Sudan', 'SSD'),
(162, 'Spain', 'ESP'),
(163, 'Sri Lanka', 'LKA'),
(164, 'Sudan', 'SDN'),
(165, 'Suriname', 'SUR'),
(166, 'Sweden', 'SWE'),
(167, 'Switzerland', 'CHE'),
(168, 'Syria', 'SYR'),
(169, 'Tajikistan', 'TJK'),
(170, 'Tanzania', 'TZA'),
(171, 'Thailand', 'THA'),
(172, 'Timor-Leste', 'TLS'),
(173, 'Togo', 'TGO'),
(174, 'Tonga', 'TON'),
(175, 'Trinidad and Tobago', 'TTO'),
(176, 'Tunisia', 'TUN'),
(177, 'Turkey', 'TUR'),
(178, 'Turkmenistan', 'TKM'),
(179, 'Tuvalu', 'TUV'),
(180, 'Uganda', 'UGA');

USE TouristAgency;

-- Вставка следующих 20 стран по алфавиту
INSERT INTO Сountries (ID, CountryName, CountryCode)
VALUES
(181, 'Ukraine', 'UKR'),
(182, 'United Arab Emirates', 'ARE'),
(183, 'United Kingdom', 'GBR'),
(184, 'United States', 'USA'),
(185, 'Uruguay', 'URY'),
(186, 'Uzbekistan', 'UZB'),
(187, 'Vanuatu', 'VUT'),
(188, 'Vatican City', 'VAT'),
(189, 'Venezuela', 'VEN'),
(190, 'Vietnam', 'VNM'),
(191, 'Yemen', 'YEM'),
(192, 'Zambia', 'ZMB'),
(193, 'Zimbabwe', 'ZWE')


ALTER TABLE Сountries
ADD CONSTRAINT UQ_Countries_CountryCode UNIQUE (CountryCode);


USE TouristAgency

CREATE TABLE Cities
(
    ID INT PRIMARY KEY,
    CityName NVARCHAR(MAX) NOT NULL,
    CountryCode VARCHAR(4) NOT NULL,
    CONSTRAINT FK_Cities_Countries 
        FOREIGN KEY (CountryCode) 
        REFERENCES Сountries(CountryCode)
);



USE TouristAgency

CREATE TABLE Tourists (
    ID INT PRIMARY KEY,
    FirstName NVARCHAR(MAX) NOT NULL,
    LastName NVARCHAR(MAX) NOT NULL,
    PhoneNumber VARCHAR(20),
	Email VARCHAR(MAX)
);


USE TouristAgency

CREATE TABLE Resorts (
    ID INT PRIMARY KEY,
    Name NVARCHAR(MAX),
    CityID INT FOREIGN KEY REFERENCES Cities(ID),
    Description NVARCHAR(MAX)
);

USE TouristAgency

CREATE TABLE Hotels (
    ID INT PRIMARY KEY,
    HotelName NVARCHAR(MAX),
    ResortID INT FOREIGN KEY REFERENCES Resorts(ID),
    Rating INT,
    Description NVARCHAR(MAX)
);

CREATE TABLE TypesOfLeisure (
    ID INT PRIMARY KEY,
    Name NVARCHAR(MAX)
);

CREATE TABLE TypesOfTransport (
    ID INT PRIMARY KEY,
    Name NVARCHAR(MAX)
);

CREATE TABLE Trips (
    ID INT PRIMARY KEY,
    ResortID INT FOREIGN KEY REFERENCES Resorts(ID),
    Duration INT,
    Cost DECIMAL(10, 2),
    LeisureID INT FOREIGN KEY REFERENCES TypesOfLeisure(ID),
    TransportID INT FOREIGN KEY REFERENCES TypesOfTransport(ID),
);

