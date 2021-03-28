using BillCalc.DAL.EF;
using BillCalc.DAL.Entities;
using BillCalc.DAL.Interfaces;
using System;

namespace BillCalc.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private BillCalcContext db;

        private HappeningRepository happeningRepository;
        private DealRepository dealRepository;
        private ClientRepository clientRepository;

        private bool _disposed = false;

        public EFUnitOfWork(string connectionString)
        {
            db = new BillCalcContext(connectionString);
        }

        public IRepository<Happening> Happenings
        {
            get
            {
                if (happeningRepository == null)
                {
                    happeningRepository = new HappeningRepository(db);
                }

                return happeningRepository;
            }
        }

        public IRepository<Deal> Deals
        {
            get
            {
                if (dealRepository == null)
                {
                    dealRepository = new DealRepository(db);
                }

                return dealRepository;
            }
        }

        public IRepository<Client> Clients
        {
            get
            {
                if (clientRepository == null)
                {
                    clientRepository = new ClientRepository(db);
                }

                return clientRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (_disposed == false)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
