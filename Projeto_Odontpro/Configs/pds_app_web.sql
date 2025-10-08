create database pds_app_web;
use pds_app_web;

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