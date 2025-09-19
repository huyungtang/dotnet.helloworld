using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace webapi.services
{
  public static partial class ServiceRegistrationExtension
  {
    #region Properties ####################################################################################################################



    #endregion ############################################################################################################################

    #region Public Functions ##############################################################################################################

    public static void AddWebapiServicesRegistration(this IServiceCollection services)
    {
      Assembly.GetExecutingAssembly()
              ?.GetTypes()
              .Where(tp => tp.IsClass
                        && !tp.IsAbstract
                        && tp.FullName != null
                        && tp.FullName.EndsWith("Service"))
              .ToList()
              .ForEach(service => services.AddScoped(service, service));
    }

    #endregion ############################################################################################################################

    #region Private Functions #############################################################################################################



    #endregion ############################################################################################################################
  }

}
