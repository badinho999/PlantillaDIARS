Use DBDiags
go

Create Proc SP_GenerarBitacora
(
	@prmstrAccountID nvarchar(125)
)
as
begin
	Insert Into Bitacora(Ingreso,Salida,AccountID)
	Values
	(
		convert(varchar, getdate(), 0),
		null,
		@prmstrAccountID
	)
end
go

Create Proc SP_GenerarSalida
(
	@prmstrSalida datetime,
	@prmintBitacoraID int
)
as
begin
	Update Bitacora
	set Salida = @prmstrSalida
	Where BitacoraID = @prmintBitacoraID
end
go

Create Proc SP_MostrarBitacora
(
	@prmstrAccountID nvarchar(125)
)
as
begin
	Select * from Bitacora
	Where AccountID = @prmstrAccountID
	Order by Cast(Ingreso as datetime) desc
end
go

Select Cast(GETDATE() as datetime)

