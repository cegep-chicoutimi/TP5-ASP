using TP5_ASP.Models;

namespace TP5_ASP.Areas.Admin.ViewModels
{
    public class MenuListVM
    {
        //Cette viewModel est pour remplir la liste déroulante des Menu, qui sera proposée... !

        public List<Menu> Menus { get; }


        //Constructeur
        public MenuListVM(List<Menu> menus)
        {
            this.Menus = menus;
        }
    }
}
