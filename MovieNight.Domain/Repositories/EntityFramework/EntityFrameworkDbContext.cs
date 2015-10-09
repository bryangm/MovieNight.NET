using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieNight.Domain.Entities;

namespace MovieNight.Domain.Repositories.EntityFramework
{
    public class EntityFrameworkDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Night> Nights { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Submission> Submissions { get; set; }
    }
}
