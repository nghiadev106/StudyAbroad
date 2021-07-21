using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudyAbroad.Web.Models
{
    public class OrderCategoryViewModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Bạn cần nhập tên danh mục")]
        [StringLength(120, ErrorMessage = "Tên danh mục không quá 120 ký tự")]
        public string Name { get; set; }
        public string Description { get; set; }

        [Required(ErrorMessage = "Bạn cần chọn trạng thái")]
        public Nullable<int> Status { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    }
}