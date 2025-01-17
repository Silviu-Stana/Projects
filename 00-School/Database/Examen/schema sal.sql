create table salarii(
	marca int primary key references ru.angajati(marca),
	salariu_baza int,
	data_angajarii date,
	vechime_anterioara int
);

create table pontaj(
	id_pontaj int primary key,
	marca int references ru.angajati(marca),
	luna int,
	anul int,
	ore_lucrate int default 0,
	ore_supl int default 0,
	co int default 0, --concediu de odihna 
	cb int default 0  --concediu boala obisnuita
);


insert into salarii values(1, 3200, '08-Aug-2000',2);
insert into salarii values(2, 2800, '10-Jan-1999',5);
insert into salarii values(3, 3500, '08-Aug-2014',2);
insert into salarii values(4, 2500, '10-Jan-2015',5);

--vizualizare tabela salarii
select * from salarii;


--Sa se adauge tabelului salarii coloana prima de tip int.

alter table salarii 
	add prima int;


--Sa se stearga coloana prima.

alter table salarii
  drop column prima; 

--Sa se adauge tabelului salarii coloana prima de tip int cu constangerea ca prima sa fie mai mica sau egala decat 100.

alter table salarii 
	add prima int check(prima<=100);

--Sa se modifice coloana prima astfel incat sa fie de tipul number (7,2) (7 cifre dintre care doua dupa virgula).

alter table salarii
	modify (prima number(7,2) );

-- adaugare constrangere de tipul CHECK
ALTER TABLE salarii
ADD CONSTRAINT vechime_3  CHECK(vechime_anterioara>=0);

--stergere constrangere
ALTER TABLE salarii
drop constraint vechime_3;

--Sa se afiseze din tabelul salarii coloanele marca, salariu_baza, prima, total (=salariu_baza+prima).

select marca,salariu_baza,prima,salariu_baza+NVL(prima,0) as total
from salarii;

--Sa se utilizeze pseudocoloana rownum pt numerotarea randurilor rezultat ale comenzii select.

select rownum as nrCrt, salarii.* from salarii order by marca desc;

--Sa se afiseze cele mai mari 2 salarii in ordinea descrescatoare a lor.

select rownum as nrCrt, salarii.* from salarii where rownum<=2 order by salariu_baza desc;

--Sa se determine totalul cheltuielilor salariale la nivel de departament.

select cod_Dep, sum(salariu_baza+NVL(prima,0)) as TOTAL
	from ru.angajati A inner join salarii B  on A.marca=B.marca 
	group by cod_Dep;

--Sa se afiseze salariatii cu salariu_baza maxim.

select * from ru.angajati A inner join salarii B on A.marca=B.marca 
where salariu_baza = ( select max(salariu_baza) from salarii);

--Sa se acorde o prima de 100 lei salariatului cu marca=1;

update salarii 
set prima=100
where marca=1;

select * from salarii;

--Sa se acorde aceleasi drepturi salariale angajatului cu marca=2 ca si celui cu marca=1.

update salarii
set (salariu_baza, prima)=(select salariu_baza, prima
                          from salarii 
                          where marca=1
                          )
where marca=2;
select * from salarii;

--Sa se acorde angajatului cu marca=2 salariul angajatului cu marca=1 cu 200lei mai putin si prima pe jumatate.

update salarii
	set (salariu_baza, prima)=(select salariu_baza-200, prima/2 
                            from salarii 
                            where marca=1
                            )
where marca=2;

select * from salarii;

--sa se acorde angajatilor cu prima=null o prima egala cu 100 din salariu
update salarii
set prima = 100
where prima is null;

--functia decode
update salarii 
set salariu_baza=salariu_baza* decode(marca, 1, 1.1,  2, 1.15,   1.05) ;


select * from salarii;

--Sa se modifice salariu_baza pentru salariatii din departamentul IT conform formulei: salariu_baza=salariu_baza*1.1 ;

update salarii S
	set salariu_baza=salariu_baza*1.1
	where (select cod_Dep from ru.angajati A inner join salarii B on A.marca=B.marca
		where A.marca=S.marca)='IT';

