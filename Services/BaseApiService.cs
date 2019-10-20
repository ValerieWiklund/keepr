using System;
using System.Collections.Generic;
using Keepr.Repositories;

namespace Keepr.Services
{
  public abstract class BaseApiService<T, Tid>
  {
    internal readonly BaseApiRepository<T, Tid> _repo;
    public BaseApiService(BaseApiRepository<T, Tid> repo)
    {
      _repo = repo;
    }

    public virtual IEnumerable<T> Get()
    {
      return _repo.Get();
    }
    public virtual T Get(Tid id)
    {
      T exists = _repo.Get(id);
      if (exists == null) { throw new Exception("Invalid Id"); }
      return exists;
    }

    public virtual IEnumerable<T> GetByUser()
    {
      return _repo.Get();
    }


    public virtual T Create(T newT)
    {
      int id = _repo.Create(newT);

      return newT;
    }

    public virtual T Edit(T editT)
    {
      return editT;
    }


    public virtual string Delete(Tid id)
    {
      T exists = _repo.Get(id);
      if (exists == null) { throw new Exception("Invalid Id"); }
      _repo.Delete(id);
      return "Successfully Deleted";
    }

  }
}