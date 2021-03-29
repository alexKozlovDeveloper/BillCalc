using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BillCalc.WEB.Models
{
    public class DealViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}