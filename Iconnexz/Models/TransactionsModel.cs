using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Iconnexz.Models
{
    [Table("Transactions", Schema = "Wallet")]
    public class TransactionsModel
    {
        [Key]
        public int TransactionId { get; set; }
        public int Amount { get; set; }
        public string Username { get; set; }
        public string Date { get; set; }
        public string Reason { get; set; }
        public string Vendor { get; set; }
    }
}
