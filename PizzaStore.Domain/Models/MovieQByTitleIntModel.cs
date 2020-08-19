using System.Collections.Generic;

namespace PizzaStore.Domain.Models
{
  public class MovieQByTitleIntModel : MovieQByTitleModelBase
  {
    public List<MovieImdbIntModel> Movie_Results { get; set; }
    public MovieQByTitleIntModel()
    {

    }
  }
}