-- criando o database db_lojaInformatica
create database db_lojaInformatica default character set utf8 default collate utf8_general_ci;

-- usando o database db_lojaInformatica
use db_lojaInformatica;

-- drop database db_lojaInformatica
drop database db_lojaInformatica;

/* 
	cd = codigo,
	nm = nome,
    sob = sobrenome,
    sh = senha,
    tp = tipo,
    uf = sigla da cidade,
    sx = sexo,
    cel = celular,
    tel = telefone,
    eml = email,
    desc = descrição,
    
*/

-- criando as tabelas do banco de dados 

-- tabela cidade
create table tbl_estadoUf(
	cd_estado int primary key auto_increment not null,
    uf_estado varchar(2)
)default charset utf8;

-- inserindo dados na tabela cidade
insert into tbl_estadoUf(uf_estado) values ('AC');
insert into tbl_estadoUf(uf_estado) values ('AL');
insert into tbl_estadoUf(uf_estado) values ('AP');
insert into tbl_estadoUf(uf_estado) values ('AM');
insert into tbl_estadoUf(uf_estado) values ('BA');
insert into tbl_estadoUf(uf_estado) values ('CE');
insert into tbl_estadoUf(uf_estado) values ('DF');
insert into tbl_estadoUf(uf_estado) values ('ES');
insert into tbl_estadoUf(uf_estado) values ('GO');
insert into tbl_estadoUf(uf_estado) values ('MA');
insert into tbl_estadoUf(uf_estado) values ('MT');
insert into tbl_estadoUf(uf_estado) values ('MS');
insert into tbl_estadoUf(uf_estado) values ('MG');
insert into tbl_estadoUf(uf_estado) values ('PA');
insert into tbl_estadoUf(uf_estado) values ('PB');
insert into tbl_estadoUf(uf_estado) values ('PR');
insert into tbl_estadoUf(uf_estado) values ('PE');
insert into tbl_estadoUf(uf_estado) values ('PI');
insert into tbl_estadoUf(uf_estado) values ('RJ');
insert into tbl_estadoUf(uf_estado) values ('RN');
insert into tbl_estadoUf(uf_estado) values ('RS');
insert into tbl_estadoUf(uf_estado) values ('RO');
insert into tbl_estadoUf(uf_estado) values ('RR');
insert into tbl_estadoUf(uf_estado) values ('SC');
insert into tbl_estadoUf(uf_estado) values ('SP');
insert into tbl_estadoUf(uf_estado) values ('SE');
insert into tbl_estadoUf(uf_estado) values ('TO');

-- tabela pagamento
create table tbl_pagamento(
	cd_pagamento int primary key auto_increment not null,
    fr_pagamento varchar(8) not null
) default charset utf8;

-- inserindo dados na tabela pagamento
insert into tbl_pagamento(fr_pagamento) values ('Débito');
insert into tbl_pagamento(fr_pagamento) values ('Crédito');

-- tabela genero
create table tbl_genero(
	cd_genero int primary key auto_increment not null,
    nm_genero varchar(9) not null
)default charset utf8;

-- inserindo dados na tabela genero
insert into tbl_genero(nm_genero) values ('Masculino');
insert into tbl_genero(nm_genero) values ('Feminino');

-- tabela login
create table tbl_login(
	cd_login int primary key auto_increment not null,
    nm_login varchar(40) not null,
    sh_login varchar(15) not null,
    tp_login varchar(11) not null
) default charset utf8;

-- inserindo dados na tabela login
insert into tbl_login(nm_login, sh_login, tp_login) values ('torrico@gmail.com', '12345', 'Gerente');
insert into tbl_login(nm_login, sh_login, tp_login) values ('matheus@gmail.com', '12345', 'Funcionario');
insert into tbl_login(nm_login, sh_login, tp_login) values ('diogo@gmail.com', '12345', 'Comum');

-- tabela categoria
create table tbl_categoria(
	cd_categoria int primary key auto_increment not null,
    nm_categoria varchar(50) not null,
    desc_categoria varchar(1000) not null
)default charset utf8;

-- tabela funcionario
create table tbl_funcionario(
	cd_funcionario int primary key auto_increment not null,
    nm_funcionario varchar(50) not null,
    ida_funcionario varchar(14) not null,
    cpf_funcionario varchar(14) not null,
    cd_genero int not null,
    cel_funcionario varchar(15) not null,
    eml_funcionario varchar(50) not null,
    cep_funcionario varchar(9) not null,
    foreign key (cd_genero) references tbl_genero(cd_genero)
) default charset utf8;

