using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Iconnexz.Models
{
    [Table("Faq", Schema = "UserCMS")]
    public class FaqModel
    {
        [Key]
        public int FaqId { get; set; }
        public string Question1 { get; set; }
        public string Content1 { get; set; }
        public string Question2 { get; set; }
        public string Content2 { get; set; }
        public string Question3 { get; set; }
        public string Content3 { get; set; }
        public string Question4 { get; set; }
        public string Content4 { get; set; }
        public string Question5 { get; set; }
        public string Content5 { get; set; }
        public string Question6 { get; set; }
        public string Content6 { get; set; }
    }
}
