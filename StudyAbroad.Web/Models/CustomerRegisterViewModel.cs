using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudyAbroad.Web.Models
{
    public class CustomerRegisterViewModel
    {
        [Required(ErrorMessage = "Bạn cần nhập tên ")]
        [StringLength(120, ErrorMessage = "Tên không quá 120 ký tự")]
        public string Name { get; set; }

        [StringLength(10, ErrorMessage = "Số điện thoại không quá 10 ký tự")]
        [Required(ErrorMessage = "Bạn cần nhập số điện thoại.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Bạn cần nhập email.")]
        [EmailAddress(ErrorMessage = "Địa chỉ email không đúng.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Bạn cần nhập địa chỉ ")]
        [StringLength(120, ErrorMessage = "Đại chỉ không quá 120 ký tự")]
        public string Address { get; set; }
    }
}