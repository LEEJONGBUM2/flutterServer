using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Iconnexz.Models
{
        [Table("Images", Schema = "Image")]
        public class ImageModel
        {
            [Key]
            public int ImageId { get; set; }
            public string Title { get; set; }
            public byte[] Image { get; set; }
            public string ImageFilePath { get; set; }
        }
}
