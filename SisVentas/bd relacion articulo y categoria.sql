use dbventap 
go 
create table categoria
(
idcategoria int primary key identity(1,1), 
nombre varchar(50) not null, 
descripcion varchar(256) null,
);
create table presentacion
(
idpresentacion int primary key identity(1,1), 
nombre varchar(50) not null, 
descripcion varchar(256) null, 
);
create table articulo 
(
idarticulo int primary key identity(1,1),
codigo varchar(50) not null, 
nombre varchar(50) not null, 
descripcion varchar(1024) null, 
imagen image null, 
idcategoria int not null, 
idpresentacion int not null, 
FOREIGN KEY (idcategoria) references categoria(idcategoria), 
FOREIGN KEY (idpresentacion) references presentacion(idpresentacion)
);
insert into presentacion (nombre,descripcion)values('Derivao del maiz','Maiz crujiente'); 
insert into categoria (nombre,descripcion)values('Cereales','Chococrispi'); 
insert into articulo (codigo,nombre,descripcion,imagen,idcategoria,idpresentacion)values('1','Reloj','smartwatch k60','jskdfls','1','1');
select * from categoria; 
select * from presentacion;
select * from articulo;
use dbventap
go
create table proveedor
(
idproveedor int primary key identity(1,1), 
razon_social varchar(150) not null, 
sector_comercial varchar(50) not null, 
tipo_documento varchar(20) not null, 
num_documento varchar(11) not null, 
direccion varchar(100) null, 
telefono varchar(50) null, 
email varchar(50) null, 
url varchar(100) null, 
); 

create table trabajador
(
idtrabajador int primary key identity(1,1), 
nombre varchar(20) not null, 
apellidos varchar(40) not null, 
sexo varchar(1) not null, 
fecha_nacimiento date not null, 
num_documento varchar(8) not null, 
direccion varchar(100) null, 
telefono varchar(10) null, 
email varchar(50) null, 
acceso varchar(20) not null, 
usuario varchar(20) not null, 
password varchar(20) not null, 
); 

create table ingreso 
(
idingreso int primary key identity(1,1), 
idtrabajador int not null, 
idproveedor int not null, 
fecha date not null, 
tipo_comprobante varchar(20) not null,
serie varchar(4) not null, 
correlativo varchar(7) not null, 
igv decimal(4,2) not null, 
FOREIGN KEY (idproveedor) references proveedor (idproveedor), 
FOREIGN KEY (idtrabajador) references trabajador(idtrabajador), 
);

create table detalle_ingreso( 
iddetalle_ingreso int primary key identity(1,1), 
idingreso int not null, 
idarticulo int not null, 
precio_compra money not null, 
precio_venta money not null, 
stock_inicial int not null, 
stock_actual int not null,
fecha_produccion date not null, 
fecha_vencimiento date not null,
FOREIGN KEY (idingreso) references ingreso(idingreso), 
FOREIGN KEY (idarticulo) references articulo(idarticulo), 
);
create table cliente 
(
idcliente int primary key identity(1,1),
nombre varchar(50) not null,
apellidos varchar(40) null, 
sexo varchar(1) null, 
fecha_nacimiento date null, 
tipo_documento varchar(20) not null, 
num_documento varchar(11) not null, 
direccion varchar(100) null, 
telefono varchar(10) null, 
email varchar(50) null,
);
create table venta
(
idventa int primary key identity(1,1),
idcliente int not null, 
idtrabajador int not null, 
fecha date not null, 
tipo_comprobante varchar(20) not null, 
serie varchar(4) not null, 
correlativo varchar(7) not null, 
igv decimal(4,2) not null,
FOREIGN KEY (idcliente) references cliente(idcliente), 
FOREIGN KEY (idtrabajador) references trabajador(idtrabajador),  
);
create table detalle_venta
(
iddetalleventa int primary key identity(1,1), 
idventa int not null, 
iddetalle_ingreso int not null, 
cantidad int not null, 
precio_Venta money not null, 
descuento money not null, 
FOREIGN KEY (idventa) references venta(idventa), 
FOREIGN KEY (iddetalle_ingreso) references detalle_ingreso(iddetalle_ingreso)
);








