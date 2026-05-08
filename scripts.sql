-- CRIANDO DATABASE

create database FlowDesk;

use FlowDesk;

-- CRIANDO AS TABELAS DE BANCO DE DADOS	

create Table tb_usuario(
Id int primary key auto_increment,
Nome varchar(50) not null,
Email varchar(50) not null,
Senha varchar(250) not null,
Nivel varchar(50) not null

);

-- CONSULTANDO A TABELA DO BANCO DE DADOS

select * from tb_usuario;

-- INSERINDO DADOS NA TABELA DO BANCO DE DADOS

insert into tb_usuario(Nome,Email,Senha,Nivel)
values ('Administrador','admin@email.com','123456','Admin');