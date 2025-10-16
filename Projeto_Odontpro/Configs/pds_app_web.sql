create database odontpro;
use odontpro;

CREATE TABLE funcionarios (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    email VARCHAR(100) NOT NULL,
    telefone VARCHAR(20),
    cargo VARCHAR(50),
    estado varchar(50)
);

CREATE TABLE clientes (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nome VARCHAR(255) NOT NULL,
    Email VARCHAR(255),
    Sexo varchar(30),
    Telefone VARCHAR(20),
    Endereco VARCHAR(30),
    Nascimento datetime,
    Estado varchar(40),
    Observacoes varchar (300)
);


CREATE TABLE
  fornecedor (
    id_for INT NOT NULL AUTO_INCREMENT,
    nome_for VARCHAR(255) NOT NULL,
    PRIMARY KEY (id_for)
  );

CREATE TABLE
  produto (
    id_pro INT NOT NULL AUTO_INCREMENT,
    id_for_fk INT NULL,
    nome_pro VARCHAR(255) NOT NULL,
    descricao_pro TEXT NULL,
    quantidade_pro INT NOT NULL,
    preco_pro DECIMAL(10, 2) NOT NULL,
    PRIMARY KEY (id_pro),
    FOREIGN KEY (id_for_fk) REFERENCES fornecedor (id_for)
  );
  
CREATE TABLE 
  estoque (
	id_est INT NOT NULL AUTO_INCREMENT,
    id_for_fk INT NULL,
    nome_est VARCHAR(200) NOT NULL,
    quantidade_est INT NOT NULL,
    forma_pagamento_est VARCHAR(100) NOT NULL,
    marca_est VARCHAR(100) NOT NULL,
    valor_est DECIMAL(10, 2) NOT NULL,
    descricao_est VARCHAR(300) NOT NULL,
    PRIMARY KEY (id_est),
    FOREIGN KEY (id_for_fk) REFERENCES fornecedor (id_for)
  );

-- Inserindo fornecedores
INSERT INTO
  fornecedor (nome_for)
VALUES
  ('Fornecedor A'),
  ('Fornecedor B'),
  ('Fornecedor C'),
  ('Fornecedor D'),
  ('Fornecedor E'),
  ('Fornecedor F'),
  ('Fornecedor G'),
  ('Fornecedor H');

-- Inserindo produtos vinculados aos fornecedores
INSERT INTO
  produto (
    id_for_fk,
    nome_pro,
    descricao_pro,
    quantidade_pro,
    preco_pro
  )
VALUES
  (
      1,
      'Anestesia',
      'Anestesia Dental Alphacaine',
      45,
      5850.00
),
(
	  2,
      'Pasta de Dente',
      'Pasta de Dente Colgate',
      105,
      2100.00
),
(
	  3,
      'Escova de Dentes',
      'Escova de Dentes Normal Oral-B',
      200,
      1000.00
),
(
	  4,
      'Escova de Dentes Elétrica',
      'EScova de Dentes Elétrica Oral-B',
      100,
      8000.00
),
(
	  5,
      'Fio Dental',
      'Fio Dental PowerDent',
      300,
      9000.00
),
(
	  6,
      'Avental',
      'Avental de Dentista ManiaJalecos',
      50,
      3500.00
),
(
	  7,
      'Luvas',
      'Caixa de Luvas de Látex de Dentista Descarpark',
      100,
      2000.00
),
(
	  8,
      'Espelho Odontológico',
      'Espelho Odontológico Golgran',
      50,
      500.00
);

-- Inserindo estoque vinculado aos fornecedores
  INSERT INTO
  estoque (
    id_for_fk,
    nome_est,
    quantidade_est,
    forma_pagamento_est,
    marca_est,
    valor_est,
    descricao_est
  )
VALUES
  (
    1,
    'Anestesia Dental',
    45,
    'Parcelado',
    'Alphacaine',
    5850.00,
    'Anestesia Dental Alphacaine'
  ),
  (
    2,
    'Pasta de Dente',
    105,
    'À vista',
    'Colgate',
    2100.00,
    'Pasta de Dente Colgate'
  ),
  (
    3,
    'Escova de Dentes Normal',
    200,
    'À vista',
    'Oral-B',
    1000.00,
    'Escova de Dentes Normal Oral-B'
  ),
  (
    4,
    'Escova de Dentes Elétrica',
    100,
    'Parcelado',
    'Oral-B',
    8000.00,
    'Escova de Dentes Elétrica Oral-B'
  ),
  (
    5,
    'Fio Dental',
    300,
    'Parcelado',
    'PowerDent',
    9000.00,
    'Fio Dental PowerDent'
  ),
  (
    6,
    'Avental',
    50,
    'À vista',
    'JalecosMania',
    3500.00,
    'Avental de Dentista JalecosMania'
  ),
  (
    7,
    'Luvas',
    100,
    'À vista',
    'Descarpack',
    2000.00,
    'Caixa de Luvas de Látex de Dentista Descarpark'
  ),
  (
    8,
    'Espelho Odontológico',
    50,
    'À vista',
    'Golgran',
    500.00,
    'Espelho Odontológico Golgran'
  );
  
  
INSERT INTO clientes (Nome, Email, Sexo, Telefone, Endereco, Nascimento, Estado, Observacoes) VALUES
('Maria Silva', 'maria.silva@email.com', 'Feminino', '11999999999', 'Rua das Flores, 123', '1995-06-15 00:00:00', 'São Paulo', 'Cliente fiel, prefere atendimento pela manhã'),
('João Santos', 'joao.santos@email.com', 'Masculino', '21988888888', 'Av. Brasil, 456', '1988-09-22 00:00:00', 'Rio de Janeiro', 'Solicitou agendamento mensalmente'),
('Ana Oliveira', 'ana.oliveira@email.com', 'Feminino', '31977777777', 'Rua Central, 789', '2000-01-10 00:00:00', 'Minas Gerais', 'Possui alergia a anestesia local'),
('Carlos Pereira', 'carlos.pereira@email.com', 'Masculino', '41966666666', 'Av. das Américas, 321', '1992-03-05 00:00:00', 'Paraná', 'Primeira consulta realizada em 2024');

INSERT INTO funcionarios (nome, email, telefone, cargo, estado) VALUES
('Ana Souza', 'ana.souza@email.com', '(11) 98765-4321', 'Recepcionista','rj'),
('Carlos Lima', 'carlos.lima@email.com', '(21) 91234-5678', 'Dentista','sp'),
('Mariana Silva', 'mariana.silva@email.com', '(31) 99876-5432', 'Auxiliar','ro'),
('João Pereira', 'joao.pereira@email.com', '(41) 99123-4567', 'Gerente','mg'),
('Fernanda Costa', 'fernanda.costa@email.com', '(51) 98765-1234', 'Assistente Administrativo','ms');

CREATE TABLE contasaApagar (
    
    nomecp_cont VARCHAR(100),
    descricaocp_est VARCHAR(255),
    valorcp_est DECIMAL(10,2),
    
);
 INSERT INTO
  contasaApagar (

    
    nomecp_cont,
	descricaocp_est,
    valorcp_est
   
  )
VALUES
    ('Maria Isabeli', 'Aluguel mês 12', 1200),
    ('Ana Carolina', 'Conta de luz', 250.75),
    ('Sara Silva', 'Internet', 150.50),
    ('Anna Clara', 'Limpeza dental', 400.90),
    ('Douglas', 'Aparelho ', 180.00);