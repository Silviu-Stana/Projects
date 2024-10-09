insert into scoala.tFacultati(codFac, denumire, adresa)
values ('fsefi','stiinte, ed fiz, informatica','Pitesti'),
('fecc','electronica calc comunicatii','Pitesti'),
('fsed','stiinte economice si drept','Pitesti'),
('fmt','mecanica si tech','Pitesti')

select *from scoala.tFacultati
create synonym tFacultati for scoala.tFacultati
select *from tFacultati
create synonym tDepartamente for scoala.tDepartamente
select *from tDepartamente

insert into scoala.tDepartamente(codDep, denumire, codFac)
values ('mi','mate info','fsefi'),
('st','stiinte','fsefi'),
('ef','ed fizica si sport','fsefi'),
('amk','asistent medical si kineto','fsefi'),
('ecc','electro calc','fecc'),
('fce','finante contabil si econom','fsed'),
('dap','drept admin publica','fsed')
select *from tDepartamente

--Determina nr facultati
select count(codFac) as [nr facultati]
from tFacultati

--Afiseaza lista depart
select codDep, denumire, codFac
from tDepartamente

--Afiseaza fsefi
select codDep, denumire, codFac
from tDepartamente
where codFac='fsefi'
--Ordinea corecta:
--select from, where, group by, having, order by

--Exclude
select codDep, denumire, codFac
from tDepartamente
where codFac!='fsefi'
--sau
select codDep, denumire, codFac
from tDepartamente
where codFac<>'fsefi'
--sau
select codDep, denumire, codFac
from tDepartamente
where not codFac='fsefi'


--Afiseaza nr departamente la nivel de codFac
select codFac as [cod facultate], count(codDep) as [numar departamente]
from tDepartamente
group by codFac
order by [numar departamente] desc

select codFac as [cod facultate], count(codDep) as [numar departamente]
from tDepartamente
group by codFac
order by count(codDep) desc

--ia coloana 2
select codFac as [cod facultate], count(codDep) as [numar departamente]
from tDepartamente
group by codFac
order by 2 desc


insert into tDepartamente(codDep, denumire, codFac)
values ('at','auto si transport','fmt'),
('fmi','fabricatie si management','fmt')


--Afiseaza primele 2 randuri
select top 2 codFac as [cod facultate], count(codDep) as [numar departamente]
from tDepartamente
group by codFac
order by 2 desc

select top 2 with ties codFac as [cod facultate], count(codDep) as [numar departamente]
from tDepartamente
group by codFac
order by 2 desc


select codFac as [cod facultate], count(codDep) as [numar departamente]
from tDepartamente
group by codFac
having count(codDep)>=2
order by 2 desc

