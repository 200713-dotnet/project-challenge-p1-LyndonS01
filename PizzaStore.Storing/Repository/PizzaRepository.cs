using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaStore.Domain.Models;
using domain = PizzaStore.Domain.Models;

namespace PizzaStore.Storing.Repository
{
  public class PizzaRepository
  {
    // private PizzaStoreDbContext _db = new PizzaStoreDbContext();

    public void Create(PizzaModel pizza, PizzaStoreDbContext _db)
    {
      // Bind Domain PizzaModel to Storing PizzaModel
      var newPizza = new domain.PizzaModel();

      newPizza.Crust = new domain.CrustModel();
      newPizza.Size = new domain.SizeModel();
      newPizza.Toppings = new List<domain.ToppingModel>();

      newPizza.Crust.Name = pizza.Crust.Name;
      newPizza.Size.Name = pizza.Size.Name;
      newPizza.Name = pizza.Name;
      newPizza.Price = pizza.Price;

      foreach (var t in pizza.Toppings)
      {
        List<ToppingModel> newToppings = new List<ToppingModel>();
        ToppingModel newTopping = new ToppingModel();
        newTopping.Name = t.Name;
        newPizza.Toppings.Add(newTopping);
      }
      _db.Pizzas.Add(newPizza);
      _db.SaveChanges();
    }

    // public void CreateOrderDb(domain.Order order)
    // {
    //   var newOrder = new Orders();

    //   _db.Orders.Add(newOrder);
    //   _db.SaveChanges();
    // }

    public List<domain.PizzaModel> ReadAll(PizzaStoreDbContext _db)
    {
      // Bind Domain Storing to Domain PizzaModel
      var domainPizzaList = new List<domain.PizzaModel>();
      var query = _db.Pizzas.Include(t => t.Crust).Include(t => t.Size);

      foreach (var item in query.ToList())
        domainPizzaList.Add(new domain.PizzaModel()
        {
          Name = item.Name,
          Crust = new domain.CrustModel() { Name = item.Crust.Name },
          Size = new domain.SizeModel() { Name = item.Size.Name },
          Price = item.Price
          //          Toppings = new List<domain.Toppings>()
        });

      return domainPizzaList;
    }
    public void Update() { }

    public void Delete() { }

  }


}

