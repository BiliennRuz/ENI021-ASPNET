namespace TPPizza.Web.Models;

public class PizzaFormViewModel
{
    public int Id { get; set; }
    public string Nom { get; set; }
    public int PateId { get; set; }
    public List<int> IngredientsIds { get; set; }

}
