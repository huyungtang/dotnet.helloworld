using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dotnet.Controllers
{
  [AllowAnonymous]
  [ApiVersion(1.0)]
  public class SampleController : BaseController<SampleViewModel, SampleViewModel>
  {

    public override SampleViewModel Get([FromRoute] ulong id)
    {
      return new SampleViewModel { Id = id };
    }

    public override IEnumerable<SampleViewModel> GetAll([FromQuery] int page = 0, int size = 20)
    {
      return Enumerable.Range(1, size)
                       .Select(x => new SampleViewModel { Id = (ulong)x });
    }

    public override SampleViewModel Update([FromBody] SampleViewModel model)
    {
      model.Id += 10000000;

      return model;
    }

  }

  public class SampleViewModel
  {
    public ulong Id { get; set; }

  }
}
