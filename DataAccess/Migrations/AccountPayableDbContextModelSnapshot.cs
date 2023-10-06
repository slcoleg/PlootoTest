﻿// <auto-generated />
using System;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(AccountPayableDbContext))]
    partial class AccountPayableDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.11");

            modelBuilder.Entity("Model.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Amount")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("DueDate")
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("IssuedDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("State")
                        .HasColumnType("INTEGER");

                    b.Property<int>("VendorId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Invoice", (string)null);
                });

            modelBuilder.Entity("Model.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Amount")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DebitDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("InvoiceId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PaymentType")
                        .HasColumnType("INTEGER");

                    b.Property<int>("VendorId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Payment", (string)null);
                });

            modelBuilder.Entity("Model.Vendor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int>("State")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Vendor", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
