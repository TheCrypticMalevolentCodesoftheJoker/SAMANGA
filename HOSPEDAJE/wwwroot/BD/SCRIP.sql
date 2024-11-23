-- Crear base de datos
CREATE DATABASE TIHotel;
GO
USE TIHotel;
GO
-- *******************************************
-- 1. Tabla de Roles
-- *******************************************
CREATE TABLE tbl_rol (
    id_rol INT PRIMARY KEY IDENTITY(1,1),
    rol VARCHAR(50) NOT NULL,
);
-- *******************************************
-- 2. Tabla de Usuarios (empleados)
-- *******************************************
CREATE TABLE tbl_usuario (
    id_usuario INT PRIMARY KEY IDENTITY(1,1),
    id_rol INT NOT NULL,
    nombre VARCHAR(100) NOT NULL,
	apellido VARCHAR(100) NOT NULL,
    correo VARCHAR(150) NOT NULL UNIQUE,
    contraseña VARCHAR(255) NOT NULL,
    estado CHAR(1) NOT NULL,
    FOREIGN KEY (id_rol) REFERENCES tbl_rol(id_rol)
);
CREATE TABLE tbl_detalle_usuario (
	id_detalle_usuario  INT PRIMARY KEY IDENTITY(1,1),
    id_usuario INT,
    imagen VARBINARY(MAX) NULL,
    fecha_contratacion DATE DEFAULT GETDATE(),
    genero CHAR(1) NULL,
    telefono VARCHAR(20) NULL,
    direccion VARCHAR(255) NULL,
    fecha_nacimiento DATE NULL,
    preferencias VARCHAR(500) NULL,
    estado_civil CHAR(1) NULL,
    redes_sociales VARCHAR(500) NULL,
    idioma VARCHAR(50) NULL,
    ocupacion VARCHAR(100) NULL,
    notas_adicionales VARCHAR(500) NULL,
    fecha_ultima_actualizacion DATETIME NULL,
    CONSTRAINT FK_detalle_usuario_usuario FOREIGN KEY (id_usuario) REFERENCES tbl_usuario(id_usuario)
);

-- *******************************************
-- 3. Tabla de Clientes
-- *******************************************
CREATE TABLE tbl_cliente (
    id_cliente INT PRIMARY KEY IDENTITY(1,1),
    nombre VARCHAR(100) NOT NULL,
	apellido VARCHAR(100) NOT NULL,
    correo VARCHAR(150) NOT NULL UNIQUE,
    contraseña VARCHAR(255) NOT NULL,
    estado CHAR(1) NOT NULL,
    fecha_registro DATETIME DEFAULT GETDATE(),
    fecha_ultima_modificacion DATETIME NULL
);
CREATE TABLE tbl_detalle_cliente (
	id_detalle_cliente INT PRIMARY KEY IDENTITY(1,1),
    id_cliente INT,
    imagen VARBINARY(MAX) NULL,
    genero CHAR(1) NULL,
    telefono VARCHAR(20) NULL,
    direccion VARCHAR(255) NULL,
    fecha_nacimiento DATE NULL,
    preferencias VARCHAR(500) NULL,
    estado_civil CHAR(1) NULL,
    redes_sociales VARCHAR(500) NULL,
    idioma VARCHAR(50) NULL,
    ocupacion VARCHAR(100) NULL,
    notas_adicionales VARCHAR(500) NULL,
    fecha_ultima_actualizacion DATETIME NULL, 
    CONSTRAINT FK_detalle_cliente_cliente FOREIGN KEY (id_cliente) REFERENCES tbl_cliente(id_cliente)
);

