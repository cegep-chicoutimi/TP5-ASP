using System.ComponentModel.DataAnnotations;

namespace TP5_ASP.Models
{
    public class Reservation
    {
        public int Id { get; set; }

        [Display(Name = "Nom")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Le nom est requis.")]
        public string Nom { get; set; } = String.Empty;

        [Display(Name = "Courriel")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Le courriel est requis.")]
        public string Courriel { get; set; } = String.Empty;

        [Display(Name = "Nombre")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Vous devez indiquez le nombre de personne.")]
        public int NbPersonne { get; set; }

        [Display(Name = "Date")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "La date est requise.")]
        [DisplayFormat(DataFormatString ="{0:d}")]
        public DateOnly? DateReservation { get; set; }

        [Display(Name = "Choix de menu")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Le choix de menu est requis.")]
        public int MenuChoiceId { get; set; }   

        // Constructeur vide requis pour la désérialisation
        public Reservation()
        {
        }

        public Reservation(int id, string nom, string courriel, int nbPersonne, DateOnly dateReservation, int menuChoiceId)
        {
            Id = id;
            Nom = nom;
            Courriel = courriel;
            NbPersonne = nbPersonne;
            DateReservation = dateReservation;
            MenuChoiceId = menuChoiceId;
        }   
    }
}
