﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProofOfConceptOrders.InvoicingDbContext;

namespace ProofOfConceptOrders.Migrations
{
    [DbContext(typeof(InvoicingContext))]
    [Migration("20200624084133_test")]
    partial class test
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProofOfConceptOrders.Model.Action", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ActionName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("InvoiceOrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("WmsActionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceOrderId");

                    b.ToTable("Actions");
                });

            modelBuilder.Entity("ProofOfConceptOrders.Model.ActionProperty", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ActionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ActionId");

                    b.HasIndex("Name");

                    b.ToTable("ActionProperty");
                });

            modelBuilder.Entity("ProofOfConceptOrders.Model.InvoiceOrder", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Application")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ArrivalDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CountryOfArrival")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryOfDeparture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Customer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Haulier")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAutomaticInvoicingAllowed")
                        .HasColumnType("bit");

                    b.Property<bool>("IsCancelled")
                        .HasColumnType("bit");

                    b.Property<bool>("IsInvoiced")
                        .HasColumnType("bit");

                    b.Property<string>("OrderNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("OrdersId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Site")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<string>("TransportNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("WmsOrderId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("OrdersId");

                    b.ToTable("InvoiceOrders");
                });

            modelBuilder.Entity("ProofOfConceptOrders.Model.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("_Orders")
                        .HasColumnName("Orders")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ProofOfConceptOrders.Model.Property", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("InvoiceOrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceOrderId");

                    b.HasIndex("Name");

                    b.ToTable("Property");
                });

            modelBuilder.Entity("ProofOfConceptOrders.Model.StockLine", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ArticleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("GrossWeight")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("InvoiceOrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Length")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NetWeight")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Product")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surface")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Volume")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("WmsStocklineId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceOrderId");

                    b.HasIndex("WmsStocklineId");

                    b.ToTable("StockLines");
                });

            modelBuilder.Entity("ProofOfConceptOrders.Model.StockLineAction", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ActionName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("StockLineId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("WmsActionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("StockLineId");

                    b.ToTable("StockLineAction");
                });

            modelBuilder.Entity("ProofOfConceptOrders.Model.StockLineActionProperty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid?>("StockLineActionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.HasIndex("StockLineActionId");

                    b.ToTable("StockLineActionProperty");
                });

            modelBuilder.Entity("ProofOfConceptOrders.Model.StockLineProperty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("StockLineId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("StockLineId");

                    b.ToTable("StockLineProperty");
                });

            modelBuilder.Entity("ProofOfConceptOrders.Model.Action", b =>
                {
                    b.HasOne("ProofOfConceptOrders.Model.InvoiceOrder", null)
                        .WithMany("Actions")
                        .HasForeignKey("InvoiceOrderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProofOfConceptOrders.Model.ActionProperty", b =>
                {
                    b.HasOne("ProofOfConceptOrders.Model.Action", null)
                        .WithMany("Properties")
                        .HasForeignKey("ActionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProofOfConceptOrders.Model.InvoiceOrder", b =>
                {
                    b.HasOne("ProofOfConceptOrders.Model.Order", "Orders")
                        .WithMany()
                        .HasForeignKey("OrdersId");
                });

            modelBuilder.Entity("ProofOfConceptOrders.Model.Property", b =>
                {
                    b.HasOne("ProofOfConceptOrders.Model.InvoiceOrder", null)
                        .WithMany("Properties")
                        .HasForeignKey("InvoiceOrderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProofOfConceptOrders.Model.StockLine", b =>
                {
                    b.HasOne("ProofOfConceptOrders.Model.InvoiceOrder", null)
                        .WithMany("StockLines")
                        .HasForeignKey("InvoiceOrderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProofOfConceptOrders.Model.StockLineAction", b =>
                {
                    b.HasOne("ProofOfConceptOrders.Model.StockLine", null)
                        .WithMany("StockLineActions")
                        .HasForeignKey("StockLineId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProofOfConceptOrders.Model.StockLineActionProperty", b =>
                {
                    b.HasOne("ProofOfConceptOrders.Model.StockLineAction", null)
                        .WithMany("Properties")
                        .HasForeignKey("StockLineActionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProofOfConceptOrders.Model.StockLineProperty", b =>
                {
                    b.HasOne("ProofOfConceptOrders.Model.StockLine", null)
                        .WithMany("Properties")
                        .HasForeignKey("StockLineId");
                });
#pragma warning restore 612, 618
        }
    }
}
