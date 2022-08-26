namespace TPPizza.Web.Models
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using TPPizza.Business.Models;

    public class PateViewModel
    {
        public int Id { get; set; }
        public string Nom { get; set; } = String.Empty;

        public static PateViewModel FromPate(Pate pate)
        {
            //if (pate.Nom == null)
            //{
            //    return new PateViewModel { };
            //}else
            //{
                return new PateViewModel { Id = pate.Id, Nom = pate.Nom };
            //}
        }
    }
}