--Sa se selecteze Nr clienti si produse in variabile
declare @nrProduse int, @nrClienti int

select @nrClienti=count(distinct codClient)    
from tClienti

select @nrProduse=count(codProdus)    
from tProduse

print 'Nr Clienti=' + str(@nrClienti)
print 'Nr Produse='+ str(@nrProduse)


declare @codClient char(10)

set @codClient=
 ( select top 1 C.codClient 
   from tComenzi as A join tDetaliiComanda as B on A.nrComanda=B.nrComanda
   join tClienti as C on A.codClient=C.codClient
   group by C.codClient 
   order by count(A.nrComanda) desc
  )
  
print 'Clientul cu cele mai multe comenzi='+@codClient




--Calculul nr comenzi facute de dintr-un oras specificata printr-un parametru 
go
CREATE FUNCTION Pachete.pretMaxim (@Localitate varchar(30) ='%')
RETURNS int
AS BEGIN

declare @Max int

set @Max=(select COUNT(B.localitate) as [Numar de Comenzi]
from tComenzi as A join tClienti as B on A.codClient=B.codClient
where B.localitate like @Localitate
group by B.localitate)
RETURN @Max;
end

--Apel
print 'Nr Comenzi din :'
print Pachete.pretMaxim('Pitesti')


--Cursor pentru Informații Client:
DECLARE client_cursor CURSOR SCROLL DYNAMIC FOR
SELECT codClient, numeClient, localitate
FROM tClienti;


--Cursor pentru Informații Comandă:
DECLARE order_cursor CURSOR SCROLL DYNAMIC FOR
SELECT nrComanda, codClient, dataComanda, dataLivrare
FROM tComenzi;

--Cursor pentru Informații Produs:
DECLARE product_cursor CURSOR SCROLL DYNAMIC FOR
SELECT codProdus, denumire, unitateMasura, pret
FROM tProduse;




--TRANSACTIONS

--BEGIN TRANSACTION name
--COMMIT TRANSACTION name
--ROLLBACK TRANSACTION name

BEGIN TRANSACTION
-- Instrucțiuni pentru actualizarea tabelelor
UPDATE tComenzi SET    dataComanda = '2024-05-04' WHERE  nrComanda = 10;
UPDATE tDetaliiComanda SET    cantitate = 20 WHERE  nrComanda = 10;
SELECT * FROM   tComenzi WHERE  nrComanda = 10;

SELECT * FROM   tDetaliiComanda WHERE  nrComanda = 10;
COMMIT



--Insereaza si modifica randuri simplu.
select * from Pachete.tFunctii
Begin transaction

insert into tFunctii(codFunctie, functie)
values('F8','Coordonator de Echipa')

update tFunctii
 set functie='Specialist Vamal'
 where codFunctie='F6'

Commit transaction
select * from Pachete.tFunctii




--Introducere sir de caracter in int, da Eroare intentionat, si Rollback
BEGIN TRY
 BEGIN TRANSACTION

  insert into tDetaliiComanda(nrComanda,idRand,cantitate,codProdus)
  values('20',1,'20','P6')

  select * from  tDetaliiComanda

  update tDetaliiComanda set cantitate='II' where nrComanda='20'

  select * from  tDetaliiComanda

 COMMIT TRANSACTION
 print 'Tranzactie incheiata cu succes'
END TRY

BEGIN CATCH
 ROLLBACK TRANSACTION
 print 'Tranzactie incheiata cu esec'
END CATCH



--Tranzactie: care sa previna plasarea unei comenzi cu cantitatea prea mare de produse
GO
CREATE PROCEDURE ps_CantitatePreaMare
    @nrComanda CHAR(10),
    @idRand INT,
    @cantitate SMALLINT,
    @codProdus VARCHAR(10)
AS
BEGIN
    BEGIN TRANSACTION t1;
    BEGIN TRY
        UPDATE tDetaliiComanda SET cantitate = cantitate - @cantitate WHERE codProdus = @codProdus;

        IF (SELECT cantitate FROM tDetaliiComanda WHERE nrComanda = @nrComanda) > 100
        BEGIN
            THROW 50001, 'Cantitatea comenzii este prea mare.', 1
        END

        COMMIT TRANSACTION t1
    END TRY
    BEGIN CATCH
        PRINT ERROR_MESSAGE()
        ROLLBACK TRANSACTION t1
    END CATCH
END



--TRIGGERE


-- Modifica dataLivrare sa fie la 7 days dupa plasarea comenzii:
GO
CREATE TRIGGER tg_dataLivrare
ON tComenzi
AFTER INSERT
AS
BEGIN

    UPDATE t
    SET t.dataLivrare = DATEADD(DAY, 7, i.dataComanda)
    FROM tComenzi t
    INNER JOIN inserted i ON t.nrComanda = i.nrComanda;
END




-- TRIGGER: eroare daca pretul unui produs introdus este Negativ
GO
CREATE TRIGGER trg_prevent_negative_price
ON tProduse
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (
        SELECT 1
        FROM inserted
        WHERE pret < 0
    )
    BEGIN
        RAISERROR ('Price cannot be negative', 16, 1);
        ROLLBACK TRANSACTION;
    END
END;




select * from Pachete.tFunctii
select * from Pachete.tAngajati
select * from Pachete.tClienti
select * from Pachete.tProduse
select * from Pachete.tComenzi
select * from Pachete.tDetaliiComanda



--FUNCTII

--O functie care calculează valoarea totală a unei comenzi, luând în considerare cantitatea și prețul fiecărui produs din comandă.
GO
ALTER FUNCTION Pachete.CalculValoareComanda(@nrComanda INT)
RETURNS DECIMAL(10, 2)
AS
BEGIN
    DECLARE @valoare DECIMAL(10, 2);
    
    SELECT @valoare = SUM(pret * cantitate)
    FROM tProduse p
    INNER JOIN tDetaliiComanda dc ON p.codProdus = dc.codProdus
    WHERE dc.nrComanda = @nrComanda;

    RETURN @valoare;
END


--Apel
SELECT Pachete.CalculValoareComanda(3) AS 'ValoareTotalaComanda';



--Afiseaza toate comenzile efectuate de un anumit client într-un anumit interval de timp.
GO
CREATE PROCEDURE AfiseazaComenziClientInInterval
    @codClient INT,
    @dataInceput DATE,
    @dataSfarsit DATE
AS
BEGIN
    SELECT c.nrComanda, c.dataComanda, c.dataLivrare, dc.cantitate, p.denumire, p.unitateMasura, p.pret
    FROM tComenzi c
    INNER JOIN tDetaliiComanda dc ON c.nrComanda = dc.nrComanda
    INNER JOIN tProduse p ON dc.codProdus = p.codProdus
    WHERE c.codClient = @codClient
    AND c.dataComanda BETWEEN @dataInceput AND @dataSfarsit;
END

--Apel
EXECUTE AfiseazaComenziClientInInterval @codClient = 1,
    @dataInceput = '2023-01-01',
    @dataSfarsit = '2024-05-11';

--PROCEDURI STOCATE