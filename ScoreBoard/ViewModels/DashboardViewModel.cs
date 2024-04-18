using ScoreBoard.Models;
using ScoreBoard.ViewModels;

namespace ScoreBoard.ViewModels
{
    public class DashboardViewModel
    {
		public List<Joueur> TopJoueurs { get; set; }
		public List<Jeu> JeuRecents { get; set; }
	}
}
