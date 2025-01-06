using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TARS_Delivery_System.Models;

public partial class Tars_EprojectDbContext : IdentityDbContext
{
    public Tars_EprojectDbContext()
    {
    }

    public Tars_EprojectDbContext(DbContextOptions<Tars_EprojectDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BranchTbl> BranchTbls { get; set; }

    public virtual DbSet<DeliverablesTbl> DeliverablesTbls { get; set; }

    public virtual DbSet<EmployeesTbl> EmployeesTbls { get; set; }

    public virtual DbSet<LogsTbl> LogsTbls { get; set; }

    public virtual DbSet<PaymentTbl> PaymentTbls { get; set; }

    public virtual DbSet<ServiceChargesTbl> ServiceChargesTbls { get; set; }

    public virtual DbSet<TrackingTbl> TrackingTbls { get; set; }

    public virtual DbSet<UserTbl> UserTbls { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-62GJAP8; Initial Catalog=Tars_EprojectDB; Trusted_Connection=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BranchTbl>(entity =>
        {
            entity.HasKey(e => e.BranchId);

            entity.ToTable("Branch_Tbl");

            entity.Property(e => e.BranchId)
                .ValueGeneratedNever()
                .HasColumnName("Branch_id");
            entity.Property(e => e.BranchName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Branch_name");
            entity.Property(e => e.ContactNumber)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Contact_number");
            entity.Property(e => e.Location)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PinCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Pin_Code");
        });

        modelBuilder.Entity<DeliverablesTbl>(entity =>
        {
            entity.HasKey(e => e.DeliverableId);

            entity.ToTable("Deliverables_Tbl");

            entity.Property(e => e.DeliverableId)
                .ValueGeneratedNever()
                .HasColumnName("Deliverable_id");
            entity.Property(e => e.BranchId).HasColumnName("Branch_id");
            entity.Property(e => e.Charge)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("charge");
            entity.Property(e => e.DeliveryDate)
                .HasColumnType("datetime")
                .HasColumnName("Delivery_date");
            entity.Property(e => e.DeliveryType)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Delivery_type");
            entity.Property(e => e.PaymentStatus)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Payment_status");
            entity.Property(e => e.ProductName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Product_Name");
            entity.Property(e => e.ReceiverAddress)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Receiver_Address");
            entity.Property(e => e.ReceiverContact)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Receiver_Contact");
            entity.Property(e => e.ReceiverName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Receiver_Name");
            entity.Property(e => e.SendDate)
                .HasColumnType("datetime")
                .HasColumnName("Send_date");
            entity.Property(e => e.SenderContact)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Sender_Contact");
            entity.Property(e => e.SenderName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Sender_Name");
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.TrackingId).HasColumnName("Tracking_Id");
            entity.Property(e => e.UserId).HasColumnName("User_id");
            entity.Property(e => e.Weight).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Branch).WithMany(p => p.DeliverablesTbls)
                .HasForeignKey(d => d.BranchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Deliverables_Tbl_Branch_Tbl");

            entity.HasOne(d => d.User).WithMany(p => p.DeliverablesTbls)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Deliverables_Tbl_User_Tbl");
        });

        modelBuilder.Entity<EmployeesTbl>(entity =>
        {
            entity.HasKey(e => e.EmployeeId);

            entity.ToTable("Employees_Tbl");

            entity.Property(e => e.EmployeeId)
                .ValueGeneratedNever()
                .HasColumnName("Employee_id");
            entity.Property(e => e.BranchId).HasColumnName("Branch_id");
            entity.Property(e => e.Role)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.UserId).HasColumnName("User_id");

            entity.HasOne(d => d.Branch).WithMany(p => p.EmployeesTbls)
                .HasForeignKey(d => d.BranchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employees_Tbl_Branch_Tbl");

            entity.HasOne(d => d.User).WithMany(p => p.EmployeesTbls)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employees_Tbl_User_Tbl");
        });

        modelBuilder.Entity<LogsTbl>(entity =>
        {
            entity.HasKey(e => e.LogId);

            entity.ToTable("Logs_Tbl");

            entity.Property(e => e.LogId)
                .ValueGeneratedNever()
                .HasColumnName("Log_id");
            entity.Property(e => e.Action).HasColumnType("text");
            entity.Property(e => e.IpAdress)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("Ip_adress");
            entity.Property(e => e.LogDate)
                .HasColumnType("datetime")
                .HasColumnName("Log_date");
            entity.Property(e => e.UserId).HasColumnName("User_id");

            entity.HasOne(d => d.User).WithMany(p => p.LogsTbls)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Logs_Tbl_User_Tbl");
        });

        modelBuilder.Entity<PaymentTbl>(entity =>
        {
            entity.HasKey(e => e.PaymentId);

            entity.ToTable("Payment_Tbl");

            entity.Property(e => e.PaymentId)
                .ValueGeneratedNever()
                .HasColumnName("Payment_id");
            entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.DeliverableId).HasColumnName("Deliverable_id");
            entity.Property(e => e.PaymentDate)
                .HasColumnType("datetime")
                .HasColumnName("Payment_date");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Payment_method");
            entity.Property(e => e.PaymentStatus)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Payment_status");

            entity.HasOne(d => d.Deliverable).WithMany(p => p.PaymentTbls)
                .HasForeignKey(d => d.DeliverableId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Payment_Tbl_Deliverables_Tbl");
        });

        modelBuilder.Entity<ServiceChargesTbl>(entity =>
        {
            entity.HasKey(e => e.ServiceChargeId);

            entity.ToTable("Service_Charges_Tbl");

            entity.Property(e => e.ServiceChargeId)
                .ValueGeneratedNever()
                .HasColumnName("Service_charge_id");
            entity.Property(e => e.BaseCharge)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Base_charge");
            entity.Property(e => e.DistanceFactor)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Distance_factor");
            entity.Property(e => e.ServiceType)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Service_type");
            entity.Property(e => e.WeightFactor)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Weight_factor");
        });

        modelBuilder.Entity<TrackingTbl>(entity =>
        {
            entity.HasKey(e => e.TrackingId);

            entity.ToTable("Tracking_Tbl");

            entity.Property(e => e.TrackingId)
                .ValueGeneratedNever()
                .HasColumnName("Tracking_id");
            entity.Property(e => e.ActionTaken)
                .HasColumnType("text")
                .HasColumnName("Action_taken");
            entity.Property(e => e.DeliverableId).HasColumnName("Deliverable_id");
            entity.Property(e => e.Location).HasMaxLength(255);
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("Update_date");
            entity.Property(e => e.UpdatedBy).HasColumnName("Updated_by");

            entity.HasOne(d => d.Deliverable).WithMany(p => p.TrackingTbls)
                .HasForeignKey(d => d.DeliverableId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tracking_Tbl_Deliverables_Tbl");
        });

        modelBuilder.Entity<UserTbl>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.ToTable("User_Tbl");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("User_Id");
            entity.Property(e => e.ContactNumber)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Contact_number");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Role)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UserEmail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("User_email");
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("User_name");
        });

        base.OnModelCreating(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
