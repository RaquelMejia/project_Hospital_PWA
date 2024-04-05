CREATE DATABASE dbHospital
go

use dbHospital
go

CREATE TABLE Pacientes(
PacienteID int primary key identity(1,1),
NombreCompleto varchar (50),
Edad int,
Dui varchar(10),
Contacto varchar(50)
)
go

CREATE TABLE Habitaciones(
HabitacionID  int primary key identity(1,1),
NumeroHabitacion varchar(10)
)
go

CREATE TABLE Medicamentos(
MedicamentoID int primary key identity(1,1),
Nombre varchar(50),
Descripcion varchar(255)
)
go

CREATE TABLE EspecialidadDoctor(
EspecialidadID int primary key identity(1,1),
NombreEspecialidad varchar(50),
DescripcionEspecialidad varchar(255)
)
go

CREATE TABLE RegistroHabitaciones(
RegistroHabitacionID int primary key identity(1,1),
HabitacionID int foreign key references Habitaciones (HabitacionID),
PacienteID int foreign key references Pacientes (PacienteID)
)
go

CREATE TABLE Doctores(
DoctorID int primary key identity(1,1),
NombreCompleto varchar(50),
EspecialidadID int foreign key references EspecialidadDoctor (EspecialidadID),
Dui varchar(10),
Contacto varchar(50)
)
go

CREATE TABLE Consultas(
ConsultaID int primary key identity(1,1),
PacienteID int foreign key references Pacientes (PacienteID),
DoctorID int foreign key references Doctores (DoctorID),
Diagnostico varchar(255),
MedicamentoID int foreign key references Medicamentos (MedicamentoID),
FechaConsulta datetime
)
go

--------------------- Procesos almacenados -------------------------

---- Pacientes -----------------------------------------------------------------------------

-- select
CREATE PROCEDURE sp_select_paciente
AS
BEGIN
	select * from Pacientes
END
GO

-- select id
CREATE PROCEDURE sp_select_byId_paciente
(
@PacienteID INT
)
AS
BEGIN
	select * from Pacientes where PacienteID = @PacienteID
END
GO

-- insert
CREATE PROCEDURE sp_insert_paciente
(
@NombreCompleto varchar (50),
@Edad int,
@Dui varchar(10),
@Contacto varchar(50)
)
AS
BEGIN 
	insert into Pacientes
	values (@NombreCompleto, @Edad, @Dui, @Contacto)
END
GO

-- update
CREATE PROCEDURE sp_update_paciente
(
@PacienteID int,
@NombreCompleto varchar (50),
@Edad int,
@Dui varchar(10),
@Contacto varchar(50)
)
AS
BEGIN 
	UPDATE Pacientes
	SET NombreCompleto = @NombreCompleto, 
		Edad = @Edad,
		Dui = @Dui,
		Contacto = @Contacto
	WHERE PacienteID = @PacienteID
END
GO

-- delete
CREATE PROCEDURE sp_delete_paciente
@PacienteID int
AS
BEGIN
	delete from Pacientes where PacienteID = @PacienteID
END
GO

-------------------------------------------------------------------------------------
---- Habitaciones
-- select
CREATE PROCEDURE sp_select_habitaciones
AS
BEGIN
	select * from Habitaciones
END
GO

-- select id
CREATE PROCEDURE sp_select_byId_habitaciones
(
@HabitacionID INT
)
AS
BEGIN
	select * from Habitaciones where HabitacionID = @HabitacionID
END
GO

-- insert
CREATE PROCEDURE sp_insert_Habitacion
(
@NumeroHabitacion varchar(10)
)
AS
BEGIN 
	insert into Habitaciones
	values (@NumeroHabitacion)
END
GO

-- update
CREATE PROCEDURE sp_update_habitaciones
(
@HabitacionID  int,
@NumeroHabitacion varchar(10)
)
AS
BEGIN 
	UPDATE Habitaciones
	SET NumeroHabitacion = @NumeroHabitacion
	WHERE HabitacionID = @HabitacionID
END
GO

-- delete
CREATE PROCEDURE sp_delete_habitaciones
@HabitacionID  int
AS
BEGIN
	delete from Habitaciones where HabitacionID = @HabitacionID
END
GO

------------------------------------------------------------------------------------------------
---- Medicamentos
--- insert
CREATE PROCEDURE sp_insert_medicamentos
(
@Nombre varchar(50),
@Descripcion varchar(255)
)
AS
BEGIN
    INSERT INTO Medicamentos VALUES (@Nombre, @Descripcion)
END
go

