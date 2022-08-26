namespace TPPizza.Web.Controllers;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TPPizza.Business;
using TPPizza.Business.Models;
using TPPizza.Web.Models;

public class PizzaController : Controller
{
   // private static readonly List<PizzaViewModel> pizzaVM;

    private readonly PizzaService pizzaService;

    public PizzaController(PizzaService pizzaService)
    {
        this.pizzaService = pizzaService;
    }

    // GET: PizzaController
    public ActionResult Index(PizzaService pizzaService)
    {
        var listPizzas =  this.pizzaService.GetListPizzas();
        var pizzaVM = listPizzas.Select(pi => PizzaViewModel.FromPizza(pi));
        //Ingredients = new IngredientViewModel
        //{
        //    Id = pi.Id,
        //    Nom = pi.Nom
        //}
        //);

        return View(pizzaVM);
    }

    // GET: PizzaController/Details/5
    public ActionResult Details(int id)
    {
        var listPizzas = this.pizzaService.GetListPizzas();
        var pizzaVM = listPizzas.Select(pi => new PizzaViewModel { Id = pi.Id, Nom = pi.Nom });
        var pizzaDetail = pizzaVM.FirstOrDefault(pi => pi.Id == id);
        return View(pizzaDetail);
    }

    // GET: PizzaController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: PizzaController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(IFormCollection collection, PizzaViewModel pizzaViewModel)
    {
        try
        {
            var pizza = new Pizza{ Nom = pizzaViewModel.Nom };
            this.pizzaService.AddPizza(pizza);
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: PizzaController/Edit/5
    public ActionResult Edit(int id)
    {
        // On recupere la liste de "Pizza"
        var listPizzas = this.pizzaService.GetListPizzas();
        // On cherche dans la liste "PizzaViewModel", celle qui a le même Id
        var pizzaEdit = listPizzas.FirstOrDefault(pi => pi.Id == id);
        // On transforme en "PizzaFormViewModel"
        var pizzaVM = new PizzaFormViewModel { Id = pizzaEdit.Id, Nom = pizzaEdit.Nom };

        // On recupere la liste de "Pate"
        var listPates = this.pizzaService.GetListPate();
        // On transforme en "PateViewModel"
        var pateVM = listPates.Select(pa => new PateViewModel
        {
            Id = pa.Id,
            Nom = pa.Nom,
        });
        //var pateEdit = pateVM.FirstOrDefault(pa => pa.Id == id);
        this.ViewData["listePates"] = pateVM;

        return View(pizzaVM);
    }

    // POST: PizzaController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id,PizzaFormViewModel pizzaformViewModel)
    {
        try
        {
            var pizza = new Pizza { Id = pizzaformViewModel.Id, Nom = pizzaformViewModel.Nom };
            this.pizzaService.EditPizza(pizza, pizzaformViewModel.PateId);



            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: PizzaController/Delete/5
    public ActionResult Delete(int id)
    {
        var listPizzas = this.pizzaService.GetListPizzas();
        var pizzaVM = listPizzas.Select(pi => new PizzaViewModel { Id = pi.Id, Nom = pi.Nom });
        var pizzaDelete = pizzaVM.FirstOrDefault(pi => pi.Id == id);
        return View(pizzaDelete);
    }

    // POST: PizzaController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, IFormCollection collection)
    {
        try
        {
            this.pizzaService.RemovePizza(id);
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}
