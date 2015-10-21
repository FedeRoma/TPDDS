using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using TP_DDS.Models;

namespace TP_DDS.DAL
{
    public class TPDDSContext : DbContext
    {
        public TPDDSContext(): base("TPDDSContext")
        {

        }

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

            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //modelBuilder.Entity<Course>()
            //    .HasMany(c => c.Instructors).WithMany(i => i.Courses)
            //    .Map(t => t.MapLeftKey("CourseID")
            //        .MapRightKey("InstructorID")
            //        .ToTable("CourseInstructor"));

            //modelBuilder.Entity<Department>().MapToStoredProcedures();
        }
    }
}