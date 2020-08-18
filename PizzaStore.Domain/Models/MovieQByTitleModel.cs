using System.Collections.Generic;

namespace PizzaStore.Domain.Models
{
  public class MovieQByTitleModel
  {
    public List<MovieImdbModel> movie_results { get; set; }
    public int search_results { get; set; }
    public string status { get; set; }
    public string status_message { get; set; }

    public MovieQByTitleModel()
    {

    }
  }
}