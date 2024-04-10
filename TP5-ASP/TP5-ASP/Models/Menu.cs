
using System.ComponentModel.DataAnnotations;

namespace TP5_ASP.Models
{
    public class Menu
    {
        public int Id { get; set; }

        [Display(Name = "Description")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Le champ est requis.")]
        public string Description { get; set; } = String.Empty;

        //Constructeur vide requis pour la désérialisation
        public Menu()
        {
        }

        public Menu(int id, string description)
        {
            Id = id;
            Description = description;
        }   
    }

}
