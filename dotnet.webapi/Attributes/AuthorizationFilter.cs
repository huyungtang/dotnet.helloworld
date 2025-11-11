using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace dotnet.Attributes
{
  public class AuthorizationFilter : IAuthorizationFilter
  {

    public void OnAuthorization(AuthorizationFilterContext context)
    {
      if (!context.ActionDescriptor
                  .EndpointMetadata
                  .Any(x => x.GetType() == typeof(AllowAnonymousAttribute)))
      {
        context.Result = new JsonResult(new { code = 999 });
        return;
      }
    }
  }
}
