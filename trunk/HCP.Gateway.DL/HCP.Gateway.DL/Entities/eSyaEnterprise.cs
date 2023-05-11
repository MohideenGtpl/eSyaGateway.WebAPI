﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HCP.Gateway.DL.Entities
{
    public partial class eSyaEnterprise : DbContext
    {
        public static string _connString = "";
        public eSyaEnterprise()
        {
        }

        public eSyaEnterprise(DbContextOptions<eSyaEnterprise> options)
            : base(options)
        {
        }

        public virtual DbSet<GtEcapcd> GtEcapcd { get; set; }
        public virtual DbSet<GtEcaprl> GtEcaprl { get; set; }
        public virtual DbSet<GtEcbsln> GtEcbsln { get; set; }
        public virtual DbSet<GtEcclco> GtEcclco { get; set; }
        public virtual DbSet<GtEccncd> GtEccncd { get; set; }
        public virtual DbSet<GtEcfmal> GtEcfmal { get; set; }
        public virtual DbSet<GtEcfmfd> GtEcfmfd { get; set; }
        public virtual DbSet<GtEcfmnm> GtEcfmnm { get; set; }
        public virtual DbSet<GtEcltcd> GtEcltcd { get; set; }
        public virtual DbSet<GtEcltfc> GtEcltfc { get; set; }
        public virtual DbSet<GtEcmamn> GtEcmamn { get; set; }
        public virtual DbSet<GtEcmnfl> GtEcmnfl { get; set; }
        public virtual DbSet<GtEcprrl> GtEcprrl { get; set; }
        public virtual DbSet<GtEcsbmn> GtEcsbmn { get; set; }
        public virtual DbSet<GtEcsmsc> GtEcsmsc { get; set; }
        public virtual DbSet<GtEcsmsd> GtEcsmsd { get; set; }
        public virtual DbSet<GtEcsmsh> GtEcsmsh { get; set; }
        public virtual DbSet<GtEcsmsl> GtEcsmsl { get; set; }
        public virtual DbSet<GtEcsmsr> GtEcsmsr { get; set; }
        public virtual DbSet<GtEcsmss> GtEcsmss { get; set; }
        public virtual DbSet<GtEcsmsv> GtEcsmsv { get; set; }
        public virtual DbSet<GtEsdocd> GtEsdocd { get; set; }
        public virtual DbSet<GtEupapp> GtEupapp { get; set; }
        public virtual DbSet<GtEuusac> GtEuusac { get; set; }
        public virtual DbSet<GtEuusbl> GtEuusbl { get; set; }
        public virtual DbSet<GtEuuscg> GtEuuscg { get; set; }
        public virtual DbSet<GtEuusfa> GtEuusfa { get; set; }
        public virtual DbSet<GtEuusgr> GtEuusgr { get; set; }
        public virtual DbSet<GtEuusml> GtEuusml { get; set; }
        public virtual DbSet<GtEuusms> GtEuusms { get; set; }
        public virtual DbSet<GtEuusph> GtEuusph { get; set; }
        public virtual DbSet<GtEuusrl> GtEuusrl { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(_connString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<GtEcapcd>(entity =>
            {
                entity.HasKey(e => e.ApplicationCode)
                    .HasName("PK_GT_ECAPCD_1");

                entity.ToTable("GT_ECAPCD");

                entity.Property(e => e.ApplicationCode).ValueGeneratedNever();

                entity.Property(e => e.CodeDesc)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.ShortCode).HasMaxLength(15);
            });

            modelBuilder.Entity<GtEcaprl>(entity =>
            {
                entity.HasKey(e => new { e.RuleId, e.ProcessId });

                entity.ToTable("GT_ECAPRL");

                entity.Property(e => e.RuleId).HasColumnName("RuleID");

                entity.Property(e => e.ProcessId).HasColumnName("ProcessID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.Notes).HasMaxLength(1000);

                entity.Property(e => e.RuleDesc)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(d => d.Process)
                    .WithMany(p => p.GtEcaprl)
                    .HasForeignKey(d => d.ProcessId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GT_ECAPRL_GT_ECPRRL");
            });

            modelBuilder.Entity<GtEcbsln>(entity =>
            {
                entity.HasKey(e => new { e.BusinessId, e.SegmentId })
                    .HasName("PK_GT_ECBSLN_1");

                entity.ToTable("GT_ECBSLN");

                entity.HasIndex(e => e.BusinessKey)
                    .HasName("IX_GT_ECBSLN")
                    .IsUnique();

                entity.Property(e => e.BusinessId).HasColumnName("BusinessID");

                entity.Property(e => e.SegmentId).HasColumnName("SegmentID");

                entity.Property(e => e.BusinessName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CurrencyCode)
                    .IsRequired()
                    .HasMaxLength(4);

                entity.Property(e => e.EActiveUsers)
                    .IsRequired()
                    .HasColumnName("eActiveUsers");

                entity.Property(e => e.EBusinessKey)
                    .IsRequired()
                    .HasColumnName("eBusinessKey");

                entity.Property(e => e.ENoOfBeds).HasColumnName("eNoOfBeds");

                entity.Property(e => e.ESyaLicenseType)
                    .IsRequired()
                    .HasColumnName("eSyaLicenseType")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.EUserLicenses)
                    .IsRequired()
                    .HasColumnName("eUserLicenses");

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Isdcode).HasColumnName("ISDCode");

                entity.Property(e => e.LocationCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.LocationDescription)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.TocurrConversion).HasColumnName("TOCurrConversion");

                entity.Property(e => e.TolocalCurrency)
                    .IsRequired()
                    .HasColumnName("TOLocalCurrency")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.TorealCurrency).HasColumnName("TORealCurrency");
            });

            modelBuilder.Entity<GtEcclco>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.FinancialYear });

                entity.ToTable("GT_ECCLCO");

                entity.Property(e => e.FinancialYear).HasColumnType("numeric(4, 0)");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FromDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.TillDate).HasColumnType("datetime");

                entity.HasOne(d => d.BusinessKeyNavigation)
                    .WithMany(p => p.GtEcclco)
                    .HasPrincipalKey(p => p.BusinessKey)
                    .HasForeignKey(d => d.BusinessKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GT_ECCLCO_GT_ECBSLN");
            });

            modelBuilder.Entity<GtEccncd>(entity =>
            {
                entity.HasKey(e => e.Isdcode);

                entity.ToTable("GT_ECCNCD");

                entity.Property(e => e.Isdcode)
                    .HasColumnName("ISDCode")
                    .ValueGeneratedNever();

                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasMaxLength(4);

                entity.Property(e => e.CountryFlag)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CurrencyCode)
                    .IsRequired()
                    .HasMaxLength(4);

                entity.Property(e => e.DateFormat)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IsPinapplicable).HasColumnName("IsPINApplicable");

                entity.Property(e => e.IsPoboxApplicable).HasColumnName("IsPOBoxApplicable");

                entity.Property(e => e.MobileNumberPattern)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.Nationality).HasMaxLength(50);

                entity.Property(e => e.PincodePattern)
                    .HasColumnName("PINcodePattern")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.PoboxPattern)
                    .HasColumnName("POBoxPattern")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.ShortDateFormat)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Uidlabel)
                    .HasColumnName("UIDLabel")
                    .HasMaxLength(50);

                entity.Property(e => e.Uidpattern)
                    .HasColumnName("UIDPattern")
                    .HasMaxLength(25);
            });

            modelBuilder.Entity<GtEcfmal>(entity =>
            {
                entity.HasKey(e => new { e.FormId, e.ActionId });

                entity.ToTable("GT_ECFMAL");

                entity.Property(e => e.FormId).HasColumnName("FormID");

                entity.Property(e => e.ActionId).HasColumnName("ActionID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.HasOne(d => d.Form)
                    .WithMany(p => p.GtEcfmal)
                    .HasForeignKey(d => d.FormId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GT_ECFMAL_GT_ECFMFD");
            });

            modelBuilder.Entity<GtEcfmfd>(entity =>
            {
                entity.HasKey(e => e.FormId);

                entity.ToTable("GT_ECFMFD");

                entity.Property(e => e.FormId)
                    .HasColumnName("FormID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ControllerName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FormName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.ToolTip).HasMaxLength(100);
            });

            modelBuilder.Entity<GtEcfmnm>(entity =>
            {
                entity.HasKey(e => new { e.FormId, e.FormIntId });

                entity.ToTable("GT_ECFMNM");

                entity.Property(e => e.FormId).HasColumnName("FormID");

                entity.Property(e => e.FormIntId)
                    .HasColumnName("FormIntID")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormDescription)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.NavigateUrl)
                    .IsRequired()
                    .HasColumnName("NavigateURL")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Form)
                    .WithMany(p => p.GtEcfmnm)
                    .HasForeignKey(d => d.FormId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GT_ECFMNM_GT_ECFMFD");
            });

            modelBuilder.Entity<GtEcltcd>(entity =>
            {
                entity.HasKey(e => new { e.ResourceId, e.Culture })
                    .HasName("PK_GT_ECLTFT");

                entity.ToTable("GT_ECLTCD");

                entity.Property(e => e.ResourceId).HasColumnName("ResourceID");

                entity.Property(e => e.Culture).HasMaxLength(10);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.HasOne(d => d.Resource)
                    .WithMany(p => p.GtEcltcd)
                    .HasForeignKey(d => d.ResourceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GT_ECLTFT_GT_ECLTFC");
            });

            modelBuilder.Entity<GtEcltfc>(entity =>
            {
                entity.HasKey(e => e.ResourceId);

                entity.ToTable("GT_ECLTFC");

                entity.Property(e => e.ResourceId)
                    .HasColumnName("ResourceID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.ResourceName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GtEcmamn>(entity =>
            {
                entity.HasKey(e => e.MainMenuId);

                entity.ToTable("GT_ECMAMN");

                entity.Property(e => e.MainMenuId)
                    .HasColumnName("MainMenuID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ImageUrl)
                    .HasColumnName("ImageURL")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MainMenu)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);
            });

            modelBuilder.Entity<GtEcmnfl>(entity =>
            {
                entity.HasKey(e => new { e.FormId, e.MainMenuId, e.MenuItemId });

                entity.ToTable("GT_ECMNFL");

                entity.HasIndex(e => e.MenuKey)
                    .HasName("IX_GT_ECMNFL")
                    .IsUnique();

                entity.Property(e => e.FormId).HasColumnName("FormID");

                entity.Property(e => e.MainMenuId).HasColumnName("MainMenuID");

                entity.Property(e => e.MenuItemId).HasColumnName("MenuItemID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormNameClient)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.HasOne(d => d.Form)
                    .WithMany(p => p.GtEcmnfl)
                    .HasForeignKey(d => d.FormId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GT_ECMNFL_GT_ECFMFD");

                entity.HasOne(d => d.MainMenu)
                    .WithMany(p => p.GtEcmnfl)
                    .HasForeignKey(d => d.MainMenuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GT_ECMNFL_GT_ECMAMN");
            });

            modelBuilder.Entity<GtEcprrl>(entity =>
            {
                entity.HasKey(e => e.ProcessId);

                entity.ToTable("GT_ECPRRL");

                entity.Property(e => e.ProcessId)
                    .HasColumnName("ProcessID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.ProcessControl)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ProcessDesc)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<GtEcsbmn>(entity =>
            {
                entity.HasKey(e => new { e.MenuItemId, e.MainMenuId });

                entity.ToTable("GT_ECSBMN");

                entity.Property(e => e.MenuItemId).HasColumnName("MenuItemID");

                entity.Property(e => e.MainMenuId).HasColumnName("MainMenuID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ImageUrl)
                    .HasColumnName("ImageURL")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MenuItemName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.HasOne(d => d.MainMenu)
                    .WithMany(p => p.GtEcsbmn)
                    .HasForeignKey(d => d.MainMenuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GT_ECSBMN_GT_ECMAMN");
            });

            modelBuilder.Entity<GtEcsmsc>(entity =>
            {
                entity.HasKey(e => new { e.ReminderType, e.Smsid, e.ReferenceKey });

                entity.ToTable("GT_ECSMSC");

                entity.Property(e => e.ReminderType)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Smsid)
                    .HasColumnName("SMSID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<GtEcsmsd>(entity =>
            {
                entity.HasKey(e => new { e.Smsid, e.ParameterId });

                entity.ToTable("GT_ECSMSD");

                entity.Property(e => e.Smsid)
                    .HasColumnName("SMSID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ParameterId).HasColumnName("ParameterID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.HasOne(d => d.Sms)
                    .WithMany(p => p.GtEcsmsd)
                    .HasForeignKey(d => d.Smsid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GT_ECSMSD_GT_ECSMSH");
            });

            modelBuilder.Entity<GtEcsmsh>(entity =>
            {
                entity.HasKey(e => e.Smsid);

                entity.ToTable("GT_ECSMSH");

                entity.Property(e => e.Smsid)
                    .HasColumnName("SMSID")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId).HasColumnName("FormID");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.Smsdescription)
                    .IsRequired()
                    .HasColumnName("SMSDescription")
                    .HasMaxLength(100);

                entity.Property(e => e.Smsstatement)
                    .IsRequired()
                    .HasColumnName("SMSStatement")
                    .HasMaxLength(500);

                entity.Property(e => e.TeventId).HasColumnName("TEventID");
            });

            modelBuilder.Entity<GtEcsmsl>(entity =>
            {
                entity.HasKey(e => e.Smsid);

                entity.ToTable("GT_ECSMSL");

                entity.Property(e => e.Smsid).HasColumnName("SMSID");

                entity.Property(e => e.MessageType)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SendDateTime).HasColumnType("smalldatetime");

                entity.Property(e => e.Smsstatement)
                    .HasColumnName("SMSStatement")
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<GtEcsmsr>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.Smsid, e.MobileNumber });

                entity.ToTable("GT_ECSMSR");

                entity.Property(e => e.Smsid)
                    .HasColumnName("SMSID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.RecipientName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Remarks).HasMaxLength(25);

                entity.HasOne(d => d.Sms)
                    .WithMany(p => p.GtEcsmsr)
                    .HasForeignKey(d => d.Smsid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GT_ECSMSR_GT_ECSMSH");
            });

            modelBuilder.Entity<GtEcsmss>(entity =>
            {
                entity.HasKey(e => new { e.ReminderType, e.Smsid });

                entity.ToTable("GT_ECSMSS");

                entity.Property(e => e.ReminderType)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Smsid)
                    .HasColumnName("SMSID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);
            });

            modelBuilder.Entity<GtEcsmsv>(entity =>
            {
                entity.HasKey(e => e.Smsvariable);

                entity.ToTable("GT_ECSMSV");

                entity.Property(e => e.Smsvariable)
                    .HasColumnName("SMSVariable")
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.Smscomponent)
                    .IsRequired()
                    .HasColumnName("SMSComponent")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GtEsdocd>(entity =>
            {
                entity.HasKey(e => e.DoctorId);

                entity.ToTable("GT_ESDOCD");

                entity.Property(e => e.DoctorId)
                    .HasColumnName("DoctorID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AllowSms).HasColumnName("AllowSMS");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DoctorName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DoctorRegnNo)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.DoctorRemarks).HasMaxLength(150);

                entity.Property(e => e.DoctorShortName)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.EmailId)
                    .HasColumnName("EmailID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Experience).HasMaxLength(150);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Isdcode).HasColumnName("ISDCode");

                entity.Property(e => e.LanguageKnown).HasMaxLength(150);

                entity.Property(e => e.MobileNumber)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(20);

                entity.Property(e => e.Qualification)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TimeSlotInMintues).HasDefaultValueSql("((5))");

                entity.Property(e => e.TraiffFrom)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')");
            });

            modelBuilder.Entity<GtEupapp>(entity =>
            {
                entity.HasKey(e => e.ParameterId);

                entity.ToTable("GT_EUPAPP");

                entity.Property(e => e.ParameterId)
                    .HasColumnName("ParameterID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.ParmValue).HasColumnType("numeric(18, 6)");
            });

            modelBuilder.Entity<GtEuusac>(entity =>
            {
                entity.HasKey(e => new { e.UserGroup, e.UserType, e.UserRole, e.MenuKey, e.ActionId });

                entity.ToTable("GT_EUUSAC");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);
            });

            modelBuilder.Entity<GtEuusbl>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.BusinessKey });

                entity.ToTable("GT_EUUSBL");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.AllowMtfy).HasColumnName("AllowMTFY");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);
            });

            modelBuilder.Entity<GtEuuscg>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("GT_EUUSCG");

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LoginDesc)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LoginId)
                    .IsRequired()
                    .HasColumnName("LoginID")
                    .HasMaxLength(20);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(2000);
            });

            modelBuilder.Entity<GtEuusfa>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.BusinessKey, e.MenuKey, e.ActionId });

                entity.ToTable("GT_EUUSFA");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.ActionId).HasColumnName("ActionID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.HasOne(d => d.BusinessKeyNavigation)
                    .WithMany(p => p.GtEuusfa)
                    .HasPrincipalKey(p => p.BusinessKey)
                    .HasForeignKey(d => d.BusinessKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GT_EUUSFA_GT_ECBSLN");

                entity.HasOne(d => d.GtEuusml)
                    .WithMany(p => p.GtEuusfa)
                    .HasForeignKey(d => new { d.UserId, d.BusinessKey, d.MenuKey })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GT_EUUSFA_GT_EUUSML");
            });

            modelBuilder.Entity<GtEuusgr>(entity =>
            {
                entity.HasKey(e => new { e.UserGroup, e.UserType, e.UserRole, e.MenuKey });

                entity.ToTable("GT_EUUSGR");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.HasOne(d => d.MenuKeyNavigation)
                    .WithMany(p => p.GtEuusgr)
                    .HasPrincipalKey(p => p.MenuKey)
                    .HasForeignKey(d => d.MenuKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GT_EUUSGR_GT_ECMNFL");

                entity.HasOne(d => d.UserGroupNavigation)
                    .WithMany(p => p.GtEuusgrUserGroupNavigation)
                    .HasForeignKey(d => d.UserGroup)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GT_EUUSGR_GT_ECAPCD");

                entity.HasOne(d => d.UserTypeNavigation)
                    .WithMany(p => p.GtEuusgrUserTypeNavigation)
                    .HasForeignKey(d => d.UserType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GT_EUUSGR_GT_ECAPCD1");
            });

            modelBuilder.Entity<GtEuusml>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.BusinessKey, e.MenuKey });

                entity.ToTable("GT_EUUSML");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.HasOne(d => d.MenuKeyNavigation)
                    .WithMany(p => p.GtEuusml)
                    .HasPrincipalKey(p => p.MenuKey)
                    .HasForeignKey(d => d.MenuKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GT_EUUSML_GT_ECMNFL");

                entity.HasOne(d => d.GtEuusbl)
                    .WithMany(p => p.GtEuusml)
                    .HasForeignKey(d => new { d.UserId, d.BusinessKey })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GT_EUUSML_GT_EUUSBL");
            });

            modelBuilder.Entity<GtEuusms>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("GT_EUUSMS");

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AllowMobileLogin)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DeactivationReason).HasMaxLength(50);

                entity.Property(e => e.DoctorId).HasColumnName("DoctorID");

                entity.Property(e => e.EMailId)
                    .IsRequired()
                    .HasColumnName("eMailID")
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Isdcode)
                    .HasColumnName("ISDCode")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LastActivityDate).HasColumnType("datetime");

                entity.Property(e => e.LastPasswordChangeDate).HasColumnType("datetime");

                entity.Property(e => e.LoginAttemptDate).HasColumnType("datetime");

                entity.Property(e => e.LoginDesc)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LoginId)
                    .IsRequired()
                    .HasColumnName("LoginID")
                    .HasMaxLength(20);

                entity.Property(e => e.MobileNumber)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.OtpgeneratedDate)
                    .HasColumnName("OTPGeneratedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Otpnumber)
                    .HasColumnName("OTPNumber")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.PhotoUrl)
                    .HasColumnName("PhotoURL")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.PreferredLanguage).HasMaxLength(10);

                entity.Property(e => e.UserAuthenticatedDate).HasColumnType("datetime");

                entity.Property(e => e.UserCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.UserDeactivatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<GtEuusph>(entity =>
            {
                entity.ToTable("GT_EUUSPH");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LastPassword)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.LastPasswordChanged).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<GtEuusrl>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.BusinessKey, e.UserGroup, e.UserType, e.UserRole, e.EffectiveFrom });

                entity.ToTable("GT_EUUSRL");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.EffectiveFrom).HasColumnType("datetime");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EffectiveTill).HasColumnType("datetime");

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);
            });
        }
    }
}
