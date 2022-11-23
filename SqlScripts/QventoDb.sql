-- DATABASE
USE qventodb;

DROP TABLE IF EXISTS Invitations;
DROP TABLE IF EXISTS Qventos;
DROP TABLE IF EXISTS Users;

-- USERS

CREATE TABLE Users
(
    UserId INT IDENTITY(100,1),
    Name VARCHAR(255) NOT NULL,
    LastName VARCHAR(255) NOT NULL,
    Email VARCHAR(255) NOT NULL,
    PasswordHash VARCHAR(255) NOT NULL,
    Phone VARCHAR(25),
    Address VARCHAR(255),
    PRIMARY KEY (UserId)
);

-- Password is 'qvento' in SHA3-512 bits -> https://www.browserling.com/tools/sha3-hash
INSERT INTO Users (Name, LastName, Email, PasswordHash, Phone, Address) VALUES ('Antonio', 'Antunes Arriba', 'antonio@fake.com', '75ea9ed7c44cbc17aebc0104ccacbf6646dc6d9a72b80ab77bd5e9acc44d26a4ebb8ae681bf67f578c49185d9ff1117ad85ef3d04b9d2630dd45c387c820b679', '123123123', 'Calle Piruleta 1');
INSERT INTO Users (Name, LastName, Email, PasswordHash, Phone, Address) VALUES ('Beatriz', 'Bonito Bueno', 'beatriz@fake.com', '75ea9ed7c44cbc17aebc0104ccacbf6646dc6d9a72b80ab77bd5e9acc44d26a4ebb8ae681bf67f578c49185d9ff1117ad85ef3d04b9d2630dd45c387c820b679', '123123123', 'Calle Piruleta 2');
INSERT INTO Users (Name, LastName, Email, PasswordHash, Phone, Address) VALUES ('Carlos', 'Castro Carrillo', 'carlos@fake.com', '75ea9ed7c44cbc17aebc0104ccacbf6646dc6d9a72b80ab77bd5e9acc44d26a4ebb8ae681bf67f578c49185d9ff1117ad85ef3d04b9d2630dd45c387c820b679', '123123123', 'Calle Piruleta 3');
INSERT INTO Users (Name, LastName, Email, PasswordHash, Phone, Address) VALUES ('Diana', 'Duran Dadada', 'diana@fake.com', '75ea9ed7c44cbc17aebc0104ccacbf6646dc6d9a72b80ab77bd5e9acc44d26a4ebb8ae681bf67f578c49185d9ff1117ad85ef3d04b9d2630dd45c387c820b679', '123123123', 'Calle Piruleta 4');

-- QVENTOS

CREATE TABLE Qventos
(
    QventoId INT IDENTITY(100,1),
    CreatedBy INT NOT NULL,
    Title VARCHAR(50) NOT NULL,
    DateOfQvento DATE NOT NULL,
    DateCreated DATE NOT NULL,
    Status VARCHAR(1) NOT NULL,
    Description VARCHAR(255),
    Location VARCHAR(255),
    PRIMARY KEY (QventoId),
    FOREIGN KEY (CreatedBy) REFERENCES Users(UserId)
);

INSERT INTO Qventos VALUES (
    100,
    'Fake Qvento 01',
    '2022-12-01',
    '2022-11-01',
    'A',
    'El veloz murciélago hindú comía feliz cardillo y kiwi. La cigüeña tocaba el saxofón detrás del palenque de paja.',
    'Calle Falsa 01, Madrid');

INSERT INTO Qventos VALUES (
    101,
    'Fake Qvento 02',
    '2022-12-22',
    '2022-11-01',
    'A',
    'El pingüino Wenceslao hizo kilómetros bajo exhaustiva lluvia y frío, añoraba a su querido cachorro.',
    'Calle Falsa 02, Sevilla');

INSERT INTO Qventos VALUES (
    102,
    'Fake Qvento 03',
    '2023-02-28',
    '2022-11-01',
    'C',
    'Le gustaba cenar un exquisito sándwich de jamón con zumo de piña y vodka fría.',
    'Calle Falsa 03, Jerez de la Frontera');

INSERT INTO Qventos VALUES (
    103,
    'Fake Qvento 04',
    '2022-09-01',
    '2022-08-01',
    'F',
    'El viejo Señor Gómez pedía queso, kiwi y habas, pero le ha tocado un saxofón. Exhíbanse politiquillos zafios, con orejas kilométricas y uñas de gavilán.',
    'Calle Falsa 04, Valencia');

-- INVITATIONS

CREATE TABLE Invitations
(
    QventoId INT,
    UserId INT,
    Status CHAR(1) NOT NULL,
    PRIMARY KEY (QventoId, UserId),
    FOREIGN KEY (QventoId) REFERENCES Qventos(QventoId),
    FOREIGN KEY (UserId) REFERENCES Users(UserId)
);

-- Invitations to Qvento 100
INSERT INTO Invitations VALUES (100, 101, 'P'); -- Pending
INSERT INTO Invitations VALUES (100, 102, 'R'); -- Rejected
INSERT INTO Invitations VALUES (100, 103, 'A'); -- Accepted

-- Invitations to Qvento 101
INSERT INTO Invitations VALUES (101, 100, 'A');
INSERT INTO Invitations VALUES (101, 102, 'A');
INSERT INTO Invitations VALUES (101, 103, 'A');