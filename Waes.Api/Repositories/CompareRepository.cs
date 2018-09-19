using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Waes.Api.Models;

namespace Waes.Api.Repositories
{
    public class CompareRepository : ICompareRepository
    {
        readonly ApiContext db;
        public CompareRepository(ApiContext dbContext)
        {
            db = dbContext;
        }

        public void Add(Element model)
        {
            var existing = db.Elements.Where(x => x.Id == model.Id && x.Direction == model.Direction).FirstOrDefault();

            if (existing != null)
            {
                existing.Value = model.Value;
                db.Elements.Update(existing);
            }
            else
            {
                db.Elements.Add(model);
            }

            db.SaveChanges();
        }

        public IList<Element> GetById(int Id)
        {
            return db.Elements.Where(x => x.Id == Id).ToList();
        }
    }
}
