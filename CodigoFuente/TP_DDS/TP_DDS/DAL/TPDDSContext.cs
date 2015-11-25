using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using TP_DDS.Models;
using TP_DDS.ViewModels;
using System.Data.SqlClient;

namespace TP_DDS.DAL
{
    public class TPDDSContext : DbContext
    {
        public TPDDSContext(): base("TPDDSContext")
        {

        }

        #region DbSetConfig
            public DbSet<CondicionPreexistente> CondicionesPreexistentes { get; set; }
            public DbSet<Complexion> Complexiones { get; set; }
            public DbSet<Dieta> Dietas { get; set; }
            public DbSet<Sexo> Sexo { get; set; }
            public DbSet<Rutina> Rutinas { get; set; }
            public DbSet<Preferencia> Preferencias { get; set; }
            public DbSet<Usuario> Usuarios { get; set; }
            public DbSet<Grupo> Grupos { get; set; }
            public DbSet<Clasificacion> Clasificaciones { get; set; }
            public DbSet<Condimento> Condimentos { get; set; }
            public DbSet<Ingrediente> Ingredientes { get; set; }
            public DbSet<PiramideAlimenticia> PiramideAlimenticia { get; set; }
            public DbSet<Temporada> Temporadas { get; set; }
            public DbSet<Receta> Recetas { get; set; }
            public DbSet<Procedimiento> Procedimientos { get; set; }
            public DbSet<IngredienteReceta> IngredientesRecetas { get; set; }
            public DbSet<Calificacion> Calificaciones { get; set; }
            public DbSet<GrupoUsuario> GruposUsuarios { get; set; }
            public DbSet<Estadistica> Estadisticas { get; set; }
            public DbSet<GrupoReceta> GruposRecetas { get; set; }
            public DbSet<Dificultad> Dificultades { get; set; }
            public DbSet<TipoIngrediente> TipoIngredientes { get; set; }
            public DbSet<Comida> Comidas { get; set; }
            public DbSet<ComidaReceta> ComidasRecetas { get; set; }
        #endregion

        #region Mapeo_SP_Consultas

            //Mapeo los SP de Consultas con los ViewModel (Results)
            public IEnumerable<CaloriasMaxByRutina_Result>
                        GetCaloriasMaxByRutina(int rutinaId)
            {
                return this.Database.SqlQuery<CaloriasMaxByRutina_Result>
                                        ("GetCaloriasMaxByRutina @rutinaId",
                    new SqlParameter("@rutinaId", rutinaId));
            }

            public IEnumerable<RecetasByCondimento_Result>
                        GetRecetasByCondimento(int condimentoId)
            {
                return this.Database.SqlQuery<RecetasByCondimento_Result>
                                        ("GetRecetasByCondimento @condimentoId",
                    new SqlParameter("@condimentoId", condimentoId));
            }

            public IEnumerable<RecetasByDieta_Result>
                        GetRecetasByDieta(int dietaId)
            {
                return this.Database.SqlQuery<RecetasByDieta_Result>
                                        ("GetRecetasByDieta @dietaId",
                    new SqlParameter("@dietaId", dietaId));
            }

            public IEnumerable<RecetasByPiramide_Result>
                        GetRecetasByPiramide(int piramideId)
            {
                return this.Database.SqlQuery<RecetasByPiramide_Result>
                                        ("GetRecetasByPiramide @piramideId",
                    new SqlParameter("@piramideId", piramideId));
            }

            public IEnumerable<RecetasByPreferencia_Result>
                        GetRecetasByPreferencia(int preferenciaId)
            {
                return this.Database.SqlQuery<RecetasByPreferencia_Result>
                                        ("GetRecetasByPreferencia @preferenciaId",
                    new SqlParameter("@preferenciaId", preferenciaId));
            }

