using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Iconnexz.Models
{
    [Table("Wallet", Schema = "Wallet")]
    public class WalletModel
    {
        [Key]
        public int WalletId { get; set; }
        public int Amount { get; set; }
        public string Username { get; set; }
        public string Date { get; set; }
        public string VirtualCardNumber { get; set; }
        public string Reason { get; set; }
        public string Vendor { get; set; }
    }
}
