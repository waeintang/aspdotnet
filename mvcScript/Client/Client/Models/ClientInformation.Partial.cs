namespace Client.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(ClientInformationMetaData))]
    public partial class ClientInformation
    {
    }
    
    public partial class ClientInformationMetaData
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int ClientId { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string BankName { get; set; }
        [Required]
        public int BankCode { get; set; }
        public Nullable<int> BranchBankCode { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string AccountName { get; set; }
        
        [StringLength(20, ErrorMessage="欄位長度不得大於 20 個字元")]
        [Required]
        public string AccountNo { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
    
        public virtual ClientData ClientData { get; set; }
    }
}
