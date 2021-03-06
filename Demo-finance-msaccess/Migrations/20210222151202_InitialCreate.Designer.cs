﻿// <auto-generated />
using System;
using App;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Demo_finance_msaccess.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20210222151202_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.3");

            modelBuilder.Entity("App.Agent", b =>
                {
                    b.Property<int>("AgentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("AgentId");

                    b.ToTable("Agents");
                });

            modelBuilder.Entity("App.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<int?>("AgentId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ContractNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("ClientId");

                    b.HasIndex("AgentId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("App.Collection", b =>
                {
                    b.Property<int>("CollectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ClientId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("TEXT");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("CollectionId");

                    b.HasIndex("ClientId");

                    b.ToTable("Collections");
                });

            modelBuilder.Entity("App.Client", b =>
                {
                    b.HasOne("App.Agent", "Agent")
                        .WithMany("Clients")
                        .HasForeignKey("AgentId");

                    b.Navigation("Agent");
                });

            modelBuilder.Entity("App.Collection", b =>
                {
                    b.HasOne("App.Client", "Client")
                        .WithMany("Collections")
                        .HasForeignKey("ClientId");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("App.Agent", b =>
                {
                    b.Navigation("Clients");
                });

            modelBuilder.Entity("App.Client", b =>
                {
                    b.Navigation("Collections");
                });
#pragma warning restore 612, 618
        }
    }
}
