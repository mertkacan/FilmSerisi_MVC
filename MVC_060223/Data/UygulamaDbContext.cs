using Microsoft.EntityFrameworkCore;

namespace MVC_060223.Data
{
    public class UygulamaDbContext : DbContext
    {
        public UygulamaDbContext(DbContextOptions<UygulamaDbContext> options) : base(options)
        {

        }

        public DbSet<Film> Filmler => Set<Film>();

        public DbSet<Tur> Turler => Set<Tur>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Film>().HasData(
                new Film() { Id = 1, Ad = "Fight Club", Yil = 1999, Puan = 8.7m },
                new Film() { Id = 2, Ad = "Inception", Yil = 2010, Puan = 8.7m },
                new Film() { Id = 3, Ad = "The Matrix", Yil = 1999, Puan = 8.7m },
                new Film() { Id = 4, Ad = "Joker", Yil = 2019, Puan = 8.3m },
                new Film() { Id = 5, Ad = "Die Hard", Yil = 1988, Puan = 8.2m },
                new Film() { Id = 6, Ad = "Green Book", Yil = 2018, Puan = 8.2m }
                );

            modelBuilder.Entity<Tur>().HasData(
                new Tur() { Id = 1, Ad = "Aksiyon" },
                new Tur() { Id = 2, Ad = "Macera" },
                new Tur() { Id = 3, Ad = "Animasyon" },
                new Tur() { Id = 4, Ad = "Biyografi" },
                new Tur() { Id = 5, Ad = "Komedi" },
                new Tur() { Id = 6, Ad = "Suç" },
                new Tur() { Id = 7, Ad = "Drama" },
                new Tur() { Id = 8, Ad = "Aile" },
                new Tur() { Id = 9, Ad = "Fantastik" },
                new Tur() { Id = 10, Ad = "Siyah Beyaz" },
                new Tur() { Id = 11, Ad = "Tarih" },
                new Tur() { Id = 12, Ad = "Korku" },
                new Tur() { Id = 13, Ad = "Müzik" },
                new Tur() { Id = 14, Ad = "Müzikal" },
                new Tur() { Id = 15, Ad = "Gizem" },
                new Tur() { Id = 16, Ad = "Romantik" },
                new Tur() { Id = 17, Ad = "Bilim Kurgu" },
                new Tur() { Id = 18, Ad = "Gerilim" },
                new Tur() { Id = 19, Ad = "Savaş" },
                new Tur() { Id = 20, Ad = "Batı" }
                );
        }
    }
}
