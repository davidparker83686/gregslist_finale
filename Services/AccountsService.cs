
using System;
using gregslist_finale.Models;
using gregslist_finale.Repositories;

namespace gregslist_finale.Services
{
  public class AccountsService
  {
    private readonly AccountsRepository _repo;

    public AccountsService(AccountsRepository repo)
    {
      _repo = repo;
    }

    internal Account GetOrCreateAccount(Account userInfo)
    {
      Account account = _repo.GetById(userInfo.Id);
      if (account == null)
      {
        return _repo.Create(userInfo);
      }
      return account;
    }
  }
}