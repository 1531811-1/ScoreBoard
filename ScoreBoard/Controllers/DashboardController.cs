using Microsoft.AspNetCore.Mvc;
using ScoreBoard.Models;
using ScoreBoard.ViewModels;
using System.Linq;

namespace ScoreBoard.Controllers
{
	public class DashboardController : Controller
	{
		private readonly CatalogueJeuDbContext _context;

		public DashboardController(CatalogueJeuDbContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			// Get score joueur de la base de donnée
			var joueurs = _context.Joueurs.ToList();

			// Calcule score total de chaque joueur
			foreach (var joueur in joueurs)
			{
				joueur.TotalScore = joueur.Jeux.Sum(j => j.ScoreJoueur);
			}

			// Sort le score total des joueurs
			var topJoueurs = joueurs.OrderByDescending(p => p.TotalScore).ToList();

			// Create DashboardViewModel et passe les meilleurs joeurus à la vue
			var viewModel = new DashboardViewModel
			{
				TopJoueurs = topJoueurs
			};

			return View(viewModel);
		}
	}
}