            public IEnumerable<RecetasBySexComplex_Result>
                        GetRecetasBySexComplex(int sexoId, int complexionId, int calificacionId)
            {
                return this.Database.SqlQuery<RecetasBySexComplex_Result>
                                        ("GetRecetasBySexComplex @sexoId, @complexionId, @calificacionId",
                    new SqlParameter("@sexoId", sexoId),
                    new SqlParameter("@complexionId", complexionId),
                    new SqlParameter("@calificacionId", calificacionId));
            }

            public IEnumerable<RecetasByTempoCalif_Result>
                        GetRecetasByTempoCalif(int temporadaId, int calificacion)
            {
                return this.Database.SqlQuery<RecetasByTempoCalif_Result>
                                        ("GetRecetasByTempoCalif @temporadaId, @calificacion",
                    new SqlParameter("@temporadaId", temporadaId),
                    new SqlParameter("@calificacion", calificacion));
            }
        #endregion

        #region Mapeo_SP_Reportes

            public IEnumerable<RptRecetasPorPeriodo>
                GetRecetasPorPeriodo(DateTime fechaIni, DateTime fechaFin, int usuarioId)
            {
                return this.Database.SqlQuery<RptRecetasPorPeriodo>
                        ("GetRecetasPorPeriodo @fechaIni, @fechaFin, @usuarioId",
                            new SqlParameter("@fechaIni", fechaIni),
                            new SqlParameter("@fechaFin", fechaFin),
                            new SqlParameter("@usuarioId", usuarioId));
            }

            public IEnumerable<RptRecetasNuevas>
                    GetRecetasNuevas(DateTime fechaIni, DateTime fechaFin, int usuarioId)
            {
                return this.Database.SqlQuery<RptRecetasNuevas>
                                        ("GetRecetasNuevas @fechaIni, @fechaFin, @usuarioId",
                    new SqlParameter("@fechaIni", fechaIni),
                    new SqlParameter("@fechaFin", fechaFin),
                    new SqlParameter("@usuarioId", usuarioId));
            }

            public IEnumerable<RptRecetasPorCalorias>
                        GetRecetasPorCalorias(int caloriasMin, int caloriasMax, int usuarioId)
            {
                return this.Database.SqlQuery<RptRecetasPorCalorias>
                                        ("GetRecetasPorCalorias @caloriasMin, @caloriasMax, @usuarioId",
                    new SqlParameter("@caloriasMin", caloriasMin),
                    new SqlParameter("@caloriasMax", caloriasMax),
                    new SqlParameter("@usuarioId", usuarioId));
            }

        #endregion

        #region Mapeo_SP_Estadisticas

            public IEnumerable<EstadisticaSexo>
                GetEstadisticaBySexo(int tipo)
            {
                return this.Database.SqlQuery<EstadisticaSexo>
                                        ("GetEstadisticaBySexo @tipo",
                    new SqlParameter("@tipo", tipo));
            }

            public IEnumerable<EstadisticaDificultad>
                GetEstadisticaByDificultad(int tipo)
            {
                return this.Database.SqlQuery<EstadisticaDificultad>
                                        ("GetEstadisticaByDificultad @tipo",
                    new SqlParameter("@tipo", tipo));
            }

            public IEnumerable<EstadisticaRanking>
                GetEstadisticaByRanking(int tipo)
            {
                return this.Database.SqlQuery<EstadisticaRanking>
                                        ("GetEstadisticaByRanking @tipo",
                    new SqlParameter("@tipo", tipo));
            }

        #endregion

