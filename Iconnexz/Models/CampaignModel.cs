using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Iconnexz.Models
{
    [Table("Campaign", Schema = "Campaign")]
    public class CampaignModel
    {
        [Key]
        public int CampaignId { get; set; }
        public string CampaignName { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Vendor { get; set; }
    }
}
