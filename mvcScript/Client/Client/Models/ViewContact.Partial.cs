namespace Client.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(ViewContactMetaData))]
    public partial class ViewContact
    {
    }
    
    public partial class ViewContactMetaData
    {
        [Required]
        public int ClientId { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string ClientName { get; set; }
        public Nullable<int> ContactNum { get; set; }
        public Nullable<int> InfoNum { get; set; }
    }
}
