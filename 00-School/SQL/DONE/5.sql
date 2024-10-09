--Sa se adauge coloana adresa tabelului tFacultati
alter table scoala.tFacultati
add adresa varchar(30)

--Sa se impuna constrangere notNull coloanei adresa
alter table scoala.tFacultati
alter column adresa varchar(30) not null

--Cream tabelul tProfesori
create table scoala.tProfesori
(codProf char(10),
nume varchar(30),
gradDidactic varchar(20),
codDep char(10))

--Adaugam constrangere cheie primara
alter table scoala.tProfesori
add constraint pk_prof primary key(codProf)

alter table scoala.tProfesori
alter column codProf char(10) not null

alter table scoala.tProfesori
add constraint fk_depProf foreign key(codDep)
references scoala.tDepartamente(codDep)

--Sa se modifice tipul coloanei gradDidactic din varchar(30) in char
alter table scoala.tProfesori
alter column gradDidactic char
--Sa se adauge constrangerea de tip validare coloanei gradDidactic considerand
--A asistent L lector C conferential P profesor

--Folosind procedura sp_rename, modifica denumirea coloanei gradDidactic in grad
alter table scoala.tProfesori
drop constraint ck_grad
execute sp_rename 'scoala.tProfesori.gradDidactic','grad','column'

alter table scoala.tProfesori
add constraint ck_grad check(grad in ('A','L','C','P'))