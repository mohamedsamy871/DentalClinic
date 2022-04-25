﻿// <auto-generated />
using System;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccess.Migrations
{
    [DbContext(typeof(MyAppContext))]
    [Migration("20220425101010_removeFKConstrainFromBill")]
    partial class removeFKConstrainFromBill
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("DataAccess.Models.ClinicSchedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Day")
                        .HasColumnType("int");

                    b.Property<int>("Month")
                        .HasColumnType("int");

                    b.Property<int?>("PatientId")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("ClinicSchedules");
                });

            modelBuilder.Entity("DataAccess.Models.DoctorAssessment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Diagnosis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LabTest")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("VisitId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VisitId");

                    b.ToTable("DoctorAssessment");
                });

            modelBuilder.Entity("DataAccess.Models.PatientBill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("TotalAmout")
                        .HasColumnType("int");

                    b.Property<int>("VisitAmout")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PatientBills");
                });

            modelBuilder.Entity("DataAccess.Models.PatientInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("DataAccess.Models.Procedure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PatientBillId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PatientBillId");

                    b.ToTable("Procedures");
                });

            modelBuilder.Entity("DataAccess.Models.VisitInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("BillId")
                        .HasColumnType("int");

                    b.Property<string>("Date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PatientId")
                        .HasColumnType("int");

                    b.Property<string>("Time")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BillId")
                        .IsUnique()
                        .HasFilter("[BillId] IS NOT NULL");

                    b.HasIndex("PatientId");

                    b.ToTable("Visits");
                });

            modelBuilder.Entity("DataAccess.Models.ClinicSchedule", b =>
                {
                    b.HasOne("DataAccess.Models.PatientInfo", "PatientInfo")
                        .WithMany()
                        .HasForeignKey("PatientId");

                    b.Navigation("PatientInfo");
                });

            modelBuilder.Entity("DataAccess.Models.DoctorAssessment", b =>
                {
                    b.HasOne("DataAccess.Models.VisitInfo", "Visit")
                        .WithMany("DoctorAssessments")
                        .HasForeignKey("VisitId");

                    b.Navigation("Visit");
                });

            modelBuilder.Entity("DataAccess.Models.Procedure", b =>
                {
                    b.HasOne("DataAccess.Models.PatientBill", null)
                        .WithMany("Procedures")
                        .HasForeignKey("PatientBillId");
                });

            modelBuilder.Entity("DataAccess.Models.VisitInfo", b =>
                {
                    b.HasOne("DataAccess.Models.PatientBill", "Bill")
                        .WithOne("Visit")
                        .HasForeignKey("DataAccess.Models.VisitInfo", "BillId");

                    b.HasOne("DataAccess.Models.PatientInfo", "PatientInfo")
                        .WithMany("Visits")
                        .HasForeignKey("PatientId");

                    b.Navigation("Bill");

                    b.Navigation("PatientInfo");
                });

            modelBuilder.Entity("DataAccess.Models.PatientBill", b =>
                {
                    b.Navigation("Procedures");

                    b.Navigation("Visit");
                });

            modelBuilder.Entity("DataAccess.Models.PatientInfo", b =>
                {
                    b.Navigation("Visits");
                });

            modelBuilder.Entity("DataAccess.Models.VisitInfo", b =>
                {
                    b.Navigation("DoctorAssessments");
                });
#pragma warning restore 612, 618
        }
    }
}
