USE [CS6-3]

----------/// CREACION DE TABLAS ///---------------


-------------/// Tabla Propietario ///--------------

CREATE TABLE PROPIETARIO (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    DNI VARCHAR(10) UNIQUE,
    NOMBRES VARCHAR(100),
    APELLIDOS VARCHAR(100),
    CORREO VARCHAR(100),
    TELEFONO VARCHAR(20),
    DIRECCION VARCHAR(200));

------------/// Tabla Vehiculo ///-------------

CREATE TABLE VEHICULO (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    PLACA VARCHAR(8) UNIQUE,
    VALOR DECIMAL(10,2), 
    AÑO INT,
    CILINDRAJE INT, 
    MODELO VARCHAR(50), 
	COLOR VARCHAR(100),
	ID_PROPIETARIO INT FOREIGN KEY REFERENCES PROPIETARIO(ID));

----------/// Tabla Deuda ///-----------

CREATE TABLE DEUDA (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    TOTAL DECIMAL(10,2),
    ID_VEHICULO INT FOREIGN KEY REFERENCES VEHICULO(ID));

---------/// Tabla Pagos ///--------------

CREATE TABLE PAGOS (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    PAGADO BIT DEFAULT 0, -- Columna tipo booleano (0 = No pagado, 1 = Pagado)
    ID_DEUDA INT FOREIGN KEY REFERENCES DEUDA(ID));


-------------------/// PROCEDIEMIENTOS ///-----------------

--        /// Procedimientos de Propietario///

-- Procedimiento para insertar un propietario
CREATE PROCEDURE InsertarPropietario
    @DNI VARCHAR(10),
    @NOMBRES VARCHAR(100),
    @APELLIDOS VARCHAR(100),
    @CORREO VARCHAR(100),
    @TELEFONO VARCHAR(20),
    @DIRECCION VARCHAR(200)
AS
BEGIN
    INSERT INTO PROPIETARIO (DNI, NOMBRES, APELLIDOS, CORREO, TELEFONO, DIRECCION)
    VALUES (@DNI, @NOMBRES, @APELLIDOS, @CORREO, @TELEFONO, @DIRECCION);
END


-- Procedimiento para modificar un propietario
CREATE PROCEDURE ModificarPropietario
    @DNI VARCHAR(10),
    @NOMBRES VARCHAR(100),
    @APELLIDOS VARCHAR(100),
    @CORREO VARCHAR(100),
    @TELEFONO VARCHAR(20),
    @DIRECCION VARCHAR(200)
AS
BEGIN
    UPDATE PROPIETARIO
    SET NOMBRES = @NOMBRES,
        APELLIDOS = @APELLIDOS,
        CORREO = @CORREO,
        TELEFONO = @TELEFONO,
        DIRECCION = @DIRECCION
    WHERE DNI = @DNI;
END


-- Procedimiento para eliminar un propietario
CREATE PROCEDURE EliminarPropietario
    @DNI VARCHAR(10)
AS
BEGIN
    DECLARE @ID_PROPIETARIO INT
    DECLARE @ID_VEHICULO INT

    -- Obtener el ID del propietario basado en su DNI
    SELECT @ID_PROPIETARIO = ID 
    FROM PROPIETARIO 
    WHERE DNI = @DNI;

    -- Eliminar los pagos relacionados con las deudas de los vehículos del propietario
    DELETE FROM PAGOS
    WHERE ID_DEUDA IN (
        SELECT D.ID 
        FROM DEUDA D
        INNER JOIN VEHICULO V ON D.ID_VEHICULO = V.ID
        WHERE V.ID_PROPIETARIO = @ID_PROPIETARIO
    );

    -- Eliminar las deudas relacionadas con los vehículos del propietario
    DELETE FROM DEUDA
    WHERE ID_VEHICULO IN (
        SELECT ID 
        FROM VEHICULO 
        WHERE ID_PROPIETARIO = @ID_PROPIETARIO
    );

    -- Eliminar los vehículos relacionados con el propietario
    DELETE FROM VEHICULO 
    WHERE ID_PROPIETARIO = @ID_PROPIETARIO;

    -- Eliminar el propietario
    DELETE FROM PROPIETARIO
    WHERE DNI = @DNI;
