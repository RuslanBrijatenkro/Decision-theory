using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace lab4Realization
{
    public partial class lab4Context : DbContext
    {
        public lab4Context()
        {
        }

        public lab4Context(DbContextOptions<lab4Context> options)
            : base(options)
        {
        }

        public virtual DbSet<GetVotes> GetVotes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-OSOHBHJ; Database=lab4; Trusted_Connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");
        }
    }
}
