create table salarii(
	marca int primary key references angajati2(marca),
	salariu_baza int,
	data_angajarii date,
	vechime_anterioara int
);

create table pontaj(
	id_pontaj int primary key,
	marca int references angajati2(marca),
	luna int,
	anul int,
	ore_lucrate int default 0,
	ore_supl int default 0,
	co int default 0, --concediu de odihna 
	cb int default 0  --concediu boala obisnuita
);


insert into salarii values(1, 3200, '08-08-2000',2);
insert into salarii values(2, 2800, '10-01-1999',5);
insert into salarii values(3, 3500, '08-08-2014',2);
insert into salarii values(4, 2500, '10-01-2015',5);

--vizualizare tabela salarii
select * from salarii;


--Add column
alter table salarii 
	add prima int;

--Delete column
alter table salarii
  drop column prima; 

alter table salarii 
	add prima int check(prima<=100);

--Modify column data type
alter table salarii
	modify (prima number(7,2) );

-- Add CHECK
ALTER TABLE salarii
ADD CONSTRAINT vechime_3  CHECK(vechime_anterioara>=0);

--delete constrangere
ALTER TABLE salarii
drop constraint vechime_3;


select marca,salariu_baza,prima,salariu_baza+NVL(prima,0) as total
from salarii;

--Show 2 top salaries
select rownum as nrCrt, salarii.* from salarii where rownum<=2 order by salariu_baza desc;

--Determine all salary expenses at department level.
select cod_Dep, sum(salariu_baza+NVL(prima,0)) as TOTAL
      from angajati2 A inner join salarii B  on A.marca=B.marca 
      group by cod_Dep;

--Max salary
select * from angajati2 A inner join salarii B on A.marca=B.marca 
where salariu_baza = ( select max(salariu_baza) from salarii);

--Sa se acorde o prima de 100 lei salariatului cu marca=1;
update salarii 
set prima=100
where marca=1;


--Give same to marca=2 as marca=1. (salariu-200, prima/2)
update salarii
	set (salariu_baza, prima)=(select salariu_baza-200, prima/2 
                            from salarii 
                            where marca=1
                            )
where marca=2;


--sa se acorde angajatilor cu prima=null o prima egala cu 100 din salariu
update salarii
set prima = 100
where prima is null;

--functia decode
update salarii 
set salariu_baza=salariu_baza* decode(marca, 1, 1.1,  2, 1.15,   1.05) ;


--Modifica salariu_baza pentru salariatii din departamentul IT cu x1.1
update salarii S
	set salariu_baza=salariu_baza*1.1
	where (select den_dep from departamente D inner join angajati2 A on A.cod_dep=D.cod_dep
		where A.marca=S.marca)='IT';


--Sa se creeze vederea v_Angajati pe baza datelor din tabelul angajati din schema RU si salarii si schema SAL. Vederea se va crea in schema SAL.
create view v_Angajati as 
	select A.*, salariu_baza, data_angajarii, vechime_anterioara
	from angajati2 A inner join salarii B on A.marca=B.marca;


Select * from v_Angajati;

--Sa se creeze tabelul t_SAprovizionare pe baza datelor din vederea v_Angajati.

create table t_Aprovizionare as
	select* from v_Angajati;
  
select * from t_aprovizionare;
drop table t_Aprovizionare; 


--Sa se afiseze salariatii cu salariu_baza maxim din fiecare departament.
select * from v_Angajati A
where salariu_baza=(select max(salariu_baza)
                    from v_angajati
                    where A.cod_dep=cod_dep
);