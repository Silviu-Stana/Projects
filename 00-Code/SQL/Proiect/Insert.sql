select * from Pachete.tFunctii
select * from Pachete.tAngajati
select * from Pachete.tClienti
select * from Pachete.tProduse
select * from Pachete.tComenzi
select * from Pachete.tDetaliiComanda


--Cream 7 functii
select * from Pachete.tFunctii
insert into Pachete.tFunctii(codFunctie, functie)
values('F1','Manager Depozit'),
('F2','Lucrator Depozit'),
('F3','Operator Echipament Ridicare'),
('F4','Coordonator Logistic'),
('F5','Inspector de Calitate'),
('F6','Specialist documentatia Vamala'),
('F7','Manager de Operatiuni')


--Adaugam 20 de angajati.
select * from Pachete.tAngajati
insert into Pachete.tAngajati(codAngajat, numeAngajat, codFunctie)
values('A1','Vasile','F2'),
('A2', 'Ana', 'F1'),
('A3', 'Ion', 'F3'),
('A4', 'Maria', 'F5'),
('A5', 'Andrei', 'F2'),
('A6', 'Elena', 'F6'),
('A7', 'Mihai', 'F4'),
('A8', 'Cristina', 'F7'),
('A9', 'Alexandru', 'F2'),
('A10', 'Raluca', 'F1'),
('A11', 'Gabriel', 'F3'),
('A12', 'Diana', 'F4'),
('A13', 'Victor', 'F5'),
('A14', 'Andreea', 'F2'),
('A15', 'Ciprian', 'F7'),
('A16', 'Adriana', 'F1'),
('A17', 'Bogdan', 'F3'),
('A18', 'Simona', 'F6'),
('A19', 'Razvan', 'F4'),
('A20', 'Laura', 'F2')


--Introducem 24 de clienti.
select * from Pachete.tClienti
insert into Pachete.tClienti(codClient, numeClient, localitate)
values
('C1', 'Maria Popescu', 'Pitesti'),
('C2', 'Ion Ionescu', 'Bucuresti'),
('C3', 'Elena Dumitrescu', 'Cluj'),
('C4', 'Andrei Radu', 'Ploiesti'),
('C5', 'Ana Stoica', 'Mioveni'),
('C6', 'Mihai Gheorghe', 'Pitesti'),
('C7', 'Cristina Marinescu', 'Bucuresti'),
('C8', 'Alexandru Popa', 'Cluj'),
('C9', 'Raluca Andrei', 'Ploiesti'),
('C10', 'Gabriel Cojocaru', 'Mioveni'),
('C11', 'Andreea Vasilescu', 'Pitesti'),
('C12', 'Adrian Georgescu', 'Bucuresti'),
('C13', 'Mihaela Neagu', 'Cluj'),
('C14', 'Daniel Stan', 'Ploiesti'),
('C15', 'Laura Dragomir', 'Mioveni'),
('C16', 'Bogdan Pop', 'Pitesti'),
('C17', 'Alina Iancu', 'Bucuresti'),
('C18', 'George Popovici', 'Cluj'),
('C19', 'Ioana Munteanu', 'Ploiesti'),
('C20', 'Robert', 'Mioveni'),
('C21', 'Diana Ilie', 'Pitesti'),
('C22', 'Florin Marin', 'Bucuresti'),
('C23', 'Ioan Vasilache', 'Cluj'),
('C24', 'Irina Moraru', 'Ploiesti')


--Introducem 6 produse.
select * from Pachete.tProduse
insert into Pachete.tProduse(codProdus, denumire, unitateMasura, pret)
values('P1','Pachet Mic','10g','5'),
('P2','Pachet Mediu','30g','15'),
('P3','Pachet Mare','70g','30'),
('P4','Banda Adeziva','150g','40'),
('P5','Etichete','','60'),
('P6','Folii Protectoare','','20')


