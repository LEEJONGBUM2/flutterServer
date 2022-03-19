using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Iconnexz.Models
{
    [Table("VendorRegImage", Schema = "VendorCMS")]
    public class VendorRegImageModel
    {
        [Key]
        public int VendorRegImageId { get; set; }
        public byte[] ThumbnailImage { get; set; }
        public string ThumbnailImageFilePath { get; set; }
        public byte[] VendorRegImage { get; set; }
        public string VendorRegImageFilePath { get; set; }
    }
}
