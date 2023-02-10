create database cadastroRefeicao;
use cadastroRefeicao;

create table pessoa(
    nome varchar(45) not null,
    cpf int not null,
    refeicao varchar(30) not null,
    id int not null AUTO_INCREMENT,

    constraint PK_id
    primary key (id)
)