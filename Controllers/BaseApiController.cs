using System;
using keepr.Services;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{
  [ApiController]
  public abstract class BaseApiController<T, Tid> : ControllerBase
  {
    public readonly BaseApiService<T, Tid> _service;
    public BaseApiController(BaseApiService<T, Tid> service)
    {
      _service = service;
    }
    [HttpGet]
    public virtual ActionResult<IEnumberable<T>> Get()
    {
      try
      {
        return Ok(_service.Get());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public virtual ActionResult<T> GetAction(Tid id)
    {
      try
}




  }
  }