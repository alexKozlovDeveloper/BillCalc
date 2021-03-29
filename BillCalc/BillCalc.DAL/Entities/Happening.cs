using System;
using System.Collections.Generic;

namespace BillCalc.DAL.Entities
{
    public class Happening
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }

        public virtual ICollection<Deal> Deals { get; set; }

        public Happening()
        {
            Deals = new List<Deal>();
        }
    }
}
