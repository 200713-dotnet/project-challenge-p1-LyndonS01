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

    public List<domain.PizzaModel> ReadAll(PizzaStoreDbContext _db)
    {
      // Bind Domain Storing to Domain PizzaModel
      var domainPizzaList = new List<domain.PizzaModel>();
      var query = _db.Pizzas.Include(t => t.Crust).Include(t => t.Size).Include(t => t.Toppings);

      foreach (var item in query.ToList())
      {
        domainPizzaList.Add(new domain.PizzaModel()
        {
          Name = item.Name,
          Crust = new domain.CrustModel() { Name = item.Crust.Name },
          Size = new domain.SizeModel() { Name = item.Size.Name },
          Price = item.Price,
          Toppings = new List<ToppingModel>()
        });
        var toppings = item.Toppings.ToList();
        foreach (var t in toppings)
        {
          domainPizzaList.LastOrDefault().Toppings.Add(new ToppingModel() {Name = t.Name});
        }    
      }

      return domainPizzaList;
    }
    public void Update() { }

    public void Delete() { }

  }


}

