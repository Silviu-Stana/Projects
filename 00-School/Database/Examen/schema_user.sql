--DROP TABLESPACE ts_Prof INCLUDING CONTENTS AND DATAFILES;
--DROP TABLESPACE ts_temp_Prof INCLUDING CONTENTS AND DATAFILES;
--drop user profesor cascade;

create tablespace ts_Prof datafile 'C:\ORACLE\ORADATA\ORCL\prof1.dbf' size 5M;

create temporary tablespace ts_temp_Prof tempfile 'C:\ORACLE\ORADATA\ORCL\prof2.dbf' size 5M;
alter session set "_ORACLE_SCRIPT"=true;

create user profesor identified by profesor
default tablespace t_prof
temporary tablespace ts_prof
quota unlimited on ts_prof;

--drop role dev;
create role dev;
grant create session, create table, create view, create procedure, create synonym, create sequence to dev;

grant dev to profesor;





