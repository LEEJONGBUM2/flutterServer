using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Iconnexz.Models
{
    [Table("Contact", Schema = "UserCMS")]
    public class ContactModel
    {
        [Key]
        public int ContactId { get; set; }
        public string SelectDepartment { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string ContactNumber { get; set; }
        public string Message { get; set; }
    }
}
