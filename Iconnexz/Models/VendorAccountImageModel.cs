using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Iconnexz.Models
{
    
    [Table("VendorAccountImage", Schema = "VendorCMS")]
    public class VendorAccountImageModel
    {
        [Key]
        public int VendorAccountImageId { get; set; }
        public byte[] ThumbnailImage { get; set; }
        public string ThumbnailImageFilePath { get; set; }
        public byte[] VendorAccountImage { get; set; }
        public string VendorAccountImageFilePath { get; set; }
    }
}
