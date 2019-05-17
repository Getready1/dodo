﻿// <auto-generated />
using System;
using Dodo.EFDataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Dodo.EFDataAccess.Migrations
{
    [DbContext(typeof(DodoEFContext))]
    [Migration("20190516150348_ChangedTodoModel")]
    partial class ChangedTodoModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Dodo.Domain.Models.Todo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Category");

                    b.Property<string>("Content");

                    b.Property<DateTimeOffset>("CreatedDate");

                    b.Property<bool>("IsCompleted");

                    b.HasKey("Id");

                    b.ToTable("Todos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Category = 1,
                            Content = "0TestTestTestTest TestTest",
                            CreatedDate = new DateTimeOffset(new DateTime(2019, 5, 16, 18, 3, 48, 283, DateTimeKind.Unspecified).AddTicks(7990), new TimeSpan(0, 3, 0, 0, 0)),
                            IsCompleted = false
                        },
                        new
                        {
                            Id = 2,
                            Category = 1,
                            Content = "1TestTestTestTest TestTest",
                            CreatedDate = new DateTimeOffset(new DateTime(2019, 5, 16, 18, 3, 48, 285, DateTimeKind.Unspecified).AddTicks(2718), new TimeSpan(0, 3, 0, 0, 0)),
                            IsCompleted = false
                        },
                        new
                        {
                            Id = 3,
                            Category = 1,
                            Content = "2TestTestTestTest TestTest",
                            CreatedDate = new DateTimeOffset(new DateTime(2019, 5, 16, 18, 3, 48, 285, DateTimeKind.Unspecified).AddTicks(2740), new TimeSpan(0, 3, 0, 0, 0)),
                            IsCompleted = false
                        },
                        new
                        {
                            Id = 4,
                            Category = 1,
                            Content = "3TestTestTestTest TestTest",
                            CreatedDate = new DateTimeOffset(new DateTime(2019, 5, 16, 18, 3, 48, 285, DateTimeKind.Unspecified).AddTicks(2746), new TimeSpan(0, 3, 0, 0, 0)),
                            IsCompleted = false
                        });
                });
#pragma warning restore 612, 618
        }
    }
}