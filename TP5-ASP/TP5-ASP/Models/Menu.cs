namespace TP5_ASP.Models
{
    public class Menu
    {
        public int Id { get; set; }    
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
