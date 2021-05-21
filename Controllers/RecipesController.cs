using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using gregslist_finale.Models;
using gregslist_finale.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace auth_cs_gregslist.Controllers
{
  [ApiController]
  [Route("api/[controller]")]

  // class-----------------------------------------
  public class RecipesController : ControllerBase
  {
    private readonly RecipesService _serviceVAR;
    private readonly AccountsService _acctServiceVAR;


    // constructor-----------------------------------------
    public RecipesController(RecipesService serviceVAR, AccountsService acctServiceVAR)
    {
      _serviceVAR = serviceVAR;
      _acctServiceVAR = acctServiceVAR;
    }


    [HttpGet]
    public ActionResult<IEnumerable<Recipe>> GetAll()
    {
      try
      {
        IEnumerable<Recipe> reciepesVAR = _serviceVAR.GetAll();
        return Ok(reciepesVAR);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    [HttpGet("{id}")]
    public ActionResult<Recipe> GetById(int id)
    {
      try
      {
        Recipe found = _serviceVAR.GetById(id);
        return Ok(found);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }



    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Recipe>> Create([FromBody] Recipe newRecipe)
    {
      try
      {
        // TODO[epic=Auth] Get the user info to set the creatorID
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        // safety to make sure an account exists for that user before CREATE-ing stuff.
        _acctServiceVAR.GetOrCreateAccount(userInfo);
        newRecipe.CreatorId = userInfo.Id;

        Recipe reciepe = _serviceVAR.Create(newRecipe);
        return Ok(reciepe);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult<Recipe>> Delete(int id)
    {
      try
      {
        // TODO[epic=Auth] Get the user info to set the creatorID
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        // safety to make sure an account exists for that user before CREATE-ing stuff.
        _serviceVAR.Delete(id, userInfo.Id);
        return Ok("Delorted");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }




  }
}