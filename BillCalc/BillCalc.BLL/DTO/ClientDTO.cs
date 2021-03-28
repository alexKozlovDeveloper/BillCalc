using System.Collections.Generic;

namespace BillCalc.BLL.DTO
{
    public class ClientDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public ICollection<int> Deals { get; set; }

        public ClientDTO()
        {
            Deals = new List<int>();
        }
    }
}
