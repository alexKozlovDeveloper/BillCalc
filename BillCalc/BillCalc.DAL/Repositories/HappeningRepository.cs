using BillCalc.DAL.EF;
using BillCalc.DAL.Entities;
using BillCalc.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BillCalc.DAL.Repositories
{
    public class HappeningRepository : IRepository<Happening>
    {
        private BillCalcContext db;

        public HappeningRepository(BillCalcContext context)
        {
            this.db = context;
        }

        public IEnumerable<Happening> GetAll()
        {
            return db.Happenings;
        }

        public Happening Get(int id)
        {
            return db.Happenings.Find(id);
        }

        public void Create(Happening happening)
        {
            db.Happenings.Add(happening);
        }

        public void Update(Happening happening)
        {
            db.Entry(happening).State = EntityState.Modified;
        }

        public IEnumerable<Happening> Find(Func<Happening, bool> predicate)
        {
            return db.Happenings.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Happening happening = db.Happenings.Find(id);

            if (happening != null)
            {
                db.Happenings.Remove(happening);
            }
        }
    }
}
