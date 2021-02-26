create table Produtos (
	Id int identity primary key,
	Nome varchar(50),
	Descricao varchar(150),
	Preco decimal,
	Estoque int
)

select * from Produtos

insert into Produtos 
values ('Teste Produto 1', 'Teste Produto 1', 20.0, 10),
       ('Teste Produto 2', 'Teste Produto 2', 130.0, 8),
	   ('Teste Produto 3', 'Teste Produto 3', 45.0, 9),
	   ('Teste Produto 4', 'Teste Produto 4', 120.0, 3),
	   ('Teste Produto 5', 'Teste Produto 5', 190.0, 4)