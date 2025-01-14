--CREATE DATABASE dbFirma
--use dbFirma
--CREATE SCHEMA Pachete;

--COMENZILE TREBUIE RULATE 1 CATE 1 PENTRU A PREVENII ERORI LA CREARE


SELECT * FROM   Pachete.tFunctii
SELECT * FROM   Pachete.tAngajati
SELECT * FROM   Pachete.tClienti
SELECT * FROM   Pachete.tProduse
SELECT * FROM   Pachete.tComenzi
SELECT * FROM   Pachete.tDetaliiComanda



CREATE TABLE Pachete.tClienti
  (
     codClient  char(10) constraint pk_client primary key,
     numeClient varchar(30) not null,
     localitate varchar(20)
  )

  --Sa se creeze tabelul
--tComenzi(nrComanda, #codClient, dataComanda, dataLivrare, cantitate)
CREATE TABLE Pachete.tComenzi
  (
     nrComanda   char(10),
     codClient   char(10),
     dataComanda smalldatetime,
     dataLivrare smalldatetime,
     cantitate   smallint
  )

ALTER TABLE Pachete.tComenzi
  ADD CONSTRAINT df_data DEFAULT Getdate() for dataComanda

--Sa se corecteze conditia "not NULL" unde este necesar.
ALTER TABLE Pachete.tComenzi
  ALTER column nrComanda char(10) not null

ALTER TABLE Pachete.tComenzi
 ALTER column codClient char(10) not null

ALTER TABLE Pachete.tComenzi
  ALTER column dataComanda smalldatetime not null

--In schimb, Data de livrare poate fii NULL, daca coletul nu a fost inca livrat.
--Not Null - este nevoie pentru primary key.
ALTER TABLE Pachete.tComenzi
  ADD CONSTRAINT pk_comanda PRIMARY KEY(nrComanda)

ALTER TABLE Pachete.tComenzi
  ADD CONSTRAINT fk_tComenzi_client FOREIGN KEY(codClient) references
  Pachete.tClienti(codClient)

--Sa se creeze tabelul
--tProduse(codProdus, denumire, unitateMasura, pret)
CREATE TABLE Pachete.tProduse
  (
     codProdus     CHAR(10) not null,
     denumire      VARCHAR(30) not null,
     unitateMasura VARCHAR(10) not null,
     pret          SMALLINT
  )

ALTER TABLE Pachete.tProduse
  ADD CONSTRAINT pk_produs PRIMARY KEY(codProdus)

--Sa se creeze tabelul
--tDetaliiComanda(#nrComanda, idRand, #codProdus, #codClient, cantitate)
CREATE TABLE Pachete.tDetaliiComanda
  (
     nrComanda CHAR(10) CONSTRAINT fk_comanda FOREIGN KEY REFERENCES
     Pachete.tComenzi(nrComanda) not
     null,
     idRand    INT not null,
     codClient CHAR(10),
     cantitate SMALLINT,
  )

--Am uitat sa adaug #codProdus!
ALTER TABLE Pachete.tDetaliiComanda
  ADD codProdus CHAR(10) NOT NULL CONSTRAINT fk_prod FOREIGN KEY REFERENCES
  Pachete.tProduse(codProdus) 

ALTER TABLE Pachete.tDetaliiComanda
  add CONSTRAINT fk_tDetaliiComanda_Client FOREIGN KEY(codClient) REFERENCES
  Pachete.tClienti(codClient)

ALTER TABLE Pachete.tDetaliiComanda
  ADD CONSTRAINT pk_detaliiComanda PRIMARY KEY(nrComanda, idRand)

--Sa se creeze tabelul
--tFunctii(codFunctie, functie)
CREATE TABLE Pachete.tFunctii
  (
     codFunctie INT IDENTITY(1, 1) CONSTRAINT pk_functie PRIMARY KEY NOT NULL,
     functie    varchar(30)
  )

--Sa se creeze tabelul
--tAngajati(codAngajat, numeAngajat, functie)
CREATE TABLE Pachete.tAngajati
  (
     codAngajat int IDENTITY(1, 1) CONSTRAINT pk_angajat PRIMARY KEY NOT NULL,
     numeAngajat varchar(30),
     codFunctie int
  )

ALTER TABLE Pachete.tAngajati
  ADD CONSTRAINT fk_func FOREIGN KEY(codFunctie) REFERENCES
  Pachete.tFunctii(codFunctie)


  --Cream 7 functii
INSERT INTO Pachete.tFunctii(functie)
VALUES     ('Manager Depozit'),
            ('Lucrator Depozit'),
            ('Operator Echipament Ridicare'),
            ('Coordonator Logistic'),
            ('Inspector de Calitate'),
            ('Specialist documentatia Vamala'),
            ('Manager de Operatiuni')

--Adaugam 20 de angajați.
INSERT INTO Pachete.tAngajati (numeAngajat, codFunctie)
VALUES     ('Vasile', 2),
           ('Ana', 1),
           ('Ion', 3),
           ('Maria', 5),
           ('Andrei', 2),
           ('Elena', 6),
           ('Mihai', 4),
           ('Cristina', 7),
           ('Alexandru', 2),
           ('Raluca', 1),
           ('Gabriel', 3),
           ('Diana', 4),
           ('Victor', 5),
           ('Andreea', 2),
           ('Ciprian', 7),
           ('Adriana', 1),
           ('Bogdan', 3),
           ('Simona', 6),
           ('Razvan', 4),
           ('Laura', 2);

--Introducem 24 de clienti.
INSERT INTO Pachete.tClienti(codClient,numeClient,localitate)
VALUES      ('C1','Maria Popescu','Pitesti'),
            ('C2','Ion Ionescu','Bucuresti'),
            ('C3','Elena Dumitrescu','Cluj'),
            ('C4','Andrei Radu','Ploiesti'),
            ('C5','Ana Stoica','Mioveni'),
            ('C6','Mihai Gheorghe','Pitesti'),
            ('C7','Cristina Marinescu','Bucuresti'),
            ('C8','Alexandru Popa','Cluj'),
            ('C9','Raluca Andrei','Ploiesti'),
            ('C10','Gabriel Cojocaru','Mioveni'),
            ('C11','Andreea Vasilescu','Pitesti'),
            ('C12','Adrian Georgescu','Bucuresti'),
            ('C13','Mihaela Neagu','Cluj'),
            ('C14','Daniel Stan','Ploiesti'),
            ('C15','Laura Dragomir','Mioveni'),
            ('C16','Bogdan Pop','Pitesti'),
            ('C17','Alina Iancu','Bucuresti'),
            ('C18','George Popovici','Cluj'),
            ('C19','Ioana Munteanu','Ploiesti'),
            ('C20','Robert','Mioveni'),
            ('C21','Diana Ilie','Pitesti'),
            ('C22','Florin Marin','Bucuresti'),
            ('C23','Ioan Vasilache','Cluj'),
            ('C24','Irina Moraru','Ploiesti')

--Introducem 6 produse.
INSERT INTO Pachete.tProduse(codProdus,denumire,unitateMasura,pret)
VALUES     ('P1','Pachet Mic','10g','5'),
            ('P2','Pachet Mediu','30g','15'),
            ('P3','Pachet Mare','70g','30'),
            ('P4','Banda Adeziva','150g','40'),
            ('P5','Etichete','','60'),
            ('P6','Folii Protectoare','','20')




ALTER TABLE Pachete.tComenzi
  DROP COLUMN cantitate

--În tabelul tDetaliiComanda, codClient apare din nou, ceea ce poate crea confuzie.
--Dacă tDetaliiComanda reprezintă detaliile specifice ale fiecărei comenzi
--Am decis sa elimin coloana "codClient". Va fii accesat prin intermediul tabelului tComenzi.

--Eliminam ambele  Foreign Keys
ALTER TABLE Pachete.tDetaliiComanda
  DROP CONSTRAINT fk_tDetaliiComanda_Client;

ALTER TABLE Pachete.tComenzi
  DROP CONSTRAINT fk_tComenzi_client;

--Se adaugă din nou în tComenzi cu un Nume mai simplu.

ALTER TABLE Pachete.tComenzi
  ADD CONSTRAINT fk_client FOREIGN KEY(codClient) REFERENCES Pachete.tClienti(codClient)

ALTER TABLE Pachete.tDetaliiComanda
  DROP COLUMN codClient



--Adaugam 19 comenzi.
--Unele comenzi nu au încă o data de livrare! Altele vor fii livrare in cateva zile.
INSERT INTO Pachete.tComenzi(nrComanda,codClient,dataComanda,dataLivrare)
VALUES     (1,'C1',Getdate(),Getdate()),
            (2,'C1',Getdate(),Getdate()),
            (3,'C3',Getdate(),Getdate() + 3),
            (4,'C6',Getdate(),NULL),
            (5,'C4',Getdate(),Getdate() + 4),
            (6,'C2',Getdate(),NULL),
            (7,'C1',Getdate(),Getdate() + 1),
            (8,'C1',Getdate(),NULL),
            (9,'C5',Getdate(),Getdate()),
            (10,'C9',Getdate(),Getdate() + 2),
            (11,'C12',Getdate(),Getdate()),
            (12,'C5',Getdate(),Getdate() + 5),
            (13,'C3',Getdate(),Getdate() + 5),
            (14,'C5',Getdate(),NULL),
            (15,'C5',Getdate(),Getdate() + 2),
            (16,'C5',Getdate(),Getdate() + 2),
            (17,'C9',Getdate(),NULL),
            (18,'C1',Getdate(),Getdate()),
            (19,'C13',Getdate(),NULL)



INSERT INTO Pachete.tDetaliiComanda(nrComanda,idRand,cantitate,codProdus)
VALUES
-- Comanda 1
(1,1,3,'P1'),
            (1,2,15,'P1'),
            (1,3,7,'P2'),
            -- Comanda 2
            (2,1,5,'P2'),
            (2,2,10,'P3'),
            (2,3,2,'P5'),
            -- Comanda 3
            (3,1,5,'P4'),
            (3,2,12,'P6'),
            -- Si asa mai departe…
            (4,1,3,'P6'),
            (5,1,1000,'P2'),
            (6,1,300,'P4'),
            (7,1,150,'P1'),
            (8,1,150,'P1'),
            (9,1,650,'P5'),
            (9,2,150,'P1'),
            (10,1,220,'P2'),
            (10,2,400,'P3'),
            (10,3,700,'P4'),
            (11,1,100,'P6'),
            (12,1,1000,'P6'),
            (13,1,300,'P2'),
            (14,1,600,'P4'),
            (15,1,130,'P1'),
            (16,1,120,'P2'),
            (17,1,300,'P6'),
            (18,1,15,'P1'),
            (19,1,7,'P2');



CREATE synonym tFunctii FOR Pachete.tFunctii
CREATE synonym tAngajati FOR Pachete.tAngajati
CREATE synonym tClienti FOR Pachete.tClienti
CREATE synonym tProduse FOR Pachete.tProduse
CREATE synonym tComenzi FOR Pachete.tComenzi
CREATE synonym tDetaliiComanda FOR Pachete.tDetaliiComanda



GO
CREATE PROCEDURE adaugaAngajat
  @NumeAngajat VARCHAR(30),
  @CodFunctie INT
AS
BEGIN
  BEGIN TRY
    BEGIN TRANSACTION;

    -- Verificăm dacă funcția există în tabelul tFunctii
    IF NOT EXISTS (SELECT 1 FROM Pachete.tFunctii WHERE codFunctie = @CodFunctie)
    BEGIN
      THROW 50001, 'Funcția specificată nu există.', 1;
    END

    -- Adăugăm angajatul în tabelul tAngajati
    INSERT INTO Pachete.tAngajati (numeAngajat, codFunctie)
    VALUES (@NumeAngajat, @CodFunctie);

    COMMIT TRANSACTION;
  END TRY
  BEGIN CATCH
    ROLLBACK TRANSACTION;

    -- Aruncăm eroarea pentru debugging
    DECLARE @ErrorMessage NVARCHAR(4000);
    SET @ErrorMessage = ERROR_MESSAGE();
    THROW 50002, @ErrorMessage, 1;
  END CATCH
END