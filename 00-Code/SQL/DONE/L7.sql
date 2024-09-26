select *from tFacultati
select *from scoala.tDepartamente
select *from scoala.tSpecializari
select *from tStudenti

create synonym tSpecializari for scoala.tSpecializari
create synonym tStudenti for scoala.tStudenti
insert into tSpecializari(codSpec, denumire, codDep)
values('info','informatica','mi'),
('mate','matematica','mi'),
('fb','finante banci','fce'),
('cig','contabilitate si informatica de gestiune','fce'),
('man','management','fce'),
('dr','drept','dap'),
('ap','administratie publica','dap'),
('calc','calculatoare','ecc')

--Sa se afiseaze departamentele codFacultate, denumire, codDepartament, denumire
select A.codFac, A.denumire, B.codDep, B.denumire
from tFacultati as A inner join tDepartamente as B on A.codFac=B.codFac

insert into tFacultati(codFac,denumire,adresa)
values('se','stiintele educatiei','Pitesti'),
('tilia','teologie istorie si altele','Pitesti')

--Sa se afiseze toate facultatiile impreuna cu departamente
select A.codFac, A.denumire, B.codDep, B.denumire
from tFacultati as A left join tDepartamente as B on A.codFac=B.codFac

--Sa se afiseze codDep, denumire, codFac, denumire
select A.codDep, A.denumire, B.codFac, B.denumire
from tDepartamente as A right join tFacultati as B on A.codFac=B.codFac

--Facultate->Departamente->Specializari
--Sa se afiseze codFac,denumire,codSpec,denumire
select A.codFac, A.denumire, C.codSpec, C.denumire
from tFacultati as A inner join tDepartamente as B on A.codFac=B.codFac
inner join tSpecializari as C on B.codDep=C.codDep

--Sa se afiseze Nr de Facultati
select count(codFac) as [Nr Facultati]
from tFacultati

--Sa se afiseze Nr departamente la nivel de facultate
select A.codFac, A.denumire, count(codDep) as [Nr Departamente]
from tFacultati as A join tDepartamente as B on A.codFac=B.codFac
group by A.codFac,A.denumire
--Ordoneaza descrescator dupa nr departamente
order by [Nr Departamente] desc

--Sa se afiseze Nr departamente la nivel de facultate
select A.codFac, A.denumire, count(codDep) as [Nr Departamente]
from tFacultati as A left join tDepartamente as B on A.codFac=B.codFac
group by A.codFac,A.denumire

--Sa se afiseze Nr departamente la nivel de facultate
--count(*) numara si valorile NULL
select A.codFac, A.denumire, count(*) as [Nr Departamente]
from tFacultati as A left join tDepartamente as B on A.codFac=B.codFac
group by A.codFac,A.denumire


--Sa se afiseze Nr Departamente la nivel de facultate pt. codFac 'fsefi' si 'fsed'
select A.codFac, A.denumire, count(codDep) as [Nr Departamente]
from tFacultati as A join tDepartamente as B on A.codFac=B.codFac
group by A.codFac,A.denumire
having A.codFac in ('fsefi','fsed')


--[VARIANTA OPTIMA] Sa se afiseze Nr Departamente la nivel de facultate pt. codFac 'fsefi' si 'fsed'
--Facem operatii doar pe randurile din 'where'
select A.codFac, A.denumire, count(codDep) as [Nr Departamente]
from tFacultati as A join tDepartamente as B on A.codFac=B.codFac
where A.codFac in('fsefi','fsed')
group by A.codFac,A.denumire



use dbStudentiMidus2024
--* afiseaza toate coloanele
select *from tStudenti


--Ia anul 03 din CNP + 2000
alter table scoala.tStudenti
add anulNasterii as convert (int,substring(cnp,2,2))+2000


--Sa se afiseze studentii de la "info"
select *from tStudenti
where codSpec='info'


--Sa se afiseze studentii cu prima litera a numelui este "a"
select *from tStudenti
where nume like 'A%'

--Afiseaza studentii cu prima litera a numelui este "a" si a 3-a "i"
select *from tStudenti
where nume like 'A_i%'

--Afiseaza studentii cu prima litera "A" sau "B", 'C' 'D' 'E'
select *from tStudenti
where nume like '[A-E]%'

--Afiseaza studentii cu prima litera "A" sau "B", 'C' 'D' 'E' sau 'P' 'R' 'S' 'T' 'U' 'V'
select *from tStudenti
where nume like '[A-EP-V]%'

--Cei care nu contin literele mentionate.
select *from tStudenti
where nume not like '[A-EP-V]%'
--sau:  where nume like '[^A-EP-V]%'

select *from tStudenti
where nume like '%Ina%'