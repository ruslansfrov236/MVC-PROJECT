using Task_15.Models.Entities;

namespace Task_15.ViewsModels.Home
{
    public class HomeIndexViewModel
    {
      public  List<Product> Products = new List<Product>();

        public List<Recent> Recents = new List<Recent>();   
    }
}
