using Task_15.Models.Entities;
using A = Task_15.Models.Entities;

namespace Task_15.ViewsModels.About
{
    public class AboutIndexViewModel
    {
        public AboutHeader  AboutHeaders ; 
        public List<A::About> Abouts = new List<A::About>();


    }
}
