using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Iconnexz.Models
{
    [Table("VendorAddress", Schema = "VendorCMS")]
    public class VendorAddressModel
    {
        [Key]
        public int VendorAddressId { get; set; }
        public string VendorAddress { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string BusinessLatitude { get; set; }
        public string BusinessLongitude { get; set; }
        public string IsPublished { get; set; }
    }
}