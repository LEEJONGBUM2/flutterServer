using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Iconnexz.Models
{
    [Table("ServiceVariation", Schema = "ManageService")]
    public class ServiceVariationsModel
    {
        [Key]
        public int VariationsId { get; set; }
        public string VariationName { get; set; }
        public string Vendor { get; set; }
        public string Control { get; set; }

    }
}
