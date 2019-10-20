using System;
using System.Collections.Generic;
using System.Security.Claims;
using Keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
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
    public virtual ActionResult<IEnumerable<T>> Get()
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
    public virtual ActionResult<T> Get(Tid id)
    {
      try
      {
        return Ok(_service.Get(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("user/{id}")]
    public virtual ActionResult<IEnumerable<T>> GetByUser()
    {
      try
      {
        string userId = HttpContext.User.FindFirstValue("Id");
        return Ok(_service.Get());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [Authorize]
    [HttpPost]

    public virtual ActionResult<T> Create([FromBody] T newT)
    {
      try
      {
        return Ok(_service.Create(newT));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [Authorize]
    [HttpPut("{id}")]
    public virtual ActionResult<T> Edit([FromBody] T editT, Tid id)
    {
      try
      {

        return Ok(_service.Edit(editT));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [Authorize]
    [HttpDelete("{id}")]

    public virtual ActionResult<T> Delete(Tid id)
    {
      try
      {
        return Ok(_service.Delete(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}