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

      newPizza.Crust.Name = pizza.Crust.Name;
      newPizza.Size.Name = pizza.Size.Name;
      newPizza.Name = pizza.Name;
      newPizza.Price = pizza.Price;

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
      {
        var newP = new domain.PizzaModel();
        var newC = new domain.CrustModel();
        newC.Name = item.Crust.Name;
        var newS = new domain.SizeModel();
        newS.Name = item.Size.Name;

        newP.Name = item.Name;
        newP.Price = item.Price;
        newP.Crust = newC;
        newP.Size = newS;
        domainPizzaList.Add(newP);
      }
        
        // domainPizzaList.Add(new domain.PizzaModel()
        // {
        //   Name = item.Name,
        //   new domain.CrustModel(){Name = item.Crusts.Name},
        //   new domain.SizeModel(){Name = item.Sizes.Name},
        //   // Size = item.Size.Name,
        //   Price = item.Price
        // }
        // );

      return domainPizzaList;
    }
    public void Update() { }

    public void Delete() { }

  }


}

