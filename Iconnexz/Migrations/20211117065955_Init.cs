using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Iconnexz.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "VendorCMS");

            migrationBuilder.EnsureSchema(
                name: "Wallet");

            migrationBuilder.EnsureSchema(
                name: "Campaign");

            migrationBuilder.EnsureSchema(
                name: "UserCMS");

            migrationBuilder.EnsureSchema(
                name: "Image");

            migrationBuilder.EnsureSchema(
                name: "Login");

            migrationBuilder.EnsureSchema(
                name: "Orders");

            migrationBuilder.EnsureSchema(
                name: "ManageService");

            migrationBuilder.EnsureSchema(
                name: "Navbar");

            migrationBuilder.CreateTable(
                name: "AccountInfo",
                schema: "VendorCMS",
                columns: table => new
                {
                    AccountInfoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PersonInChargeName = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    VendorEmail = table.Column<string>(type: "text", nullable: true),
                    IsPublished = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountInfo", x => x.AccountInfoId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserType = table.Column<int>(type: "integer", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Balance",
                schema: "Wallet",
                columns: table => new
                {
                    BalanceId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Balance = table.Column<int>(type: "integer", nullable: false),
                    Vendor = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Balance", x => x.BalanceId);
                });

            migrationBuilder.CreateTable(
                name: "BankInformation",
                schema: "VendorCMS",
                columns: table => new
                {
                    BankInformationId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BankName = table.Column<string>(type: "text", nullable: true),
                    AccountName = table.Column<string>(type: "text", nullable: true),
                    IsPublished = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankInformation", x => x.BankInformationId);
                });

            migrationBuilder.CreateTable(
                name: "BusinessInfo",
                schema: "VendorCMS",
                columns: table => new
                {
                    BusinessInfoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ContactNumber = table.Column<string>(type: "text", nullable: true),
                    CompanyDescription = table.Column<string>(type: "text", nullable: true),
                    BusinessStartTime = table.Column<string>(type: "text", nullable: true),
                    BusinessFinishTime = table.Column<string>(type: "text", nullable: true),
                    Monday = table.Column<string>(type: "text", nullable: true),
                    Tuesday = table.Column<string>(type: "text", nullable: true),
                    Wednesday = table.Column<string>(type: "text", nullable: true),
                    Thursday = table.Column<string>(type: "text", nullable: true),
                    Friday = table.Column<string>(type: "text", nullable: true),
                    Saturday = table.Column<string>(type: "text", nullable: true),
                    Sunday = table.Column<string>(type: "text", nullable: true),
                    IsPublished = table.Column<string>(type: "text", nullable: true),
                    PersonInChargeName = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    VendorEmail = table.Column<string>(type: "text", nullable: true),
                    IsPublished2 = table.Column<string>(type: "text", nullable: true),
                    VendorAddress = table.Column<string>(type: "text", nullable: true),
                    Country = table.Column<string>(type: "text", nullable: true),
                    State = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    PostCode = table.Column<string>(type: "text", nullable: true),
                    BusinessLatitude = table.Column<string>(type: "text", nullable: true),
                    BusinessLongitude = table.Column<string>(type: "text", nullable: true),
                    IsPublished3 = table.Column<string>(type: "text", nullable: true),
                    BankName = table.Column<string>(type: "text", nullable: true),
                    AccountNumber = table.Column<string>(type: "text", nullable: true),
                    IsPublished4 = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessInfo", x => x.BusinessInfoId);
                });

            migrationBuilder.CreateTable(
                name: "Campaign",
                schema: "Campaign",
                columns: table => new
                {
                    CampaignId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CampaignName = table.Column<string>(type: "text", nullable: true),
                    StartDate = table.Column<string>(type: "text", nullable: true),
                    EndDate = table.Column<string>(type: "text", nullable: true),
                    Vendor = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaign", x => x.CampaignId);
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                schema: "Wallet",
                columns: table => new
                {
                    CardId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Vendor = table.Column<string>(type: "text", nullable: true),
                    VirtualCardNumber = table.Column<string>(type: "text", nullable: true),
                    Expiry = table.Column<string>(type: "text", nullable: true),
                    CVV = table.Column<string>(type: "text", nullable: true),
                    CardType = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.CardId);
                });

            migrationBuilder.CreateTable(
                name: "Contact",
                schema: "UserCMS",
                columns: table => new
                {
                    ContactId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SelectDepartment = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Subject = table.Column<string>(type: "text", nullable: true),
                    ContactNumber = table.Column<string>(type: "text", nullable: true),
                    Message = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.ContactId);
                });

            migrationBuilder.CreateTable(
                name: "ContactQ",
                schema: "UserCMS",
                columns: table => new
                {
                    ContactQId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Q1 = table.Column<string>(type: "text", nullable: true),
                    C1 = table.Column<string>(type: "text", nullable: true),
                    Q2 = table.Column<string>(type: "text", nullable: true),
                    C2 = table.Column<string>(type: "text", nullable: true),
                    Q3 = table.Column<string>(type: "text", nullable: true),
                    C3 = table.Column<string>(type: "text", nullable: true),
                    Q4 = table.Column<string>(type: "text", nullable: true),
                    C4 = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactQ", x => x.ContactQId);
                });

            migrationBuilder.CreateTable(
                name: "Faq",
                schema: "UserCMS",
                columns: table => new
                {
                    FaqId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Question1 = table.Column<string>(type: "text", nullable: true),
                    Content1 = table.Column<string>(type: "text", nullable: true),
                    Question2 = table.Column<string>(type: "text", nullable: true),
                    Content2 = table.Column<string>(type: "text", nullable: true),
                    Question3 = table.Column<string>(type: "text", nullable: true),
                    Content3 = table.Column<string>(type: "text", nullable: true),
                    Question4 = table.Column<string>(type: "text", nullable: true),
                    Content4 = table.Column<string>(type: "text", nullable: true),
                    Question5 = table.Column<string>(type: "text", nullable: true),
                    Content5 = table.Column<string>(type: "text", nullable: true),
                    Question6 = table.Column<string>(type: "text", nullable: true),
                    Content6 = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faq", x => x.FaqId);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                schema: "Image",
                columns: table => new
                {
                    ImageId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Image = table.Column<byte[]>(type: "bytea", nullable: true),
                    ImageFilePath = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.ImageId);
                });

            migrationBuilder.CreateTable(
                name: "Login",
                schema: "Login",
                columns: table => new
                {
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Login", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                schema: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderStatus = table.Column<string>(type: "text", nullable: true),
                    Vendor = table.Column<string>(type: "text", nullable: true),
                    Customer = table.Column<string>(type: "text", nullable: true),
                    StartDate = table.Column<string>(type: "text", nullable: true),
                    EndDate = table.Column<string>(type: "text", nullable: true),
                    OrderTotal = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "ServiceImage",
                schema: "ManageService",
                columns: table => new
                {
                    ServiceImageId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ThumbnailImage = table.Column<byte[]>(type: "bytea", nullable: true),
                    ThumbnailImageFilePath = table.Column<string>(type: "text", nullable: true),
                    ServiceImage = table.Column<byte[]>(type: "bytea", nullable: true),
                    ServiceImageFilePath = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceImage", x => x.ServiceImageId);
                });

            migrationBuilder.CreateTable(
                name: "ServiceInformation",
                schema: "ManageService",
                columns: table => new
                {
                    ServiceId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ServiceName = table.Column<string>(type: "text", nullable: true),
                    ServiceDescription = table.Column<string>(type: "text", nullable: true),
                    SSU = table.Column<string>(type: "text", nullable: true),
                    ServicePrice = table.Column<string>(type: "text", nullable: true),
                    Stock = table.Column<int>(type: "integer", nullable: false),
                    ServiceSpecialPrice = table.Column<string>(type: "text", nullable: true),
                    SpecialPriceStart = table.Column<string>(type: "text", nullable: true),
                    SpecialPriceEnd = table.Column<string>(type: "text", nullable: true),
                    TaxType = table.Column<string>(type: "text", nullable: true),
                    IsPublished = table.Column<string>(type: "text", nullable: true),
                    Vendor = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceInformation", x => x.ServiceId);
                });

            migrationBuilder.CreateTable(
                name: "ServiceMapping",
                schema: "ManageService",
                columns: table => new
                {
                    MappingId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Mapping = table.Column<string>(type: "text", nullable: true),
                    Vendor = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceMapping", x => x.MappingId);
                });

            migrationBuilder.CreateTable(
                name: "ServiceVariation",
                schema: "ManageService",
                columns: table => new
                {
                    VariationsId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VariationName = table.Column<string>(type: "text", nullable: true),
                    Vendor = table.Column<string>(type: "text", nullable: true),
                    Control = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceVariation", x => x.VariationsId);
                });

            migrationBuilder.CreateTable(
                name: "Suggest",
                schema: "UserCMS",
                columns: table => new
                {
                    SuggestId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VendorName = table.Column<string>(type: "text", nullable: true),
                    OwnerName = table.Column<string>(type: "text", nullable: true),
                    HPNumber = table.Column<int>(type: "integer", nullable: false),
                    TelNumber = table.Column<int>(type: "integer", nullable: false),
                    EmailAddress = table.Column<string>(type: "text", nullable: true),
                    Street = table.Column<string>(type: "text", nullable: true),
                    PostalCode = table.Column<int>(type: "integer", nullable: false),
                    City = table.Column<string>(type: "text", nullable: true),
                    State = table.Column<string>(type: "text", nullable: true),
                    Country = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suggest", x => x.SuggestId);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                schema: "Wallet",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Amount = table.Column<int>(type: "integer", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<string>(type: "text", nullable: true),
                    Reason = table.Column<string>(type: "text", nullable: true),
                    Vendor = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionId);
                });

            migrationBuilder.CreateTable(
                name: "UserIndividual",
                schema: "UserCMS",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FullName = table.Column<string>(type: "text", nullable: true),
                    EmailAddress = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    ContactNumber = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserIndividual", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "UserNavbar",
                schema: "Navbar",
                columns: table => new
                {
                    NavbarId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    uItem1 = table.Column<string>(type: "text", nullable: true),
                    uItem2 = table.Column<string>(type: "text", nullable: true),
                    uItem3 = table.Column<string>(type: "text", nullable: true),
                    uItem4 = table.Column<string>(type: "text", nullable: true),
                    uItem5 = table.Column<string>(type: "text", nullable: true),
                    uItem6 = table.Column<string>(type: "text", nullable: true),
                    uItem7 = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserNavbar", x => x.NavbarId);
                });

            migrationBuilder.CreateTable(
                name: "UserOrganization",
                schema: "UserCMS",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CompanyName = table.Column<string>(type: "text", nullable: true),
                    CompanyRocNumber = table.Column<int>(type: "integer", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Country = table.Column<string>(type: "text", nullable: true),
                    State = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    PostalCode = table.Column<int>(type: "integer", nullable: false),
                    EmailAddress = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    ContactNumber = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOrganization", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "VendorAccountImage",
                schema: "VendorCMS",
                columns: table => new
                {
                    VendorAccountImageId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ThumbnailImage = table.Column<byte[]>(type: "bytea", nullable: true),
                    ThumbnailImageFilePath = table.Column<string>(type: "text", nullable: true),
                    VendorAccountImage = table.Column<byte[]>(type: "bytea", nullable: true),
                    VendorAccountImageFilePath = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorAccountImage", x => x.VendorAccountImageId);
                });

            migrationBuilder.CreateTable(
                name: "VendorAddress",
                schema: "VendorCMS",
                columns: table => new
                {
                    VendorAddressId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VendorAddress = table.Column<string>(type: "text", nullable: true),
                    Country = table.Column<string>(type: "text", nullable: true),
                    State = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    PostCode = table.Column<string>(type: "text", nullable: true),
                    BusinessLatitude = table.Column<string>(type: "text", nullable: true),
                    BusinessLongitude = table.Column<string>(type: "text", nullable: true),
                    IsPublished = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorAddress", x => x.VendorAddressId);
                });

            migrationBuilder.CreateTable(
                name: "VendorReg",
                schema: "VendorCMS",
                columns: table => new
                {
                    VendorRegId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BusinessType = table.Column<string>(type: "text", nullable: true),
                    VendorName = table.Column<string>(type: "text", nullable: true),
                    RegisterOfCompanyNo = table.Column<int>(type: "integer", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true),
                    companyDescription = table.Column<string>(type: "text", nullable: true),
                    IntroducerCode = table.Column<int>(type: "integer", nullable: false),
                    contactNumber = table.Column<string>(type: "text", nullable: true),
                    VerificationCode = table.Column<int>(type: "integer", nullable: false),
                    MondayCheck = table.Column<string>(type: "text", nullable: true),
                    TuesdayCheck = table.Column<string>(type: "text", nullable: true),
                    WednesdayCheck = table.Column<string>(type: "text", nullable: true),
                    ThursdayCheck = table.Column<string>(type: "text", nullable: true),
                    FridayCheck = table.Column<string>(type: "text", nullable: true),
                    SaturdayCheck = table.Column<string>(type: "text", nullable: true),
                    SundayCheck = table.Column<string>(type: "text", nullable: true),
                    StartBusinessHours = table.Column<string>(type: "text", nullable: true),
                    EndBusinessHours = table.Column<string>(type: "text", nullable: true),
                    personInChargeName = table.Column<string>(type: "text", nullable: true),
                    emailAddress = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    ConfirmPassword = table.Column<string>(type: "text", nullable: true),
                    ContactNumber2 = table.Column<string>(type: "text", nullable: true),
                    VerificationCode2 = table.Column<int>(type: "integer", nullable: false),
                    ServiceCategory = table.Column<string>(type: "text", nullable: true),
                    BusinessCategory = table.Column<string>(type: "text", nullable: true),
                    TypeOfBusiness = table.Column<string>(type: "text", nullable: true),
                    CountryCategory = table.Column<string>(type: "text", nullable: true),
                    RestaurantCategory = table.Column<string>(type: "text", nullable: true),
                    TypeOfFood = table.Column<string>(type: "text", nullable: true),
                    address = table.Column<string>(type: "text", nullable: true),
                    country = table.Column<string>(type: "text", nullable: true),
                    state = table.Column<string>(type: "text", nullable: true),
                    city = table.Column<string>(type: "text", nullable: true),
                    Postcode = table.Column<int>(type: "integer", nullable: false),
                    shopLatitude = table.Column<string>(type: "text", nullable: true),
                    shopLongitude = table.Column<string>(type: "text", nullable: true),
                    flatRate = table.Column<string>(type: "text", nullable: true),
                    forFirst = table.Column<string>(type: "text", nullable: true),
                    everyAdditional = table.Column<string>(type: "text", nullable: true),
                    bankName = table.Column<string>(type: "text", nullable: true),
                    bankAccountNo = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorReg", x => x.VendorRegId);
                });

            migrationBuilder.CreateTable(
                name: "VendorRegImage",
                schema: "VendorCMS",
                columns: table => new
                {
                    VendorRegImageId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ThumbnailImage = table.Column<byte[]>(type: "bytea", nullable: true),
                    ThumbnailImageFilePath = table.Column<string>(type: "text", nullable: true),
                    VendorRegImage = table.Column<byte[]>(type: "bytea", nullable: true),
                    VendorRegImageFilePath = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorRegImage", x => x.VendorRegImageId);
                });

            migrationBuilder.CreateTable(
                name: "VendorSidebar",
                schema: "Navbar",
                columns: table => new
                {
                    SidebarId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Item1 = table.Column<string>(type: "text", nullable: true),
                    Item2 = table.Column<string>(type: "text", nullable: true),
                    Item3 = table.Column<string>(type: "text", nullable: true),
                    Item4 = table.Column<string>(type: "text", nullable: true),
                    Item5 = table.Column<string>(type: "text", nullable: true),
                    Item6 = table.Column<string>(type: "text", nullable: true),
                    Item7 = table.Column<string>(type: "text", nullable: true),
                    Item8 = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorSidebar", x => x.SidebarId);
                });

            migrationBuilder.CreateTable(
                name: "Wallet",
                schema: "Wallet",
                columns: table => new
                {
                    WalletId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Amount = table.Column<int>(type: "integer", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<string>(type: "text", nullable: true),
                    VirtualCardNumber = table.Column<string>(type: "text", nullable: true),
                    Reason = table.Column<string>(type: "text", nullable: true),
                    Vendor = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallet", x => x.WalletId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountInfo",
                schema: "VendorCMS");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Balance",
                schema: "Wallet");

            migrationBuilder.DropTable(
                name: "BankInformation",
                schema: "VendorCMS");

            migrationBuilder.DropTable(
                name: "BusinessInfo",
                schema: "VendorCMS");

            migrationBuilder.DropTable(
                name: "Campaign",
                schema: "Campaign");

            migrationBuilder.DropTable(
                name: "Cards",
                schema: "Wallet");

            migrationBuilder.DropTable(
                name: "Contact",
                schema: "UserCMS");

            migrationBuilder.DropTable(
                name: "ContactQ",
                schema: "UserCMS");

            migrationBuilder.DropTable(
                name: "Faq",
                schema: "UserCMS");

            migrationBuilder.DropTable(
                name: "Images",
                schema: "Image");

            migrationBuilder.DropTable(
                name: "Login",
                schema: "Login");

            migrationBuilder.DropTable(
                name: "Orders",
                schema: "Orders");

            migrationBuilder.DropTable(
                name: "ServiceImage",
                schema: "ManageService");

            migrationBuilder.DropTable(
                name: "ServiceInformation",
                schema: "ManageService");

            migrationBuilder.DropTable(
                name: "ServiceMapping",
                schema: "ManageService");

            migrationBuilder.DropTable(
                name: "ServiceVariation",
                schema: "ManageService");

            migrationBuilder.DropTable(
                name: "Suggest",
                schema: "UserCMS");

            migrationBuilder.DropTable(
                name: "Transactions",
                schema: "Wallet");

            migrationBuilder.DropTable(
                name: "UserIndividual",
                schema: "UserCMS");

            migrationBuilder.DropTable(
                name: "UserNavbar",
                schema: "Navbar");

            migrationBuilder.DropTable(
                name: "UserOrganization",
                schema: "UserCMS");

            migrationBuilder.DropTable(
                name: "VendorAccountImage",
                schema: "VendorCMS");

            migrationBuilder.DropTable(
                name: "VendorAddress",
                schema: "VendorCMS");

            migrationBuilder.DropTable(
                name: "VendorReg",
                schema: "VendorCMS");

            migrationBuilder.DropTable(
                name: "VendorRegImage",
                schema: "VendorCMS");

            migrationBuilder.DropTable(
                name: "VendorSidebar",
                schema: "Navbar");

            migrationBuilder.DropTable(
                name: "Wallet",
                schema: "Wallet");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
