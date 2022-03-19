using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Iconnexz.Models
{
    [Table("Orders", Schema = "Orders")]
    public class OrdersModel
    {
        [Key]
        public int OrderId { get; set; }
        public string OrderStatus { get; set; }
        public string Vendor { get; set; }
        public string Customer { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string OrderTotal { get; set; }
    }
}
