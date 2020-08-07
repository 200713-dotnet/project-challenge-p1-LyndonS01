using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using PizzaStore.Domain.Factories;
using PizzaStore.Domain.Models;

namespace PizzaStore.Client.Models
{
  public class PizzaViewModel
  {
    public const int _min_toppings = 2;
    public const int _max_toppings = 5;

    // out to the client
    public List<CrustModel> Crusts { get; set; }
    public List<SizeModel> Sizes { get; set; }
    public List<ToppingModel> Toppings { get; set; }
    public List<string> Types { get; set; }
    public Dictionary<string, decimal> Prices { get; set; }

    // in from the client
    [Required(ErrorMessage = "A type is required")]
    public string Type { get; set; }
    [Required(ErrorMessage = "A crust is required")]
    public string Crust { get; set; }
    [Required(ErrorMessage = "A size is required")]
    public string Size { get; set; }
    [DisplayName("Toppings")]
    [Required(ErrorMessage="{0} is required.")]
    [MinLength(_min_toppings, ErrorMessage = "A minimum of {1} topping(s) is required")]
    [MaxLength(_max_toppings, ErrorMessage = "There is a limit of {1} toppings")]
    public List<string> SelectedToppings { get; set; }
    // public bool SelectedTopping { get; set; }

    public PizzaViewModel()
    {
      Crusts = new List<CrustModel>()
        {
          new CrustModel{Name = "Thin"},
          new CrustModel{Name = "Thick"},
          new CrustModel{Name = "Stuffed"}
        };

      Sizes = new List<SizeModel>()
        {
          new SizeModel{Name = "Regular"},
          new SizeModel{Name = "Large"},
          new SizeModel{Name = "Family"}
        };

      Toppings = new List<ToppingModel>()
        {
          new ToppingModel{Name = "cheese"},
          new ToppingModel{Name = "extra cheese"},
          new ToppingModel{Name = "pepperoni"},
          new ToppingModel{Name = "ham"},
          new ToppingModel{Name = "pineapple"},
          new ToppingModel{Name = "mushrooms"},
          new ToppingModel{Name = "bell peppers"},
          new ToppingModel{Name = "sausage"}                
        };
      
      Types = new List<string>
        {
          "Cheese",
          "Pepperoni",
          "Hawaiian"
        };

      // Type = "Custom";  //default value for View Model  

      Prices = new Dictionary<string, decimal>
        {
          {"Cheese", 8.0m},
          {"Pepperoni", 8.5m},
          {"Hawaiian", 8.5m}
        };
    }
  }
}
