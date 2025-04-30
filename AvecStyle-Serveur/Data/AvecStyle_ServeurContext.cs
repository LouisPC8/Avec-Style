using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AvecStyle_Serveur.Models;

namespace AvecStyle_Serveur.Data
{
    public class AvecStyle_ServeurContext : DbContext
    {
        public AvecStyle_ServeurContext (DbContextOptions<AvecStyle_ServeurContext> options)
            : base(options)
        {
        }

        public DbSet<Article> Article { get; set; } = default!;
        public DbSet<Image> Image { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
        }
    }
}