        //Cambio el nombre de las tablas para el Mapeo
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CondicionPreexistente>().ToTable("CondicionesPreexistentes");
            modelBuilder.Entity<Complexion>().ToTable("Complexiones");
            modelBuilder.Entity<Dieta>().ToTable("Dietas");
            modelBuilder.Entity<Sexo>().ToTable("Sexo");
            modelBuilder.Entity<Rutina>().ToTable("Rutinas");
            modelBuilder.Entity<Preferencia>().ToTable("Preferencias");
            modelBuilder.Entity<Usuario>().ToTable("Usuarios");
            modelBuilder.Entity<Grupo>().ToTable("Grupos");
            modelBuilder.Entity<Clasificacion>().ToTable("Clasificaciones");
            modelBuilder.Entity<Condimento>().ToTable("Condimentos");
            modelBuilder.Entity<Ingrediente>().ToTable("Ingredientes");
            modelBuilder.Entity<PiramideAlimenticia>().ToTable("PiramideAlimenticia");
            modelBuilder.Entity<Temporada>().ToTable("Temporadas");
            modelBuilder.Entity<Receta>().ToTable("Recetas");
            modelBuilder.Entity<Procedimiento>().ToTable("Procedimientos");
            modelBuilder.Entity<IngredienteReceta>().ToTable("IngredientesRecetas");
            modelBuilder.Entity<Calificacion>().ToTable("Calificaciones");
            modelBuilder.Entity<GrupoUsuario>().ToTable("GruposUsuarios");
            modelBuilder.Entity<GrupoReceta>().ToTable("GruposRecetas");
            modelBuilder.Entity<Estadistica>().ToTable("Estadisticas");
            modelBuilder.Entity<Dificultad>().ToTable("Dificultades");
            modelBuilder.Entity<TipoIngrediente>().ToTable("TipoIngredientes");
            modelBuilder.Entity<Comida>().ToTable("Comidas");
            modelBuilder.Entity<ComidaReceta>().ToTable("ComidasRecetas");

            //modelBuilder.Entity<Comida>()
            //        .HasMany(x => x.Recetas)
            //        .WithMany(x => x.Comidas)
            //    .Map(x =>
            //    {
            //        x.ToTable("ComidasRecetas");
            //        x.MapLeftKey("Comida_Id");
            //        x.MapRightKey("Receta_Id");
            //    });

            modelBuilder.Entity<Receta>()
                    .HasMany(x => x.Temporadas)
                    .WithMany(x => x.Recetas)
                .Map(x =>
                {
                    x.ToTable("TemporadasRecetas");
                    x.MapLeftKey("Receta_Id");
                    x.MapRightKey("Temporada_Id");
                });

            modelBuilder.Entity<Receta>()
                    .HasMany(x => x.Clasificaciones)
                    .WithMany(x => x.Recetas)
                .Map(x =>
                {
                    x.ToTable("ClasificacionesRecetas");
                    x.MapLeftKey("Receta_Id");
                    x.MapRightKey("Clasificacion_Id");
                });

            modelBuilder.Entity<Receta>()
                    .HasMany(x => x.Condimentos)
                    .WithMany(x => x.Recetas)
                .Map(x =>
                {
                    x.ToTable("CondimentosRecetas");
                    x.MapLeftKey("Receta_Id");
                    x.MapRightKey("Condimento_Id");
                });

            modelBuilder.Entity<Grupo>()
                    .HasMany(x => x.Preferencias)
                    .WithMany(x => x.Grupos)
                .Map(x =>
                {
                    x.ToTable("GruposPreferencias");
                    x.MapLeftKey("Grupo_Id");
                    x.MapRightKey("Preferencia_Id");
                });

            modelBuilder.Entity<Usuario>()
                    .HasMany(x => x.Preferencias)
                    .WithMany(x => x.Usuarios)
                .Map(x =>
                {
                    x.ToTable("UsuariosPreferencias");
                    x.MapLeftKey("Usuario_Id");
                    x.MapRightKey("Preferencia_Id");
                });

            modelBuilder.Entity<Preferencia>()
                    .HasMany(x => x.Dietas)
                    .WithMany(x => x.Preferencias)
                .Map(x =>
                {
                    x.ToTable("DietasPreferencias");
                    x.MapLeftKey("Preferencia_Id");
                    x.MapRightKey("Dieta_Id");
                });

            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}