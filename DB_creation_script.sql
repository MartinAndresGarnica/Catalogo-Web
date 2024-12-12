DROP DATABASE IF exists CATALOGO_WEB_DB;
Create DATABASE CATALOGO_WEB_DB;
USE CATALOGO_WEB_DB;

CREATE TABLE USUARIO (
	id_usuario int AUTO_INCREMENT primary key,
    nombre_usuario varchar(255) NOT NULL,
    apellido_usuario varchar(255) NOT NULL,
    email varchar(255) NOT NULL UNIQUE,
    pass varchar(255) NOT NULL,
    imagen varchar(500),
    administrador bool
);

CREATE TABLE MARCA (
	id_marca int auto_increment primary key,
    descripcion varchar(255) not null
);

CREATE TABLE CATEGORIA (
	id_categoria int auto_increment primary key,
    descripcion varchar(255) not null unique
);

CREATE TABLE ARTICULO (
	id_articulo int AUTO_INCREMENT primary key,
    codigo varchar(255) NOT NULL unique,
    nombre varchar (255) NOT NULL,
    descripcion varchar(1000),
    imagen varchar(500),
    precio decimal (10,2) NOT NULL CHECK(precio>0),
    id_marca INT NOT NULL,
    foreign key (id_marca) REFERENCES MARCA(id_marca),
    id_categoria int not null,
    foreign key (id_categoria) references CATEGORIA(id_categoria)
);

-- Poblar la tabla MARCA
INSERT INTO MARCA (descripcion)
VALUES 
    ('Samsung'),
    ('Apple'),
    ('Sony'),
    ('LG'),
    ('Xiaomi');

-- Poblar la tabla CATEGORIA
INSERT INTO CATEGORIA (descripcion)
VALUES 
    ('Smartphones'),
    ('Televisores'),
    ('Electrodomésticos'),
    ('Auriculares'),
    ('Laptops');

-- Poblar la tabla ARTICULO
INSERT INTO ARTICULO (codigo, nombre, descripcion, imagen, precio, id_marca, id_categoria)
VALUES 
    ('A001', 'iPhone 14', 'Último modelo de iPhone', 'Content/Images/Iphone-14.jpg', 999.99, 2, 1),
    ('A002', 'Samsung Galaxy S22', 'Teléfono de alta gama', 'Content/Images/samsungS22.jpeg', 899.99, 1, 1),
    ('A003', 'Sony Bravia 55"', 'Televisor inteligente 4K', '', 1200.00, 3, 2),
    ('A004', 'LG ThinQ Washing Machine', 'Lavarropas inteligente', '', 650.00, 4, 3),
    ('A005', 'Xiaomi Mi Headphones', 'Auriculares inalámbricos', '', 75.50, 5, 4),
    ('A006', 'MacBook Air M2', 'Laptop de última generación', '', 1299.99, 2, 5),
    ('A007', 'LG Gram 17"', 'Laptop ultraligera', '', 1100.00, 4, 5),
    ('A008', 'Samsung QLED TV', 'Televisor QLED 65"', '', 1400.00, 1, 2),
    ('A009', 'Xiaomi Smart Air Fryer', 'Freidora inteligente', '', 120.00, 5, 3),
    ('A010', 'Sony WH-1000XM5', 'Auriculares con cancelación de ruido', '', 300.00, 3, 4);
