using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScoreBoard.Models
{
    public class Jeu
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Nom { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date de Sortie")]
        [DateAuPasse(ErrorMessage = "La date de sortie doit être antérieure à la date du jour.")]
        public DateTime DateSortie { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [ForeignKey("Joueur")]
        public int JoueurId { get; set; }

        [Required]
        public Joueur Joueur { get; set; }

        [Required][Range(0, 100)]
        public int ScoreJoueur { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date d'Enregistrement")]
        [DateAuPasse(ErrorMessage = "La date d'enregistrement doit être antérieure à la date du jour.")]
        public DateTime DateEnregistrement { get; set; }
    }

	public class DateAuPasseAttribute : ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			if (value != null)
			{
				DateTime dateValue = (DateTime)value;
				if (dateValue >= DateTime.Today)
				{
					return new ValidationResult(ErrorMessage ?? "La date doit être dans le passé.");
				}
			}
			return ValidationResult.Success;
		}
	}


}
