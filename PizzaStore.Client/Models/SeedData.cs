// using PizzaStore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using domain = PizzaStore.Domain.Models;
using PizzaStore.Storing;
using System;
using System.Linq;
using System.Collections.Generic;
using PizzaStore.Domain.Models;

namespace PizzaStore.Client.Models
{
  public static class SeedData
  {
    public static void Initialize(IServiceProvider serviceProvider)
    {
      using (var context = new PizzaStoreDbContext(
          serviceProvider.GetRequiredService<
              DbContextOptions<PizzaStoreDbContext>>()))
      {
        // Look for any movies.
        if (!context.Crusts.Any())
        {
          context.Crusts.AddRange(
              new domain.CrustModel
              {
                Name = "Thick"
              },
              new domain.CrustModel
              {
                Name = "Thin"
              },
              new domain.CrustModel
              {
                Name = "Stuffed"
              }
          );
        }

        if (!context.Sizes.Any())
        {
          context.Sizes.AddRange(
              new domain.SizeModel
              {
                Name = "Regular"
              },
              new domain.SizeModel
              {
                Name = "Large"
              },
              new domain.SizeModel
              {
                Name = "Family"
              }
          );

        }

        if (!context.Toppings.Any())
        {
          context.Toppings.AddRange(
              new domain.ToppingModel
              {
                Name = "cheese"
              },
              new domain.ToppingModel
              {
                Name = "extra cheese"
              },
              new domain.ToppingModel
              {
                Name = "pepperoni"
              },
              new domain.ToppingModel
              {
                Name = "ham"
              },
              new domain.ToppingModel
              {
                Name = "pineapple"
              },
              new domain.ToppingModel
              {
                Name = "mushrooms"
              },
              new domain.ToppingModel
              {
                Name = "bell peppers"
              },
              new domain.ToppingModel
              {
                Name = "sausage"
              }
          );

        }
        
        if (!context.Pizzas.Any())
        {
          // adding Thin, Regular, Cheese Pizza
          var newP = new domain.PizzaModel();
          
          var newT = new domain.ToppingModel();
          // var toppingSet = new List<string>() {"cheese"};

          // foreach (var t in toppingSet)
          // {
          //   newT = new domain.ToppingModel();
          //   newT.Name = t;
          //   List<ToppingModel> newPizzaT = new List<ToppingModel>(); 
          //   newPizzaT.Add(newT);
          //   newP.Toppings.Add(newPizzaT);  
          // }

          // var newPizzaT = new List<ToppingModel>(); 
          List<ToppingModel> newPizzaT = new List<ToppingModel>();
          newT.Name = "cheese";
          newPizzaT.Add(newT);
          newP.Toppings = newPizzaT;           
          
          newP.Name = "Cheese";
          newP.Crust = new domain.CrustModel{Name = "Thin"};
          newP.Size = new domain.SizeModel{Name = "Regular"};

          context.Pizzas.Add(newP);
          // adding Thick, Large, Pepperoni Pizza

        }

        context.SaveChanges();
      }
    }
  }
}
