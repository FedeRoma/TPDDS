/*-------1----------*/

/* en codigo trabajamos con el id de la receta (variable: receta_id*/
/*busco ingredientes que su id sean los que consigo*/
select sum(caloriasPorcion) from dbo.IngredienteConjunto
where
id in (
/*Consigo los id de los ingredientes*/
select ingredienteID from dbo.IngredienteRecetaConjunto 
where 
recetaID = receta_id
)


 /*busco ingredientes que su id sean los que consigo*/
select sum(caloriasPorcion) from dbo.IngredienteConjunto
where
id in (
/*Consigo los id de los ingredientes*/
select ingredienteID from dbo.IngredienteRecetaConjunto 

)

/*-------2----------*/

/* en codigo trabajamos con el nombre de la temporada: nombreTemporada*/
select * from dbo.RecetaConjunto as receta, dbo.ClasificacionRecetaConjunto as clasificacion, dbo.CalificacionConjunto as calificacion
where
receta.id in
(select RecetaId from dbo.TemporadaConjunto
where
nombre = nombreTemporada)
and receta.Id = clasificacion.IdReceta
and clasificacion.idReceta = calificacion.Id
and calificacion.Valor = 5;

/*-------3----------*/
/*tomamos la dieta determinada como dieta_ID*/
/*traigo todas las recetas sin repetir de los usuario que tengan esa dieta*/
select distinct receta.id 
from receta,usuario,dieta,
dietasExcluidos as de, ingrediente as i
where 
usuario.DietaID = dieta_ID and
receta.UsuarioID = usuario.Id and
dieta.Id = dieta_ID and
de.ID_Dieta = dieta.ID and
receta.IngredienteReceta_ID = i.Id and
i.preferenciaId != de.Id_preferencia


/*-------4----------*/
/*tomamos la preferencia determinada como preferencia_ID*/
select distinct receta.Id from receta,ingrediente as i, usuarioPreferencia as up, usuario,
preferencia as p
where
usuario.Id = up.IdUsuario and
up.idPreferencia = p.Id and
receta.usuaroID =  usuario.ID and
receta.IngredienteReceta_ID = i.Id and
i.preferenciaId = p.Id


/*-------5----------*/
/*tomamos el condimento determinada como condimento_ID*/
select distinct top 5 r.Id from receta as r, condimentoReceta as cr, condimento as c
where
r.CondimentoRecetaIdReceta = cr.IdReceta and
c.Id = cr.IdCondimento and
c.Id = condimento_ID


/*-------6----------*/
/*tomamos el sexo y la complexion determinada como sexo_ID y complexion_ID respectivamente*/
select top 10 * from usuario,complexion,receta,calificacion,clasificacionReceta as cr
where
usuario.ComplexionID = complexion.Id and
usuario.sexo = sexo_ID and
usuario.ID = receta.usuarioID and
receta.Id = cr.IdReceta and
cr.calificacion = Calificacion.Id

/*-------7----------*/
/*tomamos la posicion de la piramide como piramide_ID*/
select distinct top 5 r.Id from usuario as u,usuarioGrupo as ug,grupo,
piramideAlimenticia as pa, receta as r
where
u.usuarioGrupo = ug.IdUsuario and
ug.IdGrupo = grupo.Id and
grupo.piramideAlimenticia_Id = pa.Id and
pa.Id = piramide_ID and
r.usuarioId = u.Id