using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using PizzaStore.Domain.Factories;
using PizzaStore.Domain.Models;

namespace PizzaStore.Client.Models
{
  public class MovieViewIntModel
  {

    // out to the client
    public List<MovieImdbIntModel> MovieResults { get; set; }
    public string Results { get; set; }

    // in from the client
    [DisplayName("Title")]
    [Required(ErrorMessage="{0} is required.")]
    public string Title { get; set; }
    
    public MovieViewIntModel()
    {
      
    }
  }
}