/*================================================
Consulta 1 - Para una Rutina-Ejercicio-Físico 
particular de usuario, las calorías máximas a
consumir en una receta, 
por ejemplo para una rutina LEVE
================================================*/

-- GetCaloriasMaxByRutina 2
CREATE PROC GetCaloriasMaxByRutina
	@rutinaId int
AS
declare @fechaActual Datetime

--Set @rutinaId = 2 --LEVE
Set @fechaActual = GETDATE()

Select  Usuario = U.nombre,
		CaloriasMaximas = ((S.CoefCalcCalorias +
							(S.CoefCalcCalPeso * U.Peso) +
							(S.CoefCalcCalAltura * U.Altura) -
							(S.CoefCalcCalEdad * (DATEDIFF(month, u.FechaNacimiento, @fechaActual ) / 12))) 
							* R.CoefCalcCalorias)
From Usuarios U
Inner Join Sexo S On S.Id = U.SexoId
Inner Join Rutinas R On R.Id = U.RutinaId And R.Id = @rutinaId

/*================================================
Consulta 2 - Mostrar todas las recetas con 
calificación 5 y de una determinada Temporada, 
por ejemplo verano
================================================*/

-- GetRecetasByTempoCalif 1, 5
CREATE PROC GetRecetasByTempoCalif
	@temporadaId int,
	@calificacion int
AS
--Set @temporadaId = 1 --VERANO
--Set @calificacion = 5

Select	R.*,
		SectorPiramide = PA.NombreGrupo,
		Creador = UR.Nombre
From Recetas R
Inner Join TemporadasRecetas TR On TR.RecetaId = R.Id 
	And TR.TemporadaId = @temporadaId 
Inner Join Usuarios UR ON UR.Id = R.UsuarioId
Inner Join PiramideAlimenticia PA ON PA.Id = R.PiramideId
Where R.CalificacionPromedio = @calificacion

/*================================================
Consulta 3 - Para un Dieta determinada mostrar 
las recetas disponibles, 
por ejemplo para un Vegano.
================================================*/

-- GetRecetasByDieta 1
ALTER PROC GetRecetasByDieta
	@dietaId int
AS
--Set @dietaId = 4 --VEGANO

--Select	R.Id, R.Nombre, R.Dificultad, R.TotalCalorias, 
--		R.PiramideId, R.UsuarioId, R.CalificacionPromedio,
--		SectorPiramide = PA.NombreGrupo,
--		Creador = U.Nombre
--From Recetas R
--Inner Join PiramideAlimenticia PA ON PA.Id = R.PiramideId
--inner Join Usuarios U on U.Id = R.UsuarioId and U.DietaId = @dietaId
--inner join Dietas D On D.Id = U.DietaId
--Inner Join IngredientesRecetas IR ON IR.RecetaId = R.Id
--Inner Join Ingredientes I On I.Id = IR.IngredienteId
--Where I.PreferenciaId in (Select DP.Preferencia_Id 
--							From DietasPreferencias DP
--							Where Dieta_Id = U.DietaId)
--Group By R.Id, R.Nombre, R.Dificultad, R.TotalCalorias,
--		R.PiramideId, R.UsuarioId, R.CalificacionPromedio,
--		PA.NombreGrupo, U.Nombre

Select R.Id, CantIngre = count(IR.Id)
into #tmpRecetasIngre
From Recetas R
Inner Join IngredientesRecetas IR ON IR.RecetaId = R.Id
Group By R.Id

Select R.Id, CantIngre = count(IR.Id)
into #tmpRecetasDieta
From Recetas R
Inner Join IngredientesRecetas IR ON IR.RecetaId = R.Id
Inner Join Ingredientes I On I.Id = IR.IngredienteId
Where I.PreferenciaId in (Select DP.Preferencia_Id 
							From DietasPreferencias DP
							Where Dieta_Id = @dietaId)
Group By R.Id

Select	R.*,
		SectorPiramide = PA.NombreGrupo,
		Creador = UR.Nombre
From #tmpRecetasIngre TRI
Inner Join #tmpRecetasDieta TRD ON TRD.Id = TRI.Id
	And TRD.CantIngre = TRI.CantIngre
Inner Join Recetas R On TRI.Id = R.Id
Inner Join Usuarios UR ON UR.Id = R.UsuarioId
Inner Join PiramideAlimenticia PA ON PA.Id = R.PiramideId

/*================================================
Consulta 4 - Según Preferencia Alimenticias 
del usuario, mostrar 3 recetas posibles, como ser
pescado o mariscos
================================================*/

