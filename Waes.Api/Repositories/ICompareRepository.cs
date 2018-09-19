using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Waes.Api.Models;

namespace Waes.Api.Repositories
{
    public interface ICompareRepository : IRepository<Element>
    {
        IList<Element> GetById(int Id);
    }
}
