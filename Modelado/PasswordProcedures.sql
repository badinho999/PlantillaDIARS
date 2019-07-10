Use DBDiags
go

/*En HashTable*/
/*Contrase�a segura*/
Create Proc SP_NewHash
(
	@prmstrHashCode nvarchar(350)
)
as
begin
	Insert Into Hashtable(HashCode)
	Values(@prmstrHashCode)
end
GO

/*En PasswordAccount*/
/*Crea contrase�a original*/
Alter Proc SP_NewPassword
(
	/*Password original*/
	@prmstrPasswordstring nvarchar(350),
	/*Hash*/
	@prmstrHashCode nvarchar(350)
)
as
begin
	Insert Into PasswordAccount(Passwordstring,HashCode)
	Values
	(
		@prmstrPasswordstring,
		@prmstrHashCode
	)
end
go

/*En Account hash table*/
/*Enlaza con la cuenta*/
Create Proc SP_EnlazarHashCuenta
(
	@prmstrNombreUsuario nvarchar(125),
	@prmstrHashCode nvarchar(350)
)
as
begin
	Insert into AccountHashTable(HashCode,NombreUsuario,Activa)
	Values
	(
		@prmstrHashCode,
		@prmstrNombreUsuario,
		1
	)
end
GO

/*BuscaContrase�a*/
Alter Proc SP_BuscarPassword
(
	@prmstrNombreUsuario nvarchar(125),
	@prmstrHashCode nvarchar(350)
)
as
begin
	Select hs.HashCode
	From AccountHashTable aht inner join Account acc on(aht.NombreUsuario=acc.NombreUsuario)
	inner join Hashtable hs on(aht.HashCode=hs.HashCode)
	Where hs.HashCode = @prmstrHashCode and acc.NombreUsuario = @prmstrNombreUsuario and aht.Activa = 1
end
go

Alter Proc SP_BuscarPasswordSignUp
as
begin
	Select HashCode
	From Hashtable
end

Create Proc [dbo].[SP_BuscarPasswordSignUp]
as
begin
	Select HashCode
	From Hashtable
end

Create Proc [dbo].[SP_ActualizarEstado]
(
	@prmstrNombreUsuario nvarchar(125),
	@prmstrHashCode nvarchar(350)
)
as
begin
	Update AccountHashTable
	set Activa = 0
	where NombreUsuario = @prmstrNombreUsuario AND HashCode = @prmstrHashCode
end