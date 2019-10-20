using System;
using System.Collections.Generic;
using System.Data;
using Dapper;

namespace Keepr.Repositories
{
  public abstract class BaseApiRepository<T, Tid>
  {
    internal readonly IDbConnection _db;
    private readonly string _table;
    public BaseApiRepository(IDbConnection db, string tablename)
    {
      _db = db;
      _table = tablename;
    }

    internal IEnumerable<T> Get()
    {
      string sql = $"SELECT * FROM {_table}";
      return _db.Query<T>(sql);
    }

    internal T Get(Tid id)
    {
      string sql = $"SELECT * FROM {_table} WHERE id = @id";
      return _db.QueryFirstOrDefault<T>(sql, new { id });
    }

    internal IEnumerable<T> GetByUser()
    {
      string sql = $"SELECT * FROM {_table} WHERE userId = @UserId";
      return _db.Query<T>(sql);
    }

    public virtual int Create(T newT)
    {
      string sql = @"
        ";
      return _db.ExecuteScalar<int>(sql, newT);
    }

    public virtual void Edit(T t)
    {
      string sql = @"
                UPDATE players
                SET
                    name = @Name,
                    teamId = @TeamId
                WHERE id = @Id";
      _db.Execute(sql, t);
    }

    internal void Delete(Tid id)
    {
      string sql = $"DELETE FROM {_table} WHERE id = @id";
      _db.Execute(sql, new { id });
    }

  }
}