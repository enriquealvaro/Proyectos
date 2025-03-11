Create Database Coparental;
Use Coparental;
-- Tabla Usuarios
CREATE TABLE usuarios (
    Id_Usuario INT AUTO_INCREMENT PRIMARY KEY,
    Rol VARCHAR(50) NOT NULL,
    Genero VARCHAR(50) NOT NULL,
    Nombre VARCHAR(100) NOT NULL,
    Apellidos VARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL UNIQUE,
    Password VARCHAR(255) NOT NULL,
    Codigo_Compartido VARCHAR(8) DEFAULT NULL
);


-- Tabla Grupos Familiares
CREATE TABLE grupos_familiares (
    id_grupo INT AUTO_INCREMENT PRIMARY KEY,
    codigo_compartido VARCHAR(8) UNIQUE NOT NULL
);

-- Tabla Intermedia Usuarios ↔ Grupos Familiares
CREATE TABLE grupo_usuario (
    id_grupo_usuario INT AUTO_INCREMENT PRIMARY KEY,
    id_grupo INT NOT NULL,
    id_usuario INT NOT NULL,
    FOREIGN KEY (id_grupo) REFERENCES grupos_familiares(id_grupo),
    FOREIGN KEY (id_usuario) REFERENCES usuarios(id_usuario),
    UNIQUE (id_grupo, id_usuario)
);

-- Tabla Hijos
CREATE TABLE hijos (
    id_hijo INT AUTO_INCREMENT PRIMARY KEY,
    id_grupo INT NOT NULL,
    nombre VARCHAR(100) NOT NULL,
    fecha_nacimiento DATE,
    FOREIGN KEY (id_grupo) REFERENCES grupos_familiares(id_grupo)
);

-- Tabla Calendario (Eventos)
CREATE TABLE calendario (
    id_evento INT AUTO_INCREMENT PRIMARY KEY,
    id_grupo INT NOT NULL,
    id_hijo INT NOT NULL,
    id_usuario INT NOT NULL,
    titulo VARCHAR(100) NOT NULL,
    descripcion TEXT,
    fecha DATE NOT NULL,
    hora TIME,
    FOREIGN KEY (id_grupo) REFERENCES grupos_familiares(id_grupo),
    FOREIGN KEY (id_hijo) REFERENCES hijos(id_hijo),
    FOREIGN KEY (id_usuario) REFERENCES usuarios(id_usuario)
);

-- Tabla Gastos
CREATE TABLE gastos (
    id_gasto INT AUTO_INCREMENT PRIMARY KEY,
    id_grupo INT NOT NULL,
    id_hijo INT NOT NULL,
    id_usuario INT NOT NULL,
    concepto VARCHAR(100) NOT NULL,
    importe DECIMAL(10,2) NOT NULL,
    fecha DATE NOT NULL,
    descripcion TEXT,
    FOREIGN KEY (id_grupo) REFERENCES grupos_familiares(id_grupo),
    FOREIGN KEY (id_hijo) REFERENCES hijos(id_hijo),
    FOREIGN KEY (id_usuario) REFERENCES usuarios(id_usuario)
);