-- *******************************************
-- 4. Tabla de Habitaciones
-- *******************************************
CREATE TABLE tbl_estado (
    id_estado INT PRIMARY KEY IDENTITY(1,1),
    Estado VARCHAR(50) NOT NULL,
);
CREATE TABLE tbl_categoria (
    id_categoria INT PRIMARY KEY IDENTITY(1,1),
    Categoria VARCHAR(50) NOT NULL,
);
CREATE TABLE tbl_habitacion (
    id_habitacion INT PRIMARY KEY IDENTITY(1,1),
    id_categoria INT NOT NULL,
    id_estado INT NOT NULL,
    numero VARCHAR(10) NOT NULL,
    precio DECIMAL(10,2) NOT NULL,
    descripcion VARCHAR(255) NULL,
    FOREIGN KEY (id_categoria) REFERENCES tbl_categoria(id_categoria),
    FOREIGN KEY (id_estado) REFERENCES tbl_estado(id_estado)
);
CREATE TABLE tbl_detalle_habitacion (
	id_detalle_habitacion INT PRIMARY KEY IDENTITY(1,1),
    id_habitacion INT,
    tamanio_habitacion DECIMAL(5,2) NOT NULL,
    tipo_cama VARCHAR(50) NULL,
    numero_camas INT NOT NULL,
    capacidad_personas INT NOT NULL, 
    vistas VARCHAR(100) NULL,
    accesibilidad VARCHAR(100) NULL,
    tipo_bano VARCHAR(100) NULL,
    wifi VARCHAR(100) NULL,
    television VARCHAR(100) NULL,
    ducha VARCHAR(100) NULL,
    ventilador VARCHAR(100) NULL,
    calefaccion VARCHAR(100) NULL,
    aire_acondicionado VARCHAR(100) NULL,
    frigo_bar VARCHAR(100) NULL,
    piso VARCHAR(50) NULL,
    extras VARCHAR(255) NULL,
    servicios_adicionales VARCHAR(255) NULL,
    FOREIGN KEY (id_habitacion) REFERENCES tbl_habitacion(id_habitacion)
);
CREATE TABLE tbl_imagen_habitacion (
    id_imagen INT PRIMARY KEY IDENTITY(1,1),
    id_habitacion INT NOT NULL,
    url_imagen VARCHAR(255) NULL,
    FOREIGN KEY (id_habitacion) REFERENCES tbl_habitacion(id_habitacion)
);
CREATE TABLE tbl_mantenimiento_limpieza (
    id_man_limp INT PRIMARY KEY IDENTITY(1,1),
    id_habitacion INT NOT NULL,
    id_usuario INT NOT NULL,
    tipo_actividad CHAR(1) NOT NULL,
    estado CHAR(1) NOT NULL,
    fecha_inicio DATETIME NULL,
    fecha_fin DATETIME NULL,
    observaciones VARCHAR(500) NULL,
    fecha_creacion DATETIME DEFAULT GETDATE(),
    fecha_actualizacion DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (id_habitacion) REFERENCES tbl_habitacion(id_habitacion) ON DELETE CASCADE,
    FOREIGN KEY (id_usuario) REFERENCES tbl_usuario(id_usuario)
);

-- *******************************************
-- 5. Tabla de Reservas
-- *******************************************
CREATE TABLE tbl_reserva (
    id_reserva INT PRIMARY KEY IDENTITY(1,1),
    id_cliente INT NOT NULL,
    fecha_reserva DATETIME DEFAULT GETDATE(),
    fecha_entrada DATE NOT NULL,
    fecha_salida DATE NOT NULL,
    estado CHAR(1) NOT NULL,
    total_pago DECIMAL(10,2) NOT NULL,
    metodo_pago VARCHAR(50) NOT NULL,
    FOREIGN KEY (id_cliente) REFERENCES tbl_cliente(id_cliente)
);

CREATE TABLE tbl_detalle_reserva (
    id_reserva INT NOT NULL,
    id_habitacion INT NOT NULL,
    cantidad_personas INT NOT NULL,
    tipo_servicio VARCHAR(255) NULL,
    costo_servicio DECIMAL(10,2) NULL,
    pago_parcial DECIMAL(10,2) NULL,
    fecha_pago DATETIME NULL,
    estado_pago VARCHAR(20) NOT NULL,
    fecha_ultima_modificacion DATETIME NULL,
    PRIMARY KEY (id_reserva, id_habitacion),
    FOREIGN KEY (id_reserva) REFERENCES tbl_reserva(id_reserva) ON DELETE CASCADE,
    FOREIGN KEY (id_habitacion) REFERENCES tbl_habitacion(id_habitacion)
);

CREATE TABLE tbl_reporte_problema (
    id_problema INT PRIMARY KEY IDENTITY(1,1),
    id_habitacion INT NOT NULL,
    id_cliente INT NULL,
    descripcion VARCHAR(1000) NOT NULL,
    fecha_reporte DATETIME DEFAULT GETDATE(),
    estado CHAR(1) NOT NULL,
    fecha_resolucion DATETIME NULL,
    FOREIGN KEY (id_habitacion) REFERENCES tbl_habitacion(id_habitacion),
    FOREIGN KEY (id_cliente) REFERENCES tbl_cliente(id_cliente)
);

-- *******************************************
-- 6. Tabla de Lista de Espera
-- *******************************************
CREATE TABLE tbl_lista_espera (
    id_espera INT PRIMARY KEY IDENTITY(1,1),
    id_cliente INT NOT NULL,
    fecha_solicitud DATETIME DEFAULT GETDATE(),
    prioridad VARCHAR(20) NOT NULL,
    estado CHAR(1) NOT NULL,
    descripcion VARCHAR(100) NULL,
    FOREIGN KEY (id_cliente) REFERENCES tbl_cliente(id_cliente)
);