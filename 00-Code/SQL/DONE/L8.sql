--Afis studenti cu nota Max
select A.codStud, nume, nota
from tStudenti as A inner join tNote as B
on A.codStud = B.codStud
where nota=(select max(nota) from tNote)

--Afis studentii cu Max nota la 'FP'
select codCurs, A.codStud, nume, nota
from tStudenti as A inner join tNote as B
on A.codStud=B.codStud
where codCurs='FP' and nota=(select max(nota) from tNote
							where codCurs='FP')

--Arata comenzile facute din Bucuresti fara data de livrare stabilita
select A.codStud, nume, codCurs, nota
from tStudenti as A left join (select * from tNote
								where codCurs='FP') as B
on A.codStud=B.codStud
where nota is null

--Solutia 2
select codStud, nume
from tStudenti
where codStud not in (select codStud from tNote
						where codCurs='FP')


--Afis media note la nivel student
select A.codStud, nume, avg(convert(decimal(4,2),nota)) as [Media notelor]
from tStudenti as A inner join tNote as B
on A.codStud=B.codStud
group by A.codStud, nume

--Afis studentii cu media mai mare decat media tuturor notelor
select A.codStud, nume, avg(convert(decimal(4,2),nota)) as [Media notelor]
from tStudenti as A inner join tNote as B
on A.codStud=B.codStud
group by A.codStud, nume
having avg(convert(decimal(4,2),nota)) > (select avg(convert(decimal(4,2),nota))
										from tNote)

--Afis student cu cea mai mare medie
--1. Calc medii studenti
select codStud, avg(convert(decimal,nota)) as [Media]
from tNote
group by codStud

--2. Determina media Max
--A. Media maxima (fara nume)
select max(Media)
from (select codStud, avg(convert(decimal,nota)) as [Media]
from tNote
group by codStud) as A

--B. Toate mediile
select A.codStud, nume, media
from tStudenti as A inner join (select codStud, avg(convert(decimal,nota)) as [Media]
from tNote
group by codStud) as B
on A.codStud=B.codStud

--C. combinare
select A.codStud, nume, media
from tStudenti as A inner join (select codStud, avg(convert(decimal,nota)) as [Media]
from tNote
group by codStud) as B
on A.codStud=B.codStud
where Media=(select max(Media)
from (select codStud, avg(convert(decimal,nota)) as [Media]
from tNote
group by codStud) as C)


--Determina studenti cu Media > Media tuturor notelor
select A.codStud, nume, media, (select avg(convert(decimal,nota)) from tNote) as [NOTA MEDIE]
from tStudenti as A inner join (select codStud, avg(convert(decimal,nota)) as [Media]
from tNote
group by codStud) as B
on A.codStud=B.codStud
where Media>(select avg(convert(decimal,nota)) from tNote)


--Afis lista studenti cu NotaFinala > Media notelor la curs
select A.codStud, nume, codCurs, nota, (select avg(convert(numeric,nota)) from tNote 
										where codCurs=B.codCurs) as [Nota medie la acest Curs]
from tStudenti as A inner join tNote as B
on A.codStud=B.codStud
where nota > (select avg(convert(numeric,nota)) from tNote
				where codCurs=B.codCurs)
order by nume


--Afis studenti cu cel putin 1 notaFinala > 8
select codStud, nume
from tStudenti as A
where exists(select * from tNote
			where codStud=A.codStud and nota>8)