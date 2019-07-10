use DBDiags
go

Alter Proc SP_CrearCuenta
(
	@prmstrEmail nvarchar(320),
	@prmstrTelefono char(9),
	@prmstrNombreUsuario nvarchar(125),
	@prmstrDni char(9) 
)
as
begin
	Insert into Account(Email,Fechacreacion,Telefono,NombreUsuario,Dni)
	Values
	(
		@prmstrEmail,
		CONVERT(varchar(10),GETDATE(),111),
		@prmstrTelefono,
		@prmstrNombreUsuario,
		@prmstrDni
	)
end
go

Create  Proc [dbo].[SP_BuscarCuenta]
(
	@prmstrNombreUsuario nvarchar(125),
	@prmstrHashCode nvarchar(350)
)
as
begin
	Select cli.ApellidosCliente,cli.FechaNacimiento,cli.NombreCliente,cli.Sexo,cli.Dni,
		   acc.Email,acc.Fechacreacion,acc.Telefono,acc.NombreUsuario
	From Account acc inner join Cliente cli on(acc.Dni = cli.Dni)
	inner join AccountHashTable pass on(acc.NombreUsuario=pass.NombreUsuario)
	inner join Hashtable hs on(pass.HashCode = hs.HashCode)
	Where acc.NombreUsuario = @prmstrNombreUsuario AND hs.HashCode = @prmstrHashCode AND pass.Activa = 1
end

Create Proc SP_BuscarEmail
(
	@prmstrEmail nvarchar(320)
)
as
begin
	Select Email
	From Account
	Where Email = @prmstrEmail
end
go

Create Proc SP_BuscarUsername
(
	@prmstrNombreUsuario nvarchar(125)
)
as
begin
	Select NombreUsuario 
	From Account
	Where NombreUsuario = @prmstrNombreUsuario
end
go



