using System.Collections.Generic;

namespace PizzaStore.Domain.Models
{
  public class MovieQByTitleModelBase
  {
    public int Search_Results { get; set; }
    public string Status { get; set; }
    public string Status_message { get; set; }

    public MovieQByTitleModelBase()
    {

    }
  }
}