using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Client.ViewModels
{
    public class ClientDataListVM
    {
        public int Id { get; set; }
    
        [Required]
        [Display(Name = "客戶名稱")]
        public string ClientName { get; set; }

        [Required]
        [Display(Name = "統一編號")]
        public string EINNumber { get; set; }

        [Required]
        [Display(Name = "手機")]
        public string Phone { get; set; }

        [Required]
        [Display(Name = "fax")]
        public string Fax { get; set; }

        [Required]
        [Display(Name = "聯絡地址")]
        public string ContactAddress { get; set; }

        [Required]
        [Display(Name = "電子郵件")]
        [EmailAddress]
        public string Email { get; set; }
    }
}