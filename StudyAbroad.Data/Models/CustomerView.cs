using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyAbroad.Data.Models
{
    public class CustomerView
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public string Avatar { get; set; }
        public Nullable<System.DateTime> OrderTestDay { get; set; }
        public Nullable<int> Gender { get; set; }    
        public string OrderName { get; set; }
        public Nullable<decimal> OrderSalary { get; set; }
        public Nullable<decimal> OrderPrice { get; set; }
        public string OrderImage { get; set; }
        public string OrderAddress { get; set; }
    }
}
