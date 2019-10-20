using System;
using System.Collections.Generic;
using keepr.Models;
using keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{
  //   [Authorize]
  [ApiController]
  [Route("/api/vaults")]
  public class VaultsController : ControllerBase
  {
    private readonly VaultsService _vs;
    public VaultsController(VaultsService vs)
    {
      _vs = vs;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Vault>> Get()
    {
      try
      {
        return Ok(_vs.Get());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}