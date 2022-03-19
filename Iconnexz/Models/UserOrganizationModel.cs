using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Iconnexz.Models
{
    [Table("UserOrganization", Schema = "UserCMS")]
    public class UserOrganizationModel
    {
        [Key]
        public int UserId { get; set; }

        public string CompanyName { get; set; }

        public int CompanyRocNumber { get; set; }

        public string Address { get; set; }

        public string Country { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public int PostalCode { get; set; }

        [EmailAddress]
        public string EmailAddress { get; set; }

        public string Password { get; set; }

        public string ContactNumber { get; set; }
    }
}
