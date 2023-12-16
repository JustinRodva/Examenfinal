CREATE TABLE Encuestas (
    NumeroEncuesta INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(50) NOT NULL,
    Edad INT NOT NULL CHECK (Edad BETWEEN 18 AND 50),
    CorreoElectronico NVARCHAR(100) NOT NULL,
    PartidoPolitico NVARCHAR(50) NOT NULL CHECK (PartidoPolitico IN ('PLN', 'PUSC', 'PAC'))
);
