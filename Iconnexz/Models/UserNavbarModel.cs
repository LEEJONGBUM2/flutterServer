using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Iconnexz.Models
{
    [Table("UserNavbar", Schema = "Navbar")]
    public class UserNavbarModel
    {
        [Key]
        public int NavbarId { get; set; }
        public string uItem1 { get; set; }
        public string uItem2 { get; set; }
        public string uItem3 { get; set; }
        public string uItem4 { get; set; }
        public string uItem5 { get; set; }
        public string uItem6 { get; set; }
        public string uItem7 { get; set; }

    }
}
