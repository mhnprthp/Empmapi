﻿// <auto-generated />
using EmployeeManagementSystem;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace EmployeeManagementSystem.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("EmployeeManagementSystem.Model.Attachment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int>("EmpID")
                        .HasColumnType("integer");

                    b.Property<string>("FileName")
                        .HasColumnType("text");

                    b.Property<string>("FileUrl")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("EmpID");

                    b.ToTable("Attachments");
                });

            modelBuilder.Entity("EmployeeManagementSystem.Model.Employee", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("ContactNo")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("Gender")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean");

                    b.HasKey("ID");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("EmployeeManagementSystem.Model.Salary", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<bool>("Annual")
                        .HasColumnType("boolean");

                    b.Property<decimal>("Bonus")
                        .HasColumnType("numeric");

                    b.Property<int>("EmpID")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("EmpID");

                    b.ToTable("Salaries");
                });

            modelBuilder.Entity("EmployeeManagementSystem.Model.Attachment", b =>
                {
                    b.HasOne("EmployeeManagementSystem.Model.Employee", "Employee")
                        .WithMany("Attachments")
                        .HasForeignKey("EmpID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("EmployeeManagementSystem.Model.Salary", b =>
                {
                    b.HasOne("EmployeeManagementSystem.Model.Employee", "Employee")
                        .WithMany("Salaries")
                        .HasForeignKey("EmpID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("EmployeeManagementSystem.Model.Employee", b =>
                {
                    b.Navigation("Attachments");

                    b.Navigation("Salaries");
                });
#pragma warning restore 612, 618
        }
    }
}
