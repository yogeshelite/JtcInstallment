using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace jtcinstallment.Api.Entity
{
    public partial class jtc_installmentContext : DbContext
    {
        public jtc_installmentContext()
        {
        }

        public jtc_installmentContext(DbContextOptions<jtc_installmentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Sysdiagrams> Sysdiagrams { get; set; }
        public virtual DbSet<TblAgentMaster> TblAgentMaster { get; set; }
        public virtual DbSet<TblAttribute> TblAttribute { get; set; }
        public virtual DbSet<TblAttributsMaster> TblAttributsMaster { get; set; }
        public virtual DbSet<TblAuctionBack> TblAuctionBack { get; set; }
        public virtual DbSet<TblAuctionMaster> TblAuctionMaster { get; set; }
        public virtual DbSet<TblBank> TblBank { get; set; }
        public virtual DbSet<TblBlog> TblBlog { get; set; }
        public virtual DbSet<TblCategoryMaster> TblCategoryMaster { get; set; }
        public virtual DbSet<TblCfs> TblCfs { get; set; }
        public virtual DbSet<TblCnFmaster> TblCnFmaster { get; set; }
        public virtual DbSet<TblColor> TblColor { get; set; }
        public virtual DbSet<TblCompany> TblCompany { get; set; }
        public virtual DbSet<TblCountryMaster> TblCountryMaster { get; set; }
        public virtual DbSet<TblCurrencyMaster> TblCurrencyMaster { get; set; }
        public virtual DbSet<TblCustomerAccount> TblCustomerAccount { get; set; }
        public virtual DbSet<TblCustomerAccountHistory> TblCustomerAccountHistory { get; set; }
        public virtual DbSet<TblCustomerDeal> TblCustomerDeal { get; set; }
        public virtual DbSet<TblCustomerMaster> TblCustomerMaster { get; set; }
        public virtual DbSet<TblCustomerRequest> TblCustomerRequest { get; set; }
        public virtual DbSet<TblCustomerRequestHistory> TblCustomerRequestHistory { get; set; }
        public virtual DbSet<TblCustomerTt> TblCustomerTt { get; set; }
        public virtual DbSet<TblExchangeCurrency> TblExchangeCurrency { get; set; }
        public virtual DbSet<TblExtraCharge> TblExtraCharge { get; set; }
        public virtual DbSet<TblFavouriteBrand> TblFavouriteBrand { get; set; }
        public virtual DbSet<TblFile> TblFile { get; set; }
        public virtual DbSet<TblFindPerfectFit> TblFindPerfectFit { get; set; }
        public virtual DbSet<TblGroupMaster> TblGroupMaster { get; set; }
        public virtual DbSet<TblInspection> TblInspection { get; set; }
        public virtual DbSet<TblInspectionCompanyFee> TblInspectionCompanyFee { get; set; }
        public virtual DbSet<TblInstallment> TblInstallment { get; set; }
        public virtual DbSet<TblInstallmentDetail> TblInstallmentDetail { get; set; }
        public virtual DbSet<TblInvoice> TblInvoice { get; set; }
        public virtual DbSet<TblInvoiceAdjustmentAudit> TblInvoiceAdjustmentAudit { get; set; }
        public virtual DbSet<TblInvoiceHistory> TblInvoiceHistory { get; set; }
        public virtual DbSet<TblLoginAudit> TblLoginAudit { get; set; }
        public virtual DbSet<TblOfferSetting> TblOfferSetting { get; set; }
        public virtual DbSet<TblOsasDocumentPrintAudit> TblOsasDocumentPrintAudit { get; set; }
        public virtual DbSet<TblPackageDeal> TblPackageDeal { get; set; }
        public virtual DbSet<TblPortAgent> TblPortAgent { get; set; }
        public virtual DbSet<TblPortMaster> TblPortMaster { get; set; }
        public virtual DbSet<TblProduct> TblProduct { get; set; }
        public virtual DbSet<TblProfit> TblProfit { get; set; }
        public virtual DbSet<TblRegister> TblRegister { get; set; }
        public virtual DbSet<TblSaleMaster> TblSaleMaster { get; set; }
        public virtual DbSet<TblSetting> TblSetting { get; set; }
        public virtual DbSet<TblShipment> TblShipment { get; set; }
        public virtual DbSet<TblShippingAgent> TblShippingAgent { get; set; }
        public virtual DbSet<TblShippingAgentCharges> TblShippingAgentCharges { get; set; }
        public virtual DbSet<TblSlab> TblSlab { get; set; }
        public virtual DbSet<TblStock> TblStock { get; set; }
        public virtual DbSet<TblTransportation> TblTransportation { get; set; }
        public virtual DbSet<TblTtadjustment> TblTtadjustment { get; set; }
        public virtual DbSet<TblUserMaster> TblUserMaster { get; set; }
        public virtual DbSet<TblVariantMaster> TblVariantMaster { get; set; }
        public virtual DbSet<TblVehicleAttributeLink> TblVehicleAttributeLink { get; set; }
        public virtual DbSet<TblVehicleMaser> TblVehicleMaser { get; set; }
        public virtual DbSet<TblVesselMaster> TblVesselMaster { get; set; }
        public virtual DbSet<TblVesselName> TblVesselName { get; set; }
        public virtual DbSet<TblVesselRoute> TblVesselRoute { get; set; }
        public virtual DbSet<TblWishlist> TblWishlist { get; set; }
        public virtual DbSet<TblYard> TblYard { get; set; }
        public virtual DbSet<TblYardCharge> TblYardCharge { get; set; }
        public virtual DbSet<TblYardLocation> TblYardLocation { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=198.12.253.79;Database=jtc_installment;Trusted_Connection=false;User ID=jtcelite ;Password=Atlantic@1ndia;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Sysdiagrams>(entity =>
            {
                entity.HasKey(e => e.DiagramId)
                    .HasName("PK__sysdiagr__C2B05B611F9EA9FA");

                entity.ToTable("sysdiagrams");

                entity.HasIndex(e => new { e.PrincipalId, e.Name })
                    .HasName("UK_principal_name")
                    .IsUnique();

                entity.Property(e => e.DiagramId).HasColumnName("diagram_id");

                entity.Property(e => e.Definition).HasColumnName("definition");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(128);

                entity.Property(e => e.PrincipalId).HasColumnName("principal_id");

                entity.Property(e => e.Version).HasColumnName("version");
            });

            modelBuilder.Entity<TblAgentMaster>(entity =>
            {
                entity.ToTable("tbl_AgentMaster");

                entity.Property(e => e.AgentAddress)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.AgentName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ContactPerson)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.DeleteStatus).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Fax)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.RecordDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblAttribute>(entity =>
            {
                entity.ToTable("tbl_Attribute");

                entity.Property(e => e.Attribute).HasMaxLength(500);

                entity.Property(e => e.DeleteDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(500);

                entity.Property(e => e.RecordDate).HasColumnType("datetime");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("_Type")
                    .HasMaxLength(100);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblAttributsMaster>(entity =>
            {
                entity.ToTable("tbl_AttributsMaster");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Attribute)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<TblAuctionBack>(entity =>
            {
                entity.ToTable("tbl_AuctionBack");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AuctionFee).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.DeleteDate).HasColumnType("datetime");

                entity.Property(e => e.DestinationTypeAuctionOrYard)
                    .IsRequired()
                    .HasColumnName("DestinationType_Auction_or_Yard")
                    .HasMaxLength(100);

                entity.Property(e => e.MiscellaneousCharges).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.RecordDate).HasColumnType("datetime");

                entity.Property(e => e.SalePrice).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.SourceTypeAuctionOrYard)
                    .IsRequired()
                    .HasColumnName("SourceType_Auction_or_Yard")
                    .HasMaxLength(100);

                entity.Property(e => e.StockNumber).HasMaxLength(200);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblAuctionMaster>(entity =>
            {
                entity.ToTable("tbl_AuctionMaster");

                entity.Property(e => e.AuctionName)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.LocationName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TblBank>(entity =>
            {
                entity.ToTable("tbl_Bank");

                entity.Property(e => e.DeleteDate).HasColumnType("datetime");

                entity.Property(e => e.ForJtc).HasColumnName("ForJTC");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.RecordDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblBlog>(entity =>
            {
                entity.ToTable("tbl_Blog");

                entity.Property(e => e.DeleteDate).HasColumnType("datetime");

                entity.Property(e => e.Discription).HasMaxLength(500);

                entity.Property(e => e.Imageurl).HasMaxLength(500);

                entity.Property(e => e.RecordDate).HasColumnType("datetime");

                entity.Property(e => e.Title).HasMaxLength(100);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblCategoryMaster>(entity =>
            {
                entity.ToTable("tbl_CategoryMaster");

                entity.Property(e => e.BrandUrl).HasMaxLength(500);

                entity.Property(e => e.CategoryType)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Concessions).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.DeleteDate).HasColumnType("datetime");

                entity.Property(e => e.NegotiableAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Profit).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.RecordDate).HasColumnType("datetime");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("_Type")
                    .HasMaxLength(100);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblCfs>(entity =>
            {
                entity.ToTable("Tbl_CFS");

                entity.Property(e => e.Cfsname)
                    .IsRequired()
                    .HasColumnName("CFSName")
                    .HasMaxLength(100);

                entity.Property(e => e.DeleteStatus).HasColumnType("datetime");

                entity.Property(e => e.Frieght).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.RecordDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.VoyageNo).HasMaxLength(100);
            });

            modelBuilder.Entity<TblCnFmaster>(entity =>
            {
                entity.ToTable("tbl_CnFMaster");

                entity.Property(e => e.CouteryMasterId).HasColumnName("CouteryMaster_id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.Freight).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.FreightExchangeRate).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.InspectionCharges).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.MiscCharges).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PortMasterId).HasColumnName("PortMaster_Id");

                entity.Property(e => e.RecordDate).HasColumnType("date");

                entity.Property(e => e.RepairCost).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ShippingCharges).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<TblColor>(entity =>
            {
                entity.ToTable("tbl_Color");

                entity.Property(e => e.DeleteDate).HasColumnType("datetime");

                entity.Property(e => e.Haxadecimalvalue)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.RecordDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblCompany>(entity =>
            {
                entity.ToTable("tbl_Company");

                entity.Property(e => e.Address).HasMaxLength(500);

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.CompanyType).HasMaxLength(100);

                entity.Property(e => e.DeleteDate).HasColumnType("datetime");

                entity.Property(e => e.Emailid).HasMaxLength(500);

                entity.Property(e => e.Fax).HasMaxLength(20);

                entity.Property(e => e.Mobile).HasMaxLength(20);

                entity.Property(e => e.RecordDate).HasColumnType("datetime");

                entity.Property(e => e.Telephone).HasMaxLength(20);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblCountryMaster>(entity =>
            {
                entity.ToTable("tbl_CountryMaster");

                entity.Property(e => e.CountryCode).HasMaxLength(50);

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.CurrencyCode).HasMaxLength(50);

                entity.Property(e => e.DefaultAuctionFee).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.DefaultCif)
                    .HasColumnName("DefaultCIF")
                    .HasColumnType("decimal(18, 4)");

                entity.Property(e => e.DefaultInspectionFee).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.DefaultInspectionValidInMonth).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.DefaultRecycleFee).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.DefaultRepairFee).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.DefaultTax).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.DefaultTransportationFee).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.DialingCode).HasMaxLength(50);

                entity.Property(e => e.InspectionCompanyId).HasMaxLength(500);

                entity.Property(e => e.Symbols).HasMaxLength(5);
            });

            modelBuilder.Entity<TblCurrencyMaster>(entity =>
            {
                entity.ToTable("tbl_CurrencyMaster");

                entity.Property(e => e.CurrencyType).HasMaxLength(50);

                entity.Property(e => e.DeleteStatus).HasColumnType("datetime");

                entity.Property(e => e.DollerExchangeValue).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.KenyanShillingExchangeValue).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.RecordDate).HasColumnType("datetime");

                entity.Property(e => e.Status).HasMaxLength(100);

                entity.Property(e => e.StockId).HasColumnName("Stock_Id");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.YenExchangeValue).HasColumnType("decimal(18, 4)");
            });

            modelBuilder.Entity<TblCustomerAccount>(entity =>
            {
                entity.ToTable("tbl_CustomerAccount");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AccountUpdateStatus)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.AdvanceAmountJpy)
                    .HasColumnName("AdvanceAmountJPY")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.AdvanceAmountUsd)
                    .HasColumnName("AdvanceAmountUSD")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.BalanceAmountJpy)
                    .HasColumnName("BalanceAmountJPY")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.BalanceAmountUsd)
                    .HasColumnName("BalanceAmountUSD")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CustomerMasterId).HasColumnName("CustomerMaster_Id");

                entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

                entity.Property(e => e.RefundAmountJpy)
                    .HasColumnName("RefundAmountJPY")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.RefundAmountUsd)
                    .HasColumnName("RefundAmountUSD")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalAdjustedAdvanceJpy)
                    .HasColumnName("TotalAdjustedAdvanceJPY")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalAdjustedAdvanceUsd)
                    .HasColumnName("TotalAdjustedAdvanceUSD")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalAdjustedAmountJpy)
                    .HasColumnName("TotalAdjustedAmountJPY")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalAdjustedAmountUsd)
                    .HasColumnName("TotalAdjustedAmountUSD")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalAdjustedBalanceJpy)
                    .HasColumnName("TotalAdjustedBalanceJPY")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalAdjustedBalanceUsd)
                    .HasColumnName("TotalAdjustedBalanceUSD")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalDepositAdvanceJpy)
                    .HasColumnName("TotalDepositAdvanceJPY")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalDepositAdvanceUsd)
                    .HasColumnName("TotalDepositAdvanceUSD")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalDepositAmountJpy)
                    .HasColumnName("TotalDepositAmountJPY")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalDepositAmountUsd)
                    .HasColumnName("TotalDepositAmountUSD")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalDepositBalanceJpy)
                    .HasColumnName("TotalDepositBalanceJPY")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalDepositBalanceUsd)
                    .HasColumnName("TotalDepositBalanceUSD")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TransferAmountJpy)
                    .HasColumnName("TransferAmountJPY")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TransferAmountUsd)
                    .HasColumnName("TransferAmountUSD")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TransferRemarks)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UserMasterId).HasColumnName("UserMaster_Id");
            });

            modelBuilder.Entity<TblCustomerAccountHistory>(entity =>
            {
                entity.ToTable("tbl_CustomerAccountHistory");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AccountUpdateForInvoi)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.AccountUpdateReason)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.Currency).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CustomerMasterId).HasColumnName("CustomerMaster_Id");

                entity.Property(e => e.RefundAmountJpy)
                    .HasColumnName("RefundAmountJPY")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.RefundAmountUsd)
                    .HasColumnName("RefundAmountUSD")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalAdjustedAdvance).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalAdjustedBalance).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalAdvanceAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalBalanceAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TransferRemarks)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UserMasterId).HasColumnName("UserMaster_Id");
            });

            modelBuilder.Entity<TblCustomerDeal>(entity =>
            {
                entity.ToTable("tbl_CustomerDeal");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Blcharges)
                    .HasColumnName("BLCharges")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ChargesType)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DealEndDate).HasColumnType("datetime");

                entity.Property(e => e.DealName).HasMaxLength(500);

                entity.Property(e => e.DealStartDate).HasColumnType("datetime");

                entity.Property(e => e.DealType).HasMaxLength(100);

                entity.Property(e => e.DeleteDate).HasColumnType("datetime");

                entity.Property(e => e.Freight).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.HandlingCharges).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.InspectionCharges).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.MiscellaneouseCharges).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.OtherCharges).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PaymentDeadLineDate).HasColumnType("datetime");

                entity.Property(e => e.PriceRangeFrom).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PriceRangeTo).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ProfitAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.RecordDate).HasColumnType("datetime");

                entity.Property(e => e.SealCharges).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ShippingCharges).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SizeFrom).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SizeTo).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.VanningCharges).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.VesselType)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.TblCustomerDeal)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_CustomerDeal_tbl_CountryMaster");

                entity.HasOne(d => d.Currency)
                    .WithMany(p => p.TblCustomerDeal)
                    .HasForeignKey(d => d.CurrencyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_CustomerDeal_tbl_CurrencyMaster");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.TblCustomerDeal)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_CustomerDeal_tbl_CustomerMaster");
            });

            modelBuilder.Entity<TblCustomerMaster>(entity =>
            {
                entity.ToTable("tbl_CustomerMaster");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Comments)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.ConsigneeName).HasMaxLength(500);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.CustomerCode).HasMaxLength(20);

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.DeleteStatus).HasColumnType("datetime");

                entity.Property(e => e.EmailId)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.InvoiceAdjustmentAuditAudit).HasColumnName("InvoiceAdjustmentAudit_Audit");

                entity.Property(e => e.LastName).HasMaxLength(100);

                entity.Property(e => e.Location).HasMaxLength(200);

                entity.Property(e => e.Mobileno)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Password).HasMaxLength(100);

                entity.Property(e => e.Phone).HasMaxLength(20);

                entity.Property(e => e.RecordDate).HasColumnType("datetime");

                entity.Property(e => e.TypeOfCustomer).HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblCustomerRequest>(entity =>
            {
                entity.ToTable("tbl_CustomerRequest");

                entity.Property(e => e.CustomerOffer).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.DeleteDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.RequestDate).HasColumnType("datetime");

                entity.Property(e => e.SoldStatus)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Status).HasMaxLength(100);

                entity.Property(e => e.StockNumber).HasMaxLength(500);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblCustomerRequestHistory>(entity =>
            {
                entity.ToTable("tbl_CustomerRequestHistory");

                entity.Property(e => e.CustomerOffer).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.DeleteDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.RequestDate).HasColumnType("datetime");

                entity.Property(e => e.SoldStatus)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.StockNumber).HasMaxLength(500);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblCustomerTt>(entity =>
            {
                entity.ToTable("tbl_CustomerTT");

                entity.Property(e => e.AccountantId).HasColumnName("Accountant_id");

                entity.Property(e => e.AdvanceRecieved)
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Amount)
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.BankCharges)
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.BankReferenceNo).HasMaxLength(200);

                entity.Property(e => e.ComfirmBy).HasMaxLength(50);

                entity.Property(e => e.DeleteDate).HasColumnType("datetime");

                entity.Property(e => e.ReceviedAmount)
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ReceviedDate).HasColumnType("datetime");

                entity.Property(e => e.RecordDate).HasColumnType("datetime");

                entity.Property(e => e.RefundAmount)
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.RefundBankCharge)
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.RefundDate).HasColumnType("datetime");

                entity.Property(e => e.Remarks).HasMaxLength(2000);

                entity.Property(e => e.RemmiterBankName).HasMaxLength(2000);

                entity.Property(e => e.RemmiterName).HasMaxLength(200);

                entity.Property(e => e.ToatalAmount)
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TransferAmount).HasDefaultValueSql("((0))");

                entity.Property(e => e.TransferBankCharge)
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TransferDate).HasColumnType("datetime");

                entity.Property(e => e.TransferttId).HasDefaultValueSql("((0))");

                entity.Property(e => e.Ttdate)
                    .HasColumnName("TTDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.TtreferenceNo)
                    .HasColumnName("TTReferenceNo")
                    .HasMaxLength(100);

                entity.Property(e => e.Ttstatus)
                    .HasColumnName("TTStatus")
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.Year).HasMaxLength(5);
            });

            modelBuilder.Entity<TblExchangeCurrency>(entity =>
            {
                entity.ToTable("tbl_ExchangeCurrency");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UsdexchangeRate)
                    .HasColumnName("USDExchangeRate")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.YenexchangeRate)
                    .HasColumnName("YENExchangeRate")
                    .HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Currency)
                    .WithMany(p => p.TblExchangeCurrency)
                    .HasForeignKey(d => d.CurrencyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_ExchangeCurrency_tbl_CurrencyMaster");
            });

            modelBuilder.Entity<TblExtraCharge>(entity =>
            {
                entity.ToTable("tbl_ExtraCharge");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Comment).IsRequired();

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.StockNumber)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<TblFavouriteBrand>(entity =>
            {
                entity.ToTable("tbl_FavouriteBrand");

                entity.Property(e => e.DeleteDate).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Favouritebrand)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.PhoneNumber).HasMaxLength(15);

                entity.Property(e => e.RecordDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblFile>(entity =>
            {
                entity.ToTable("tbl_File");

                entity.Property(e => e.DeleteDate).HasColumnType("datetime");

                entity.Property(e => e.DocName)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.DocType).HasMaxLength(100);

                entity.Property(e => e.RecordDate).HasColumnType("datetime");

                entity.Property(e => e.StockNumber)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.Url).HasMaxLength(500);
            });

            modelBuilder.Entity<TblFindPerfectFit>(entity =>
            {
                entity.ToTable("tbl_FindPerfectFit");

                entity.Property(e => e.DeleteDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.RecordDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<TblGroupMaster>(entity =>
            {
                entity.ToTable("tbl_GroupMaster");

                entity.Property(e => e.GroupName)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<TblInspection>(entity =>
            {
                entity.ToTable("tbl_Inspection");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<TblInspectionCompanyFee>(entity =>
            {
                entity.ToTable("tbl_InspectionCompanyFee");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.InspectionFee).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<TblInstallment>(entity =>
            {
                entity.ToTable("tbl_installment");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DeletedDate).HasColumnType("datetime");

                entity.Property(e => e.DownPayment).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.FinalAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.InstallAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Installmentmode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.InvoiceNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SalePrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.StockNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TaxAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TaxPer).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblInstallmentDetail>(entity =>
            {
                entity.ToTable("tbl_InstallmentDetail");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DeletedDate).HasColumnType("datetime");

                entity.Property(e => e.DueDate).HasColumnType("datetime");

                entity.Property(e => e.FinalAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.InstallmentDate).HasColumnType("datetime");

                entity.Property(e => e.InstallmentGivenDate).HasColumnType("datetime");

                entity.Property(e => e.PaidAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PaymentBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PaymentStatus)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ReffNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TaxAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TaxPer).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblInvoice>(entity =>
            {
                entity.ToTable("tbl_Invoice");

                entity.Property(e => e.BalanceAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CancelDate).HasColumnType("datetime");

                entity.Property(e => e.Cfs)
                    .HasColumnName("CFS")
                    .HasMaxLength(200);

                entity.Property(e => e.Cifprice)
                    .HasColumnName("CIFPrice")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ConsigneeName).HasMaxLength(200);

                entity.Property(e => e.EntryDate).HasColumnType("date");

                entity.Property(e => e.Fobprice)
                    .HasColumnName("FOBPrice")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.IndividualInvoiceNumber).HasMaxLength(100);

                entity.Property(e => e.InvoiceNumber).HasMaxLength(500);

                entity.Property(e => e.NotifyParty).HasMaxLength(200);

                entity.Property(e => e.PaidAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PaymentMode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Cash')");

                entity.Property(e => e.PaymentStatus).HasMaxLength(100);

                entity.Property(e => e.PlaceofDischarge).HasMaxLength(200);

                entity.Property(e => e.ReserveDate).HasColumnType("datetime");

                entity.Property(e => e.SaleDate).HasColumnType("datetime");

                entity.Property(e => e.SalePrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Shipment).HasMaxLength(100);

                entity.Property(e => e.Status).HasMaxLength(100);

                entity.Property(e => e.StockNumber)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Type).HasMaxLength(100);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.TblInvoice)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_Invoice_tbl_CustomerMaster");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblInvoice)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_tbl_Invoice_tbl_UserMaster");
            });

            modelBuilder.Entity<TblInvoiceAdjustmentAudit>(entity =>
            {
                entity.HasKey(e => e.AuditId);

                entity.ToTable("tbl_InvoiceAdjustmentAudit");

                entity.Property(e => e.AuditId).ValueGeneratedNever();

                entity.Property(e => e.AdjustFromAdvance).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.AdjustFromBalance).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Currency)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.TotalAdjustAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UserMasterId).HasColumnName("UserMaster_Id");

                entity.Property(e => e.YenExchangeValue).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<TblInvoiceHistory>(entity =>
            {
                entity.ToTable("tbl_invoiceHistory");

                entity.Property(e => e.BalanceAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CancelDate).HasColumnType("datetime");

                entity.Property(e => e.Cfs)
                    .HasColumnName("CFS")
                    .HasMaxLength(200);

                entity.Property(e => e.Cifprice)
                    .HasColumnName("CIFPrice")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ConsigneeName).HasMaxLength(200);

                entity.Property(e => e.EntryDate).HasColumnType("date");

                entity.Property(e => e.Fobprice)
                    .HasColumnName("FOBPrice")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.InvoiceNumber).HasMaxLength(500);

                entity.Property(e => e.NotifyParty).HasMaxLength(200);

                entity.Property(e => e.PaidAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PaymentStatus).HasMaxLength(100);

                entity.Property(e => e.PlaceofDischarge).HasMaxLength(200);

                entity.Property(e => e.ReserveDate).HasColumnType("datetime");

                entity.Property(e => e.SaleDate).HasColumnType("datetime");

                entity.Property(e => e.SalePrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Status).HasMaxLength(100);

                entity.Property(e => e.StockNumber).HasMaxLength(100);

                entity.Property(e => e.Type).HasMaxLength(100);
            });

            modelBuilder.Entity<TblLoginAudit>(entity =>
            {
                entity.ToTable("tbl_LoginAudit");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Ipaddress)
                    .IsRequired()
                    .HasColumnName("IPAddress")
                    .HasMaxLength(100);

                entity.Property(e => e.LoginDate).HasColumnType("date");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<TblOfferSetting>(entity =>
            {
                entity.ToTable("tbl_offerSetting");

                entity.Property(e => e.LStatus)
                    .IsRequired()
                    .HasColumnName("L_status")
                    .HasMaxLength(100);

                entity.Property(e => e.OfferHeader)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.OfferSubHeader)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<TblOsasDocumentPrintAudit>(entity =>
            {
                entity.ToTable("tbl_OsasDocumentPrintAudit");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DocumentPrintA)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PrintDate).HasColumnType("datetime");

                entity.Property(e => e.VoyageNumber)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TblPackageDeal>(entity =>
            {
                entity.ToTable("tbl_PackageDeal");

                entity.Property(e => e.DeleteDate).HasColumnType("datetime");

                entity.Property(e => e.IncludeCharges).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.PackType)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.RecordDate).HasColumnType("datetime");

                entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblPortAgent>(entity =>
            {
                entity.HasKey(e => e.IdPa);

                entity.ToTable("tbl_PortAgent");

                entity.Property(e => e.IdPa).HasColumnName("Id_PA");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<TblPortMaster>(entity =>
            {
                entity.ToTable("tbl_PortMaster");

                entity.Property(e => e.CountryMasterId).HasColumnName("CountryMaster_Id");

                entity.Property(e => e.PortAgentId).HasColumnName("PortAgent_Id");

                entity.Property(e => e.PortName).IsRequired();

                entity.Property(e => e.RecordDate).HasColumnType("datetime");

                entity.Property(e => e.TimeZone)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.VesselRouteId).HasColumnName("VesselRoute_Id");

                entity.Property(e => e.YardMaserYardl).HasColumnName("YardMaser_Yardl");
            });

            modelBuilder.Entity<TblProduct>(entity =>
            {
                entity.ToTable("tbl_Product");

                entity.Property(e => e.ChassisType)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.DeleteDate).HasColumnType("datetime");

                entity.Property(e => e.Discription).HasMaxLength(1000);

                entity.Property(e => e.Drive).HasMaxLength(10);

                entity.Property(e => e.EngineCc)
                    .HasColumnName("EngineCC")
                    .HasMaxLength(20);

                entity.Property(e => e.Fuel).HasMaxLength(50);

                entity.Property(e => e.Hours).HasMaxLength(50);

                entity.Property(e => e.ProductType).HasMaxLength(500);

                entity.Property(e => e.RecordDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblProfit>(entity =>
            {
                entity.ToTable("tbl_Profit");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Concession).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.DeleteDate).HasColumnType("datetime");

                entity.Property(e => e.Negotiable).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Profit).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.RecordDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblRegister>(entity =>
            {
                entity.ToTable("tbl_Register");

                entity.Property(e => e.CustomerCode).HasMaxLength(10);

                entity.Property(e => e.DeleteStatus).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.MobileNo).HasMaxLength(20);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Otp).HasMaxLength(10);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.RecordStatus).HasColumnType("datetime");

                entity.Property(e => e.RegisterType)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.UpdateStatus).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblSaleMaster>(entity =>
            {
                entity.ToTable("tbl_SaleMaster");

                entity.Property(e => e.DeleteDate).HasColumnType("datetime");

                entity.Property(e => e.RecordDate).HasColumnType("date");

                entity.Property(e => e.Status).HasMaxLength(100);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblSetting>(entity =>
            {
                entity.ToTable("tbl_Setting");

                entity.Property(e => e.DeleteDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.RecordDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblSetting)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_Setting_tbl_UserMaster");
            });

            modelBuilder.Entity<TblShipment>(entity =>
            {
                entity.ToTable("tbl_Shipment");

                entity.Property(e => e.Blcharges)
                    .HasColumnName("BLCharges")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Cfsid).HasColumnName("CFSId");

                entity.Property(e => e.DeleteDate).HasColumnType("datetime");

                entity.Property(e => e.EtaDate).HasColumnType("datetime");

                entity.Property(e => e.EtdDate).HasColumnType("datetime");

                entity.Property(e => e.Freight).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.HandlingCharges).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.InspectionApplyDate).HasColumnType("datetime");

                entity.Property(e => e.InspectionCharges).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.InspectionCompany).HasMaxLength(500);

                entity.Property(e => e.InspectionStatus).HasMaxLength(50);

                entity.Property(e => e.InspectionStatusDate).HasColumnType("datetime");

                entity.Property(e => e.OtherCharges).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.RecordDate).HasColumnType("datetime");

                entity.Property(e => e.SealCharges).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ShipmentDate).HasColumnType("datetime");

                entity.Property(e => e.ShippingAgent).HasMaxLength(500);

                entity.Property(e => e.ShippingAgentCompany).HasMaxLength(500);

                entity.Property(e => e.ShippingCharges).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Status).HasMaxLength(100);

                entity.Property(e => e.StockNumber)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.VanningCharges).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.VesselType)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.VoyageNo)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TblShippingAgent>(entity =>
            {
                entity.ToTable("tbl_ShippingAgent");

                entity.Property(e => e.Address).HasMaxLength(1000);

                entity.Property(e => e.DeleteDate).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(500);

                entity.Property(e => e.MobileNo).HasMaxLength(15);

                entity.Property(e => e.RecordDate).HasColumnType("datetime");

                entity.Property(e => e.ShippingAgentName)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblShippingAgentCharges>(entity =>
            {
                entity.ToTable("tbl_ShippingAgentCharges");

                entity.Property(e => e.Blcharges)
                    .HasColumnName("BLCharges")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Chargetype).HasMaxLength(500);

                entity.Property(e => e.Freight).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.HandlingCharges).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.InspectionCharges).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.OtherCharges).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SealCharges).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ShippingCharges).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.VanningCharges).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.ShippingAgent)
                    .WithMany(p => p.TblShippingAgentCharges)
                    .HasForeignKey(d => d.ShippingAgentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_ShippingAgentCharges_tbl_ShippingAgent");
            });

            modelBuilder.Entity<TblSlab>(entity =>
            {
                entity.ToTable("tbl_Slab");

                entity.Property(e => e.DeleteDate).HasColumnType("datetime");

                entity.Property(e => e.RecordDate).HasColumnType("datetime");

                entity.Property(e => e.SlabFrom).HasMaxLength(20);

                entity.Property(e => e.SlabSign).HasMaxLength(10);

                entity.Property(e => e.SlabTo).HasMaxLength(20);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblStock>(entity =>
            {
                entity.ToTable("tbl_Stock");

                entity.Property(e => e.AccountStatus).HasMaxLength(500);

                entity.Property(e => e.AgentFess).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.AgentFessTax).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.AuctionGrade).HasMaxLength(50);

                entity.Property(e => e.BuyingPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.BuyingTax).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CEleven)
                    .HasColumnName("C_Eleven")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CElevenTax)
                    .HasColumnName("C_ElevenTax")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Cc)
                    .HasColumnName("CC")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cf)
                    .HasColumnName("CF")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Cftax)
                    .HasColumnName("CFTax")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ChassisNumber).HasMaxLength(50);

                entity.Property(e => e.CifPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CifTax).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Clr)
                    .HasColumnName("CLR")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ConsigneeName).HasMaxLength(100);

                entity.Property(e => e.DefaultImage).HasMaxLength(500);

                entity.Property(e => e.DeleteDate).HasColumnType("datetime");

                entity.Property(e => e.DeliveryOrder).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.DeliveryOrderTax).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.Drive)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Duty).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.DutyTax).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.EntryDate).HasColumnType("date");

                entity.Property(e => e.Eta)
                    .HasColumnName("ETA")
                    .HasColumnType("datetime");

                entity.Property(e => e.Etc)
                    .HasColumnName("ETC")
                    .HasMaxLength(50);

                entity.Property(e => e.Etd)
                    .HasColumnName("ETD")
                    .HasColumnType("datetime");

                entity.Property(e => e.ExchangeRateKesDoller).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ExchangeRateYenDoller).HasMaxLength(100);

                entity.Property(e => e.Expenses).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ExpensesTax).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Extracharges).HasMaxLength(10);

                entity.Property(e => e.ExtrachargesTax).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Extras)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.FakeMileage).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.FirstRegistrationDate).HasColumnType("datetime");

                entity.Property(e => e.Fuel)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GrandTotal).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.LocalInspection).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.LocallnspectionTax).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Location)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ManufactureDate).HasColumnType("datetime");

                entity.Property(e => e.Mileage).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Model)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MssLevy).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.MssLevyTax).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.NotifyParty).HasMaxLength(200);

                entity.Property(e => e.OfferPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PortCharges).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PortChargesTax).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ProductType).HasMaxLength(500);

                entity.Property(e => e.RadiationCharges).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.RadiationTax).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.RangeofMilage).HasMaxLength(200);

                entity.Property(e => e.Realisticcharges).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.RealisticchargesTax).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.RecordDate).HasColumnType("datetime");

                entity.Property(e => e.RegisterNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RepairPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.RepairTax).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.StockNumber).HasMaxLength(50);

                entity.Property(e => e.TotalKes).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.Warehouse).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.WarehouseTax).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.TblStock)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_tbl_Stock_tbl_Product");
            });

            modelBuilder.Entity<TblTransportation>(entity =>
            {
                entity.ToTable("tbl_Transportation");

                entity.Property(e => e.DeleteStatus).HasColumnType("datetime");

                entity.Property(e => e.DestinationName).HasMaxLength(500);

                entity.Property(e => e.DestinationType)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.RecordDate).HasColumnType("datetime");

                entity.Property(e => e.SourceName).HasMaxLength(500);

                entity.Property(e => e.SourceType)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblTtadjustment>(entity =>
            {
                entity.ToTable("tbl_ttadjustment");

                entity.Property(e => e.ActualAdjustedAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Adjustedamount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.DeleteDate).HasColumnType("datetime");

                entity.Property(e => e.RecordDate).HasColumnType("datetime");

                entity.Property(e => e.StockNumber)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.TtrefNo)
                    .IsRequired()
                    .HasColumnName("TTRefNo")
                    .HasMaxLength(100);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblUserMaster>(entity =>
            {
                entity.ToTable("tbl_UserMaster");

                entity.Property(e => e.CustomerMasterL).HasColumnName("CustomerMaster_l");

                entity.Property(e => e.DeleteStatus).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.LastLogin).HasColumnType("datetime");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.RecordDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TblVariantMaster>(entity =>
            {
                entity.ToTable("tbl_VariantMaster");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.VariantName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.VehicleMasterL).HasColumnName("VehicleMaster_l");
            });

            modelBuilder.Entity<TblVehicleAttributeLink>(entity =>
            {
                entity.ToTable("tbl_VehicleAttributeLink");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AttributesId).HasColumnName("Attributes_Id");

                entity.Property(e => e.StockId).HasColumnName("Stock_Id");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(1000);
            });

            modelBuilder.Entity<TblVehicleMaser>(entity =>
            {
                entity.ToTable("tbl_VehicleMaser");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AverageSellingPric).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CategoryMasterId).HasColumnName("CategoryMaster_Id");

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.M3).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Weight).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<TblVesselMaster>(entity =>
            {
                entity.ToTable("tbl_VesselMaster");

                entity.Property(e => e.DeleteDate).HasColumnType("datetime");

                entity.Property(e => e.Etddate)
                    .HasColumnName("ETDDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.LastCfsdate)
                    .HasColumnName("LastCFSDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.LastConsigneDate).HasColumnType("datetime");

                entity.Property(e => e.RecordDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.VesselType).HasMaxLength(500);

                entity.Property(e => e.VoyageNo).HasMaxLength(500);
            });

            modelBuilder.Entity<TblVesselName>(entity =>
            {
                entity.ToTable("tbl_VesselName");

                entity.Property(e => e.DeleteDate).HasColumnType("datetime");

                entity.Property(e => e.RecordDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.VesselName)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<TblVesselRoute>(entity =>
            {
                entity.ToTable("tbl_VesselRoute");

                entity.Property(e => e.LastPuttingdate).HasColumnType("datetime");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.VesselMasterId).HasColumnName("VesselMaster_Id");
            });

            modelBuilder.Entity<TblWishlist>(entity =>
            {
                entity.ToTable("tbl_Wishlist");

                entity.Property(e => e.CustomerEmail)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DeleteDate).HasColumnType("datetime");

                entity.Property(e => e.RecordDate).HasColumnType("datetime");

                entity.Property(e => e.StockNumber)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TblYard>(entity =>
            {
                entity.ToTable("tbl_Yard");

                entity.Property(e => e.DeleteDate).HasColumnType("datetime");

                entity.Property(e => e.GodownCharges).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.HandlingChages).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.OtherCharges).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.RadiationCharges).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.RecordDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblYardCharge>(entity =>
            {
                entity.ToTable("tbl_YardCharge");

                entity.Property(e => e.ChargesDiscription)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.DeleteDate).HasColumnType("datetime");

                entity.Property(e => e.Fee).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ParkingFee).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ProductType)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.RecordDate).HasColumnType("datetime");

                entity.Property(e => e.ShippingCharge).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SlabType)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.VanningCharge).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<TblYardLocation>(entity =>
            {
                entity.ToTable("tbl_YardLocation");

                entity.Property(e => e.LocationDiscription)
                    .IsRequired()
                    .HasMaxLength(500);
            });
        }
    }
}
