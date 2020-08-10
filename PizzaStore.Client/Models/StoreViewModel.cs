using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using PizzaStore.Domain.Models;

namespace PizzaStore.Client.Models
{
  public class StoreViewModel : AModel
  {
    // out to the client
    public List<PizzaModel> Pizzas { get; set; }        // use Pizza Models instead of Order Models for now
    public int Qty { get; set; }
    public decimal Price { get; set; }
    public List<string> Toppings { get; set; }

    // in from the client
    public StoreViewModel() {}
  }
}