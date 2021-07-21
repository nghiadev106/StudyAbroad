using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudyAbroad.Web.Models
{
    public class ProgramViewModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Bạn cần nhập tên chương trình")]
        [StringLength(120, ErrorMessage = "Tênchương trình không quá 120 ký tự")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Bạn cần nhập mô tả")]
        [StringLength(550, ErrorMessage = "Mô tả không quá 550 ký tự")]
        public string Description { get; set; }

        [AllowHtml]
        public string Detail { get; set; }


        [Required(ErrorMessage = "Bạn cần chọn ngày bắt đầu ")]
        public Nullable<System.DateTime> DateWorkStart { get; set; }

        [Required(ErrorMessage = "Bạn cần chọn ngày kết thúc ")]
        public Nullable<System.DateTime> DateWorkEnd { get; set; }

        [Required(ErrorMessage = "Bạn cần nhậpghi chú")]
        [StringLength(120, ErrorMessage = "ghi chú không quá 550 ký tự")]
        public string Note { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }

        [Required(ErrorMessage = "Bạn cần chọn trạng thái ")]
        public Nullable<int> Status { get; set; }
    }
}