﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project1.Data;

namespace Project1.Data.Migrations
{
    [DbContext(typeof(Project1Context))]
    [Migration("20200513021247_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Project1.Domain.StoreItem", b =>
                {
                    b.Property<int>("StoreItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("StoreItemInventoryId")
                        .HasColumnType("int");

                    b.Property<int?>("StoreLocationId")
                        .HasColumnType("int");

                    b.Property<string>("itemName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("itemPrice")
                        .HasColumnType("float");

                    b.HasKey("StoreItemId");

                    b.HasIndex("StoreItemInventoryId");

                    b.HasIndex("StoreLocationId");

                    b.ToTable("StoreItems");
                });

            modelBuilder.Entity("Project1.Domain.StoreItemInventory", b =>
                {
                    b.Property<int>("StoreItemInventoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("itemInventory")
                        .HasColumnType("int");

                    b.HasKey("StoreItemInventoryId");

                    b.ToTable("StoreItemInventories");
                });

            modelBuilder.Entity("Project1.Domain.StoreLocation", b =>
                {
                    b.Property<int>("StoreLocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StoreLocationId");

                    b.ToTable("StoreLocations");
                });

            modelBuilder.Entity("Project1.Domain.UserInfo", b =>
                {
                    b.Property<int>("UserInfoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("fName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserInfoId");

                    b.ToTable("UserInfos");
                });

            modelBuilder.Entity("Project1.Domain.UserOrder", b =>
                {
                    b.Property<int>("UserOrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("StoreLocationId")
                        .HasColumnType("int");

                    b.Property<int?>("UserInfoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("timeStamp")
                        .HasColumnType("datetime2");

                    b.HasKey("UserOrderId");

                    b.HasIndex("StoreLocationId");

                    b.HasIndex("UserInfoId");

                    b.ToTable("UserOrders");
                });

            modelBuilder.Entity("Project1.Domain.UserOrderItem", b =>
                {
                    b.Property<int>("UserOrderItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("StoreItemId")
                        .HasColumnType("int");

                    b.Property<int?>("UserOrderId")
                        .HasColumnType("int");

                    b.HasKey("UserOrderItemId");

                    b.HasIndex("StoreItemId");

                    b.HasIndex("UserOrderId");

                    b.ToTable("UserOrderItems");
                });

            modelBuilder.Entity("Project1.Domain.UserOrderQuantity", b =>
                {
                    b.Property<int>("UserOrderQuantityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("StoreItemId")
                        .HasColumnType("int");

                    b.Property<int?>("UserOrderId")
                        .HasColumnType("int");

                    b.Property<int>("orderQuantity")
                        .HasColumnType("int");

                    b.HasKey("UserOrderQuantityId");

                    b.HasIndex("StoreItemId");

                    b.HasIndex("UserOrderId");

                    b.ToTable("UserOrderQuantities");
                });

            modelBuilder.Entity("Project1.Domain.StoreItem", b =>
                {
                    b.HasOne("Project1.Domain.StoreItemInventory", "StoreItemInventory")
                        .WithMany("StoreItem")
                        .HasForeignKey("StoreItemInventoryId");

                    b.HasOne("Project1.Domain.StoreLocation", "StoreLocation")
                        .WithMany("StoreItems")
                        .HasForeignKey("StoreLocationId");
                });

            modelBuilder.Entity("Project1.Domain.UserOrder", b =>
                {
                    b.HasOne("Project1.Domain.StoreLocation", "StoreLocation")
                        .WithMany()
                        .HasForeignKey("StoreLocationId");

                    b.HasOne("Project1.Domain.UserInfo", "UserInfo")
                        .WithMany()
                        .HasForeignKey("UserInfoId");
                });

            modelBuilder.Entity("Project1.Domain.UserOrderItem", b =>
                {
                    b.HasOne("Project1.Domain.StoreItem", "StoreItem")
                        .WithMany()
                        .HasForeignKey("StoreItemId");

                    b.HasOne("Project1.Domain.UserOrder", "UserOrder")
                        .WithMany("UserOrderItems")
                        .HasForeignKey("UserOrderId");
                });

            modelBuilder.Entity("Project1.Domain.UserOrderQuantity", b =>
                {
                    b.HasOne("Project1.Domain.StoreItem", "StoreItem")
                        .WithMany()
                        .HasForeignKey("StoreItemId");

                    b.HasOne("Project1.Domain.UserOrder", "UserOrder")
                        .WithMany("UserOrderQuantity")
                        .HasForeignKey("UserOrderId");
                });
#pragma warning restore 612, 618
        }
    }
}
