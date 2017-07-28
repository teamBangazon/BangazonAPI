using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using BangazonAPI.Data;

namespace BangazonAPI.Migrations
{
    [DbContext(typeof(BangazonAPIContext))]
    partial class BangazonAPIContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("BangazonAPI.Models.Computer", b =>
                {
                    b.Property<int>("ComputerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DecommisionedDate");

                    b.Property<string>("PurchasedDate")
                        .IsRequired();

                    b.HasKey("ComputerId");

                    b.ToTable("Computer");
                });

            modelBuilder.Entity("BangazonAPI.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("strftime('%Y-%m-%d %H:%M:%S')");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.HasKey("CustomerId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("BangazonAPI.Models.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("ExpenseBudget");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("DepartmentId");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("BangazonAPI.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateHired")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("strftime('%Y-%m-%d %H:%M:%S')");

                    b.Property<int>("DepartmentId");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<bool>("Supervisor");

                    b.HasKey("EmployeeId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("BangazonAPI.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CustomerId");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<int>("Price");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("ProductId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("BangazonAPI.Models.Employee", b =>
                {
                    b.HasOne("BangazonAPI.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BangazonAPI.Models.Product", b =>
                {
                    b.HasOne("BangazonAPI.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
