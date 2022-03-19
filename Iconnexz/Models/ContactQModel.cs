using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Iconnexz.Models
{
    [Table("ContactQ", Schema = "UserCMS")]
    public class ContactQModel
    {
        [Key]
        public int ContactQId { get; set; }
        public string Q1 { get; set; }
        public string C1 { get; set; }
        public string Q2 { get; set; }
        public string C2 { get; set; }
        public string Q3 { get; set; }
        public string C3 { get; set; }
        public string Q4 { get; set; }
        public string C4 { get; set; }
    }
}
