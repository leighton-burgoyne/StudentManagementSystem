using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Data
{
    public class SMSData : DbContext
    {
        public SMSData (DbContextOptions<SMSData> options)
            : base(options)
        {
        }

        public DbSet<Student> Student { get; set; }
        public DbSet<Parent> Parent { get; set; }
        public DbSet<Intervention> Intervention { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Module> Module { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable(nameof(Course));
            modelBuilder.Entity<Student>().ToTable(nameof(Student));
            modelBuilder.Entity<Parent>().ToTable(nameof(Parent));
            modelBuilder.Entity<Intervention>().ToTable(nameof(Intervention));
        }
    }
}
