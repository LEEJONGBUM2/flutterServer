using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Iconnexz.Models
{
    [Table("BusinessInfo", Schema = "VendorCMS")]
    public class BusinessInfoModel
    {
        [Key]
        public int BusinessInfoId { get; set; }
        public string ContactNumber { get; set; }
        public string CompanyDescription { get; set; }
        public string BusinessStartTime { get; set; }
        public string BusinessFinishTime { get; set; }
        public string Monday { get; set; }
        public string Tuesday { get; set; }
        public string Wednesday { get; set; }
        public string Thursday { get; set; }
        public string Friday { get; set; }
        public string Saturday { get; set; }
        public string Sunday { get; set; }
        public string IsPublished { get; set; }
        public string PersonInChargeName { get; set; }
        public string PhoneNumber { get; set; }
        public string VendorEmail { get; set; }
        public string IsPublished2 { get; set; }
        public string VendorAddress { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string BusinessLatitude { get; set; }
        public string BusinessLongitude { get; set; }
        public string IsPublished3 { get; set; }
        public string BankName { get; set; }
        public string AccountNumber { get; set; }
        public string IsPublished4 { get; set; }
    }
}