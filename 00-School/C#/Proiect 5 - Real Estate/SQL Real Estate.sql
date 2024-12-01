CREATE TABLE Owner (
    OwnerId INT PRIMARY KEY NOT NULL IDENTITY(1,1), -- Auto-increment
    Name NVARCHAR(50) NOT NULL,             
    Email NVARCHAR(60) NOT NULL,                 
    Phone NVARCHAR(15) NULL, -- (optional)
    Cnp NVARCHAR(13) NOT NULL
);

CREATE TABLE Picture (
    PictureId INT PRIMARY KEY NOT NULL IDENTITY(1,1),
    Name NVARCHAR(255) NOT NULL,                     -- File name with extension (example: picture2.jpg)
    CreateDate DATETIME NOT NULL,                    
    Size BIGINT NOT NULL                             -- File size in bytes
);

CREATE TABLE Estate (
    EstateId INT PRIMARY KEY NOT NULL IDENTITY(1,1),
    Name NVARCHAR(255) NOT NULL,                   
    Address NVARCHAR(500) NOT NULL,              
    Price FLOAT NOT NULL,                         
    Type INT NOT NULL,                             -- Estate type (example: apartment, house, etc.)
    CreateDate DATETIME NOT NULL,
);

CREATE TABLE OwnerEstate (
    OwnerId INT NOT NULL,                          -- Foreign key
    EstateId INT NOT NULL,                         -- Foreign key
    CONSTRAINT PK_OwnerEstate PRIMARY KEY (OwnerId, EstateId), -- Composite primary key
    CONSTRAINT FK_OwnerEstate_Owner FOREIGN KEY (OwnerId) REFERENCES Owner (OwnerId)
        ON DELETE CASCADE ON UPDATE CASCADE,       --On owner delete, delete here too.
    CONSTRAINT FK_OwnerEstate_Estate FOREIGN KEY (EstateId) REFERENCES Estate (EstateId)
        ON DELETE CASCADE ON UPDATE CASCADE        --On estate delete, delete here too.
);

CREATE TABLE EstatePicture (
    EstateId INT NOT NULL,                         -- Foreign key
	PictureId INT NOT NULL,                          -- Foreign key
    CONSTRAINT PK_EstatePicture PRIMARY KEY (PictureId, EstateId), -- Composite primary key
    CONSTRAINT FK_EstatePicture_Picture FOREIGN KEY (PictureId) REFERENCES Picture (PictureId)
        ON DELETE CASCADE ON UPDATE CASCADE,       --On owner delete, delete here too.
    CONSTRAINT FK_EstatePicture_Estate FOREIGN KEY (EstateId) REFERENCES Estate (EstateId)
        ON DELETE CASCADE ON UPDATE CASCADE        --On estate delete, delete here too.
);



--VALUES ('Good House', 'Strada Cocolino', '20000', 1, GETDATE());
INSERT INTO Estate (Name, Address, Price, Type, CreateDate) VALUES
('Luxe Villa', 'Strada Primaverii 123, Bucharest', 500000, 2, '2024-11-01'),
('Modern Loft', 'Strada Victoriei 45, Cluj-Napoca', 350000, 1, '2024-11-02'),
('Cozy Cottage', 'Strada Muncii 67, Timisoara', 80000, 2, '2024-11-03'),
('Luxury Penthouse', 'Strada Dorobanti 12, Bucharest', 1200000, 1, '2024-11-04'),
('Charming Bungalow', 'Strada Dorului 22, Brasov', 200000, 2, '2024-11-05'),
('Seaside Retreat', 'Strada Plaja 78, Constanta', 450000, 2, '2024-11-06'),
('Suburban Home', 'Strada Lalelelor 15, Cluj-Napoca', 150000, 2, '2024-11-07'),
('Mountain Lodge', 'Strada Moților 10, Sibiu', 250000, 2, '2024-11-08'),
('City Center Apartment', 'Strada Unirii 99, Bucharest', 350000, 1, '2024-11-09'),
('Rustic Farmhouse', 'Strada Valea 33, Alba Iulia', 120000, 2, '2024-11-10'),
('Elegant Mansion', 'Strada Calea 50, Craiova', 900000, 2, '2024-11-11'),
('Beachfront Condo', 'Strada Marii 5, Constanta', 700000, 1, '2024-11-12'),
('New York Style Loft', 'Strada Lunca 11, Timisoara', 250000, 1, '2024-11-13'),
('Urban Retreat', 'Strada Mosilor 26, Bucharest', 150000, 1, '2024-11-14'),
('Historic Castle', 'Strada Castelului 120, Ploiesti', 3500000, 2, '2024-11-15'),
('Country House', 'Strada Pădurii 8, Piatra Neamt', 180000, 2, '2024-11-16'),
('Sleek Studio', 'Strada Lalelelor 99, Bucharest', 100000, 1, '2024-11-17'),
('Spacious Loft', 'Strada Tineretului 52, Iasi', 200000, 1, '2024-11-18'),
('Villa with Pool', 'Strada Carpatilor 5, Brasov', 600000, 2, '2024-11-19'),
('Elegant Townhouse', 'Strada Republicii 23, Constanta', 350000, 2, '2024-11-20'),
('Eco-Friendly Home', 'Strada Verde 70, Timisoara', 220000, 2, '2024-11-21'),
('Architectural Gem', 'Strada Iancului 18, Cluj-Napoca', 850000, 2, '2024-11-22'),
('Urban Loft', 'Strada Stefan 14, Bucharest', 380000, 1, '2024-11-23'),
('Chic Studio', 'Strada Nicolae Iorga 88, Brasov', 120000, 1, '2024-11-24'),
('Penthouse with View', 'Strada Aviatorilor 40, Bucharest', 2000000, 1, '2024-11-25'),
('Exclusive Mansion', 'Strada Zorilor 55, Cluj-Napoca', 2200000, 2, '2024-11-26'),
('Gated Community Villa', 'Strada Păcii 10, Oradea', 750000, 2, '2024-11-27'),
('Townhouse by the Park', 'Strada Florilor 12, Timisoara', 300000, 2, '2024-11-28'),
('Luxury Flat', 'Strada Obor 5, Bucharest', 450000, 1, '2024-11-29'),
('Peaceful Cottage', 'Strada Lumina 7, Piatra Neamt', 95000, 2, '2024-11-30'),
('Industrial Loft', 'Strada Soselei 17, Cluj-Napoca', 600000, 1, '2024-12-01');