---- select 
CREATE PROCEDURE sp_select_medicamentos
AS
BEGIN
    SELECT * FROM Medicamentos
END
go

---- select byID
CREATE PROCEDURE sp_select_byId_medicamentos
(
@MedicamentoID int
)
AS
BEGIN
    SELECT * FROM Medicamentos WHERE MedicamentoID = @MedicamentoID
END
go

---- update
CREATE PROCEDURE sp_update_medicamentos
(
@MedicamentoID int,
@Nombre varchar(50),
@Descripcion varchar(255)
)
AS
BEGIN
    UPDATE Medicamentos
    SET Nombre = @Nombre, Descripcion = @Descripcion
    WHERE MedicamentoID = @MedicamentoID
END
go

---- delete
CREATE PROCEDURE sp_delete_medicamentos
(
@MedicamentoID int
)
AS
BEGIN
    DELETE FROM Medicamentos
    WHERE MedicamentoID = @MedicamentoID
END
GO


------------------------------------------------------------------------------------------------
---- EspecialidadDoctor

-- insert
CREATE PROCEDURE sp_insert_especialidadDoctor
(
@NombreEspecialidad varchar(50),
@DescripcionEspecialidad varchar(255)
)
AS
BEGIN
    INSERT INTO EspecialidadDoctor
    VALUES (@NombreEspecialidad, @DescripcionEspecialidad)
END
GO

-- select
CREATE PROCEDURE sp_select_especialidadDoctor
AS
BEGIN
    SELECT * FROM EspecialidadDoctor
END
GO

-- select ById
CREATE PROCEDURE sp_select_byId_especialidadDoctor
(
@EspecialidadID int
)
AS
BEGIN
    SELECT * FROM EspecialidadDoctor WHERE EspecialidadID = @EspecialidadID
END
GO

-- update
CREATE PROCEDURE sp_update_especialidadDoctor
(
@EspecialidadID int,
@NombreEspecialidad varchar(50),
@DescripcionEspecialidad varchar(255)
)
AS
BEGIN
    UPDATE EspecialidadDoctor
    SET NombreEspecialidad = @NombreEspecialidad, DescripcionEspecialidad = @DescripcionEspecialidad
    WHERE EspecialidadID = @EspecialidadID
END
GO

-- delete
CREATE PROCEDURE sp_delete_especialidadDoctor
(
@EspecialidadID int
)
AS
BEGIN
    DELETE FROM EspecialidadDoctor
    WHERE EspecialidadID = @EspecialidadID
END
GO

------------------------------------------------------------------------------------------------
---- RegistroHabitacion

-- insert
CREATE PROCEDURE sp_insert_registroHabitaciones
(
@HabitacionID int,
@PacienteID int
)
AS
BEGIN
    INSERT INTO RegistroHabitaciones
    VALUES (@HabitacionID, @PacienteID)
END
go

--select
CREATE PROCEDURE sp_select_registroHabitaciones
AS
BEGIN
    SELECT * FROM RegistroHabitaciones
END
go

-- select id
CREATE PROCEDURE sp_select_byId_registroHabitaciones
(
@RegistroHabitacionID int
)
AS
BEGIN
    SELECT * FROM RegistroHabitaciones WHERE RegistroHabitacionID = @RegistroHabitacionID
END
go

-- update
CREATE PROCEDURE sp_update_registroHabitaciones
(
@RegistroHabitacionID int,
@HabitacionID int,
@PacienteID int
)
AS
BEGIN
    UPDATE RegistroHabitaciones
	SET HabitacionID = @HabitacionID,
		PacienteID = @PacienteID
	WHERE RegistroHabitacionID = @RegistroHabitacionID
END
GO

-- delete
CREATE PROCEDURE sp_delete_registroHabitaciones
(
@RegistroHabitacionID int
)
AS
BEGIN
    DELETE FROM RegistroHabitaciones WHERE RegistroHabitacionID = @RegistroHabitacionID
END
GO

------------------------------------------------------------------------------------------------
---- Doctor

-- insert
CREATE PROCEDURE sp_insertar_doctor
(
@NombreCompleto varchar(50),
@EspecialidadID int,
@Dui varchar(10),
@Contacto varchar(50)
)
AS
BEGIN
    INSERT INTO Doctores
    VALUES (@NombreCompleto, @EspecialidadID, @Dui, @Contacto)
END
go

-- select
CREATE PROCEDURE sp_select_doctor
AS
BEGIN
    SELECT * FROM Doctores
END
GO

