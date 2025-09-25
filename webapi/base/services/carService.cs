namespace webapi.services
{
  public interface ICar
  {
    void Accele();

    void Break();
  }

  public class Car : ICar, ITransient
  {
    public void Accele()
    {
      Console.WriteLine($"---------- Car: Speed Up!");
    }

    public void Break()
    {
      Console.WriteLine($"---------- Car: Slow Down!");
    }
  }

  public class SUVCar : ICar, ITransient
  {
    public void Accele()
    {
      Console.WriteLine($"---------- SUV Car: Speed Up!");
    }

    public void Break()
    {
      Console.WriteLine($"---------- SUV Car: Slow Down!");
    }
  }

  public class CarService(IEnumerable<ICar> cars) : ICarService, ISingleton
  {

    #region Properties ####################################################################################################################

    private readonly IEnumerable<ICar> _cars = cars;

    #endregion ############################################################################################################################

    #region Public Functions ##############################################################################################################

    public void Accele(string carType)
    {
      var instance = GetInstance(carType);
      if (instance != null)
      {
        instance.Accele();
      }
    }

    public void Break(string carType)
    {
      var instance = GetInstance(carType);
      if (instance != null)
      {
        instance.Break();
      }
    }

    #endregion ############################################################################################################################

    #region Private Functions #############################################################################################################

    private ICar? GetInstance(string carType)
    {
      ICar? instance = null;
      switch (carType)
      {
        case "car":
          instance = _cars.FirstOrDefault(x => x.GetType().Name == "Car");
          break;
        case "suv":
          instance = _cars.FirstOrDefault(x => x.GetType().Name == "SUVCar");
          break;
      }

      return instance;
    }

    #endregion ############################################################################################################################

  }

  public interface ICarService
  {
    void Accele(string carType);

    void Break(string carType);
  }

}