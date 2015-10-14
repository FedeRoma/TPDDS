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
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
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