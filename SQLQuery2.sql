CREATE PROCEDURE AgregarEncuesta
    @Nombre NVARCHAR(50),
    @Edad INT,
    @CorreoElectronico NVARCHAR(100),
    @PartidoPolitico NVARCHAR(50)
AS
BEGIN
    INSERT INTO Encuestas (Nombre, Edad, CorreoElectronico, PartidoPolitico)
    VALUES (@Nombre, @Edad, @CorreoElectronico, @PartidoPolitico);
END;
