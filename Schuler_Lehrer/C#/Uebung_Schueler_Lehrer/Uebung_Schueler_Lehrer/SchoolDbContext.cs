using ClassLibrary.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Uebung_Schueler_Lehrer
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options) { }


        public DbSet<Student> Students{ get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ClassTeacher>()
                .HasKey(c => new { c.ClassId, c.TeacherId });

            modelBuilder.Entity<ClassTeacher>()
                .HasOne(ct => ct.Class)
                .WithMany(c => c.ClassTeachers)
                .HasForeignKey(ct => ct.TeacherId);

            modelBuilder.Entity<ClassTeacher>()
                .HasOne(ct => ct.Teacher)
                .WithMany(t => t.ClassTeachers)
                .HasForeignKey(ct => ct.ClassId);

            modelBuilder.Entity<Student>()
                .HasOne(s => s.Class)
                .WithMany(c => c.Students)
                .HasForeignKey(s => s.ClassId);


        }
    }
}
