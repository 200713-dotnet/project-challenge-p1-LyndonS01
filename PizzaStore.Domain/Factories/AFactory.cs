namespace PizzaStore.Domain.Factories
{
  public abstract class AFactory<T> where T : class, new()
  {
    public abstract T CreateRegular();

    public virtual T CreateSpeciality()
    {
      return new T();
    }
  }
}
