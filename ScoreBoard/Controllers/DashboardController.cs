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
			// Get player scores from the database
			var joueurs = _context.Joueurs.ToList();

			// Calculate total score for each player
			foreach (var joueur in joueurs)
			{
				joueur.TotalScore = joueur.Jeux.Sum(j => j.ScoreJoueur);
			}

			// Sort players by total score in descending order
			var topJoueurs = joueurs.OrderByDescending(p => p.TotalScore).ToList();

			// Create DashboardViewModel and pass top players to the view
			var viewModel = new DashboardViewModel
			{
				TopJoueurs = topJoueurs
			};

			return View(viewModel);
		}
	}
}
