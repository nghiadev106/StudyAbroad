using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudyAbroad.Web.Models
{
    public class OrderViewModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Bạn cần nhập tên đơn hàng")]
        [StringLength(120, ErrorMessage = "Tên đơn hàng không quá 120 ký tự")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Bạn cần chọn danh mục")]
        public int CategoryID { get; set; }
        public string Description { get; set; }

        [AllowHtml]
        public string Content { get; set; }
        [Required(ErrorMessage = "Bạn cần chọn ngày thi Test")]
        public Nullable<System.DateTime> TestDay { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }

        [Required(ErrorMessage = "Bạn cần chọn trạng thái ")]
        public Nullable<int> Status { get; set; }

        [Required(ErrorMessage = "Bạn cần Nhập mức lương")]
        public Nullable<decimal> Salary { get; set; }
        [Required(ErrorMessage = "Bạn cần Nhập số lượng")]
        public Nullable<int> Count { get; set; }

        [Required(ErrorMessage = "Bạn cần nhập địa chỉ")]
        [StringLength(250, ErrorMessage = "Địa chỉ không quá 250 ký tự")]
        public string Address { get; set; }
        public string Image { get; set; }

        [Required(ErrorMessage = "Bạn cần Nhập đơn giá")]
        public Nullable<decimal> Price { get; set; }

        public HttpPostedFileWrapper LogoFile { get; set; }
    }
}