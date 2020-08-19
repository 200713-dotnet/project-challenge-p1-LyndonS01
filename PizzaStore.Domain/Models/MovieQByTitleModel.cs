using System.Collections.Generic;

namespace PizzaStore.Domain.Models
{
  public class MovieQByTitleModel : MovieQByTitleModelBase
  {
    public List<MovieImdbModel> Movie_Results { get; set; }
    public MovieQByTitleModel()
    {

    }
  }
}