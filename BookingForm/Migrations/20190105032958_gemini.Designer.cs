﻿// <auto-generated />
using System;
using BookingForm.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BookingForm.Migrations
{
    [DbContext(typeof(BookingFormContext))]
    [Migration("20190105032958_gemini")]
    partial class gemini
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BookingForm.Models.Appoinment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<double>("Cash");

                    b.Property<string>("Cmnd");

                    b.Property<bool>("Confirm");

                    b.Property<int>("Contract");

                    b.Property<string>("Customer")
                        .IsRequired();

                    b.Property<string>("DType")
                        .IsRequired();

                    b.Property<DateTime>("Day");

                    b.Property<string>("Deposit");

                    b.Property<string>("Details");

                    b.Property<string>("Email");

                    b.Property<string>("Gender")
                        .IsRequired();

                    b.Property<string>("HKTT")
                        .IsRequired();

                    b.Property<bool>("IsActive");

                    b.Property<string>("Job");

                    b.Property<double>("Money");

                    b.Property<int>("NCH1");

                    b.Property<int>("NCH2");

                    b.Property<int>("NCH21");

                    b.Property<int>("NCH3");

                    b.Property<int>("NMS");

                    b.Property<int>("NS");

                    b.Property<int>("NSH");

                    b.Property<int>("NSH1");

                    b.Property<int>("NSHH");

                    b.Property<bool>("New");

                    b.Property<string>("Note");

                    b.Property<bool>("Official");

                    b.Property<bool>("OldContract");

                    b.Property<string>("Phone")
                        .IsRequired();

                    b.Property<string>("Photo");

                    b.Property<string>("Place");

                    b.Property<double>("Price");

                    b.Property<string>("Purpose")
                        .IsRequired();

                    b.Property<string>("Requires");

                    b.Property<string>("SEmail");

                    b.Property<string>("SaleDetails");

                    b.Property<Guid?>("SaleId");

                    b.Property<DateTime>("WDay");

                    b.Property<double>("WMoney");

                    b.Property<string>("WType");

                    b.Property<string>("WithdrawCode");

                    b.Property<string>("WorkPlace");

                    b.Property<string>("cTime");

                    b.Property<string>("dTime");

                    b.Property<string>("password")
                        .IsRequired();

                    b.Property<int>("ph");

                    b.Property<int>("pms");

                    b.Property<int>("pns");

                    b.Property<int>("psh");

                    b.Property<int>("psh1");

                    b.Property<int>("pshh");

                    b.Property<bool>("supporter");

                    b.HasKey("Id");

                    b.HasIndex("SaleId");

                    b.ToTable("appoinment");
                });

            modelBuilder.Entity("BookingForm.Models.Feedback", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content")
                        .IsRequired();

                    b.Property<Guid>("SaleId");

                    b.HasKey("Id");

                    b.HasIndex("SaleId");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("BookingForm.Models.Logger", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Browser");

                    b.Property<string>("Customer");

                    b.Property<string>("Device");

                    b.Property<string>("Ip_Address");

                    b.Property<string>("Log_Time");

                    b.HasKey("ID");

                    b.ToTable("Loggers");
                });

            modelBuilder.Entity("BookingForm.Models.Manager", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("FullName");

                    b.Property<string>("Password");

                    b.Property<string>("Phone");

                    b.Property<string>("Portrait");

                    b.HasKey("ID");

                    b.ToTable("Manager");
                });

            modelBuilder.Entity("BookingForm.Models.Request", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Contents");

                    b.Property<Guid?>("OwnerId");

                    b.Property<string>("RequestName");

                    b.Property<int>("Status");

                    b.Property<string>("Subject");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("BookingForm.Models.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("BookingForm.Models.RoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<Guid>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("BookingForm.Models.Sale", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Address");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("DOB");

                    b.Property<string>("Display");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("Gender");

                    b.Property<string>("Info");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("Members");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<byte[]>("Portrait");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("BookingForm.Models.Transaction", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Diachi");

                    b.Property<string>("Giogd");

                    b.Property<string>("Hieuthietbi");

                    b.Property<string>("Loaithe");

                    b.Property<string>("Machuanchi");

                    b.Property<string>("Ngaygd");

                    b.Property<string>("Ngayxl");

                    b.Property<string>("Phi");

                    b.Property<string>("Sohieudv");

                    b.Property<string>("Solo");

                    b.Property<string>("Sothamchieu");

                    b.Property<string>("Sothe");

                    b.Property<string>("Tiengd");

                    b.Property<string>("Tylephantram");

                    b.Property<string>("VAT");

                    b.HasKey("ID");

                    b.ToTable("transactions");
                });

            modelBuilder.Entity("BookingForm.Models.UserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("BookingForm.Models.UserLogin", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<Guid>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("BookingForm.Models.UserRole", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<Guid>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("BookingForm.Models.UserToken", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("BookingForm.Models.Appoinment", b =>
                {
                    b.HasOne("BookingForm.Models.Sale", "Sale")
                        .WithMany("Meetings")
                        .HasForeignKey("SaleId");
                });

            modelBuilder.Entity("BookingForm.Models.Feedback", b =>
                {
                    b.HasOne("BookingForm.Models.Sale")
                        .WithMany("Feedbacks")
                        .HasForeignKey("SaleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BookingForm.Models.Request", b =>
                {
                    b.HasOne("BookingForm.Models.Sale", "Owner")
                        .WithMany("Requests")
                        .HasForeignKey("OwnerId");
                });

            modelBuilder.Entity("BookingForm.Models.RoleClaim", b =>
                {
                    b.HasOne("BookingForm.Models.Role", "Role")
                        .WithMany("RoleClaims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BookingForm.Models.UserClaim", b =>
                {
                    b.HasOne("BookingForm.Models.Sale", "User")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BookingForm.Models.UserLogin", b =>
                {
                    b.HasOne("BookingForm.Models.Sale", "User")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BookingForm.Models.UserRole", b =>
                {
                    b.HasOne("BookingForm.Models.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BookingForm.Models.Sale", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BookingForm.Models.UserToken", b =>
                {
                    b.HasOne("BookingForm.Models.Sale", "User")
                        .WithMany("Tokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
