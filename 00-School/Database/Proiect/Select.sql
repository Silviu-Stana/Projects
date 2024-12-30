
select * from Pachete.tFunctii
select * from Pachete.tAngajati
select * from Pachete.tClienti
select * from Pachete.tProduse
select * from Pachete.tComenzi
select * from Pachete.tDetaliiComanda


--Determina nr clienti
select count(codClient) as [Numar Clienti]
from tClienti


--Afiseaza lista angajati (si functia lor din tabelul extern tFunctii)
select numeAngajat, B.functie
from tAngajati as A JOIN tFunctii as B
on A.codFunctie=B.codFunctie


--Afiseaza doar angajatii cu functia "Lucratorii de Depozit"
select numeAngajat, B.functie
from tAngajati as A JOIN tFunctii as B
on A.codFunctie=B.codFunctie
where B.codFunctie='F2'


--Afiseaza doar clientii care NU sunt din "Pitesti"
select numeClient, localitate
from tClienti
where localitate!='Pitesti'
order by localitate


select * from tComenzi
--Afiseaza nr de comenzi totale facute de fiecare client
select codClient as [Cod Client], COUNT(codClient) as [Numar Comenzi]
from tComenzi
group by codClient
order by COUNT(codClient)



--Afiseaza nr de comenzi totale, DAR SI numele fiecarui client (in loc de codClient)
select B.numeClient as [Nume Client], COUNT(A.codClient) as [Numar Comenzi]
from tComenzi as A INNER JOIN tClienti AS B
on A.codClient=B.codClient
group by B.numeClient
order by COUNT(A.codClient)



--Afiseaza doar primele 2 rezultate
select top 2 B.numeClient as [Nume Client], COUNT(A.codClient) as [Numar Comenzi]
from tComenzi as A INNER JOIN tClienti AS B
on A.codClient=B.codClient
group by B.numeClient
order by COUNT(A.codClient)



--Afiseaza lista de clienti cu prima litera din nume 'A' sau 'D' (ordonate alfabetic)
select numeClient
from tClienti
where numeClient like '[A,D]%'
order by numeClient



--Sa se afiseze toate comenzile fara o "Data de Livrare" stabilita



--Sa se calculeze Numarul de clienti cu Nume care care incep cu litera "A"
select 'A' as [Nume cu Litera], COUNT(numeClient) as [Numar Clienti]
from tClienti
where numeClient like 'A%'


--Sa se calculeze Numarul de clienti cu fiecare Litera din Alfabet
SELECT LEFT(numeClient, 1) as [Nume cu Litera], COUNT(numeClient) as [Numar Clienti]
FROM tClienti
GROUP BY LEFT(numeClient, 1)
ORDER BY [Nume cu Litera];



--Sa se calculeze Numarul de clienti care provin din Fiecare Oras
select localitate as [Provin din], COUNT(localitate) as [Nr Clienti]
from tClienti
group by localitate


--Sa se afiseze toate comenzile care inca NU au o data stabilita de livrare
select B.numeClient, A.dataComanda, A.dataLivrare
from tComenzi as A left join tClienti as B on A.codClient=B.codClient
where A.dataLivrare IS NULL
order by B.numeClient


--Sa se selecteze doar Numarul de clienti care provin din Orase care incep cu litera 'P'
select localitate as [Provin din], COUNT(localitate) as [Nr Clienti]
from tClienti
where localitate like 'P%'
group by localitate



--(in loc sa afisam codProdus si codClient)
--Sa se afiseze detaliile fiecarei comenzi IMPREUNA cu Numele clientului si al Produselor comandate!
select C.numeClient, A.nrComanda, A.idRand, A.cantitate, D.denumire
from tDetaliiComanda as A join tComenzi as B on A.nrComanda=B.nrComanda
join tClienti as C on B.codClient=C.codClient
join tProduse as D on A.codProdus=D.codProdus




--Sa se afiseze istoricul produselor cumparate de "Maria Popescu"
select C.numeClient, B.dataComanda, D.denumire, A.cantitate, D.pret
from tDetaliiComanda as A inner join tComenzi as B on A.nrComanda=B.nrComanda
inner join tClienti as C on B.codClient=C.codClient
inner join tProduse as D on A.codProdus=D.codProdus
where C.numeClient='Maria Popescu'




--Sa se afiseze Pretul Total pentru fiecare tip de produs cumparat.
--Folosim CAST ca sa prevenim eroarea overflow la conversie in tip smallint
select C.numeClient, B.dataComanda, D.denumire, A.cantitate, CAST(A.cantitate as float) * D.pret as [Pret Total]
from tDetaliiComanda as A inner join tComenzi as B on A.nrComanda=B.nrComanda
inner join tClienti as C on B.codClient=C.codClient
inner join tProduse as D on A.codProdus=D.codProdus




--Sa se calculeze Suma intreaga a fiecarei Comenzi!
select D.numeClient, A.nrComanda, SUM(CAST(A.cantitate as float) * B.pret) as [Pret Total Comanda]
from tDetaliiComanda as A inner join tProduse as B on A.codProdus=B.codProdus
inner join tComenzi as C on A.nrComanda=C.nrComanda
inner join tClienti as D on C.codClient=D.codClient
group by D.numeClient, A.nrComanda
order by [Pret Total Comanda]