END


-- Procedimiento para buscar un propietario por su DNI
CREATE PROCEDURE BuscarPropietarioPorDNI
    @DNI VARCHAR(10)
AS
BEGIN
    SELECT ID, DNI, NOMBRES, APELLIDOS, CORREO, TELEFONO, DIRECCION
    FROM PROPIETARIO
    WHERE DNI = @DNI;
END


--       /// Procedimientos de Vehiculos ///

-- Procedimiento para insertar un vehículo
CREATE PROCEDURE InsertarVehiculo
    @PLACA VARCHAR(8),
    @VALOR DECIMAL(10,2),
    @AÑO INT,
    @CILINDRAJE INT,
    @MODELO VARCHAR(50),
    @COLOR VARCHAR(100),
    @DNI_PROPIETARIO VARCHAR(10)
AS
BEGIN
    DECLARE @ID_PROPIETARIO INT
    SELECT @ID_PROPIETARIO = ID FROM PROPIETARIO WHERE DNI = @DNI_PROPIETARIO
    INSERT INTO VEHICULO (PLACA, VALOR, AÑO, CILINDRAJE, MODELO, COLOR, ID_PROPIETARIO)
    VALUES (@PLACA, @VALOR, @AÑO, @CILINDRAJE, @MODELO, @COLOR, @ID_PROPIETARIO);
END


-- Procedimiento para modificar un vehículo --
CREATE PROCEDURE ModificarVehiculo
    @Placa VARCHAR(10),
    @Valor DECIMAL(18, 2),
    @Año INT,
    @Cilindraje INT,
    @Modelo VARCHAR(50),
    @Color VARCHAR(50),
    @ID_Propietario INT
AS
BEGIN
    UPDATE Vehiculo
    SET 
        Valor = @Valor,
        Año = @Año,
        Cilindraje = @Cilindraje,
        Modelo = @Modelo,
        Color = @Color,
        ID_Propietario = @ID_Propietario
    WHERE Placa = @Placa;
END


-- Procedimiento para eliminar un vehículo --
CREATE PROCEDURE EliminarVehiculo
    @PLACA VARCHAR(8)
AS
BEGIN
    DECLARE @ID_VEHICULO INT;

    -- Obtener el ID del vehículo basado en su placa
    SELECT @ID_VEHICULO = ID 
    FROM VEHICULO 
    WHERE PLACA = @PLACA;

    -- Eliminar los pagos relacionados con las deudas del vehículo
    DELETE FROM PAGOS
    WHERE ID_DEUDA IN (
        SELECT ID 
        FROM DEUDA 
        WHERE ID_VEHICULO = @ID_VEHICULO
    );

    -- Eliminar las deudas relacionadas con el vehículo
    DELETE FROM DEUDA
    WHERE ID_VEHICULO = @ID_VEHICULO;

    -- Eliminar el vehículo
    DELETE FROM VEHICULO
    WHERE PLACA = @PLACA;
END


-- Procedimiento para buscar un vehículo por su placa --
CREATE PROCEDURE BuscarVehiculoPorPlaca
    @PLACA VARCHAR(8)
AS
BEGIN
    SELECT V.PLACA, V.VALOR, V.AÑO, V.CILINDRAJE, V.MODELO, V.COLOR, P.DNI, P.NOMBRES, P.APELLIDOS, P.CORREO, P.TELEFONO, P.DIRECCION
    FROM VEHICULO V
    INNER JOIN PROPIETARIO P ON V.ID_PROPIETARIO = P.ID
    WHERE V.PLACA = @PLACA;
END


-- Procedimiento para verificar si el DNI del propietario Existe --
CREATE PROCEDURE VerificarDNI
    @DNI VARCHAR(10)
