/*================================================
Consulta 1 - Para una Rutina-Ejercicio-Físico 
particular de usuario, las calorías máximas a
consumir en una receta, 
por ejemplo para una rutina LEVE
================================================*/

declare @rutinaId int
declare @fechaActual Datetime

Set @rutinaId = 2 --LEVE
Set @fechaActual = GETDATE()

Select U.nombre,
		CaloriasMaximas = ((S.CoefCalcCalorias +
							(S.CoefCalcCalPeso * U.Peso) +
							(S.CoefCalcCalAltura * U.Altura * 100 ) -
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

declare @temporadaId int
declare @calificacion int

Set @temporadaId = 1 --VERANO
Set @calificacion = 5

Select R.*
From Recetas R
Inner Join Procedimientos P On P.RecetaId = R.Id
Inner Join CondimentosRecetas CR On CR.Receta_Id = R.Id
Inner Join Condimentos C On C.Id = CR.Condimento_Id
Inner Join IngredientesRecetas IR ON IR.RecetaId = R.Id
Inner Join Ingredientes I On I.Id = IR.IngredienteId
Inner Join TemporadasRecetas TR On TR.Receta_Id = R.Id 
	And TR.Temporada_Id = @temporadaId 
Inner Join Calificaciones C ON C.RecetaId = R.Id
	And C.Valor = @calificacion

/*================================================
Consulta 3 - Para un Dieta determinada mostrar 
las recetas disponibles, 
por ejemplo para un Vegano.
================================================*/

declare @dietaId int

Set @dietaId = 4 --VEGANO

Select *
From Recetas R
Inner Join Procedimientos P On P.RecetaId = R.Id
Inner Join CondimentosRecetas CR On CR.Receta_Id = R.Id
Inner Join Condimentos C On C.Id = CR.Condimento_Id
Inner Join IngredientesRecetas IR ON IR.RecetaId = R.Id
Inner Join Ingredientes I On I.Id = IR.IngredienteId
Where I.PreferenciaId in (Select DP.Preferencia_Id 
							From DietasPreferencias DP
							Where Dieta_Id = @dietaId)

/*================================================
Consulta 4 - Según Preferencia Alimenticias 
del usuario, mostrar 3 recetas posibles, como ser
pescado o mariscos
================================================*/

Select Top 3 *
From Recetas R
Inner Join Procedimientos P On P.RecetaId = R.Id
Inner Join CondimentosRecetas CR On CR.Receta_Id = R.Id
Inner Join Condimentos C On C.Id = CR.Condimento_Id
Inner Join IngredientesRecetas IR ON IR.RecetaId = R.Id
Inner Join Ingredientes I On I.Id = IR.IngredienteId
Where I.PreferenciaId in (1, 2) -- pescado o mariscos

/*================================================
Consulta 5 - Para un Condimento en particular 
mostrar 5 recetas que lo contengan, por ejemplo
con Romero
================================================*/

declare @condimentoId int

Set @condimentoId = 7 --Romero

Select Top 5 *
From Recetas R
Inner Join Procedimientos P On P.RecetaId = R.Id
Inner Join IngredientesRecetas IR ON IR.RecetaId = R.Id
Inner Join Ingredientes I On I.Id = IR.IngredienteId
Inner Join CondimentosRecetas CR On CR.Receta_Id = R.Id
Inner Join Condimentos C On C.Id = CR.Condimento_Id 
	And C.Id = @condimentoId

/*================================================
Consulta 6 - Para un determinado sexo y complexión 
determinada, mostrar las 10 recetas con una 
calificación determinada, por ejemplo sexo 
masculino complexión mediana y calificación 
de receta 3.
================================================*/

declare @sexoId int
declare @complexionId int
declare @calificacion int
declare @CaloriasMax decimal(18,4)
declare @CaloriasMin decimal(18,4)

Set @sexoId = 1 --Hombre
Set @complexionId = 2 --Mediana
Set @calificacion = 3
-- Preguntar como se calcula en base a Complexion y Sexo??
Set @CaloriasMin = 1500
Set @CaloriasMax = 2500

Select Top 10 *
From Recetas R
Inner Join Procedimientos P On P.RecetaId = R.Id
Inner Join IngredientesRecetas IR ON IR.RecetaId = R.Id
Inner Join Ingredientes I On I.Id = IR.IngredienteId
Inner Join CondimentosRecetas CR On CR.Receta_Id = R.Id
Inner Join Condimentos C On C.Id = CR.Condimento_Id
Inner Join Calificaciones C ON C.RecetaId = R.Id
	And C.Valor = @calificacion
Where R.TotalCalorias between @CaloriasMin And @CaloriasMax

/*================================================
Consulta 7 - Según Grupo Alimenticio de la 
Pirámide alimentaria mostrar 5 recetas, 
por ejemplo para el grupo de lácteos
================================================*/

declare @piramideId int

Set @piramideId = 2 --Lacteos, Leguminosas y Animales

Select Top 10 *
From Recetas R
Inner Join Procedimientos P On P.RecetaId = R.Id
Inner Join IngredientesRecetas IR ON IR.RecetaId = R.Id
Inner Join Ingredientes I On I.Id = IR.IngredienteId
Inner Join CondimentosRecetas CR On CR.Receta_Id = R.Id
Inner Join Condimentos C On C.Id = CR.Condimento_Id 
Where R.PiramideId = @piramideId
