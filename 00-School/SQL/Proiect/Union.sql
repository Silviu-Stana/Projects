--sa se afiseze comenzile care contin Produsul P1 , dar nu si produsul P2
--Sa se excluda total comenzile care nu indeplinesc ambele conditii.
SELECT nrComanda, idRand, cantitate, B.denumire 
FROM tDetaliiComanda AS A 
INNER JOIN tProduse AS B ON A.codProdus=B.codProdus
WHERE A.nrComanda IN (
						SELECT nrComanda
						FROM tDetaliiComanda
						WHERE codProdus = 'P1'
						EXCEPT
						SELECT nrComanda
						FROM tDetaliiComanda
						WHERE codProdus = 'P2'
					 )



--Sa se insereze Randuri de Sinteza
select * from tDetaliiComanda

--total quantity per order
select nrComanda, sum(CAST(cantitate as int)) as [Cantitate], '-' as [Pret]
from tDetaliiComanda
group by nrComanda
UNION 
--total price per order
SELECT nrComanda, '-' as [Cantitate], SUM(CAST(B.pret AS int) * A.cantitate) as [Pret]
FROM tDetaliiComanda AS A
JOIN tProduse AS B ON A.codProdus = B.codProdus
GROUP BY nrComanda



--Sa se insereze Randuri de Sinteza pentru sumele cantitatilor si a preturilor totale a fiecarei comenzi.
SELECT *
FROM (
	--Cantitatea totala a comenzii
    SELECT nrComanda, SUM(cantitate) AS [Cantitate Totala], '-' AS [Pret]
    FROM tDetaliiComanda
    GROUP BY nrComanda

    UNION 
	--Pretul total al comenzii
    SELECT nrComanda, '-', SUM(CAST(B.pret AS int) * A.cantitate) AS [Pret]
    FROM tDetaliiComanda AS A
    JOIN tProduse AS B ON A.codProdus = B.codProdus
    GROUP BY nrComanda
) AS combined_results
--Trebuie sa il facem subquerry, ca sa il putem sorta crescator dupa "nrComanda"
ORDER BY CAST(nrComanda AS int);




--Sa se insereze Randuri de Sinteza pentru MEDIA la nivel de produse de pe fiecare comanda.
SELECT *
FROM (
	--Cantitatea medie a produselor de pe bon
    SELECT nrComanda, AVG(cantitate) AS [Cantitate Medie], '-' AS [Pret Mediu al Produselor]
    FROM tDetaliiComanda
    GROUP BY nrComanda

    UNION 
	--Pretul mediu al produselor de pe bon
    SELECT nrComanda, '-', AVG(CAST(B.pret AS int) * A.cantitate) AS [Pret]
    FROM tDetaliiComanda AS A
    JOIN tProduse AS B ON A.codProdus = B.codProdus
    GROUP BY nrComanda
) AS combined_results
ORDER BY CAST(nrComanda AS int);




--Sa se arate cantitatile totale ale fiecarei comenzi, impreuna cu cantitatea pe toate vanzarile dintotdeauna adunate
    SELECT CAST(nrComanda as int) as [Nr Comanda], SUM(cantitate) AS [Cantitate Totala], '-' AS [Pret]
    FROM tDetaliiComanda
    GROUP BY CAST(nrComanda as int)
	with rollup


	select * from tDetaliiComanda



--Sa se arate fiecare comanda, plus un rand in plus cu Cantitatea totala vanduta la finalul fiecarei comenzi.
SELECT 
    nrComanda, 
    IIF(GROUPING(A.cantitate) = 0, CONVERT(VARCHAR(50), A.cantitate), '-') AS cantitate,
    SUM(A.cantitate) AS [Total Cantitate]
FROM tDetaliiComanda AS A INNER JOIN tProduse AS B ON A.codProdus=B.codProdus
GROUP BY nrComanda, A.cantitate
WITH ROLLUP;






--TABELE PIVOT

--Sa se afiseze Cantitatea totala cumpara din fiecare produs de Clienti
SELECT *
FROM (
    SELECT C.numeClient, P.codProdus, A.cantitate
    FROM tDetaliiComanda AS A
	INNER JOIN tComenzi AS B on A.nrComanda=B.nrComanda
	INNER JOIN tClienti AS C ON B.codClient=C.codClient
    INNER JOIN tProduse AS P ON A.codProdus=P.codProdus
) AS TabelSursa
PIVOT(SUM(cantitate) FOR codProdus IN ([P1], [P2], [P3], [P4], [P5], [P6])) AS TabelPivot;






