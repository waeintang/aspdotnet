namespace Client.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(ClientContactMetaData))]
    public partial class ClientContact
    {
    }
    
    public partial class ClientContactMetaData
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int ClientId { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string Occupation { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string ClientName { get; set; }
        
        [StringLength(250, ErrorMessage="欄位長度不得大於 250 個字元")]
        [Required]
        public string ClientEmail { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string ClientMobile { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string ClientPhone { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
    
        public virtual ClientData ClientData { get; set; }
    }
}
