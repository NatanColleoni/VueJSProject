using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using projectVue.Models;

namespace projectVue.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Teacher>().HasData(
                    new List<Teacher>()
                    {
                        new Teacher()
                        {
                            Id = 1,
                            Name = "Jose"
                        },
                        new Teacher()
                        {
                            Id = 2,
                            Name = "Josefina"
                        }
                    }
                  );
            builder.Entity<Student>().HasData(
                    new List<Student>()
                    {
                        new Student()
                        {
                            Id = 1,
                            Name = "Aluno 1",
                            Birthdate = "10/10/2015",
                            TeacherId = 1
                        },
                        new Student() 
                        {
                            Id = 2,
                            Name = "Aluno 2",
                            Birthdate = "20/10/2020",
                            TeacherId = 2
                        }
                    }
                );
        }
    }
}