-- inserindo dados na tabela funcionario
insert into tbl_funcionario(nm_funcionario, ida_funcionario, cpf_funcionario, cd_genero, cel_funcionario, eml_funcionario, cep_funcionario) values ('Diogo', '17', '310.049.967-12', '1', '(11) 98396-1174', 'diogo@gmail.com', '08240-859');

-- tabela cliente
create table tbl_cliente(
	cd_cliente int primary key auto_increment not null,
    nm_cliente varchar(20) not null,
    sob_cliente varchar(20) not null,
    ida_cliente varchar(14) not null,
	cpf_cliente varchar(14) not null,
    cd_genero int not null,
    cel_cliente varchar(15) not null,
    eml_cliente varchar(50) not null,
    cd_estado int,
    cep_cliente varchar(9) not null,
    foreign key (cd_genero) references tbl_genero(cd_genero),
    foreign key (cd_estado) references tbl_estadoUf(cd_estado)
) default charset utf8;

-- inserindo dados na tabela cliente
insert into tbl_cliente(nm_cliente, sob_cliente, ida_cliente, cpf_cliente, cd_genero, cel_cliente, eml_cliente, cd_estado, cep_cliente) values('Henrique', 'Torrico', '17', '528.977.658-62', '1', '(11) 9628-1187', 'henriquetorrico12@gmail.com', '25', '08240-590');

-- tabela fornecedor
create table tbl_fornecedor(
	cd_fornecedor int primary key auto_increment not null,
    nm_fornecedor varchar(50) not null,
    tel_fornecedor varchar(14) not null,
    cnpj_fornecedor varchar(18) not null,
    cd_estado int not null,
    cep_fornecedor varchar(9) not null,
    foreign key(cd_estado) references tbl_estadoUf(cd_estado)
) default charset utf8;
 
-- inserindo dados na tabela fornecedor
insert into tbl_fornecedor(nm_fornecedor, tel_fornecedor, cnpj_fornecedor, cd_estado, cep_fornecedor) values('Mercado Livre', '(11) 2054-1355', '54.838.549/1973-87', '25', '06892-760');

-- tabela fabricante
create table tbl_fabricante(
	cd_fabricante int primary key auto_increment not null,
    nm_fabricante varchar(50) not null,
    tel_fabricante varchar(14) not null,
    cnpj_fabricante varchar(18) not null,
    eml_fabricante varchar(50) not null,
    cd_estado int not null,
    cep_fabricante varchar(9) not null,
    foreign key(cd_estado) references tbl_estadoUf(cd_estado)
) default charset utf8;

-- tabela produto
create table tbl_produto(
	cd_produto int primary key auto_increment not null,
    nm_produto varchar(50) not null,
    cd_fornecedor int not null,
	cd_categoria int not null,
    vl_produto varchar(20) not null,
	qt_produto int not null,
	cd_fabricante int not null,
    img_produto varchar(5000) not null,
    foreign key(cd_categoria) references tbl_categoria(cd_categoria),
    foreign key(cd_fornecedor) references tbl_fornecedor(cd_fornecedor),
    foreign key(cd_fabricante) references tbl_fabricante(cd_fabricante)
) default charset utf8;

-- tabela vendas
create table tbl_vendas(
	cd_venda int primary key auto_increment not null,
    cd_cliente int not null,
    cd_produto int not null,
    qt_produto int(2) not null,
    vl_total varchar(25) not null,
    cd_pagamento int not null,
    cd_funcionario int not null,
    foreign key(cd_cliente) references tbl_cliente(cd_cliente),
    foreign key(cd_produto) references tbl_produto(cd_produto),
    foreign key(cd_funcionario) references tbl_funcionario(cd_funcionario),
    foreign key(cd_pagamento) references tbl_pagamento(cd_pagamento)
) default charset utf8;

-- consultando as tabelas do banco de dados
select * from tbl_estadoUf;
select * from tbl_login;
select * from tbl_pagamento;
select * from tbl_genero;
select * from tbl_categoria;
select * from tbl_cliente;
select * from tbl_funcionario;
select * from tbl_fornecedor;
select * from tbl_fabricante;
select * from tbl_produto;
select * from tbl_vendas;

-- excluindo as tabelas do banco de dados
drop table tbl_cidadeUf;
drop table tbl_login;
drop table tbl_genero;
drop table tbl_pagamento;
drop table tbl_categoria;
drop table tbl_cliente;
drop table tbl_funcionario;
drop table tbl_fornecedor;
drop table tbl_fabricante;
drop table tbl_produto;
drop table tbl_vendas;

