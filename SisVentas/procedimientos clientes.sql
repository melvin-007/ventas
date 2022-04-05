create database DemoCapas
go
use DemoCapas
go
create table clientes(
codigo varchar(5) not null primary key, 
nombres varchar(50) not null, 
apellidos varchar(100) not null,
correo varchar(100) not null,
estado int not null
)
go
create procedure proc_insertar
@codigo varchar(5), 
@nombres varchar(50),
@apellidos varchar(100), 
@correo varchar(100),
@estado int
as
begin
insert into clientes values (@codigo, @nombres, @apellidos, @correo, @estado)
end
go
create procedure proc_actualizar
@codigo varchar(5), 
@nombres varchar(50),
@apellidos varchar(100), 
@correo varchar(100)
as
begin
update clientes set  nombres=@nombres, apellidos=@apellidos, correo=@correo
where codigo=@codigo
end
go
create procedure proc_consultar
@codigo varchar(5)
as
begin
select codigo, nombres, apellidos, correo from clientes
where codigo = @codigo
end
go
create procedure proc_listar
@apellidos varchar(100)
as
begin
select codigo, nombres, apellidos, correo from clientes
where estado =1 and apellidos like @apellidos + '%'
end
go
create procedure proc_eliminar
@codigo varchar(5),
@estado int
as
begin
update clientes set estado = @estado
where codigo = @codigo
end
SELECT * FROM clientes;