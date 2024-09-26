--Sa se insereze in tabelul tRestantieri studentii cu nota 5
insert into tRestantieri
select codSpec, A.codStud, nume, C.codCurs, denumire, nota
from tStudenti as A left join tNote as B on A.codStud=B.codStud
left join tCursuri as C on B.codCurs=C.codCurs
where nota = 5


--Sa se stearga studentii care au luat nota 5 din tRestantieri
delete from tRestantieri
where nota=5

--Sa se stearga toate randurile din tRestantieri
delete from tRestantieri

--varianta2:
truncate table tRestantieri

--Sa se mareasca nota studentului S2 la 'FP' +1
update tNote
set nota=nota+1
where codStud='S2' and codCurs='FP'


--Sa se modifice notele studentului S4 astfel incat la Engleza sa aiba nota 9 si la FP nota 7
update tNote
set nota=case codCurs when 'BD' then 9
when 'FP' then 7
--daca nu exista, sa ramana la fel
else nota end
where codStud='S2'

--Sa se creeze tabelul tNoteProiect cu coloanele
--codStud, codCurs, nota
create table tNoteProiect(
codStud char (10) not null constraint fk_studP foreign key references scoala.tStudenti(codStud),
codCurs char(10) not null constraint fk_cursP foreign key references scoala.tCursuri(codCurs),
nota int,
constraint pk_noteP primary key(codStud,codCurs))

alter table tNoteProiect
add constraint pk_noteP primary key(codStud,codCurs)

drop table tNoteProiect

update tNote
set NotaProiect=NULL

--Sa se preia "NotaProiect" a tabelului tNoteProiect -> tNote
update tNote
set NotaProiect=A.nota
from tNoteProiect as A inner join tNote as B
on A.codCurs=B.codCurs and A.codStud=B.codStud

--UTILIZAREA VEDERILOR
--Sa se determine mediile studentilor
select C.codSpec, denumire, B.codStud, nume, avg(convert(decimal(4,2),nota)) as Media
from tNote as A inner join tStudenti as B
on A.codStud=B.codStud
inner join tSpecializari as C
on B.codSpec=C.codSpec
group by C.codSpec, denumire, B.codStud, nume


--go: vederiile vor sa ruleze primele in script
go 
create view vMediiStud
as select C.codSpec, denumire, B.codStud, nume, avg(convert(decimal(4,2),nota)) as Media
from tNote as A inner join tStudenti as B
on A.codStud=B.codStud
inner join tSpecializari as C
on B.codSpec=C.codSpec
group by C.codSpec, denumire, B.codStud, nume


select *from vMediiStud

--Afiseaza studentii cu Media > media mediilor studentilor
select avg(Media) from vMediiStud

--Afiseaza studentii cu Media > 
select codSpec, denumire, codStud, media
from vMediiStud
where media<(select avg(media) from vMediiStud)

--DONT FORGET: la final sa faci screenshot la (Database Tabels Visual View)
