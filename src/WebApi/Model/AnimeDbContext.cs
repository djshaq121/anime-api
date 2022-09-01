using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebApi.Entities;

namespace WebApi.Model
{
    public class AnimeDbContext : DbContext
    {
        public AnimeDbContext()
        {
        }

        public AnimeDbContext(DbContextOptions<AnimeDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Anime> Animes { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Anime>(entity =>
            {
                entity.ToTable("Anime");

                entity.Property(e => e.BroadcastDay).HasMaxLength(50);

                entity.Property(e => e.EnglishTitle).HasMaxLength(100);

                entity.Property(e => e.MediaGenre).HasMaxLength(50);

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.Title).HasMaxLength(200);
            });

        }
        
    }
}
