create table departamente
        (  cod_Dep char(10) primary key,
           den_Dep varchar2(30) not null,
           adresa varchar2(50) not null
       );
create table nomenclator_functii
       ( cod_functie char(10) primary key,
          den_functie varchar2(30)
       );

create table angajati2
       ( marca int  primary key, 
         nume varchar2(30),
         CNP char(13),
         cod_functie char(10) references nomenclator_functii(cod_functie), 
         cod_Dep char(10) references departamente(cod_Dep)
      );
      

insert into departamente values ('D1','Marketing','pitesti trivale');
insert into departamente values ('D2','IT','pitesti teilor');
insert into departamente values ('D3','Vanzari','pitesti prundu');

select * from departamente;

insert into nomenclator_functii values ('IT_PROG','programator');
insert into nomenclator_functii values ('SA_MAN','manager vanzari');
insert into nomenclator_functii values ('SA_REP','reprezentant vanzari');
insert into nomenclator_functii values ('MK_MAN','manager marketing');
insert into nomenclator_functii values ('MK_REP','reprezentant marketing');

select * from nomenclator_functii;

insert into angajati2(marca, nume, cod_functie, cod_Dep) values (1,'popescu ion','IT_PROG','D2');
insert into angajati2(marca, nume, cod_functie, cod_Dep) values (2,'rotariu alina','SA_MAN','D3');

create sequence seq_marca increment by 1 start with 2;
select seq_marca.nextval from dual;
select seq_marca.currval from dual;

insert into angajati2(marca, nume, cod_functie, cod_Dep) values (seq_marca.nextval,'rata vlad','SA_REP','D3');
insert into angajati2(marca, nume, cod_functie, cod_Dep) values (seq_marca.nextval,'popa andrei','MK_MAN','D1');

select * from angajati2;

grant references on angajati2 to salProf;
grant select on angajati2 to salProf;



