CREATE TABLE Person (
    id INTEGER IDENTITY(1,1) PRIMARY KEY,
    address varchar(100) not null,
	first_name varchar(80) not null,	
	gender varchar(6) not null,
	last_name varchar(80) not null
	);


insert  Person values ('Alameda dos Unios 158', 'João', 'Male', 'Pacheco');

insert  Person values ('Casa dos testes', 'Maria', 'Female', 'Augusta');

select * from Person