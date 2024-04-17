using System;
using System.Collections.Generic;
using ScoreBoard.Models;

namespace ScoreBoard.Models
{
	public class DbSeeder
	{
		public static void SeedData(CatalogueJeuDbContext context)
		{
			SeedJoueurs(context);
			SeedJeux(context);
		}

		public static void Seed(IApplicationBuilder applicationBuilder)
		{
			// Retrieve ScoreBoardDbContext from the applicationBuilder
			using (var scope = applicationBuilder.ApplicationServices.CreateScope())
			{
				var services = scope.ServiceProvider;
				var dbContext = services.GetRequiredService<CatalogueJeuDbContext>();
				SeedData(dbContext);
			}
		}

		private static void SeedJoueurs(CatalogueJeuDbContext context)
		{
			if (!context.Joueurs.Any())
			{
				List<Joueur> joueurs = new List<Joueur>
				{
					new Joueur { Nom = "Dupont", Prenom = "Jean", Equipe = "AIGL", Telephone = "514-123-4567", Courriel = "jean.dupont@aigles.com" },
					new Joueur { Nom = "Tremblay", Prenom = "Lucie", Equipe = "RNRD", Telephone = "450-987-6543", Courriel = "lucie.tremblay@renards.com" },
					new Joueur { Nom = "Gagnon", Prenom = "Alexandre", Equipe = "LION", Telephone = "819-345-6789", Courriel = "alexandre.gagnon@lions.com" },
					new Joueur { Nom = "Lapointe", Prenom = "Sophie", Equipe = "TIGR", Telephone = "418-765-4321", Courriel = "sophie.lapointe@tigres.com" },
					new Joueur { Nom = "Nguyen", Prenom = "Kevin", Equipe = "EPRV", Telephone = "514-876-5432", Courriel = "kevin.nguyen@eperviers.com" }
				};

				context.Joueurs.AddRange(joueurs);
				context.SaveChanges();
			}
		}

		private static void SeedJeux(CatalogueJeuDbContext context)
		{
			if (!context.Joueurs.Any())
			{
				List<Jeu> jeux = new List<Jeu>
				{
					new Jeu { Nom = "The Legend of Zelda: Breath of the Wild", DateSortie = new DateTime(2017, 3, 3), Description = "Jeu d'action-aventure en monde ouvert", JoueurId = 1, ScoreJoueur = 60, DateEnregistrement = DateTime.Now },
					new Jeu { Nom = "Super Mario Odyssey", DateSortie = new DateTime(2017, 10, 27), Description = "Jeu de plateforme en monde ouvert", JoueurId = 1, ScoreJoueur = 50, DateEnregistrement = DateTime.Now },
					new Jeu { Nom = "Red Dead Redemption 2", DateSortie = new DateTime(2018, 10, 26), Description = "Jeu d'action-aventure en monde ouvert dans le Far West", JoueurId = 1, ScoreJoueur = 100, DateEnregistrement = DateTime.Now },
					new Jeu { Nom = "Assassin's Creed Odyssey", DateSortie = new DateTime(2018, 10, 5), Description = "Jeu d'action-aventure en monde ouvert dans la Grèce antique", JoueurId = 2, ScoreJoueur = 100, DateEnregistrement = DateTime.Now },
					new Jeu { Nom = "God of War", DateSortie = new DateTime(2018, 4, 20), Description = "Jeu d'action-aventure en monde ouvert inspiré de la mythologie nordique", JoueurId = 2, ScoreJoueur = 30, DateEnregistrement = DateTime.Now },
					new Jeu { Nom = "Cyberpunk 2077", DateSortie = new DateTime(2020, 12, 10), Description = "Jeu de rôle en monde ouvert futuriste", JoueurId = 3, ScoreJoueur = 70, DateEnregistrement = DateTime.Now},
					new Jeu { Nom = "The Last of Us Part II", DateSortie = new DateTime(2020, 6, 19), Description = "Jeu d'action-aventure et de survie post-apocalyptique", JoueurId = 4,  ScoreJoueur = 100, DateEnregistrement = DateTime.Now },
					new Jeu { Nom = "Animal Crossing: New Horizons", DateSortie = new DateTime(2020, 3, 20), Description = "Jeu de simulation de vie en monde ouvert", JoueurId = 4, ScoreJoueur = 10, DateEnregistrement = DateTime.Now },
					new Jeu { Nom = "Doom Eternal", DateSortie = new DateTime(2020, 3, 20), Description = "Jeu de tir à la première personne", JoueurId = 4, ScoreJoueur = 90, DateEnregistrement = DateTime.Now },
					new Jeu { Nom = "Ghost of Tsushima", DateSortie = new DateTime(2020, 7, 17), Description = "Jeu d'action-aventure en monde ouvert dans le Japon féodal", JoueurId = 5, ScoreJoueur = 100, DateEnregistrement = DateTime.Now },
					new Jeu { Nom = "Hades", DateSortie = new DateTime(2020, 9, 17), Description = "Jeu de rôle d'action roguelike", JoueurId = 5, ScoreJoueur = 40, DateEnregistrement = DateTime.Now }
				};

				context.Jeux.AddRange(jeux);
				context.SaveChanges();
			}
		}
	}	
}
