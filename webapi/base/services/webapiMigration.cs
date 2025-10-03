using Microsoft.EntityFrameworkCore;

namespace webapi.services
{
  public static class WebapiMigration
  {

    #region Properties ####################################################################################################################



    #endregion ############################################################################################################################

    #region Public Functions ##############################################################################################################

    public static async void MapWebapiMigration(this IApplicationBuilder builder)
    {
      using (var scope = builder.ApplicationServices.CreateScope())
      {
        var context = scope.ServiceProvider.GetRequiredService<WebapiDBContext>();

        await context.Database.MigrateAsync();
      }
    }

    #endregion ############################################################################################################################

    #region Private Functions #############################################################################################################



    #endregion ############################################################################################################################

  }
}