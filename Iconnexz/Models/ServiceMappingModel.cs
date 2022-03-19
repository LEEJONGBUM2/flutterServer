using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Iconnexz.Models
{
    [Table("ServiceMapping", Schema = "ManageService")]
    public class ServiceMappingModel
    {
        [Key]
        public int MappingId { get; set; }
        public string Mapping { get; set; }
        public string Vendor { get; set; }

    }
}
