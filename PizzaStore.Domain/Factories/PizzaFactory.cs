using System.Collections.Generic;
using PizzaStore.Domain.Models;

namespace PizzaStore.Domain.Factories
{
  public class PizzaFactory : IFactory<PizzaModel>
  {
    public PizzaModel Create()
    {
      var p = new PizzaStore.Domain.Models.PizzaModel();
      // var baseprice = 8.0m;
      // var pricepertopping = 1.0m;

      p.Crust = new CrustModel();
      p.Size = new SizeModel();
      p.Toppings = new List<ToppingModel>();
            // p.Toppings = new List<ToppingModel>{ new ToppingModel() };
      // p.Price = baseprice + pricepertopping*p.Toppings.Count();

      return p;
    }
  }
}
