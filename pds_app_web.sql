create database odontpro;
use odontpro;

-- tabela de funcionários da clínica
create table funcionario (
    id_func int primary key auto_increment,
    nome_func varchar(100) not null,
    email_func varchar(100) not null,
    telefone_func varchar(20),
    cargo_func varchar(50),
    estado_func varchar(50)
);

-- tabela de clientes/pacientes
#era bom armazenar o cpf do cliente
create table paciente (
    id_pac int primary key auto_increment,
    nome_pac varchar(255) not null,
    email_pac varchar(255),
    sexo_pac varchar(30),
    telefone_pac varchar(20),
    #o endereço ta estranho, é bom destrinchar ele, (ex: rua_cli, bairro_cli, numero_cli, etc)
    endereco_pac varchar(50),
    nascimento_pac datetime,
    estado_pac varchar(40),
    observacoes_pac varchar(300)
);

-- tabela de produtos vinculados a fornecedores
create table produto (
    id_pro int primary key auto_increment,    
    nome_pro varchar(255) not null,
    descricao_pro text,
    quantidade_pro int not null, # <-- isso pra mim já é sobre estoque
    preco_pro float not null
);

-- tabela de financeiro
#adapitei o "constaPagar" pra essa nova tabela, que aceita tanto gasto quanto ganho, assim fica mais facil para mexer na logica do codigo e pra entender o que ele faz
create table financeiro (
    id_fin int primary key auto_increment,
    nome_pagador_fin varchar(255) not null,
    descricao_fin varchar(300),
    valor_fin decimal(10,2) not null,
    
    -- tipo da transação
    # ou vai ser "gasto" ou vai ser "ganho"
    tipo_fin varchar(20) not null,

    -- data da transação
    data_fin date not null
);

select * from financeiro;