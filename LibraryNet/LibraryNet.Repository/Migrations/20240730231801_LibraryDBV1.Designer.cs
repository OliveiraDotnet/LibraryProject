﻿// <auto-generated />
using LibraryNet.Repository.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LibraryNet.Repository.Migrations
{
    [DbContext(typeof(LibraryContext))]
    [Migration("20240730231801_LibraryDBV1")]
    partial class LibraryDBV1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LibraryNet.Repository.Models.Author", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Author");
                });

            modelBuilder.Entity("LibraryNet.Repository.Models.Book", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AuthorId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Edition")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberPages")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal");

                    b.Property<string>("PublishCompanyId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ReleaseYear")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Review")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Translations")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("PublishCompanyId");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("LibraryNet.Repository.Models.PublishCompany", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WebSite")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PublishCompany");
                });

            modelBuilder.Entity("LibraryNet.Repository.Models.Book", b =>
                {
                    b.HasOne("LibraryNet.Repository.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId");

                    b.HasOne("LibraryNet.Repository.Models.PublishCompany", "PublishCompany")
                        .WithMany("Books")
                        .HasForeignKey("PublishCompanyId");

                    b.Navigation("Author");

                    b.Navigation("PublishCompany");
                });

            modelBuilder.Entity("LibraryNet.Repository.Models.Author", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("LibraryNet.Repository.Models.PublishCompany", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
