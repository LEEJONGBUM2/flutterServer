using Iconnexz.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Iconnexz.Authentication
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }
        public virtual DbSet<UserIndividualModel> UserIndividual { get; set; }
        public virtual DbSet<UserOrganizationModel> UserOrganization { get; set; }
        public virtual DbSet<VendorSidebarModel> VendorSidebar { get; set; }
        public virtual DbSet<ImageModel> Image { get; set; }
        public virtual DbSet<ServiceInformationModel> ServiceInformation { get; set; }
        public virtual DbSet<ServiceImageModel> ServiceImage { get; set; }
        public virtual DbSet<ServiceVariationsModel> ServiceVariations { get; set; }
        public virtual DbSet<ServiceMappingModel> ServiceMapping { get; set; }
        public virtual DbSet<CampaignModel> Campaign { get; set; }
        public virtual DbSet<OrdersModel> Orders { get; set; }
        public virtual DbSet<WalletModel> Wallet { get; set; }
        public virtual DbSet<BalanceModel> Balance { get; set; }
        public virtual DbSet<TransactionsModel> Transactions { get; set; }
        public virtual DbSet<UserNavbarModel> UserNavbar { get; set; }
        public virtual DbSet<VendorRegModel> VendorReg { get; set; }
        public virtual DbSet<ContactModel> Contact { get; set; }
        public virtual DbSet<ContactQModel> ContactQ { get; set; }
        public virtual DbSet<FaqModel> Faq { get; set; }
        public virtual DbSet<SuggestModel> Suggest { get; set; }
        public virtual DbSet<VendorRegImageModel> VendorRegImage { get; set; }
        public virtual DbSet<VendorAccountImageModel> VendorAccountImage { get; set; }
        public virtual DbSet<BusinessInfoModel> BusinessInfo { get; set; }
        public virtual DbSet<AccountInfoModel> AccountInfo { get; set; }
        public virtual DbSet<VendorAddressModel> VendorAddress { get; set; }
        public virtual DbSet<BankInformationModel> BankInformation { get; set; }
        public virtual DbSet<CardsModel> Cards { get; set; }
        public virtual DbSet<LoginModel> Login { get; set; }

    }

    
}
