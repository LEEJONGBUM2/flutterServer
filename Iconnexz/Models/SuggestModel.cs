using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Iconnexz.Models
{
    [Table("Suggest", Schema = "UserCMS")]
    public class SuggestModel
    {
        [Key]
        public int SuggestId { get; set; }
        public string VendorName { get; set; }
        public string OwnerName { get; set; }
        public int HPNumber { get; set; }
        public int TelNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Street { get; set; }
        public int PostalCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}
