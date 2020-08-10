using System.Collections.Generic;
using System.Linq;
using PizzaStore.Client.Models;
using Xunit;

namespace PizzaStore.Testing.Tests
{
  public class OrderTest
  {
    [Fact]
    public void Test_PizzaViewModel()
    {
      //arrange

      //act
      PizzaViewModel sut = new PizzaViewModel();

      //assert
      var no_pizzatypes = sut.Types.Count();
      Assert.True(sut.ToppingSets.Count() == no_pizzatypes);
      Assert.True(sut.Prices.Count() == no_pizzatypes);
    }
  }
}