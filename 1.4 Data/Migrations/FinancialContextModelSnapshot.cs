﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _1._4_Data;

namespace _1._4_Data.Migrations
{
    [DbContext(typeof(FinancialContext))]
    partial class FinancialContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("_1._3_Domain.Model.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NIF");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("_1._3_Domain.Model.Goal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount");

                    b.Property<DateTime>("Created");

                    b.Property<int>("CustomerId");

                    b.Property<int>("TagCategoryId");

                    b.Property<DateTime>("Updated");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("TagCategoryId");

                    b.ToTable("Goals");
                });

            modelBuilder.Entity("_1._3_Domain.Model.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OperationType");

                    b.Property<string>("Regex");

                    b.Property<int>("TagCategoryId");

                    b.HasKey("Id");

                    b.HasIndex("TagCategoryId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("_1._3_Domain.Model.TagCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int>("OperationType");

                    b.HasKey("Id");

                    b.ToTable("TagCategory");
                });

            modelBuilder.Entity("_1._3_Domain.Model.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount");

                    b.Property<DateTime>("Created");

                    b.Property<int>("CustomerId");

                    b.Property<string>("Description");

                    b.Property<int>("TagId");

                    b.Property<DateTime>("TransactionDate");

                    b.Property<DateTime>("Updated");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("TagId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("_1._3_Domain.Model.Goal", b =>
                {
                    b.HasOne("_1._3_Domain.Model.Customer", "Customer")
                        .WithMany("Goals")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("_1._3_Domain.Model.TagCategory", "TagCategory")
                        .WithMany()
                        .HasForeignKey("TagCategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("_1._3_Domain.Model.Tag", b =>
                {
                    b.HasOne("_1._3_Domain.Model.TagCategory", "TagCategory")
                        .WithMany()
                        .HasForeignKey("TagCategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("_1._3_Domain.Model.Transaction", b =>
                {
                    b.HasOne("_1._3_Domain.Model.Customer", "Customer")
                        .WithMany("Transactions")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("_1._3_Domain.Model.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
