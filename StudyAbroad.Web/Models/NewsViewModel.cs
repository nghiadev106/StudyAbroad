using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudyAbroad.Web.Models
{
    public class NewsViewModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Bạn cần nhập tiêu đề tin tức")]
        [StringLength(120, ErrorMessage = "tiêu đề tin tức không quá 120 ký tự")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Bạn cần chọn danh mục")]
        public Nullable<int> CategoryID { get; set; }

        public string Description { get; set; }

        [AllowHtml]
        public string Content { get; set; }
        public string Image { get; set; }
        [Required(ErrorMessage = "Bạn cần chọn trạng thái ")]
        public Nullable<int> Status { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }

        public HttpPostedFileWrapper LogoFile { get; set; }
    }
}