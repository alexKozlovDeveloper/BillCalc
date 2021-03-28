using System;
using System.Collections.Generic;

namespace BillCalc.BLL.DTO
{
    public class DealDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public int HappeningId { get; set; }

        public ICollection<int> Clients { get; set; }

        public DealDTO()
        {
            Clients = new List<int>();
        }
    }
}
