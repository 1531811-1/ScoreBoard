using Microsoft.EntityFrameworkCore;

namespace ScoreBoard.Models
{
    public class CatalogueJeuDbContext : DbContext
    {

        public CatalogueJeuDbContext(DbContextOptions<CatalogueJeuDbContext> options) : base(options)
        {

        }

        public DbSet<Jeu> Jeux { get; set; }
        public DbSet<Joueur> Joueurs { get; set; }
    }
}
