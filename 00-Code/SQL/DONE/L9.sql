--promovat FP dar au picat la BD 
select A.codstud, nume
from tStudenti as A inner join tNote as B
on A.codstud=B.codstud
where nota>=5 and codCurs='FP'
intersect
select A.codstud, nume
from tStudenti as A inner join tNote as B
on A.codstud=B.codstud
where nota<5 and codCurs='BD'


select A.codstud, nume
from tStudenti as A inner join tNote as B
on A.codstud=B.codstud
where nota>=5 and codCurs='FP'
except
select A.codstud, nume
from tStudenti as A inner join tNote as B
on A.codstud=B.codstud
where nota>=5 and codCurs='BD'



--sa se insereze randuri de sinteza
select codSpec, nume, codCurs, nota
from tStudenti as A inner join tNote as B
on A.codstud=B.codstud
union
select codSpec,'-',codCurs, avg(convert(decimal(4,2),nota)) as media
from tStudenti as A inner join tNote as B
on A.codstud=B.codstud
group by codSpec,codCurs
union
select codSpec,'-','-', avg(convert(decimal(4,2),nota)) as media
from tStudenti as A inner join tNote as B
on A.codstud=B.codstud
group by codSpec
union
select '-','-','-', avg(convert(decimal(4,2),nota)) as media
from tNote
order by codSpec, codCurs,nume



select codSpec, nume, codCurs, avg(convert(decimal(4,2),nota)) as media
from tStudenti as A inner join tNote as B
on A.codstud=B.codstud
group by codSpec,codCurs,nume
with rollup 



select iif(grouping(codSpec)=0,codSpec,'-') as codSpec,
 iif(grouping(nume)=0,nume,'-') as nume,
 iif(grouping(codCurs)=0,codCurs,'-') as codCurs,
  avg(convert(decimal(4,2),nota)) as media
from tStudenti as A inner join tNote as B
on A.codstud=B.codstud
group by codSpec,codCurs,nume
with rollup 



select iif(grouping(codSpec)=0,codSpec,'-') as codSpec,
 iif(grouping(nume)=0,nume,'-') as nume,
 iif(grouping(codCurs)=0,codCurs,'-') as codCurs,
  avg(convert(decimal(4,2),nota)) as media
from tStudenti as A inner join tNote as B
on A.codstud=B.codstud
group by codSpec,codCurs,nume
with cube



--sa afisam nume codcurs si nota
select nume, codCurs, nota
from tStudenti as A inner join tNote as B
on A.codstud=B.codstud
order by nume









--TABELE PIVOT

select nume,[BD],[FP],[GC],[LE]
from
(select nume, codCurs, nota
from tStudenti as A inner join tNote as B
on A.codstud=B.codstud) as A
pivot(max(nota) for codCurs in ([BD],[FP],[GC],[LE])) as pvt
order by nume



select nume,isnull(str([BD]),'-') as BD,
       isnull(str([FP]),'-') as FP, 
	   isnull(str([GC]),'-') as GC, 
	   isnull(str([LE]),'-') as LE 
from
(select nume, codCurs, nota
from tStudenti as A inner join tNote as B
on A.codstud=B.codstud) as A
pivot(max(nota) for codCurs in ([BD],[FP],[GC],[LE])) as pvt
order by nume




select codSpec,nume,isnull(str([BD]),'-') as BD,
       isnull(str([FP]),'-') as FP, 
	   isnull(str([GC]),'-') as GC, 
	   isnull(str([LE]),'-') as LE 
from
(select codSpec,nume, codCurs, nota
from tStudenti as A inner join tNote as B
on A.codstud=B.codstud) as A
pivot(max(nota) for codCurs in ([BD],[FP],[GC],[LE])) as pvt
order by codSpec, nume




--sa se afiseze nr de studenti,respectiv studente la nivel de codSpec
select codSpec, iif(substring(CNP,1,1) in ('1','5'),'M','F') as gen
from tStudenti




select codSpec,[M],[F]
from
(select codSpec, iif(substring(CNP,1,1) in ('1','5'),'M','F') as gen
from tStudenti) as A
pivot(count(gen) for gen in ([M],[F])) as pvt



--sa se afiseze luna nasterii
select convert(int,substring(CNP,4,2)) as luna
from tStudenti




select [1],[2],[3],[4],[5],[6],[7],[8],[9],[10],[11],[12]
from
(select convert(int,substring(CNP,4,2)) as luna
from tStudenti) as A
pivot(count(luna) for luna in ([1],[2],[3],[4],[5],[6],[7],[8],[9],[10],[11],[12])) as pvt