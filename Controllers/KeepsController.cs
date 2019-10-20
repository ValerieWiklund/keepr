using System;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
  [Route("/api/[controller]")]
  public class KeepsController : BaseApiController<Keep, int>
  {
    public KeepsController(BaseApiService<Keep, int> service) : base(service)
    {

    }

    [HttpPost]
    public override ActionResult<Keep> Create([FromBody] Keep newKeep)
    {
      try
      {
        return Ok(_service.Create(newKeep));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]

    public override ActionResult<Keep> Edit([FromBody] Keep editKeep, int id)
    {
      try
      {
        editKeep.Id = id;
        return Ok(_service.Edit(editKeep));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}