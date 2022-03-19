using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Iconnexz.Models
{
    [Table("ServiceImage", Schema = "ManageService")]
    public class ServiceImageModel
    {
        [Key]
        public int ServiceImageId { get; set; }
        public byte[] ThumbnailImage { get; set; }
        public string ThumbnailImageFilePath { get; set; }
        public byte[] ServiceImage { get; set; }
        public string ServiceImageFilePath { get; set; }
    }
}