-- GetRecetasByPreferencia 1
CREATE PROC GetRecetasByPreferencia
	@preferenciaID int
AS

Select R.ID
into #tmpRecetas
From Recetas R
Inner Join IngredientesRecetas IR ON IR.RecetaId = R.Id
Inner Join Ingredientes I On I.Id = IR.IngredienteId
Where I.PreferenciaId in (@preferenciaID) -- pescado o mariscos
Group By R.Id

Select Top 3	R.*,
		SectorPiramide = PA.NombreGrupo,
		Creador = UR.Nombre
From #tmpRecetas TR
Inner Join Recetas R On TR.Id = R.Id
Inner Join Usuarios UR ON UR.Id = R.UsuarioId
Inner Join PiramideAlimenticia PA ON PA.Id = R.PiramideId
Order by R.CalificacionPromedio desc

/*================================================
Consulta 5 - Para un Condimento en particular 
mostrar 5 recetas que lo contengan, por ejemplo
con Romero
================================================*/

--GetRecetasByCondimento 7
CREATE PROC GetRecetasByCondimento
	@condimentoId int
AS
--Set @condimentoId = 7 --Romero

Select R.ID
into #tmpRecetas
From Recetas R
Inner Join CondimentosRecetas CR On CR.Receta_Id = R.Id
Inner Join Condimentos C On C.Id = CR.Condimento_Id 
	And C.Id = @condimentoId
Group By R.Id

Select Top 5 R.*,
		SectorPiramide = PA.NombreGrupo,
		Creador = UR.Nombre
From #tmpRecetas TR
Inner Join Recetas R On TR.Id = R.Id
Inner Join Usuarios UR ON UR.Id = R.UsuarioId
Inner Join PiramideAlimenticia PA ON PA.Id = R.PiramideId
Order by R.CalificacionPromedio desc, R.Nombre

/*================================================
Consulta 6 - Para un determinado sexo y complexión 
determinada, mostrar las 10 recetas con una 
calificación determinada, por ejemplo sexo 
masculino complexión mediana y calificación 
de receta 3.
================================================*/

-- GetRecetasBySexComplex 1, 2, 3
CREATE PROC GetRecetasBySexComplex
	@sexoId int,
	@complexionId int,
	@calificacion int
AS
--Set @sexoId = 1 --Hombre
--Set @complexionId = 2 --Mediana
--Set @calificacion = 3

Select R.Id
into #tmpRecetas
From Recetas R
Inner Join Calificaciones Ca ON Ca.RecetaId = R.Id
	And Ca.Valor = @calificacion
Inner Join Usuarios U On U.Id = Ca.UsuarioId 
	And U.ComplexionId = @complexionId
	And U.SexoId = @sexoId
Group By R.Id

Select Top 10 R.*,
		SectorPiramide = PA.NombreGrupo,
		Creador = UR.Nombre
From #tmpRecetas TR
Inner Join Recetas R On TR.Id = R.Id
Inner Join Usuarios UR ON UR.Id = R.UsuarioId
Inner Join PiramideAlimenticia PA ON PA.Id = R.PiramideId
Order by R.CalificacionPromedio desc, R.Nombre

/*================================================
Consulta 7 - Según Grupo Alimenticio de la 
Pirámide alimentaria mostrar 5 recetas, 
por ejemplo para el grupo de lácteos
================================================*/

-- GetRecetasByPiramide 2
CREATE PROC GetRecetasByPiramide
	@piramideId int
AS
--Set @piramideId = 2 --Lacteos, Leguminosas y Animales

Select Top 10 R.*,
		Creador = UR.Nombre
From Recetas R
Inner Join Usuarios UR ON UR.Id = R.UsuarioId
Where R.PiramideId = @piramideId

/*
==============================================================================
================================ ESTADISTICAS ================================
==============================================================================
*/

/*================================================
Estadísticas (por semana y por mes):
Según el sexo: tipos de receta más consultadas
================================================*/

-- GetEstadisticaBySexo 1 -- Mensual
-- GetEstadisticaBySexo 2 -- Semanal
ALTER PROC GetEstadisticaBySexo
	@tipo int
AS

Declare @fechaActual DateTime

Set @fechaActual = GETDATE()

