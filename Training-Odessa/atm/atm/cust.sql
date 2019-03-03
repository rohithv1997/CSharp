create database atmcustomers

create table cususer(
	userid int constraint check_user_userid check(userid between 10000 and 99999)   constraint pk_user_userid primary key identity(10000,1),
	pwd varchar(5) constraint check_user_pwd check(pwd like('[0-9][0-9][0-9][0-9][0-9]')) not null,
	bal money not null
)

insert into cususer values( '12345',543.21)
insert into cususer values( '12346',101.98)
insert into cususer values( '12347',15675.34)


create table machine(
	c20 int not null default 500
)

insert into machine values (500);

select * from machine
select * from cususer;

--drop table cususer
--drop table machine