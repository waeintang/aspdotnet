using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Client.ViewModels
{
    public class ClientContactListVM
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        [Required]
        [Display(Name = "職業")]
        public string Occupation { get; set; }
        [Required]
        [Display(Name = "客戶名稱")]
        public string ClientName { get; set; }
        [Required]
        [Display(Name = "客戶電子信箱")]
        public string ClientEmail { get; set; }
        [Required]
        [Display(Name = "客戶手機")]
        public string ClientMobile { get; set; }
        [Required]
        [Display(Name = "客戶電話")]
        public string ClientPhone { get; set; }

    }
}