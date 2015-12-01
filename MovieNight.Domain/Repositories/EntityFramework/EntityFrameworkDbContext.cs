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
        public DbSet<Director> Directors { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<CastMember> CastMembers { get; set; }
        public DbSet<Submission> Submissions { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");
        }
    }
}
