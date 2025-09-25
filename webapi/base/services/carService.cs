using webapi.interfaces;
using webapi.Providers;

namespace webapi.services
{

  public class Car : ISedanCar, ISingleton
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

  public class SUVCar : ISUVCar, ISingleton
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

  public class CarService(ICarProvider provider) : ICarService, ISingleton
  {

    #region Properties ####################################################################################################################

    private readonly ICarProvider _provider = provider;

    #endregion ############################################################################################################################

    #region Public Functions ##############################################################################################################

    public void Accele<T>()
      where T : ICar
    {
      _provider.CreateCar<T>()?.Accele();
    }

    public void Break<T>()
      where T : ICar
    {
      _provider.CreateCar<T>()?.Break();
    }

    #endregion ############################################################################################################################

    #region Private Functions #############################################################################################################


    #endregion ############################################################################################################################

  }

}