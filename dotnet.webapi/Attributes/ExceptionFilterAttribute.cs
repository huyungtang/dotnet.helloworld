using Filters = Microsoft.AspNetCore.Mvc.Filters;

namespace dotnet.Attributes
{
  public class ExceptionFilterAttribute : Filters::ExceptionFilterAttribute
  {
    public override Task OnExceptionAsync(Filters::ExceptionContext context)
    {
      Console.WriteLine("Exception Filter ----------");


      return base.OnExceptionAsync(context);
    }

  }
}
