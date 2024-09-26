--CREATE database dbFirma
use dbFirma
--go
--CREATE schema Pachete



--Sa se creeze tabelul
--tClienti(codClient, numeClient, localitate)
CREATE TABLE Pachete.tClienti
(codClient char(10) constraint pk_client primary key,
numeClient varchar(30) not null,
localitate varchar(20)
)



--Sa se creeze tabelul
--tComenzi(nrComanda, #codClient, dataComanda, dataLivrare, cantitate)
CREATE TABLE Pachete.tComenzi
(nrComanda char(10), 
codClient char(10),
dataComanda smalldatetime,
dataLivrare smalldatetime,
cantitate smallint
)

ALTER TABLE Pachete.tComenzi
ADD CONSTRAINT df_data DEFAULT getDate() for dataComanda

--Sa se corecteze conditia "not NULL" unde este necesar.
ALTER TABLE Pachete.tComenzi ALTER column nrComanda char(10) not null
ALTER TABLE Pachete.tComenzi ALTER column codClient char(10) not null
ALTER TABLE Pachete.tComenzi ALTER column dataComanda smalldatetime not null
--In schimb, Data de livrare poate fii NULL, daca coletul nu a fost inca livrat.

--Not Null - este nevoie pentru primary key.
ALTER TABLE Pachete.tComenzi
ADD CONSTRAINT pk_comanda PRIMARY KEY(nrComanda) 

ALTER TABLE Pachete.tComenzi
ADD CONSTRAINT fk_tComenzi_client FOREIGN KEY(codClient) references Pachete.tClienti(codClient)




--Sa se creeze tabelul
--tProduse(codProdus, denumire, unitateMasura, pret)
CREATE TABLE Pachete.tProduse
(codProdus CHAR(10) not null,
denumire VARCHAR(30) not null,
unitateMasura VARCHAR(10) not null,
pret SMALLINT)

ALTER TABLE Pachete.tProduse
ADD CONSTRAINT pk_produs PRIMARY KEY(codProdus)




--Sa se creeze tabelul
--tDetaliiComanda(#nrComanda, idRand, #codProdus, #codClient, cantitate)
CREATE TABLE Pachete.tDetaliiComanda
(nrComanda CHAR(10) CONSTRAINT fk_comanda FOREIGN KEY REFERENCES Pachete.tComenzi(nrComanda) not null,
idRand INT not null,
codClient CHAR(10),
cantitate SMALLINT,
)

ALTER TABLE Pachete.tDetaliiComanda
ADD codProdus CHAR(10) not null CONSTRAINT fk_prod FOREIGN KEY REFERENCES Pachete.tProduse(codProdus)

ALTER TABLE Pachete.tDetaliiComanda
add CONSTRAINT fk_tDetaliiComanda_Client FOREIGN KEY(codClient) REFERENCES Pachete.tClienti(codClient)

ALTER TABLE  Pachete.tDetaliiComanda
ADD CONSTRAINT pk_detaliiComanda PRIMARY KEY(nrComanda,idRand)




--Sa se creeze tabelul
--tFunctii(codFunctie, functie)
CREATE TABLE Pachete.tFunctii
(codFunctie char(10) CONSTRAINT pk_functie PRIMARY KEY,
functie varchar(30)
)




--Sa se creeze tabelul
--tAngajati(codAngajat, numeAngajat, functie)
CREATE TABLE Pachete.tAngajati
(codAngajat char(10) CONSTRAINT pk_angajat PRIMARY KEY,
numeAngajat varchar(30),
codFunctie char(10)
)

ALTER TABLE Pachete.tAngajati
ADD CONSTRAINT fk_func FOREIGN KEY(codFunctie) REFERENCES Pachete.tFunctii(codFunctie)