--Sa se afiseze ordonat frumos toate Cantitatile Produselor cumparate de clienti
SELECT numeClient,
		isnull(str([P1]),'') as [Pachete Mici], 
	    isnull(str([P2]),'') as [Pachete Medii], 
	    isnull(str([P3]),'') as [Pachete Mari],
		isnull(str([P4]),'') as [Benzi Adezive],
		isnull(str([P5]),'') as [Etichete],
		isnull(str([P6]),'') as [Folii]
FROM (
    SELECT C.numeClient, P.codProdus, A.cantitate
    FROM tDetaliiComanda AS A
	INNER JOIN tComenzi AS B on A.nrComanda=B.nrComanda
	INNER JOIN tClienti AS C ON B.codClient=C.codClient
    INNER JOIN tProduse AS P ON A.codProdus=P.codProdus
) AS TabelSursa
PIVOT(SUM(cantitate) FOR codProdus IN ([P1], [P2], [P3], [P4], [P5], [P6])) AS TabelPivot;





--Sa se afiseze nr de comenzi cu cantitati vandute >100 sau <100
SELECT * FROM (SELECT cantitate,
				   CASE WHEN cantitate > 100 THEN 'Cantitate > 100'
				   ELSE 'Cantitate < 100'
				   END AS generare
			   FROM tDetaliiComanda) AS A
PIVOT(count(cantitate) for generare in ([Cantitate > 100], [Cantitate < 100])) as TabelPivot






--sa se afiseze luna nasterii

select [P1],[P2],[P3],[P4],[P5],[P6]
from
(select convert(int,substring(codProdus,4,2)) as nrComenziproduse
from tDetaliiComanda
group by nrComanda, codProdus) as A
pivot(count(nrComenziproduse) for nrComenziproduse in ([P1],[P2],[P3],[P4],[P5],[P6])) as pvt


SELECT [P1], [P2], [P3], [P4], [P5], [P6]
FROM (
    SELECT 
        codProdus,
        CONVERT(INT, SUBSTRING(nrComanda, 4, 2)) AS nrComenziproduse
    FROM 
        tDetaliiComanda
    GROUP BY 
        nrComanda, codProdus
) AS A
PIVOT (COUNT(codProdus) FOR codProdus IN ([P1], [P2], [P3], [P4], [P5], [P6])) AS pvt;


--Sa se stearga clientii din Targoviste
delete from tClienti
where localitate='Targoviste'


--Sa se mareasca pretul produsului P4 cu 10%
update tProduse
set pret=pret+pret*0.1
where codProdus='P4'


update tProduse
set pret=case codProdus when 'P2' then 15
when 'P1' then 5
--daca nu exista, sa ramana la fel
else pret end



--Afiseaza media de cantitate vanduta, la nivel de produse, pentru fiecare comanda
--go: vederiile vor sa ruleze primele in script
go 
create view vMediiCantitateVanduta
as select nrComanda, AVG(cantitate) as [Media Nr de Produse]
from  tDetaliiComanda
group by nrComanda


select *from vMediiCantitateVanduta

--Afiseaza produsele cu Media vanzarilor > media produselor vandute
select avg([Media Nr de Produse]) from vMediiCantitateVanduta


--Afiseaza produsele cu Media < decat medie. 
select [Media Nr de Produse]
from vMediiCantitateVanduta
where [Media Nr de Produse]<(select AVG([Media Nr de Produse]) from vMediiCantitateVanduta)




select * from tClienti
select * from tProduse
select * from tDetaliiComanda
select * from tFunctii
select * from tComenzi
select * from tAngajati


CREATE INDEX idx_functie ON Pachete.tFunctii(functie);
CREATE INDEX idx_numeProd ON Pachete.tProduse(denumire);


SELECT * FROM tFunctii WHERE functie = 'Manager Depozit';
SELECT * FROM tProduse WHERE denumire = 'Pachet Mediu';


DROP INDEX idx_functie ON Pachete.tFunctii;
DROP INDEX idx_numeProd ON Pachete.tProduse;
