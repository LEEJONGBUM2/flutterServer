using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Iconnexz.Models
{
    [Table("AccountInfo", Schema = "VendorCMS")]
    public class AccountInfoModel
    {
        [Key]
        public int AccountInfoId { get; set; }
        public string PersonInChargeName { get; set; }
        public string PhoneNumber { get; set; }
        public string VendorEmail { get; set; }
        public string IsPublished { get; set; }
    }
}