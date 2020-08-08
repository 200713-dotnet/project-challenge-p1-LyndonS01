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

  }

}
