using BillCalc.DAL.Entities;
using System;
using System.Data.Entity;

namespace BillCalc.DAL.EF
{
    public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<BillCalcContext>
    {
        protected override void Seed(BillCalcContext db)
        {
            db.Happenings.Add(new Happening { Name = "Italy", Date = DateTime.Now });
            db.Happenings.Add(new Happening { Name = "Denmark", Date = DateTime.Now.AddDays(-100) });

            db.Clients.Add(new Client {  Name="Aliaksei", PhoneNumber = "111" });
            db.Clients.Add(new Client {  Name="Andrew", PhoneNumber = "222" });
            db.Clients.Add(new Client {  Name="Alex", PhoneNumber = "333" });
            db.Clients.Add(new Client {  Name="Tony", PhoneNumber = "444" });
            db.Clients.Add(new Client {  Name="Jon", PhoneNumber = "555" });

            db.SaveChanges();
        }
    }
}
