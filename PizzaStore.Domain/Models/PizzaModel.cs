using System.Collections.Generic;
using System.Linq;

namespace PizzaStore.Domain.Models
{
  public class PizzaModel : AModel
  {
    public CrustModel Crust { get; set; }
    public SizeModel Size { get; set; }
    public List<ToppingModel> Toppings { get; set; }

    public decimal Price { get; set; }

    //   public PizzaModel(string name, CrustModel crust, SizeModel size, List<ToppingModel> toppings)
    //   {
    //     var baseprice = 8.0m;
    //     var pricepertopping = 1.0m;
    //     Name = name;
    //     Crust = crust;
    //     Size = size;
    //     Price = baseprice + pricepertopping*toppings.Count();
    //   }
    // }
  }

}
