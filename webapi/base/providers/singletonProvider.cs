namespace webapi.Providers
{
  public class SingletonProvider
  {

    private SingletonProvider() { }

    #region Properties ####################################################################################################################

    private static Lazy<SingletonProvider> _context = new Lazy<SingletonProvider>(() => new SingletonProvider());

    private int Counter { get; set; } = 0;

    public static SingletonProvider Context
    {
      get
      {
        return _context.Value;
      }
    }

    #endregion ############################################################################################################################

    #region Public Functions ##############################################################################################################

    public int Current()
    {
      return ++Counter;
    }

    #endregion ############################################################################################################################

    #region Private Functions #############################################################################################################


    #endregion ############################################################################################################################

  }
}