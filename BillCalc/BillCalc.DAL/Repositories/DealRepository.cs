using BillCalc.DAL.EF;
using BillCalc.DAL.Entities;
using BillCalc.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillCalc.DAL.Repositories
{
    public class DealRepository : IRepository<Deal>
    {
        private BillCalcContext db;

        public DealRepository(BillCalcContext context)
        {
            this.db = context;
        }

        public IEnumerable<Deal> GetAll()
        {
            return db.Deals;
        }

        public Deal Get(int id)
        {
            return db.Deals.Find(id);
        }

        public void Create(Deal deal)
        {
            db.Deals.Add(deal);
        }

        public void Update(Deal deal)
        {
            db.Entry(deal).State = EntityState.Modified;
        }

        public IEnumerable<Deal> Find(Func<Deal, bool> predicate)
        {
            return db.Deals.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Deal deal = db.Deals.Find(id);

            if (deal != null)
            {
                db.Deals.Remove(deal);
            }
        }
    }
}
