using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Waes.Api.Repositories;

namespace Waes.Api.Models
{
    public class Compare : ICompare
    {
        readonly ICompareRepository repository;

        public Compare(ICompareRepository repository)
        {
            this.repository = repository;
        }

        public void Insert(int id, string direction, string value)
        {
            repository.Add(new Element { Id = id, Direction = direction, Value = value });
        }

        public CompareResult GetResult(int Id)
        {
            var Elements = repository.GetById(Id);
            if (Elements.Count() < 2)
            {
                throw new ApplicationException("Insert left & right values");
            }
            
            return new CompareResult(Elements.First(x => x.Direction == "left").Value, Elements.First(x => x.Direction == "right").Value); // Fixed, there was a logical mistake in here both directions were "left"
        }


    }
}