AS
BEGIN
    SELECT DNI
    FROM PROPIETARIO
    WHERE DNI = @DNI;
END


-- Procedimiento para recoger los datos del propietario ----
CREATE PROCEDURE RecogerDatosPropietario
    @DNI VARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;

    -- Seleccionar los datos del propietario junto con la deuda más reciente
    SELECT 
        P.DNI, 
        P.NOMBRES, 
        P.APELLIDOS, 
        P.CORREO, 
        ISNULL(D.TOTAL, 0) AS TOTAL
    FROM 
        PROPIETARIO P
    LEFT JOIN 
        (SELECT 
             V.ID_PROPIETARIO,
             D.TOTAL,
             ROW_NUMBER() OVER (PARTITION BY V.ID_PROPIETARIO ORDER BY D.ID DESC) AS RowNum
         FROM 
             VEHICULO V
         INNER JOIN 
             DEUDA D ON V.ID = D.ID_VEHICULO) D 
    ON 
        P.ID = D.ID_PROPIETARIO AND D.RowNum = 1
    WHERE 
        P.DNI = @DNI;
END;


--- Procedimiento para calcular la deuda ----
CREATE PROCEDURE CalcularDeudaVehicular
    @PLACA VARCHAR(8)
AS
BEGIN
    DECLARE @VALOR DECIMAL(10,2);
    DECLARE @CILINDRAJE INT;
    DECLARE @TOTAL DECIMAL(10,2);
    DECLARE @ID_VEHICULO INT;
    DECLARE @ID_DEUDA INT;

    SELECT @VALOR = VALOR, @CILINDRAJE = CILINDRAJE, @ID_VEHICULO = ID
    FROM VEHICULO
    WHERE PLACA = @PLACA;

    SET @TOTAL = (@VALOR * 0.015) + (@CILINDRAJE * 0.15);

    INSERT INTO DEUDA (TOTAL, ID_VEHICULO)
    VALUES (@TOTAL, @ID_VEHICULO);

    -- Obtener el ID de la deuda recién insertada
    SET @ID_DEUDA = SCOPE_IDENTITY();

    -- Insertar el registro en la tabla PAGOS con el estado "no pagado"
    INSERT INTO PAGOS (PAGADO, ID_DEUDA)
    VALUES (0, @ID_DEUDA);
END;


---- Procediemiento para obtener datos por placa ---
CREATE PROCEDURE ObtenerDatosVehiculoYDeudaPorPlaca
    @Placa VARCHAR(8)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        V.AÑO,
        V.MODELO,
        V.COLOR,
        D.TOTAL AS DEUDA,
        P.PAGADO
    FROM 
        VEHICULO V
    INNER JOIN 
        DEUDA D ON V.ID = D.ID_VEHICULO
    INNER JOIN 
        PAGOS P ON D.ID = P.ID_DEUDA
    WHERE 
        V.PLACA = @Placa;
END;


------ Procedimiento para actualizar deuda -----
CREATE PROCEDURE ActualizarEstadoDeudaPorPlaca
    @Placa VARCHAR(8)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @ID_Deuda INT;

    -- Obtener el ID de la deuda asociada a la placa del vehículo
    SELECT 
        @ID_Deuda = D.ID
    FROM 
        VEHICULO V
    INNER JOIN 
        DEUDA D ON V.ID = D.ID_VEHICULO
    WHERE 
        V.PLACA = @Placa;

    -- Actualizar el estado de la deuda a pagado en la tabla PAGOS
    UPDATE PAGOS
    SET PAGADO = 1
    WHERE ID_DEUDA = @ID_Deuda;

	-- Establecer el total de la deuda a cero
    UPDATE DEUDA
    SET TOTAL = 0
    WHERE ID = @ID_Deuda;
END;


select * from PAGOS
select * from DEUDA
select * from VEHICULO
select * from PROPIETARIO

