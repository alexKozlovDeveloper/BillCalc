using BillCalc.DAL.Entities;
using System.Data.Entity;

namespace BillCalc.DAL.EF
{
    public class BillCalcContext : DbContext
    {
        public DbSet<Happening> Happenings { get; set; }
        public DbSet<Deal> Deals { get; set; }
        public DbSet<Client> Clients { get; set; }

        static BillCalcContext()
        {
            Database.SetInitializer(new StoreDbInitializer());
        }

        public BillCalcContext(string connectionString)
            : base(connectionString)
        {

        }
    }
}
