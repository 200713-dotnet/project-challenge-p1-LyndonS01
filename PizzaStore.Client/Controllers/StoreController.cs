using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PizzaStore.Client.Models;
using PizzaStore.Domain.Factories;
using PizzaStore.Domain.Models;
using PizzaStore.Storing;
using PizzaStore.Storing.Repository;
using RestSharp;

namespace PizzaStore.Client.Controllers
{
  [Route("/store/{id=1}")]
  // [Route("/store/")]
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
        case 4:          // display Search Movies by Title
          // GetMoviesByTitle();
          // return_view = "SearchByTitle";
          return View(return_view);
        default:
          return View(return_view);
      };
      

    }

    [HttpPost]
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

        storepizzalist.Pizzas = pizzaList;
        storepizzalist.Toppings = new List<string>();
        foreach(var p in pizzaList.ToList())
        {
          List<string> toppings = new List<string>();
          foreach(var s in p.Toppings.ToList())
          {
            toppings.Add(s.Name);
          }
          storepizzalist.Toppings.Add(string.Join(",", toppings.ToArray()));

          price += p.Price;
          qty += 1;
        }

        storepizzalist.Qty = qty;
        storepizzalist.Price = price;
        
        return storepizzalist;
    }

    // public void GetMoviesByTitle()
    // {
    //   var client = new RestClient("https://movies-tvshows-data-imdb.p.rapidapi.com/?title=indiana%20jones&type=get-movies-by-title");
    //   var request = new RestRequest(Method.GET);
    //   request.AddHeader("x-rapidapi-host", "movies-tvshows-data-imdb.p.rapidapi.com");
    //   request.AddHeader("x-rapidapi-key", "971bf2ac6fmsh604c84512ded1eap16b86fjsn950b74fe77a7");
    //   IRestResponse response = client.Execute(request); 

    //   try
    //   {
    //     var movieList = JsonSerializer.Deserialize<MovieQByTitleModel>(response.Content);
    //   }
    //   catch (Exception e)
    //   {
    //     Console.WriteLine(e);
    //   }
      
    //   return;
    // }
  }
}
