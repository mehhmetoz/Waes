using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Waes.Api.Models
{
    public interface ICompare
    {
        void Insert(int Id, string direction, string value);
        CompareResult GetResult(int Id);

    }
}
