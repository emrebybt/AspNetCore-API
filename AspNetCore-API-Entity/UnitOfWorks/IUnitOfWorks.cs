using AspNetCore_API_Entity.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore_API_Entity.UnitOfWorks
{
    public interface IUnitOfWorks
    {
        IRepository<T> GetRepository<T>() where T : class, new();
        void Commit();
        Task CommitAsync();
    }
}
