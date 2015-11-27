-- GetRecetasByTempoCalif 1, 2

Select * From PiramideAlimenticia
Select * from Usuarios

Select * From Recetas

select * from Preferencias
Select * From Ingredientes
Select * From Condimentos

select * from IngredientesRecetas
Select * From CondimentosRecetas
select * from Procedimientos
select * from ClasificacionesRecetas
select * from TemporadasRecetas
select * from Calificaciones
-- insert into Recetas values ('Torta de Vainilla', 3, 250, 1, 2, 5)

--cantidad, tipo, ingId,RecId
insert into IngredientesRecetas values (1, 1, 18, 10)
insert into IngredientesRecetas values (8, 1, 17, 10)
insert into IngredientesRecetas values (1, 1, 1, 10)

insert into CondimentosRecetas values(10,10)
insert into CondimentosRecetas values(16,10)

-- insert into Procedimientos values (1, '', '', 1)
insert into Procedimientos values (1, 'Bati manteca y azucar.', '', 10)
insert into Procedimientos values (2, 'Anda agregando todo el resto.', '', 10)
insert into Procedimientos values (3, 'Horno. 40min. 150 grados.', '', 10)

insert into ClasificacionesRecetas values (1,10)
insert into ClasificacionesRecetas values (2,10)

insert into TemporadasRecetas values (1,10)
insert into TemporadasRecetas values (2,10)
insert into TemporadasRecetas values (3,10)

insert into Calificaciones values (10, 3, 4)
insert into Calificaciones values (10, 3, 10)

-- insert into Ingredientes values('Lentejas', 1, 61, 5)
-- insert into Condimentos values('Manteca', '')