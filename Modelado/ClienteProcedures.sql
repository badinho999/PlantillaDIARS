USE [DBDiags]
GO
/****** Object:  StoredProcedure [dbo].[SP_CrearCliente]    Script Date: 26/06/2019 08:25:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER Proc [dbo].[SP_CrearCliente]
(
	@prmstrDni char(8),
	@prmstrApellidosCliente nvarchar(40),
	@prmstrFechaNacimiento datetime,
	@prmstrNombreCliente nvarchar(45),
	@prmcharSexo char(1)
)
as
begin
	Insert into Cliente(Dni,ApellidosCliente,FechaNacimiento,NombreCliente,Sexo)
	Values
	(
		@prmstrDni,
		@prmstrApellidosCliente,
		@prmstrFechaNacimiento,
		@prmstrNombreCliente,
		@prmcharSexo
	)
end
go

Create Proc SP_BuscarDni
(
	@prmstrDni char(8)
)
as
begin
	Select Dni
	From Cliente
	Where Dni = @prmstrDni
end
go

Create Proc SP_EliminarCliente
(
	@prmstrDni char(8)
)
as
begin
	Delete from Cliente
	Where Dni = @prmstrDni
end
go

DELETE FROM Account
GO
DELETE from Cliente
Where Dni = '12345678'
GO

Select * from Cliente c
inner join Account acc On(c.Dni=acc.Dni)

Select * from PasswordAccount

Select * from AccountHashTable


Delete from PasswordAccount

Delete From Hashtable

Select * from PasswordAccount
GO

Insert into AccountHashTable(Activa,HashCode,NombreUsuario)
Values
(
	1,
	'asasas',
	'gg'
)