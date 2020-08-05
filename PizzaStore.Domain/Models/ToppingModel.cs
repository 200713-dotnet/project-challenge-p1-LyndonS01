using System;
using System.Collections.Generic;

namespace PizzaStore.Domain.Models
{
  public class ToppingModel : AModel
  {
    public static implicit operator List<object>(ToppingModel v)
    {
      throw new NotImplementedException();
    }
  }
}