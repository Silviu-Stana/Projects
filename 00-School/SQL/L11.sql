--SQL11
--Se da un nr natural n. Sa se determine cifra maxima
declare @n int, @max int=0
declare @c int
set @n=25734
while @n>0
begin
set @c=@n%10
set @n=@n/10
if @c>@max set @max=@c
end
print @max


go
declare @n int, @max int=0
declare @c int
set @n=25734
inceput:
if @n=0 goto sfarsit
set @c=@n%10
set @n=@n/10
if @c>@max set @max=@c
goto inceput
sfarsit:
print @max


--Se da un nr n. Sa se obtina nr m din n, prin micsorarea cifrelor impare cu 1 si marirea celor pare +1
--25019 -> 34108
go
declare @n int, @m int=0, @p int=1
set @n=25019
while @n>0
begin
if @n%2=0 set @m+=@p*(@n%10+1)
else set @m+=@p*(@n%10-1)
set @p=@p*10
set @n=@n/10
end
print @m


--Sa se verifice daca cifrele numarului sunt crescatoare
declare @n int, @ok int=1, @ca int, @cc int
set @n=14345
set @ca=10
while @n>0
begin
	set @cc=@n%10
	if @cc>@ca
	begin set @ok=0 break
	end
	set @ca=@cc
	set @n=@n/10
end
if @ok=1 print 'Este Crescator'
else print 'NU este'


--Sa se verifice daca cifrele nenule ale lui n sunt crescatoare
go
declare @n int, @ok int=1, @ca int, @cc int
set @n=100043045
set @ca=10
while @n>0
begin
	set @cc=@n%10
	set @n=@n/10
	if @cc=0 continue
	if @cc>@ca
	begin set @ok=0 break
	end
set @ca=@cc
end
if @ok=1 print 'DA'
else print 'NU'


--Sa se afiseze notele studentiilor in ordinea disciplinelor
select * from tNote
order by codCurs

select AVG(convert(decimal(4,2),nota))
from tNote
where codCurs='BD'

--Cat timp media la BD<7, sa se mareasca nota studentiilor +1
declare @media decimal(4,2)
select @media=AVG(convert(decimal(4,2),nota))
from tNote
where codCurs='BD'
print @media

while @media<7
begin
update tNote
set nota=nota+1
where codCurs='BD' and nota<10
set @media=(select AVG(convert(decimal(4,2),nota))
			from tNote
			where codCurs='BD')
print @media
end
select * from tNote
order by codCurs


--Sa se creeze o functie care determina nr studenti de la o specializare (data prin parametru)
go
create function nrstudentispec(@codspec char(10))
returns int
as
begin
declare @nrs int
set @nrs= (select COUNT(codStud)
			from tStudenti
			where codSpec like @codspec)
return @nrs
end



go
alter function nrstudentispec(@codspec varchar(11))
returns int
as
begin
declare @nrs int
set @nrs= (select COUNT(codStud)
			from tStudenti
			where codSpec like @codspec)
return @nrs
end


print dbo.nrstudentispec('m%')



--Tratarea exceptiilor
--try, catch, throw

declare @n int=17
begin try
--...
--set @n=@n/0
--...
if @n<18
throw 50001, 'Varsta prea mica', 2
--...
end try
begin catch
print error_message()
end catch
