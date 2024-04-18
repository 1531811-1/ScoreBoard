using System.ComponentModel.DataAnnotations;

namespace ScoreBoard.Models
{
    public class Joueur
    {
        [Required]
        public int Id { get; set; }

        [Required][MinLength(2)][MaxLength(20)]
        public string Nom { get; set; }

        [Required][MinLength(2)][MaxLength(20)]
        public string Prenom { get; set; }

        public string? Equipe { get; set; }

        public string? Telephone { get; set; }

        [Required][RegularExpression(@"^[\w -\.] +@([\w -] +\.)+[\w-]{2,4}$", ErrorMessage = "adresse courriel invalide")]
        public string Courriel { get; set; }
        [Required][RegularExpression(@"[A-Z]{2,4})", ErrorMessage = "Le champs équipe doit avoir 2 à 4 lettres majuscules.")]
        public List<Jeu>? Jeux { get; set; }

		public int TotalScore { get; set; }
	}
}