-- inner join (tabela cliente, genero e cidade)
select 
	tbl_cliente.cd_cliente,
    tbl_cliente.nm_cliente,
    tbl_cliente.sob_cliente,
    tbl_cliente.ida_cliente,
    tbl_cliente.cpf_cliente,
    tbl_genero.nm_genero,
    tbl_cliente.cel_cliente,
    tbl_cliente.eml_cliente,
    tbl_estadoUf.uf_estado,
    tbl_cliente.cep_cliente 
from tbl_cliente inner join tbl_estadoUf
	on tbl_cliente.cd_estado = tbl_estadoUf.cd_estado
inner join tbl_genero
	on tbl_genero.cd_genero = tbl_cliente.cd_genero order by cd_cliente;
    

-- inner join (tabela produto, fabricante,fornecedor e categoria)
select 
	tbl_produto.cd_produto,
	tbl_produto.nm_produto,
	tbl_fornecedor.nm_fornecedor,
	tbl_categoria.nm_categoria,
	tbl_produto.vl_produto,
	tbl_produto.img_produto,
	tbl_produto.qt_produto,
	tbl_fabricante.nm_fabricante
from tbl_produto inner join tbl_fornecedor
	on tbl_produto.cd_fornecedor = tbl_fornecedor.cd_fornecedor
inner join tbl_categoria
	on tbl_categoria.cd_categoria = tbl_produto.cd_categoria
inner join tbl_fabricante
	on tbl_fabricante.cd_fabricante = tbl_produto.cd_fabricante order by cd_produto;
    
-- select na tabela categoria com apelidos
select 
	cd_categoria as Código,
    nm_categoria as Nome,
	desc_categoria as Descrição
from tbl_categoria;

-- inner join (tabela fornecedor e estado)
select 
	tbl_fornecedor.cd_fornecedor,
    tbl_fornecedor.nm_fornecedor,
    tbl_fornecedor.tel_fornecedor,
    tbl_fornecedor.cnpj_fornecedor,
	tbl_estadoUf.uf_estado,
    tbl_fornecedor.cep_fornecedor
from tbl_fornecedor inner join tbl_estadoUf
	on tbl_fornecedor.cd_estado = tbl_estadoUf.cd_estado order by cd_fornecedor;
    
-- inner join (tabela fabricante e estado)
select 
	tbl_fabricante.cd_fabricante,
    tbl_fabricante.nm_fabricante,
    tbl_fabricante.tel_fabricante,
    tbl_fabricante.cnpj_fabricante,
    tbl_fabricante.eml_fabricante,
	tbl_estadoUf.uf_estado,
    tbl_fabricante.cep_fabricante
from tbl_fabricante inner join tbl_estadoUf
	on tbl_fabricante.cd_estado = tbl_estadoUf.cd_estado order by cd_fabricante;

-- inner join (tabela funcionario e genero)
select 
	tbl_funcionario.cd_funcionario,
    tbl_funcionario.nm_funcionario,
    tbl_funcionario.ida_funcionario,
    tbl_funcionario.cpf_funcionario,
	tbl_genero.nm_genero,
    tbl_funcionario.cel_funcionario,
    tbl_funcionario.eml_funcionario,
    tbl_funcionario.cep_funcionario
from tbl_funcionario inner join tbl_genero
	on tbl_funcionario.cd_genero = tbl_genero.cd_genero order by cd_funcionario;
    
    -- inner join (tabela venda, cliente, produto, funcionario e pagamento)
select 
	tbl_vendas.cd_venda,
	tbl_cliente.nm_cliente,
	tbl_cliente.cpf_cliente,
	tbl_produto.nm_produto,
	tbl_vendas.qt_produto,
	tbl_vendas.vl_total,
	tbl_pagamento.fr_pagamento,
	tbl_funcionario.nm_funcionario
from tbl_vendas inner join tbl_cliente
	on tbl_vendas.cd_cliente = tbl_cliente.cd_cliente
inner join tbl_produto
	on tbl_vendas.cd_produto = tbl_produto.cd_produto
inner join tbl_funcionario
	on tbl_vendas.cd_funcionario = tbl_funcionario.cd_funcionario
inner join tbl_pagamento
	on tbl_vendas.cd_pagamento = tbl_pagamento.cd_pagamento order by cd_venda;