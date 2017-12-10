namespace Client.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(ClientDataMetaData))]
    public partial class ClientData
    {
    }
    
    public partial class ClientDataMetaData
    {
        [Required]
        public int Id { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string ClientName { get; set; }
        
        [StringLength(8, ErrorMessage="欄位長度不得大於 8 個字元")]
        [Required]
        public string EINNumber { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string Phone { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string Fax { get; set; }
        
        [StringLength(100, ErrorMessage="欄位長度不得大於 100 個字元")]
        public string ContactAddress { get; set; }
        
        [StringLength(250, ErrorMessage="欄位長度不得大於 250 個字元")]
        public string Email { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
    
        public virtual ICollection<ClientContact> ClientContact { get; set; }
        public virtual ICollection<ClientInformation> ClientInformation { get; set; }
    }
}
