using BillCalc.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillCalc.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Happening> Happenings { get; }
        IRepository<Deal> Deals { get; }
        IRepository<Client> Clients { get; }

        void Save();
    }
}
