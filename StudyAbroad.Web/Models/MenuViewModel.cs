using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudyAbroad.Web.Models
{
    public class MenuViewModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Bạn cần nhập tên menu")]
        [StringLength(50, ErrorMessage = "Tên menu không quá 50 ký tự")]
        public string Name { get; set; }
        public string Description { get; set; }

        [Required(ErrorMessage = "Bạn cần nhập URL")]
        [StringLength(50, ErrorMessage = "URL không quá 50 ký tự")]
        public string URL { get; set; }
        public string Icon { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> Status { get; set; }
    }
}