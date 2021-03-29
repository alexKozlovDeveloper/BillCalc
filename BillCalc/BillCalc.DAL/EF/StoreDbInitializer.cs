using BillCalc.DAL.Entities;
using System;
using System.Data.Entity;

namespace BillCalc.DAL.EF
{
    public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<BillCalcContext>
    {
        protected override void Seed(BillCalcContext db)
        {
            var happening1 = new Happening { Name = "Italy", Date = DateTime.Now };
            var happening2 = new Happening { Name = "Denmark", Date = DateTime.Now.AddDays(-100) };

            var client1 = new Client { Name = "Aliaksei", PhoneNumber = "111" };
            var client2 = new Client { Name = "Andrew", PhoneNumber = "222" };
            var client3 = new Client { Name = "Alex", PhoneNumber = "333" };
            var client4 = new Client { Name = "Tony", PhoneNumber = "444" };
            var client5 = new Client { Name = "Jon", PhoneNumber = "555" };

            var deal1 = new Deal { Happening = happening1, Date = DateTime.Now, Description = "market" };

            deal1.Clients.Add(client1);
            deal1.Clients.Add(client2);
            deal1.Clients.Add(client3);

            var deal2 = new Deal { Happening = happening1, Date = DateTime.Now, Description = "cafe" };

            deal1.Clients.Add(client1);
            deal1.Clients.Add(client4);
            deal1.Clients.Add(client5);

            var deal3 = new Deal { Happening = happening2, Date = DateTime.Now, Description = "mall" };

            deal1.Clients.Add(client1);
            deal1.Clients.Add(client2);
            deal1.Clients.Add(client3);
            deal1.Clients.Add(client4);
            deal1.Clients.Add(client5);

            //

            db.Happenings.Add(happening1);
            db.Happenings.Add(happening2);

            db.Clients.Add(client1);
            db.Clients.Add(client2);
            db.Clients.Add(client3);
            db.Clients.Add(client4);
            db.Clients.Add(client5);

            db.Deals.Add(deal1);
            db.Deals.Add(deal2);
            db.Deals.Add(deal3);

            db.SaveChanges();
        }
    }
}
