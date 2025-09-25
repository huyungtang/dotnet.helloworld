using webapi.interfaces;
using webapi.services;

namespace webapi.Providers
{
  public interface ICarProvider
  {
    ICar? CreateCar<T>() where T : ICar;
  }

  public class CarProvider(IServiceProvider provider) : ICarProvider, ISingleton
  {

    #region Properties ####################################################################################################################

    private readonly IServiceProvider _provider = provider;

    #endregion ############################################################################################################################

    #region Public Functions ##############################################################################################################

    public ICar? CreateCar<T>()
      where T : ICar
    {
      return _provider.GetService<T>();
    }

    #endregion ############################################################################################################################

    #region Private Functions #############################################################################################################



    #endregion ############################################################################################################################

  }
}