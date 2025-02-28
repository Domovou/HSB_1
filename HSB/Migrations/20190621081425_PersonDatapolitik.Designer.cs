﻿// <auto-generated />
using System;
using HSB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HSB.Migrations
{
    [DbContext(typeof(HSBContext))]
    [Migration("20190621081425_PersonDatapolitik")]
    partial class PersonDatapolitik
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("HSB.Models.Case", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<DateTime>("Birthdate");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<bool>("Conditions");

                    b.Property<string>("Diagnosis")
                        .IsRequired()
                        .HasMaxLength(1000);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<string>("Parent")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.Property<string>("PhoneNo")
                        .IsRequired()
                        .HasMaxLength(12);

                    b.Property<bool>("PrivacyNotice");

                    b.Property<DateTime?>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("Story")
                        .IsRequired()
                        .HasMaxLength(10000);

                    b.Property<string>("Zip")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Cases");
                });

            modelBuilder.Entity("HSB.Models.Donor", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Conditions");

                    b.Property<int>("Cpr");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<string>("PhoneNo")
                        .IsRequired()
                        .HasMaxLength(12);

                    b.Property<bool>("PrivacyNotice");

                    b.Property<DateTime?>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("ID");

                    b.ToTable("Donors");
                });

            modelBuilder.Entity("HSB.Models.Member", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<bool>("Conditions");

                    b.Property<int?>("Cpr");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<DateTime>("FromDate");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<bool>("MobilePay");

                    b.Property<string>("PhoneNo")
                        .IsRequired()
                        .HasMaxLength(12);

                    b.Property<bool>("PrivacyNotice");

                    b.Property<DateTime?>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<bool>("Subscribed");

                    b.Property<string>("Zip")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("HSB.Models.Story", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Headline")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<string>("ImagePath");

                    b.Property<string>("MyStory")
                        .IsRequired();

                    b.Property<DateTime?>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("ID");

                    b.ToTable("Stories");
                });
#pragma warning restore 612, 618
        }
    }
}