--Sa se creeze vederea v_Angajati pe baza datelor din tabelul angajati din schema RU si salarii si schema SAL. Vederea se va crea in schema SAL.

create view v_Angajati as 
	select A.*, salariu_baza, data_angajarii, vechime_anterioara
	from ru.angajati A inner join salarii B on A.marca=B.marca;


Select * from v_Angajati;

--Sa se creeze tabelul t_SAprovizionare pe baza datelor din vederea v_Angajati.

create table t_Aprovizionare as
	select* from v_Angajati;
  
select * from t_aprovizionare; 

--Sa se stearga tabelul t_Aprovizionare.

drop table t_Aprovizionare; 

--Sa se creeze tabelul t_Ang_Aprovizionare pe baza datelor din vederea v_Angajati  ce contine salariatii din departamentul Aprov.

create table t_Ang_Aprovizionare as
	select* from v_Angajati where cod_dep='aprov';

select * from t_Ang_Aprovizionare;


--Sa se afiseze salariatii cu salariu_baza maxim din fiecare departament.

select * from v_Angajati A
where salariu_baza=(select max(salariu_baza)
                    from v_angajati
                    where A.cod_dep=cod_dep
);









INSERT ALL
INTO ProduseVandute (codVanzare, numeProdus, pretProdus, cantitate) VALUES (1, 'SEO Service', 500.00, 10);
INTO ProduseVandute (codVanzare, numeProdus, pretProdus, cantitate) VALUES (2, 'Website Development', 1500.00, 5);
INTO ProduseVandute (codVanzare, numeProdus, pretProdus, cantitate) VALUES (3, 'Automation Service', 1200.00, 7);
INTO ProduseVandute (codVanzare, numeProdus, pretProdus, cantitate) VALUES (4, 'SEO Service', 450.00, 12);
INTO ProduseVandute (codVanzare, numeProdus, pretProdus, cantitate) VALUES (5, 'Website Development', 2000.00, 4);
INTO ProduseVandute (codVanzare, numeProdus, pretProdus, cantitate) VALUES (6, 'Automation Service', 1100.00, 9);
INTO ProduseVandute (codVanzare, numeProdus, pretProdus, cantitate) VALUES (7, 'SEO Service', 550.00, 8);
INTO ProduseVandute (codVanzare, numeProdus, pretProdus, cantitate) VALUES (8, 'Website Development', 1300.00, 6);
INTO ProduseVandute (codVanzare, numeProdus, pretProdus, cantitate) VALUES (9, 'Automation Service', 1000.00, 11);
INTO ProduseVandute (codVanzare, numeProdus, pretProdus, cantitate) VALUES (10, 'SEO Service', 480.00, 15);
INTO ProduseVandute (codVanzare, numeProdus, pretProdus, cantitate) VALUES (11, 'Website Development', 1600.00, 3);
INTO ProduseVandute (codVanzare, numeProdus, pretProdus, cantitate) VALUES (12, 'Automation Service', 1050.00, 10);
INTO ProduseVandute (codVanzare, numeProdus, pretProdus, cantitate) VALUES (13, 'SEO Service', 500.00, 13);
INTO ProduseVandute (codVanzare, numeProdus, pretProdus, cantitate) VALUES (14, 'Website Development', 1400.00, 7);
INTO ProduseVandute (codVanzare, numeProdus, pretProdus, cantitate) VALUES (15, 'Automation Service', 1150.00, 8);
INTO ProduseVandute (codVanzare, numeProdus, pretProdus, cantitate) VALUES (16, 'SEO Service', 530.00, 14);
INTO ProduseVandute (codVanzare, numeProdus, pretProdus, cantitate) VALUES (17, 'Website Development', 1550.00, 5);
INTO ProduseVandute (codVanzare, numeProdus, pretProdus, cantitate) VALUES (18, 'Automation Service', 1200.00, 6);
INTO ProduseVandute (codVanzare, numeProdus, pretProdus, cantitate) VALUES (19, 'SEO Service', 460.00, 18);
INTO ProduseVandute (codVanzare, numeProdus, pretProdus, cantitate) VALUES (20, 'Website Development', 1700.00, 4);
