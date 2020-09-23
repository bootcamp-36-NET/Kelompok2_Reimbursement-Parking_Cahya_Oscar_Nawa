﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReimbursementParkingAPI.Context;

namespace ReimbursementParkingAPI.Migrations
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ReimbursementParkingAPI.Models.Blob", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContentType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RequestReimbursementParkingId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RequestReimbursementParkingId")
                        .IsUnique();

                    b.ToTable("tb_blob");
                });

            modelBuilder.Entity("ReimbursementParkingAPI.Models.RequestDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ParkingAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ParkingName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlatNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RequestReimbursementParkingId")
                        .HasColumnType("int");

                    b.Property<int>("TotalPrice")
                        .HasColumnType("int");

                    b.Property<string>("VechicleOwner")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VechicleType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RequestReimbursementParkingId")
                        .IsUnique();

                    b.ToTable("tb_plat-number");
                });

            modelBuilder.Entity("ReimbursementParkingAPI.Models.RequestReimbursementParking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("HRDResponseTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("ManagerResponseTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("RejectReason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("RequestDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("RequestReimbursementStatusEnumId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RequestReimbursementStatusEnumId");

                    b.ToTable("tb_request-reimbursement-parking");
                });

            modelBuilder.Entity("ReimbursementParkingAPI.Models.RequestReimbursementStatusEnum", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tb_m_request-reimbursement-status-enum");
                });

            modelBuilder.Entity("ReimbursementParkingAPI.Models.Blob", b =>
                {
                    b.HasOne("ReimbursementParkingAPI.Models.RequestReimbursementParking", "RequestReimbursementParking")
                        .WithOne("Blob")
                        .HasForeignKey("ReimbursementParkingAPI.Models.Blob", "RequestReimbursementParkingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ReimbursementParkingAPI.Models.RequestDetail", b =>
                {
                    b.HasOne("ReimbursementParkingAPI.Models.RequestReimbursementParking", "RequestReimbursementParking")
                        .WithOne("RequestDetail")
                        .HasForeignKey("ReimbursementParkingAPI.Models.RequestDetail", "RequestReimbursementParkingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ReimbursementParkingAPI.Models.RequestReimbursementParking", b =>
                {
                    b.HasOne("ReimbursementParkingAPI.Models.RequestReimbursementStatusEnum", "RequestReimbursementStatusEnum")
                        .WithMany("RequestReimbursementParkings")
                        .HasForeignKey("RequestReimbursementStatusEnumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
