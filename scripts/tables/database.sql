DROP DATABASE IF EXISTS monitoreo;

CREATE DATABASE monitoreo
    DEFAULT CHARACTER SET = 'utf8mb4';

USE monitoreo;

CREATE TABLE Laboratorio (
    id_laboratorio INT PRIMARY KEY AUTO_INCREMENT,
    nombre VARCHAR(100) NOT NULL,
    ubicacion VARCHAR(250)
);

CREATE TABLE ModelosPC (
    idModelo INT PRIMARY KEY AUTO_INCREMENT,
    modelo VARCHAR(85),
    marca VARCHAR(45),
    especs TEXT,
    ram INT NOT NULL DEFAULT 8
);

CREATE TABLE Computadoras (
    idPC INT PRIMARY KEY AUTO_INCREMENT,
    codigoInventario VARCHAR(45) UNIQUE NOT NULL,
    numero_serie VARCHAR(50) UNIQUE NOT NULL,
    id_laboratorio INT,
    idModelo INT,
    sistemaOperativo VARCHAR(50),
    CONSTRAINT fk_pc_lab FOREIGN KEY (id_laboratorio) REFERENCES Laboratorio(id_laboratorio),
    CONSTRAINT fk_pc_modelo FOREIGN KEY (idModelo) REFERENCES ModelosPC(idModelo)
);

CREATE TABLE Mediciones (
    idMedicion INT PRIMARY KEY AUTO_INCREMENT,
    idPC INT,
    macAddress VARCHAR(45) UNIQUE,
    fechaIngreso DATETIME,
    fechaArreglo DATETIME,
    fechaDesecho DATETIME,
    estado VARCHAR(25) DEFAULT 'Operativo',
    temperaturaCPU DECIMAL(5, 2),
    usoRAM DECIMAL(5, 2),
    CONSTRAINT fk_medicion_computadora 
        FOREIGN KEY (idPC) REFERENCES Computadoras(idPC)
        ON DELETE CASCADE
);