--Sa se afiseze numarul de comenzi facute pana in prezent de fiecare Client
select B.numeClient as [Nume Client], COUNT(B.codClient) as [Numar de Comenzi]
from tComenzi as A join tClienti as B on A.codClient=B.codClient
group by B.numeClient


--Sa se afiseze Clasamentul: Top 3 Clientii cu numarul Maxim de comenzi!
select TOP 3 B.numeClient as [Nume Client], COUNT(B.codClient) as [Numar de Comenzi]
from tComenzi as A join tClienti as B on A.codClient=B.codClient
group by B.numeClient
order by [Numar de Comenzi] desc


--Sa se afiseze numarul de comenzi facute in fiecare Oras
select B.localitate, COUNT(B.localitate) as [Numar de Comenzi]
from tComenzi as A join tClienti as B on A.codClient=B.codClient
group by B.localitate



--Sa se afiseze numarul de comenzi facute la data de 05/04/2024
SELECT nrComanda, dataComanda
FROM tComenzi
WHERE CONVERT(VARCHAR, dataComanda, 120) LIKE '2024-05-04%'





--Sa se afiseze comanda cu cea mai mare cantitate (vanduta dintr-un singur tip de produs)
select max(cantitate)
from tDetaliiComanda


--Sa se afiseze comenzile(plural) cu cea mai mare cantitate
select nrComanda, B.denumire, cantitate
from tDetaliiComanda as A join tProduse as B on A.codProdus=B.codProdus
where cantitate=(select MAX(cantitate) from tDetaliiComanda)



--Sa se afiseze produsul comandat in cantitatea cea mai mare. (pentru fiecare comanda separat)
--Subinterogare Corelata:
				--este executata de 1 ori, pentru fiecare comanda
SELECT A.nrComanda AS [ID Comanda], C.denumire AS [Produs], MAX(A.cantitate) AS [Cantitate]
FROM tDetaliiComanda AS A JOIN tComenzi AS B ON A.nrComanda = B.nrComanda
JOIN tProduse AS C ON A.codProdus = C.codProdus
WHERE A.cantitate = (SELECT MAX(cantitate) 
                     FROM tDetaliiComanda 
                     WHERE nrComanda = A.nrComanda)
GROUP BY A.nrComanda, C.denumire
ORDER BY CAST(A.nrComanda AS INT);
--Convertim in INT ca sa putem face sortarea crescatoare corect



--Aceste produse aveau un empty string '' deci le setam la NULL
update tProduse
set unitateMasura=NULL
where codProdus='P5' or codProdus='P6'


--Sa se afiseze comanda cu maximul de 'Benzi Adezive' vandute.
select nrComanda, B.denumire, cantitate
from tDetaliiComanda as A join tProduse as B on A.codProdus=B.codProdus
where A.codProdus='P4' and cantitate=(select MAX(cantitate) from tDetaliiComanda
															where codProdus='P4')



--Arata comenzile facute din Pitesti fara data de livrare stabilita
select B.nrComanda, C.localitate, B.dataLivrare
from tDetaliiComanda as A join tComenzi as B on A.nrComanda=B.nrComanda
join (select * from tClienti
		where localitate='Pitesti') as C
on B.codClient=C.codClient
where B.dataLivrare is NULL



--Afiseaza media de cantitate vanduta, la nivel de produse, pentru fiecare comanda
select nrComanda, AVG(cantitate) as [Media Nr de Produse]
from  tDetaliiComanda
group by nrComanda


--Afiseaza cantitatea totala a fiecarei comenzi (a tuturor produselor dintr-o comanda)
select nrComanda, SUM(cantitate) as [Cantitate Totala]
from tDetaliiComanda
group by nrComanda



--Afiseaza Media Cantitatilor Totale (a tuturor comenzilor)
select avg([Cantitate Totala]) as [Media]
from (select nrComanda, SUM(cantitate) as [Cantitate Totala]
from tDetaliiComanda
group by nrComanda) as [Cantitate Totala]



--Afiseaza Comenzile cu cantitea vanduta > cantitatea medie a tuturor comenzilor
SELECT nrComanda, SUM(cantitate) AS [Cantitate Totala]
FROM tDetaliiComanda
GROUP BY nrComanda
HAVING SUM(cantitate) > (
						SELECT AVG([Cantitate Totala]) 
						FROM (
							SELECT SUM(cantitate) AS [Cantitate Totala]
							FROM tDetaliiComanda
							GROUP BY nrComanda
						) AS [Media]
						)




--Afiseaza comenzile cu cel putin 1 cantitate > 100
--Subinterogare Corelata
select nrComanda, cantitate
from tDetaliiComanda as A
where exists(select * from tDetaliiComanda
			where nrComanda=A.nrComanda and cantitate>100)


--create synonym tFunctii for Pachete.tFunctii
--create synonym tAngajati for Pachete.tAngajati
--create synonym tClienti for Pachete.tClienti
--create synonym tProduse for Pachete.tProduse
--create synonym tComenzi for Pachete.tComenzi
--create synonym tDetaliiComanda for Pachete.tDetaliiComanda