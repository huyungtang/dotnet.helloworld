using System.Reflection;

namespace webapi.services
{
  public static class ServicesRegistrationExtension
  {

    #region Properties ####################################################################################################################



    #endregion ############################################################################################################################

    #region Public Functions ##############################################################################################################

    public static void AddProjectServicesRegistraction(this IServiceCollection services)
    {
      Assembly.GetExecutingAssembly()
              ?.GetTypes()
              .Where(tp => tp.IsClass
                        && !tp.IsAbstract
                        && tp.GetInterfaces()
                             .Any(i => i == typeof(ISingleton)
                                    || i == typeof(IScoped)
                                    || i == typeof(ITransient)))
              .ToList()
              .ForEach(tp =>
              {
                var iface = tp.GetInterfaces()
                              .Except([typeof(ISingleton), typeof(IScoped), typeof(ITransient)])
                              .FirstOrDefault();
                if (iface != null)
                {
                  if (typeof(ISingleton).IsAssignableFrom(tp))
                  {
                    services.AddSingleton(iface, tp);
                  }
                  else if (typeof(IScoped).IsAssignableFrom(tp))
                  {
                    services.AddScoped(iface, tp);
                  }
                  else if (typeof(ITransient).IsAssignableFrom(tp))
                  {
                    services.AddTransient(iface, tp);
                  }
                }

              });
    }

    #endregion ############################################################################################################################

    #region Private Functions #############################################################################################################



    #endregion ############################################################################################################################

  }

  public interface ISingleton { }

  public interface IScoped { }

  public interface ITransient { }
}