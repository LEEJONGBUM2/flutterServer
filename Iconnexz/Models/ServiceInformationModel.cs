using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Iconnexz.Models
{
    [Table("ServiceInformation", Schema = "ManageService")]
    public class ServiceInformationModel
    {
        [Key]
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }
        public string SSU { get; set; }
        public string ServicePrice { get; set; }
        public int Stock { get; set; }
        public string ServiceSpecialPrice { get; set; }
        public string SpecialPriceStart { get; set; }
        public string SpecialPriceEnd { get; set; }
        public string TaxType { get; set; }
        public string IsPublished { get; set; }
        public string Vendor { get; set; }
    }
}
