using System.Collections.Generic;

namespace BillCalc.DAL.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public ICollection<Deal> Deals { get; set; }

        public Client()
        {
            Deals = new List<Deal>();
        }
    }
}
