using System.ComponentModel.DataAnnotations;

namespace TP5_ASP.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public string Nom { get; set; } = String.Empty;
        public string Courriel { get; set; } = String.Empty;
        public int NbPersonne { get; set; }

        [DisplayFormat(DataFormatString ="{0:d}")]
        public DateTime DateReservation { get; set; }

        public int MenuChoiceId { get; set; }   

        // Constructeur vide requis pour la désérialisation
        public Reservation()
        {
        }

        public Reservation(int id, string nom, string courriel, int nbPersonne, DateTime dateReservation, int menuChoiceId)
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
