using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatingApp.Base.Contracts
{
  public interface IBaseRepository<T>: IDisposable where T:class
  {
    void Add<T>(T entity) where T : class;
    void Delete<T>(T entity) where T : class;

    Task<ICollection<T>> GetAll();
  }
}
