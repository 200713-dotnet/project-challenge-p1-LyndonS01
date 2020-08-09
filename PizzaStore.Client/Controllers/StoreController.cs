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
  [Route("/store/{id=1}")]
  // [EnableCors("private")]  
  public class StoreController : Controller
  {
    private readonly PizzaStoreDbContext _db;

    public StoreController(PizzaStoreDbContext dbContext) // constructor dependency injection
    {
      _db = dbContext;
    }

    [HttpGet]
    public IActionResult Get(int id)
    {
      var return_view = "index";

      switch (id)
      {
        case 1:           // display Store Store Reports selection
          return View(return_view);
        case 2:          // display Store Sales History
          var storepizzalist = GetSales();
          return_view = "StoreSales";
          return View(return_view, storepizzalist);
        case 3:          // display Store Order History
          return View(return_view);
        default:
          return View(return_view);
      };
      

    }

    [HttpPost]
    // [ValidateAntiForgeryToken]
    // public IActionResult Post(StoreViewModel pizzaViewModel, int id)
    public IActionResult Post(int id)
    {
      var return_view = "index";

      return View(return_view);  
    }

    public StoreViewModel GetSales()
    {
        var repo_pizza = new PizzaRepository();
        List<PizzaModel> pizzaList = repo_pizza.ReadAll(_db);
        StoreViewModel storepizzalist = new StoreViewModel();

        var price = 0.0m;
        var qty = 0;

        foreach (var item in pizzaList.ToList())
        {
          price += item.Price;
          qty += 1;
        }
        storepizzalist.Pizzas = pizzaList;
        storepizzalist.Qty = qty;
        storepizzalist.Price = price;
        
        return storepizzalist;
    }
  }
}
