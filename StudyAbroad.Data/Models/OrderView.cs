using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyAbroad.Data.Models
{
    public class OrderView
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public Nullable<System.DateTime> TestDay { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<decimal> Salary { get; set; }
        public Nullable<decimal> Price { get; set; }
        public string Image { get; set; }
        public Nullable<int> Count { get; set; }
        public Nullable<int> CountCustomer { get; set; }
        public string Address { get; set; }

    }
}
