using System;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class KeepsService : BaseApiService<Keep, int>
  {
    public KeepsService(BaseApiRepository<Keep, int> repo) : base(repo)
    { }
    // private readonly KeepsRepository _krepo;
    // public KeepsService(KeepsRepository krepo)
    // {
    //   _krepo = krepo;
    // }
    public override Keep Create(Keep newKeep)
    {
      int id = _repo.Create(newKeep);
      newKeep.Id = id;
      return newKeep;
    }

    public override Keep Edit(Keep editKeep)
    {
      Keep keep = _repo.Get(editKeep.Id);
      if (keep == null) { throw new Exception("Invalid Id"); }
      keep.Name = editKeep.Name;
      keep.Description = editKeep.Description;
      keep.Img = editKeep.Img;
      keep.IsPrivate = editKeep.IsPrivate;
      _repo.Edit(keep);
      return keep;
    }

  }
}