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
        case 1:           // set return view for standard pizza orders

          return_view = "OrderStandard";
          break;
        case 2:           // set return view for custom pizza orders
          pizzaViewModel.Type = "Custom";
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

        if (pizzaViewModel.Types.Contains(pizzaViewModel.Type) || pizzaViewModel.Type == "Custom")
        {
          switch (id)
          {
            case 1:         //standard pizza chosen
              pizzaViewModel.SelectedToppings.Clear();
              pizzaViewModel.SelectedToppings.AddRange(pizzaViewModel.ToppingSets[pizzaViewModel.Type]);  // add topping sets based on chosen pizza type
              break;
            case 2:         //custom pizza chosen
              if (pizzaViewModel.SelectedToppings.Contains("dummy"))
                return View(return_view, pizzaViewModel);                   // no toppings were chosen at all, return to custom pizza order page  
              break;
            default:
              break;
          }

          var pricepertopping = 1.0m;
          switch (id)
          {
            case 1:           // set prices for standard pizza orders
              domainPizzaModel.Price = pizzaViewModel.Prices[pizzaViewModel.Type];
              break;
            case 2:           // set prices for custom pizza orders
              domainPizzaModel.Price = pizzaViewModel.Prices["Cheese"]; //cheapest
              domainPizzaModel.Price += pizzaViewModel.SelectedToppings.Count * pricepertopping;
              break;
            default:
              break;
          };
        }
        else
        {
          domainPizzaModel.Price = pizzaViewModel.Prices["Cheese"]; //cheapest
          pizzaViewModel.SelectedToppings.AddRange(pizzaViewModel.ToppingSets["Cheese"]);
        }

        // bind PizzaViewModel to Domain PizzaModel
        domainPizzaModel.Name = pizzaViewModel.Type;

        var newC = new CrustModel();
        newC.Name = pizzaViewModel.Crust;
        domainPizzaModel.Crust = newC;

        var newS = new SizeModel();
        newS.Name = pizzaViewModel.Size;
        domainPizzaModel.Size = newS;

        foreach (var t in pizzaViewModel.SelectedToppings)
        {
          var newToppings = new List<ToppingModel>();
          var newTopping = new ToppingModel();
          newTopping.Name = t;
          domainPizzaModel.Toppings.Add(newTopping);
        }

        var repo_pizza = new PizzaRepository();
        repo_pizza.Create(domainPizzaModel, _db);

        return_view = "ThankYou";
        return View(return_view);

      }


      return View(return_view, pizzaViewModel);
    }
  }
}
