using Microsoft.AspNetCore.Mvc;

namespace dotnet.Controllers
{
  [ApiController]
  [Route("api/v{version:apiVersion}/[controller]")]
  public abstract class BaseController<QModel, VModel> : ControllerBase
    where QModel : class, new()
    where VModel : class, new()
  {
    [HttpGet("{id}")]
    public virtual VModel Get([FromRoute] ulong id)
    {
      throw new NotImplementedException();
    }

    [HttpGet]
    public virtual IEnumerable<VModel> GetAll([FromQuery] int page = 0, int size = 20)
    {
      throw new NotImplementedException();
    }

    [HttpPost]
    public virtual VModel Create([FromBody] VModel model)
    {
      throw new NotImplementedException();
    }

    [HttpPut]
    public virtual VModel Update([FromBody] VModel model)
    {
      throw new NotImplementedException();
    }

    [HttpDelete("{id}")]
    public virtual VModel Delete(ulong id)
    {
      throw new NotImplementedException();
    }
  }
}