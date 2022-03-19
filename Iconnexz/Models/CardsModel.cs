using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Iconnexz.Models
{
    [Table("Cards", Schema = "Wallet")]
    public class CardsModel
    {
        [Key]
        public int CardId { get; set; }
        public string Vendor { get; set; }
        public string VirtualCardNumber { get; set; }
        public string Expiry { get; set; }
        public string CVV { get; set; }
        public string CardType { get; set; }
    }
}
