using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using V0 = dotnet.Controllers;

namespace dotnet.Controllers.v1
{
  [ApiVersion(2.0)]
  public class SampleController : V0::SampleController
  {
    public override SampleViewModel Get([FromRoute] ulong id)
    {
      return new SampleViewModel { Id = 10000000 + id };
    }

  }
}
