using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Iconnexz.Models
{
    [Table("UserIndividual", Schema = "UserCMS")]
    public class UserIndividualModel
    {
        [Key]
        public int UserId { get; set; }

        public string FullName { get; set; }

        [EmailAddress]
        public string EmailAddress { get; set; }

        public string Password { get; set; }

        public string ContactNumber { get; set; }

    }
}
