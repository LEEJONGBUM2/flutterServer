using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Iconnexz.Models
{
    [Table("Balance", Schema = "Wallet")]
    public class BalanceModel
    {
        [Key]
        public int BalanceId { get; set; }
        public int Balance { get; set; }
        public string Vendor { get; set; }
    }
}
