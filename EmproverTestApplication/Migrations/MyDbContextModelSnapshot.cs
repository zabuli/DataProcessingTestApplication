﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repositories.Database;

#nullable disable

namespace DataProcessingApplication.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Application.Contract.Dtos.IndicatorDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Execution")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SymbolId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TimeTo")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Indicator");
                });

            modelBuilder.Entity("Application.Contract.Dtos.ParameterDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("IndicatorId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDefault")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IndicatorId");

                    b.ToTable("Parameter");
                });

            modelBuilder.Entity("Application.Contract.Dtos.SymbolDto", b =>
                {
                    b.Property<string>("Column10")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Column11")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Column12")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Column13")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Column14")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Column15")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Column5")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Column6")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Column7")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Column8")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Column9")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("TimeFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TimeTo")
                        .HasColumnType("datetime2");

                    b.ToTable("Symbol");
                });

            modelBuilder.Entity("Application.Contract.Dtos.UserDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Application.Contract.Dtos.ParameterDto", b =>
                {
                    b.HasOne("Application.Contract.Dtos.IndicatorDto", "Indicator")
                        .WithMany("Parameters")
                        .HasForeignKey("IndicatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Indicator");
                });

            modelBuilder.Entity("Application.Contract.Dtos.IndicatorDto", b =>
                {
                    b.Navigation("Parameters");
                });
#pragma warning restore 612, 618
        }
    }
}