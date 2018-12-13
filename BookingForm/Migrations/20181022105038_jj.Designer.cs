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
    [Migration("20181022105038_jj")]
    partial class jj
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BookingForm.Models.Appoinment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.Property<string>("Details");

                    b.Property<string>("Email");

                    b.Property<string>("Gender")
                        .IsRequired();

                    b.Property<string>("HKTT")
                        .IsRequired();

                    b.Property<string>("Job");

                    b.Property<double>("Money");

                    b.Property<int>("NCH1");

                    b.Property<int>("NCH2");

                    b.Property<int>("NCH3");

                    b.Property<int>("NMS");

                    b.Property<int>("NSH");

                    b.Property<int>("NSHH");

                    b.Property<string>("Phone")
                        .IsRequired();

                    b.Property<string>("Place");

                    b.Property<double>("Price");

                    b.Property<int>("Priority");

                    b.Property<string>("Purpose")
                        .IsRequired();

                    b.Property<string>("Requires");

                    b.Property<int?>("SaleID");

                    b.Property<string>("WorkPlace");

                    b.Property<DateTime>("cTime");

                    b.Property<DateTime>("dTime");

                    b.Property<string>("password")
                        .IsRequired();

                    b.Property<string>("sale")
                        .IsRequired();

                    b.HasKey("ID");

                    b.HasIndex("SaleID");

                    b.ToTable("appoinment");
                });

            modelBuilder.Entity("BookingForm.Models.Sale", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("email")
                        .IsRequired();

                    b.Property<string>("name")
                        .IsRequired();

                    b.Property<string>("pass")
                        .IsRequired();

                    b.Property<string>("phone")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("sale");
                });

            modelBuilder.Entity("BookingForm.Models.Appoinment", b =>
                {
                    b.HasOne("BookingForm.Models.Sale")
                        .WithMany("meetings")
                        .HasForeignKey("SaleID");
                });
#pragma warning restore 612, 618
        }
    }
}