-- select byId
CREATE PROCEDURE sp_select_byId_doctor
(
@DoctorID int
)
AS
BEGIN
    SELECT * FROM Doctores WHERE DoctorID = @DoctorID
END
GO

-- update
CREATE PROCEDURE sp_update_doctor
(
@DoctorID int,
@NombreCompleto varchar(50),
@EspecialidadID int,
@Dui varchar(10),
@Contacto varchar(50)
)
AS
BEGIN
    UPDATE Doctores
    SET NombreCompleto = @NombreCompleto, EspecialidadID = @EspecialidadID, Dui = @Dui, Contacto = @Contacto
    WHERE DoctorID = @DoctorID
END
GO

-- delete
CREATE PROCEDURE sp_delete_doctor
(
@DoctorID int
)
AS
BEGIN
    DELETE FROM Doctores
    WHERE DoctorID = @DoctorID
END
GO

------------------------------------------------------------------------------------------------
---- Consulta

-- insert
CREATE PROCEDURE sp_insert_consulta
(
@PacienteID int,
@DoctorID int,
@Diagnostico varchar(255),
@MedicamentoID int,
@FechaConsulta datetime
)
AS
BEGIN
    INSERT INTO Consultas
    VALUES (@PacienteID, @DoctorID, @Diagnostico, @MedicamentoID, @FechaConsulta)
END
go

-- select
CREATE PROCEDURE sp_select_consulta
AS
BEGIN
    SELECT * FROM Consultas
END
go

-- select byId
CREATE PROCEDURE sp_select_byId_consulta
(
@ConsultaID int
)
AS
BEGIN
    SELECT * FROM Consultas WHERE ConsultaID = @ConsultaID
END
go

-- update
CREATE PROCEDURE sp_update_consulta
(
@ConsultaID int,
@PacienteID int,
@DoctorID int,
@Diagnostico varchar(255),
@MedicamentoID int,
@FechaConsulta datetime
)
AS
BEGIN
    UPDATE Consultas
    SET PacienteID = @PacienteID, DoctorID = @DoctorID, Diagnostico = @Diagnostico, MedicamentoID = @MedicamentoID, FechaConsulta = @FechaConsulta
    WHERE ConsultaID = @ConsultaID
END
GO

-- delete
CREATE PROCEDURE sp_delete_consulta
(
@ConsultaID int
)
AS
BEGIN
    DELETE FROM Consultas
    WHERE ConsultaID = @ConsultaID
END

-- pruebas --

/*
execute sp_insert_paciente 'Williams ortiz', 22, '0000000-0','2134-4567'
execute sp_select_paciente
execute sp_select_byId_paciente 1
execute sp_update_paciente 1, 'Williams Ortiz', 22, '0000000-0','2134-4567'
execute sp_delete_paciente 1
*/

/*
execute sp_insert_Habitacion 'A3'
execute sp_select_habitaciones
execute sp_select_byId_habitaciones 1
execute sp_update_habitaciones 1, 'A-1'
execute sp_delete_habitaciones 1
*/

/*
execute sp_insert_medicamentos 'Ibuprofeno', 'ibuprofeno de clove'
execute sp_select_medicamentos
execute sp_select_byId_medicamentos 1
execute sp_update_medicamentos 1, 'Ibuprofeno 1', 'ibuprofeno de clove 1'
execute sp_delete_medicamentos 1
*/

/*
execute sp_insert_especialidadDoctor 'Cirujano', 'Cirujano plastico 2'
execute sp_select_especialidadDoctor
execute sp_select_byId_especialidadDoctor 1
execute sp_update_especialidadDoctor 1,'Cirujano', 'Cirujano plastico 1'
execute sp_delete_especialidadDoctor 1
*/

/*
execute sp_insert_registroHabitaciones 2,1
execute sp_select_registroHabitaciones
execute sp_select_byId_registroHabitaciones 1
execute sp_update_registroHabitaciones 1, 3, 2
execute sp_delete_registroHabitaciones 1
*/

/*
execute sp_insertar_doctor 'Ariel Chavez', 2, '1111111-1', '1234-9876'
execute sp_select_doctor
execute sp_select_byId_doctor 2
execute sp_update_doctor 2, 'Cristian Chavez', 2, '1111111-1', '1234-9876'
execute sp_delete_doctor 2
*/

/*
execute sp_insert_consulta 1, 3, 'jajaja', 3, '12-12-2023';
execute sp_select_consulta
execute sp_select_byId_consulta 2
execute sp_update_consulta 1, 1, 3, 'modificate', 3, '12-12-2023';
execute sp_delete_consulta 1
*/