﻿// <auto-generated />
using System;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(ticketContext))]
    [Migration("20200707135428_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DAL.Models.Comments", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasAnnotation("MySql:CharSet", "latin1")
                        .HasAnnotation("MySql:Collation", "latin1_swedish_ci");

                    b.Property<DateTime>("CommentDate")
                        .HasColumnType("date");

                    b.Property<int>("TicketId")
                        .HasColumnType("int(11)");

                    b.Property<int>("UserId")
                        .HasColumnType("int(11)");

                    b.HasKey("CommentId")
                        .HasName("PRIMARY");

                    b.HasIndex("TicketId")
                        .HasName("FK_Comment_Ticket");

                    b.HasIndex("UserId")
                        .HasName("FK_Comment_User");

                    b.ToTable("comments");
                });

            modelBuilder.Entity("DAL.Models.Priorities", b =>
                {
                    b.Property<int>("PriorityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasAnnotation("MySql:CharSet", "latin1")
                        .HasAnnotation("MySql:Collation", "latin1_swedish_ci");

                    b.HasKey("PriorityId")
                        .HasName("PRIMARY");

                    b.ToTable("priorities");
                });

            modelBuilder.Entity("DAL.Models.Projects", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasAnnotation("MySql:CharSet", "latin1")
                        .HasAnnotation("MySql:Collation", "latin1_swedish_ci");

                    b.HasKey("ProjectId")
                        .HasName("PRIMARY");

                    b.ToTable("projects");
                });

            modelBuilder.Entity("DAL.Models.Roles", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasAnnotation("MySql:CharSet", "latin1")
                        .HasAnnotation("MySql:Collation", "latin1_swedish_ci");

                    b.HasKey("RoleId")
                        .HasName("PRIMARY");

                    b.ToTable("roles");
                });

            modelBuilder.Entity("DAL.Models.Severities", b =>
                {
                    b.Property<int>("SeverityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasAnnotation("MySql:CharSet", "latin1")
                        .HasAnnotation("MySql:Collation", "latin1_swedish_ci");

                    b.HasKey("SeverityId")
                        .HasName("PRIMARY");

                    b.ToTable("severities");
                });

            modelBuilder.Entity("DAL.Models.Statuses", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasAnnotation("MySql:CharSet", "latin1")
                        .HasAnnotation("MySql:Collation", "latin1_swedish_ci");

                    b.HasKey("StatusId")
                        .HasName("PRIMARY");

                    b.ToTable("statuses");
                });

            modelBuilder.Entity("DAL.Models.Tickets", b =>
                {
                    b.Property<int>("TicketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<int>("AssignedTo")
                        .HasColumnType("int(11)");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int(11)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("date");

                    b.Property<int>("PriorityId")
                        .HasColumnType("int(11)");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int(11)");

                    b.Property<int>("SeverityId")
                        .HasColumnType("int(11)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int(11)");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasAnnotation("MySql:CharSet", "latin1")
                        .HasAnnotation("MySql:Collation", "latin1_swedish_ci");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasAnnotation("MySql:CharSet", "latin1")
                        .HasAnnotation("MySql:Collation", "latin1_swedish_ci");

                    b.HasKey("TicketId")
                        .HasName("PRIMARY");

                    b.HasIndex("AssignedTo")
                        .HasName("FK_Ticket_Assigned");

                    b.HasIndex("CreatedBy")
                        .HasName("FK_Ticket_Creator");

                    b.HasIndex("PriorityId")
                        .HasName("FK_Tikcet_Priority");

                    b.HasIndex("ProjectId")
                        .HasName("FK_Tikcet_Project");

                    b.HasIndex("SeverityId")
                        .HasName("FK_Ticket_Severity");

                    b.HasIndex("StatusId")
                        .HasName("FK_Ticket_Status");

                    b.ToTable("tickets");
                });

            modelBuilder.Entity("DAL.Models.Userroles", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int(11)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int(11)");

                    b.HasKey("UserId", "RoleId")
                        .HasName("PRIMARY");

                    b.HasIndex("RoleId")
                        .HasName("FK_UserRole_Role");

                    b.ToTable("userroles");
                });

            modelBuilder.Entity("DAL.Models.Users", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(30)")
                        .HasAnnotation("MySql:CharSet", "latin1")
                        .HasAnnotation("MySql:Collation", "latin1_swedish_ci");

                    b.Property<byte[]>("Password")
                        .IsRequired()
                        .HasColumnType("varbinary(250)")
                        .HasMaxLength(250);

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(250)")
                        .HasMaxLength(250);

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasAnnotation("MySql:CharSet", "latin1")
                        .HasAnnotation("MySql:Collation", "latin1_swedish_ci");

                    b.HasKey("UserId")
                        .HasName("PRIMARY");

                    b.ToTable("users");
                });

            modelBuilder.Entity("DAL.Models.Comments", b =>
                {
                    b.HasOne("DAL.Models.Tickets", "Ticket")
                        .WithMany("Comments")
                        .HasForeignKey("TicketId")
                        .HasConstraintName("FK_Comment_Ticket")
                        .IsRequired();

                    b.HasOne("DAL.Models.Users", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Comment_User")
                        .IsRequired();
                });

            modelBuilder.Entity("DAL.Models.Tickets", b =>
                {
                    b.HasOne("DAL.Models.Users", "AssignedToNavigation")
                        .WithMany("TicketsAssignedToNavigation")
                        .HasForeignKey("AssignedTo")
                        .HasConstraintName("FK_Ticket_Assigned")
                        .IsRequired();

                    b.HasOne("DAL.Models.Users", "CreatedByNavigation")
                        .WithMany("TicketsCreatedByNavigation")
                        .HasForeignKey("CreatedBy")
                        .HasConstraintName("FK_Ticket_Creator")
                        .IsRequired();

                    b.HasOne("DAL.Models.Priorities", "Priority")
                        .WithMany("Tickets")
                        .HasForeignKey("PriorityId")
                        .HasConstraintName("FK_Tikcet_Priority")
                        .IsRequired();

                    b.HasOne("DAL.Models.Projects", "Project")
                        .WithMany("Tickets")
                        .HasForeignKey("ProjectId")
                        .HasConstraintName("FK_Tikcet_Project")
                        .IsRequired();

                    b.HasOne("DAL.Models.Severities", "Severity")
                        .WithMany("Tickets")
                        .HasForeignKey("SeverityId")
                        .HasConstraintName("FK_Ticket_Severity")
                        .IsRequired();

                    b.HasOne("DAL.Models.Statuses", "Status")
                        .WithMany("Tickets")
                        .HasForeignKey("StatusId")
                        .HasConstraintName("FK_Ticket_Status")
                        .IsRequired();
                });

            modelBuilder.Entity("DAL.Models.Userroles", b =>
                {
                    b.HasOne("DAL.Models.Roles", "Role")
                        .WithMany("Userroles")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK_UserRole_Role")
                        .IsRequired();

                    b.HasOne("DAL.Models.Users", "User")
                        .WithMany("Userroles")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_UserRole_User")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}