--Cantitate este o coloana Inecesara in tabelul tComenzi
--deoarece apare deja odata, si se potriveste mai bine in tabelul tDetalii comanda.
select * from Pachete.tComenzi
ALTER TABLE Pachete.tComenzi
DROP COLUMN cantitate


--În tabelul tDetaliiComanda, codClient apare din nou, ceea ce poate crea confuzie.
--Dacă tDetaliiComanda reprezintă detaliile specifice ale fiecărei comenzi
--Am decis sa elimin coloana "codClient" și ar putea fi accesat prin intermediul tabelului tComenzi.
select * from Pachete.tDetaliiComanda

--Eliminam ambele  Foreign Keys
ALTER TABLE Pachete.tDetaliiComanda
DROP CONSTRAINT fk_tDetaliiComanda_Client;
ALTER TABLE Pachete.tComenzi
DROP CONSTRAINT fk_tComenzi_client;

--Se adauga din nou in tComenzi cu un Nume mai simplu.
select * from Pachete.tComenzi
ALTER TABLE Pachete.tComenzi
ADD CONSTRAINT fk_client FOREIGN KEY(codClient) REFERENCES Pachete.tClienti(codClient)

ALTER TABLE Pachete.tDetaliiComanda
DROP COLUMN codClient


--Adaugam 19 comenzi.
--Unele comenzi nu au inca o data de livrare! Altele vor fii livrare in cateva zile.
select * from Pachete.tComenzi
INSERT INTO Pachete.tComenzi(nrComanda, codClient, dataComanda, dataLivrare)
VALUES(1,'C1', GETDATE(), GETDATE()),
(2,'C1', GETDATE(), GETDATE()),
(3,'C3', GETDATE(), GETDATE()+3),
(4,'C6', GETDATE(), NULL),
(5,'C4', GETDATE(), GETDATE()+4),
(6,'C2', GETDATE(), NULL),
(7,'C1', GETDATE(), GETDATE()+1),
(8,'C1', GETDATE(), NULL),
(9,'C5', GETDATE(), GETDATE()),
(10,'C9', GETDATE(), GETDATE()+2),
(11,'C12', GETDATE(), GETDATE()),
(12,'C5', GETDATE(), GETDATE()+5),
(13,'C3', GETDATE(), GETDATE()+5),
(14,'C5', GETDATE(), NULL),
(15,'C5', GETDATE(), GETDATE()+2),
(16,'C5', GETDATE(), GETDATE()+2),
(17,'C9', GETDATE(), NULL),
(18,'C1', GETDATE(), GETDATE()),
(19,'C13', GETDATE(), NULL)





--Introducem in sistem detalile celor 19 comenzi.
select * from Pachete.tDetaliiComanda
INSERT INTO Pachete.tDetaliiComanda(nrComanda, idRand, cantitate, codProdus)
VALUES
-- Comanda 1
(1,1,3,'P1'),
(1,2,15,'P1'),
(1,3,7,'P2'),
-- Comanda 2
(2, 1, 5, 'P2'),
(2, 2, 10, 'P3'),
(2, 3, 2, 'P5'),
-- Comanda 3
(3, 1, 5, 'P4'),
(3, 2, 12, 'P6'),
(4, 1, 3, 'P6'),
(5, 1, 1000, 'P2'),
(6, 1, 300, 'P4'),
(7, 1, 150, 'P1'),
(8, 1, 150, 'P1'),
(9, 1, 650, 'P5'),
(9, 2, 150, 'P1'),
(10, 1, 220, 'P2'),
(10, 2, 400, 'P3'),
(10, 3, 700, 'P4'),
(11, 1, 100, 'P6'),
(12, 1, 1000, 'P6'),
(13, 1, 300, 'P2'),
(14, 1, 600, 'P4'),
(15, 1, 130, 'P1'),
(16, 1, 120, 'P2'),
(17, 1, 300, 'P6'),
(18, 1, 15, 'P1'),
(19, 1, 7, 'P2')