using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using PizzaStore.Domain.Factories;
using PizzaStore.Domain.Models;

namespace PizzaStore.Client.Models
{
  public class PizzaViewModel
  {
    // out to the client
    public List<CrustModel> Crusts { get; set; }
    public List<SizeModel> Sizes { get; set; }
    public List<ToppingModel> Toppings { get; set; }


    // in from the client
    [Required(ErrorMessage = "A crust is required")]
    public string Crust { get; set; }
    [Required(ErrorMessage = "A size is required")]
    public string Size { get; set; }
    [MinLength(2, ErrorMessage = "A minimum of 2 toppings are required")]
    [MaxLength(5, ErrorMessage = "There is a limit of 5 toppings")]
    public List<string> SelectedToppings { get; set; }
    // public bool SelectedTopping { get; set; }

    public PizzaViewModel()
    {
      Crusts = new List<CrustModel>();
      Crusts.Add(new CrustModel{Name = "Thin"});
      Crusts.Add(new CrustModel{Name = "Thick"});
      Crusts.Add(new CrustModel{Name = "Stuffed"});

      Sizes = new List<SizeModel>();
      Sizes.Add(new SizeModel{Name = "Regular"});
      Sizes.Add(new SizeModel{Name = "Large"});
      Sizes.Add(new SizeModel{Name = "Family"});

      Toppings = new List<ToppingModel>();
      Toppings.Add(new ToppingModel{Name = "cheese"});
      Toppings.Add(new ToppingModel{Name = "extra cheese"});
      Toppings.Add(new ToppingModel{Name = "pepperoni"});
      Toppings.Add(new ToppingModel{Name = "ham"});
      Toppings.Add(new ToppingModel{Name = "pineapple"});
      Toppings.Add(new ToppingModel{Name = "mushrooms"});
      Toppings.Add(new ToppingModel{Name = "bell peppers"});
      Toppings.Add(new ToppingModel{Name = "sausage"});
    }
  }
}