INSERT INTO Picture (Name, CreateDate, Size)
VALUES ('Good House', GETDATE(), '20000');



INSERT INTO Owner(Name, Email, Phone, Cnp) VALUES
('John Doe', 'johndoe@email.com', '0712345678', '1990123456789'),
('Jane Smith', 'janesmith@email.com', '0723456789', '1985123456790'),
('Alice Johnson', 'alicej@email.com', '0734567890', '1992123456781'),
('Bob Brown', 'bobbrown@email.com', '0745678901', '1994023456782'),
('Charlie Davis', 'charlied@email.com', '0756789012', '1996123456783'),
('David Evans', 'davide@email.com', '0767890123', '1987123456794'),
('Eve Green', 'evegreen@email.com', '0778901234', '1998123456785'),
('Frank Harris', 'frankh@email.com', '0789012345', '2000123456786'),
('Grace White', 'gracew@email.com', '0790123456', '1989123456797'),
('Henry Clark', 'henryc@email.com', '0701234567', '1991023456788'),
('Isabel Lewis', 'isabel@email.com', '0712345678', '1984123456799'),
('Jack Young', 'jacky@email.com', '0723456789', '2001123456780'),
('Kimberly King', 'kimberlyk@email.com', '0734567890', '1996123456781'),
('Leo Scott', 'leos@email.com', '0745678901', '2002123456782'),
('Mona Turner', 'monat@email.com', '0756789012', '1985123456793'),
('Nathan Parker', 'nathanp@email.com', '0767890123', '1992123456784'),
('Olivia Martinez', 'oliviam@email.com', '0778901234', '1994123456785'),
('Paul Mitchell', 'paulm@email.com', '0789012345', '1987123456796'),
('Quincy Allen', 'quincya@email.com', '0790123456', '1993123456787'),
('Rachel Nelson', 'racheln@email.com', '0701234567', '1982123456798'),
('Samuel Adams', 'samuel@email.com', '0712345678', '1998123456789'),
('Tina Hall', 'tinah@email.com', '0723456789', '2004123456790'),
('Ursula Lewis', 'ursulal@email.com', '0734567890', '1996123456781'),
('Victor Black', 'victorb@email.com', '0745678901', '2003123456782'),
('Wendy Brooks', 'wendyb@email.com', '0756789012', '1985123456793'),
('Xander Gray', 'xander@email.com', '0767890123', '1992123456784'),
('Yvonne White', 'yvonnew@email.com', '0778901234', '1994123456785'),
('Zachary Stone', 'zacharys@email.com', '0789012345', '1987123456796'),
('Alice Wood', 'alicew@email.com', '0790123456', '1993123456787'),
('Brian Fisher', 'brianf@email.com', '0701234567', '1982123456798'),
('Catherine Long', 'catherinel@email.com', '0712345678', '1998123456789'),
('Daniel Morgan', 'danielm@email.com', '0723456789', '2004123456790'),
('Elaine Cooper', 'elainec@email.com', '0734567890', '1996123456781'),
('Freddie King', 'freddiek@email.com', '0745678901', '2003123456782'),
('Gina Ford', 'ginaf@email.com', '0756789012', '1985123456793'),
('Hannah Rogers', 'hannah@email.com', '0767890123', '1992123456784'),
('Ian Perry', 'ianp@email.com', '0778901234', '1994123456785'),
('Joan Bell', 'joanb@email.com', '0789012345', '1987123456796'),
('Kyle Brooks', 'kyleb@email.com', '0790123456', '1993123456787'),
('Lily Ward', 'lilyw@email.com', '0701234567', '1982123456798'),
('Mark Shaw', 'mark@email.com', '0712345678', '1998123456789'),
('Nancy Scott', 'nancys@email.com', '0723456789', '2004123456790'),
('Oscar Hayes', 'oscarh@email.com', '0734567890', '1996123456781'),
('Pamela Simmons', 'pamelas@email.com', '0745678901', '2003123456782'),
('Quincy Lee', 'quincyl@email.com', '0756789012', '1985123456793'),
('Rita Walker', 'ritaw@email.com', '0767890123', '1992123456784'),
('Stephen King', 'stephenk@email.com', '0778901234', '1994123456785'),
('Tracy Turner', 'tracyt@email.com', '0789012345', '1987123456796');

select * from Owner;
select * from Picture;
select * from Estate;
select * from OwnerEstate;
select * from EstatePicture;