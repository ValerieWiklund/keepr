using System;
using System.Data;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
  public class KeepsRepository : BaseApiRepository<Keep, int>
  {
    public KeepsRepository(IDbConnection db) : base(db, "keeps")
    { }

    // private readonly IDbConnection _kdb;
    // public KeepsRepository(IDbConnection kdb)
    // {
    //   _kdb = kdb;
    // }

    public override int Create(Keep newKeep)
    {
      string sql = @"
        INSERT INTO keeps
        (name, description, img, isPrivate)
        VALUES
        (@Name, @Description, @Img, @IsPrivate)";
      return _db.ExecuteScalar<int>(sql, newKeep);
    }

    public override void Edit(Keep keep)
    {
      string sql = @"
                UPDATE keepss
                SET
                    name = @Name,
                    description = @Description,
                    img = @Img,
                    isPrivate = @IsPrivate
                WHERE id = @Id";
      _db.Execute(sql, keep);
    }
  }
}