
if object_id('Scoala.tCursProf') is not null 
drop table Scoala.tCursProf

if object_id('Scoala.tProfesori') is not null 
drop table Scoala.tProfesori

if object_id('Scoala.tNote') is not null 
drop table Scoala.tNote

if object_id('Scoala.tCursuri') is not null 
drop table Scoala.tCursuri

if object_id('Scoala.tStudenti') is not null 
drop table Scoala.tStudenti

if object_id('Scoala.tSpecializari') is not null 
drop table Scoala.tSpecializari

if object_id('Scoala.tDepartamente') is not null 
drop table Scoala.tDepartamente

if object_id('Scoala.tFacultati') is not null 
drop table Scoala.tFacultati

if object_id('tSpecializari') is not null 
drop table tSpecializari

if object_id('tDepartamente') is not null 
drop table tDepartamente 
if object_id('tFacultati') is not null 
drop table tFacultati



go

drop schema Scoala

go

create schema Scoala

go 

create table Scoala.tStudenti
(cidStud char(10) constraint pk_stud primary key,
nume varchar(40) not null,
CNP varchar(13),
codJudet char(2), 
localitate varchar(20) not null,
codSpec char(10) constraint fk_spec foreign key references Scoala.tSpecializari (codSpec))

create table Scoala.tCursuri
(codCurs char(10) constraint pk_curs primary key,
denumire varchar(40) not null,
tipCurs char constraint ck_tip check (tipCurs in ('B','O','F')),
nrCred tinyint)

create table Scoala.tNote
(codCurs char(10) constraint fk_cursN foreign key references Scoala.tCursuri,
codStud char(10) constraint fk_studN foreign key references Scoala.tStudenti,
dataExamen smalldatetime constraint df_data default getDate(),
nota tinyint)

create table Scoala.tProfesori
(codProf char(10) constraint pk_prof primary key,
nume varchar(40) not null,
gradDidactic char,)


create table Scoala.tCursProf
(codCurs char(10),
codProf char(10),
activitatePredare tinyint,
constraint pk_CursProf primary key (codCurs, codProf))

alter table Scoala.tNote alter column codCurs char(10) not null
 alter table Scoala.tNote alter column codStud char(10) not null

alter table Scoala.tNote
add constraint pk_note primary key (CodCurs, codStud)

alter table Scoala.tCursProf
add constraint fk_cursP foreign key (codCurs) references Scoala.tCursuri(codCurs)

alter table Scoala.tCursProf
add constraint fk_profC foreign key (codProf) references Scoala.tProfesori (codProf)

alter table Scoala.tFacultati add adresa varchar(50)

alter table Scoala.tNote 
add constraint ck_nota check (nota between 1 and 10)

alter table Scoala.tStudenti 
add dataNasterii as convert (smalldatetime, substring(CNP, 2, 6), 12)

alter table Scoala. tStudenti
add constraint uq_cnp unique (cnp)