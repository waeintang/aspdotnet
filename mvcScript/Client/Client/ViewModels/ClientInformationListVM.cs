using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Client.ViewModels
{
    public class ClientInformationListVM
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        [Required]
        [Display(Name = "銀行名稱")]
        public string BankName { get; set; }
        [Required]
        [Display(Name = "銀行代碼")]
        public int BankCode { get; set; }
        [Required]
        [Display(Name = "銀行分支代碼")]
        public Nullable<int> BranchBankCode { get; set; }
        [Required]
        [Display(Name = "帳號名稱")]
        public string AccountName { get; set; }
        [Required]
        [Display(Name = "帳號號碼")]
        public string AccountNo { get; set; }

      
    }
}