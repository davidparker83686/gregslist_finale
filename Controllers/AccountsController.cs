using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using gregslist_finale.Models;
using gregslist_finale.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace gregslist_finale.Controllers
{
  [ApiController]
  [Route("[controller]")]
  [Authorize]
  public class AccountsController : ControllerBase
  {
    private readonly AccountsService _service;
    private AccountsController(AccountsService service)
    {
      _service = service;
    }
    // _______________________________________________________________________________________
    [HttpGet]
    public async Task<ActionResult<Account>> Get()
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        Account currentUser = _service.GetOrCreateAccount(userInfo);
        return Ok(currentUser);
      }
      catch (Exception error)
      {
        return BadRequest(error.Message);
      }
    }
  }

  internal class AccountsService
  {
  }
}