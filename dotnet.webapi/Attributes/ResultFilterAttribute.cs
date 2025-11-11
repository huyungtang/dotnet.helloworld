using Microsoft.AspNetCore.Mvc;
using Filters = Microsoft.AspNetCore.Mvc.Filters;

namespace dotnet.Attributes
{
  public class ResultFilterAttribute : Filters.ResultFilterAttribute
  {
    public override Task OnResultExecutionAsync(Filters.ResultExecutingContext context, Filters.ResultExecutionDelegate next)
    {
      Console.WriteLine("ResultFilterAttribute.OnResultExecutionAsync ----------");
      //await base.OnResultExecutionAsync(context, next);

      if (context.Result is ObjectResult originalResult)
      {
        // Create a new custom response object.
        var customResponse = new
        {
          DataResult = originalResult.Value,
          TimeStamp = DateTimeOffset.Now,
        };

        // Replace the original result with a new ObjectResult that contains the custom response.
        context.Result = new ObjectResult(customResponse) { StatusCode = 200 };

        Console.WriteLine("ResultFilterAttribute.OnResultExecutionAsync ----------");

      }

      return base.OnResultExecutionAsync(context, next);
    }
  }


}
