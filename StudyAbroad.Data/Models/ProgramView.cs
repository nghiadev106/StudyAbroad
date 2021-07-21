using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyAbroad.Data.Models
{
    public class ProgramView
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Detail { get; set; }
        public Nullable<System.DateTime> DateWorkStart { get; set; }
        public Nullable<System.DateTime> DateWorkEnd { get; set; }
        public string Note { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> Status { get; set; }
    }
}
