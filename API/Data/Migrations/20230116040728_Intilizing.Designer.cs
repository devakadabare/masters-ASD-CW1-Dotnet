﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Data.Migrations
{
    [DbContext(typeof(StoreContext))]
    [Migration("20230116040728_Intilizing")]
    partial class Intilizing
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.1");

            modelBuilder.Entity("API.Entities.Account", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("balance")
                        .HasColumnType("INTEGER");

                    b.Property<string>("description")
                        .HasColumnType("TEXT");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("status")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("userid")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.HasIndex("userid");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("API.Entities.Budget", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("amount")
                        .HasColumnType("INTEGER");

                    b.Property<int>("categoryid")
                        .HasColumnType("INTEGER");

                    b.Property<int>("month")
                        .HasColumnType("INTEGER");

                    b.Property<int>("status")
                        .HasColumnType("INTEGER");

                    b.Property<int>("userid")
                        .HasColumnType("INTEGER");

                    b.Property<int>("year")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.HasIndex("categoryid");

                    b.HasIndex("userid");

                    b.ToTable("Budgets");
                });

            modelBuilder.Entity("API.Entities.Category", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("description")
                        .HasColumnType("TEXT");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("status")
                        .HasColumnType("INTEGER");

                    b.Property<int>("type")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("userid")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.HasIndex("userid");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("API.Entities.Transaction", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("accountid")
                        .HasColumnType("INTEGER");

                    b.Property<long>("amout")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("categoryid")
                        .HasColumnType("INTEGER");

                    b.Property<int>("creditDebitIndicator")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("date")
                        .HasColumnType("TEXT");

                    b.Property<string>("note")
                        .HasColumnType("TEXT");

                    b.Property<int>("status")
                        .HasColumnType("INTEGER");

                    b.Property<int>("type")
                        .HasColumnType("INTEGER");

                    b.Property<int>("userid")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.HasIndex("accountid");

                    b.HasIndex("categoryid");

                    b.HasIndex("userid");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("API.Entities.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("lastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("passwordHash")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("API.Entities.Account", b =>
                {
                    b.HasOne("API.Entities.User", "user")
                        .WithMany("Accounts")
                        .HasForeignKey("userid");

                    b.Navigation("user");
                });

            modelBuilder.Entity("API.Entities.Budget", b =>
                {
                    b.HasOne("API.Entities.Category", "category")
                        .WithMany()
                        .HasForeignKey("categoryid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Entities.User", "user")
                        .WithMany("Budget")
                        .HasForeignKey("userid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("category");

                    b.Navigation("user");
                });

            modelBuilder.Entity("API.Entities.Category", b =>
                {
                    b.HasOne("API.Entities.User", "user")
                        .WithMany("Categories")
                        .HasForeignKey("userid");

                    b.Navigation("user");
                });

            modelBuilder.Entity("API.Entities.Transaction", b =>
                {
                    b.HasOne("API.Entities.Account", "account")
                        .WithMany("transactions")
                        .HasForeignKey("accountid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Entities.Category", "category")
                        .WithMany("transactions")
                        .HasForeignKey("categoryid");

                    b.HasOne("API.Entities.User", "user")
                        .WithMany("Transactions")
                        .HasForeignKey("userid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("account");

                    b.Navigation("category");

                    b.Navigation("user");
                });

            modelBuilder.Entity("API.Entities.Account", b =>
                {
                    b.Navigation("transactions");
                });

            modelBuilder.Entity("API.Entities.Category", b =>
                {
                    b.Navigation("transactions");
                });

            modelBuilder.Entity("API.Entities.User", b =>
                {
                    b.Navigation("Accounts");

                    b.Navigation("Budget");

                    b.Navigation("Categories");

                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}