﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Moodle.Data;

namespace Moodle.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210204121552_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("Value")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Moodle.Domain.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("GroupId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Moodle.Domain.Exercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(1000) CHARACTER SET utf8mb4")
                        .HasMaxLength(1000);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.Property<int?>("SectionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SectionId");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("Moodle.Domain.ExerciseStudent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("CompletionTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("CurrentAttempt")
                        .HasColumnType("int");

                    b.Property<int>("ExerciseId")
                        .HasColumnType("int");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<double>("Mark")
                        .HasColumnType("double");

                    b.Property<string>("StudentId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.HasIndex("StudentId");

                    b.ToTable("ExerciseStudent");
                });

            modelBuilder.Entity("Moodle.Domain.File", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.Property<string>("FileType")
                        .IsRequired()
                        .HasColumnType("varchar(20) CHARACTER SET utf8mb4")
                        .HasMaxLength(20);

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("varchar(300) CHARACTER SET utf8mb4")
                        .HasMaxLength(300);

                    b.HasKey("Id");

                    b.ToTable("Files");

                    b.HasDiscriminator<string>("FileType").HasValue("File");
                });

            modelBuilder.Entity("Moodle.Domain.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Class")
                        .HasColumnType("int");

                    b.Property<string>("HeadManId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(10) CHARACTER SET utf8mb4")
                        .HasMaxLength(10);

                    b.Property<string>("SuperVisorId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("HeadManId")
                        .IsUnique();

                    b.HasIndex("SuperVisorId")
                        .IsUnique();

                    b.ToTable("Groups");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Class = 2,
                            HeadManId = "B22638B8-42A2-4115-9631-1C2D1E2AC5F7",
                            Name = "208",
                            SuperVisorId = "B22628B8-42A2-4115-9631-1C2D1E2AC5F7"
                        });
                });

            modelBuilder.Entity("Moodle.Domain.Section", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(1000) CHARACTER SET utf8mb4")
                        .HasMaxLength(1000);

                    b.Property<string>("Header")
                        .IsRequired()
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Sections");
                });

            modelBuilder.Entity("Moodle.Domain.TeacherCourse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("TeacherId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("TeacherId");

                    b.ToTable("TeacherCourses");
                });

            modelBuilder.Entity("Moodle.Domain.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("FullName")
                        .HasColumnType("varchar(55) CHARACTER SET utf8mb4")
                        .HasMaxLength(55);

                    b.Property<DateTime?>("LastSeen")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("PhotoPass")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4")
                        .HasMaxLength(256);

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasColumnType("varchar(15) CHARACTER SET utf8mb4")
                        .HasMaxLength(15);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("UserType").HasValue("Admin");

                    b.HasData(
                        new
                        {
                            Id = "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                            AccessFailedCount = 0,
                            BirthDate = new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ConcurrencyStamp = "e2741d69-0814-46d6-88a6-d028f7632f8b",
                            Email = "Admin@Admin.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@ADMIN.COM",
                            NormalizedUserName = "MASTERADMIN",
                            PasswordHash = "AQAAAAEAACcQAAAAEDDOTxFfiHqEhEJeVViLr7T+7X9e09HwYx3hMaNVyMLAd4OsR94fO+FuU/87UvXOWA==",
                            PhoneNumber = "XXXXXXXXXXXXX",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "00000000-0000-0000-0000-000000000000",
                            TwoFactorEnabled = false,
                            UserName = "masteradmin"
                        });
                });

            modelBuilder.Entity("Moodle.Domain.ExerciseFile", b =>
                {
                    b.HasBaseType("Moodle.Domain.File");

                    b.Property<int?>("ExerciseId")
                        .HasColumnType("int");

                    b.HasIndex("ExerciseId");

                    b.HasDiscriminator().HasValue("ExerciseFile");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FileName = "1",
                            Path = "files\\MainFiles\\1.docx"
                        },
                        new
                        {
                            Id = 2,
                            FileName = "2",
                            Path = "files\\MainFiles\\2.docx"
                        },
                        new
                        {
                            Id = 3,
                            FileName = "3",
                            Path = "files\\MainFiles\\3.docx"
                        },
                        new
                        {
                            Id = 4,
                            FileName = "4",
                            Path = "files\\MainFiles\\4.pptx"
                        },
                        new
                        {
                            Id = 5,
                            FileName = "5",
                            Path = "files\\MainFiles\\5.docx"
                        });
                });

            modelBuilder.Entity("Moodle.Domain.StudentsExerciseFile", b =>
                {
                    b.HasBaseType("Moodle.Domain.File");

                    b.Property<int?>("ExerciseStudentId")
                        .HasColumnType("int");

                    b.HasIndex("ExerciseStudentId");

                    b.HasDiscriminator().HasValue("StudentsExerciseFile");
                });

            modelBuilder.Entity("Moodle.Domain.Student", b =>
                {
                    b.HasBaseType("Moodle.Domain.User");

                    b.Property<int?>("GroupId")
                        .HasColumnType("int");

                    b.HasIndex("GroupId");

                    b.HasDiscriminator().HasValue("Student");

                    b.HasData(
                        new
                        {
                            Id = "B22618B8-42A2-4115-9631-1C2D1E2AC5F7",
                            AccessFailedCount = 0,
                            BirthDate = new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ConcurrencyStamp = "fbbf844a-e3c2-420e-98d2-f5050c61255e",
                            Email = "student1@student1.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "STUDENT1@STUDENT1.COM",
                            NormalizedUserName = "STUDENT1",
                            PasswordHash = "AQAAAAEAACcQAAAAEOVcCgsFQYhS38zgQMB0xCtjh+hk+rQn6jVASfdT5mC7HM2SX7ET13qaoTsqtmvqrg==",
                            PhoneNumber = "XXXXXXXXXXXXX",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "00000000-0000-0000-0000-000000000000",
                            TwoFactorEnabled = false,
                            UserName = "student1"
                        },
                        new
                        {
                            Id = "B22618B9-42A2-4115-9631-1C2D1E2AC5F7",
                            AccessFailedCount = 0,
                            BirthDate = new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ConcurrencyStamp = "7a991414-1d3a-4a46-acd5-769c19b1b4b0",
                            Email = "student2@student2.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "STUDENT2@STUDENT2.COM",
                            NormalizedUserName = "STUDENT2",
                            PasswordHash = "AQAAAAEAACcQAAAAEAwRhFj4GgGo3R4XiPnPqX2Dn6uM1U/b+7nJs4gty4xjSQM8SV8DI8/5EEEffytYQg==",
                            PhoneNumber = "XXXXXXXXXXXXX",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "00000000-0000-0000-0000-000000000000",
                            TwoFactorEnabled = false,
                            UserName = "student2"
                        },
                        new
                        {
                            Id = "B22638B8-42A2-4115-9631-1C2D1E2AC5F7",
                            AccessFailedCount = 0,
                            BirthDate = new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ConcurrencyStamp = "3ff7ff5f-f520-41b0-a887-92d7079533f6",
                            Email = "headman@headman.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "HEADMAN@HEADMAN.COM",
                            NormalizedUserName = "HEADMAN",
                            PasswordHash = "AQAAAAEAACcQAAAAEF2otiYhbYARh7QqNZiLiSGganFTYZ+6U3wicGABiIRwwRWnH7ubdDLox3eXUEYlkg==",
                            PhoneNumber = "XXXXXXXXXXXXX",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "00000000-0000-0000-0000-000000000000",
                            TwoFactorEnabled = false,
                            UserName = "headman"
                        });
                });

            modelBuilder.Entity("Moodle.Domain.Teacher", b =>
                {
                    b.HasBaseType("Moodle.Domain.User");

                    b.HasDiscriminator().HasValue("Teacher");

                    b.HasData(
                        new
                        {
                            Id = "B22628B8-42A2-4115-9631-1C2D1E2AC5F7",
                            AccessFailedCount = 0,
                            BirthDate = new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ConcurrencyStamp = "5d7da5bd-4a85-4fc8-bb48-70deb3e9bd4f",
                            Email = "teacher@teacher.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "TEACHER@TEACHER.COM",
                            NormalizedUserName = "MASTERTEACHER",
                            PasswordHash = "AQAAAAEAACcQAAAAEKxWtPIRpBU0W7Jap6EEKHzlQV9mC8weeYHtq/xwjixPk6rbDKAS4iaYFUboDz764g==",
                            PhoneNumber = "XXXXXXXXXXXXX",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "00000000-0000-0000-0000-000000000000",
                            TwoFactorEnabled = false,
                            UserName = "masterteacher"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Moodle.Domain.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Moodle.Domain.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Moodle.Domain.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Moodle.Domain.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Moodle.Domain.Course", b =>
                {
                    b.HasOne("Moodle.Domain.Group", "Group")
                        .WithMany("Courses")
                        .HasForeignKey("GroupId");
                });

            modelBuilder.Entity("Moodle.Domain.Exercise", b =>
                {
                    b.HasOne("Moodle.Domain.Section", "Section")
                        .WithMany("Exercises")
                        .HasForeignKey("SectionId");
                });

            modelBuilder.Entity("Moodle.Domain.ExerciseStudent", b =>
                {
                    b.HasOne("Moodle.Domain.Exercise", "Exercise")
                        .WithMany("Students")
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Moodle.Domain.Student", "Student")
                        .WithMany("Exercises")
                        .HasForeignKey("StudentId");
                });

            modelBuilder.Entity("Moodle.Domain.Group", b =>
                {
                    b.HasOne("Moodle.Domain.Student", "HeadMan")
                        .WithOne("HeadGroup")
                        .HasForeignKey("Moodle.Domain.Group", "HeadManId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Moodle.Domain.Teacher", "SuperVisor")
                        .WithOne("Group")
                        .HasForeignKey("Moodle.Domain.Group", "SuperVisorId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("Moodle.Domain.Section", b =>
                {
                    b.HasOne("Moodle.Domain.Course", "Course")
                        .WithMany("Sections")
                        .HasForeignKey("CourseId");
                });

            modelBuilder.Entity("Moodle.Domain.TeacherCourse", b =>
                {
                    b.HasOne("Moodle.Domain.Course", "Course")
                        .WithMany("Teachers")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Moodle.Domain.Teacher", "Teacher")
                        .WithMany("Courses")
                        .HasForeignKey("TeacherId");
                });

            modelBuilder.Entity("Moodle.Domain.ExerciseFile", b =>
                {
                    b.HasOne("Moodle.Domain.Exercise", "Exercise")
                        .WithMany("AttachedFiles")
                        .HasForeignKey("ExerciseId");
                });

            modelBuilder.Entity("Moodle.Domain.StudentsExerciseFile", b =>
                {
                    b.HasOne("Moodle.Domain.ExerciseStudent", "ExerciseStudent")
                        .WithMany("AttachedFiles")
                        .HasForeignKey("ExerciseStudentId");
                });

            modelBuilder.Entity("Moodle.Domain.Student", b =>
                {
                    b.HasOne("Moodle.Domain.Group", "Group")
                        .WithMany("Students")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.SetNull);
                });
#pragma warning restore 612, 618
        }
    }
}
