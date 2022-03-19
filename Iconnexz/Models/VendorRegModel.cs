using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Iconnexz.Models
{
    [Table("VendorReg", Schema = "VendorCMS")]
    public class VendorRegModel
    {
        [Key]
        public int VendorRegId { get; set; }
        public string BusinessType { get; set; }
        public string VendorName { get; set; }
        public int RegisterOfCompanyNo { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string companyDescription { get; set; }
        public int IntroducerCode { get; set; }
        public string contactNumber { get; set; }
        public int VerificationCode { get; set; }
        public string MondayCheck { get; set; }
        public string TuesdayCheck { get; set; }
        public string WednesdayCheck { get; set; }
        public string ThursdayCheck { get; set; }
        public string FridayCheck { get; set; }
        public string SaturdayCheck { get; set; }
        public string SundayCheck { get; set; }
        public string StartBusinessHours { get; set; }
        public string EndBusinessHours { get; set; }
        public string personInChargeName { get; set; }
        public string emailAddress { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string ContactNumber2 { get; set; }
        public int VerificationCode2 { get; set; }
        public string ServiceCategory { get; set; }
        public string BusinessCategory { get; set; }
        public string TypeOfBusiness { get; set; }
        public string CountryCategory { get; set; }
        public string RestaurantCategory { get; set; }
        public string TypeOfFood { get; set; }
        public string address { get; set; }
        public string country { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public int Postcode { get; set; }
        public string shopLatitude { get; set; }
        public string shopLongitude { get; set; }
        public string flatRate { get; set; }
        public string forFirst { get; set; }
        public string everyAdditional { get; set; }
        public string bankName { get; set; }
        public string bankAccountNo { get; set; }
    }
}
