using System;
using System.Collections.Generic;

namespace BillCalc.DAL.Entities
{
    public class Deal
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public int? HappeningId { get; set; }
        public virtual Happening Happening { get; set; }

        public virtual ICollection<Client> Clients { get; set; }

        public Deal()
        {
            Clients = new List<Client>();
        }
    }
}
