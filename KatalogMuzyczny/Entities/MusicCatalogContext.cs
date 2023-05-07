using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatalogMuzyczny.Entities
{
    public class MusicCatalogContext : DbContext
    {
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<SupplierUser> SupplierUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=LAPTOP-TG9368EE;database=CatalogMusic;Integrated Security = SSPI;Encrypt=false");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist>()
             .HasMany(a => a.Albums)
             .WithOne(al => al.Artist)
             .HasForeignKey(al => al.ArtistId);

            modelBuilder.Entity<Album>()
                .HasMany(al => al.Songs)
                .WithOne(s => s.Album)
                .HasForeignKey(s => s.AlbumId);

            modelBuilder.Entity<Supplier>()
                .HasMany(s => s.Albums)
                .WithOne(al => al.Supplier)
                .HasForeignKey(al => al.SupplierId);

            modelBuilder.Entity<Supplier>()
                .HasIndex(s => s.Name)
                .IsUnique();


            modelBuilder.Entity<SupplierUser>().HasKey(s => new { s.SupplierId, s.UserId });


            modelBuilder.Entity<SupplierUser>()
                .HasOne<Supplier>(e => e.Supplier)
                .WithMany(p => p.SupplierUsers)
                .HasForeignKey(e => e.SupplierId);

            modelBuilder.Entity<SupplierUser>()
                .HasOne<User>(p => p.User)
                .WithMany(e => e.SupplierUsers)
                .HasForeignKey(p => p.UserId);
        }

    }
}
