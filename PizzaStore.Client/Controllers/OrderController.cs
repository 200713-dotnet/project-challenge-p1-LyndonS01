using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PizzaStore.Client.Models;
using PizzaStore.Domain.Factories;
using PizzaStore.Domain.Models;
using PizzaStore.Storing;

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

    // [Route("/home")]
    [HttpGet]
    public IActionResult Get(int id)
    {
      switch (id)
      {
        case 1:           // display available preset pizzas 
          break;
        case 2:           // display options for a custom pizza
          break;
        default:
          break;
      };
      return View("Order", new PizzaViewModel());
    }

    [HttpPost]
    // [ValidateAntiForgeryToken]
    public IActionResult Post(PizzaViewModel pizzaViewModel) //model binding
    {
      if (ModelState.IsValid) //  what is the validation? (add to viewmodel)
      {
        var p = new PizzaFactory(); // use dependency injection
        
        //p.Create(pizzaViewModel);
        //repository.Create(pizzaViewModel);

        // return View("User");
        return Redirect("/user/index");   // http 300-series status
      }

      return View("Order", pizzaViewModel);
    }
  }
}
