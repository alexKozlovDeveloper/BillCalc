using System;
using System.Collections.Generic;
namespace BillCalc.DAL.Entities
{
    public class Deal
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public int EventId { get; set; }
        public Happening Event { get; set; }

        public ICollection<Client> Deals { get; set; }

        public Deal()
        {
            Deals = new List<Client>();
        }
    }
}
