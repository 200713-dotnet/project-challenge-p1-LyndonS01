using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PizzaStore.Client.Models;
using PizzaStore.Domain.Factories;
using PizzaStore.Domain.Models;
using PizzaStore.Storing;
using PizzaStore.Storing.Repository;

namespace PizzaStore.Client.Controllers
{
  [Route("/order/{id=1}")]
  // [EnableCors("private")]  
  public class OrderController : Controller
  {
    private readonly PizzaStoreDbContext _db;

    public OrderController(PizzaStoreDbContext dbContext) // constructor dependency injection
    {
      _db = dbContext;
    }

    [HttpGet]
    public IActionResult Get(int id)
    {
      var return_view = "";

      switch (id)
      {
        case 1:           // display available preset pizzas 
          return_view = "OrderStandard";
          break;
        case 2:           // display options for a custom pizza
          return_view = "OrderCustom";
          break;
        default:
          break;
      };
      return View(return_view, new PizzaViewModel());
    }

    [HttpPost]
    // [ValidateAntiForgeryToken]
    public IActionResult Post(PizzaViewModel pizzaViewModel, int id) //model binding
    {
      var return_view = "";
      switch (id)
      {
        case 1:           // display available preset pizzas 
          return_view = "OrderStandard";
          break;
        case 2:           // display options for a custom pizza
          return_view = "OrderCustom";
          break;
        default:
          break;
      };

      if (ModelState.IsValid) //  what is the validation? (add to viewmodel)
      {
        var p = new PizzaFactory(); // use dependency injection
        PizzaModel domainPizzaModel = new PizzaModel();
        domainPizzaModel = p.Create();           // factory-created Domain PizzaModel
                                                  // bind PizzaViewModel to Domain PizzaModel
        var repository = new PizzaRepository();
        repository.Create(domainPizzaModel, _db);
        //repository.Create(pizzaViewModel);

        // return View("User");
        return Redirect("/user/index");   // http 300-series status
      }


      return View(return_view, pizzaViewModel);
    }
  }
}