IF(@tipo = 1)
BEGIN

	Select Sexo = S.Nombre, E.RecetaId, Consultas = Count(*)
	into #tmpEstBySexoM
	From Estadisticas E
	Inner Join Usuarios U On U.Id = E.UsuarioId
	Inner Join Sexo S On U.SexoId = S.Id
	Where DATEPART(MONTH, E.FechaHora) = DATEPART(MONTH, @fechaActual)
	Group By S.Nombre, E.RecetaId

	Select T.Sexo, Dieta = D.Nombre, T.Consultas
	From #tmpEstBySexoM T
	inner join Recetas R on R.Id = T.RecetaId
	inner Join Usuarios U on U.Id = R.UsuarioId
	inner join Dietas D On D.Id = U.DietaId
	Inner Join IngredientesRecetas IR ON IR.RecetaId = R.Id
	Inner Join Ingredientes I On I.Id = IR.IngredienteId
	Where I.PreferenciaId in (Select DP.Preferencia_Id 
								From DietasPreferencias DP
								Where Dieta_Id = U.DietaId)
	Group By T.Sexo, D.Nombre, T.Consultas

END
ELSE
BEGIN

	Select Sexo = S.Nombre, E.RecetaId, Consultas = Count(*)
	into #tmpEstBySexoS
	From Estadisticas E
	Inner Join Usuarios U On U.Id = E.UsuarioId
	Inner Join Sexo S On U.SexoId = S.Id
	Where DATEPART(week, E.FechaHora) = DATEPART(week, @fechaActual)
	Group By S.Nombre, E.RecetaId

	Select T.Sexo, Dieta = D.Nombre, T.Consultas
	From #tmpEstBySexoS T
	inner join Recetas R on R.Id = T.RecetaId
	inner Join Usuarios U on U.Id = R.UsuarioId
	inner join Dietas D On D.Id = U.DietaId
	Inner Join IngredientesRecetas IR ON IR.RecetaId = R.Id
	Inner Join Ingredientes I On I.Id = IR.IngredienteId
	Where I.PreferenciaId in (Select DP.Preferencia_Id 
								From DietasPreferencias DP
								Where Dieta_Id = U.DietaId)
	Group By T.Sexo, D.Nombre, T.Consultas

END

/*================================================
Estadísticas (por semana y por mes):
Consultas según nivel de dificultad de la receta
================================================*/

-- GetEstadisticaByDificultad 1 --Mensual
-- GetEstadisticaByDificultad 2 --Semanal
CREATE PROC GetEstadisticaByDificultad
	@tipo int
AS

Declare @fechaActual DateTime

Set @fechaActual = GETDATE()

IF(@tipo = 1)
BEGIN

	Select	Dificultad = (Case When R.Dificultad = 1 
							Then LTRIM(RTRIM(STR(R.Dificultad))) + ' Estrella'
							Else LTRIM(RTRIM(STR(R.Dificultad))) + ' Estrellas'
						End), 
			Consultas = Count(*)
	From Estadisticas E
	Inner Join Recetas R On R.Id = E.RecetaId
	Where DATEPART(MONTH, E.FechaHora) = DATEPART(MONTH,  @fechaActual)
	Group By R.Dificultad
	Order By R.Dificultad

END
ELSE
BEGIN

	Select	Dificultad = (Case When R.Dificultad = 1 
							Then LTRIM(RTRIM(STR(R.Dificultad))) + ' Estrella'
							Else LTRIM(RTRIM(STR(R.Dificultad))) + ' Estrellas'
						End), 
			Consultas = Count(*)
	From Estadisticas E
	Inner Join Recetas R On R.Id = E.RecetaId
	Where DATEPART(WEEK, E.FechaHora) = DATEPART(WEEK, @fechaActual)
	Group By R.Dificultad
	Order By R.Dificultad

END

/*================================================
Estadísticas (por semana y por mes):
Ranking de recetas más consultadas
================================================*/

-- GetEstadisticaByRanking 1 --Mensual
-- GetEstadisticaByRanking 2 --Semanal
CREATE PROC GetEstadisticaByRanking
	@tipo int
AS

Declare @fechaActual DateTime

Set @fechaActual = GETDATE()

IF(@tipo = 1)
BEGIN

	Select	R.Id, R.Nombre,
			Consultas = Count(*)
	From Estadisticas E
	Inner Join Recetas R On R.Id = E.RecetaId
	Where DATEPART(MONTH, E.FechaHora) = DATEPART(MONTH, @fechaActual)
	Group By R.Id, R.Nombre

END
ELSE
BEGIN

	Select	R.Id, R.Nombre,
			Consultas = Count(*)
	From Estadisticas E
	Inner Join Recetas R On R.Id = E.RecetaId
	Where DATEPART(WEEK, E.FechaHora) = DATEPART(WEEK, @fechaActual)
	Group By R.Id, R.Nombre

END