using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Iconnexz.Models
{
    [Table("BankInformation", Schema = "VendorCMS")]
    public class BankInformationModel
    {
        [Key]
        public int BankInformationId { get; set; }
        public string BankName { get; set; }
        public string AccountName { get; set; }
        public string IsPublished { get; set; }
    }
}