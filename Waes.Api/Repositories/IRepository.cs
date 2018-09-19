using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Waes.Api.Repositories
{
    public interface IRepository<T> where T : class
    {
        void Add(T model);
    }
}
