using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindVan.Domain.Entities;

namespace FindVan.Domain.Infra.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base (options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(x => x.Id);
            modelBuilder.Entity<User>().Property(x => x.Name).HasMaxLength(120).HasColumnType("varchar(120)");
            modelBuilder.Entity<User>().Property(x => x.IdFirebase).HasMaxLength(160).HasColumnType("varchar(160)");
            modelBuilder.Entity<User>().Property(x => x.Img).HasMaxLength(255).HasColumnType("varchar(255)");
            modelBuilder.Entity<User>().Property(x => x.LastLogin);
        }
    }
}
