using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AutoRentalAPI.Models;

public partial class AutoRentalContext : DbContext
{
    public AutoRentalContext()
    {
    }

    public AutoRentalContext(DbContextOptions<AutoRentalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AdditionalService> AdditionalServices { get; set; }

    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<CarType> CarTypes { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<ClientPaymentsTotalView> ClientPaymentsTotalViews { get; set; }

    public virtual DbSet<ConcludingContractsView> ConcludingContractsViews { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<RentalContract> RentalContracts { get; set; }

    public virtual DbSet<RentalCountByModelView> RentalCountByModelViews { get; set; }

    public virtual DbSet<ServicesContract> ServicesContracts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-NIKITA;Initial Catalog=AutoRental;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AdditionalService>(entity =>
        {
            entity.HasKey(e => e.ServiceId).HasName("PK__addition__3E0DB8AF9EC1326D");

            entity.ToTable("additional_services");

            entity.Property(e => e.ServiceId).HasColumnName("service_id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.PricePerDay)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price_per_day");
        });

        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasKey(e => e.CarId).HasName("PK__cars__4C9A0DB3ED77475C");

            entity.ToTable("cars");

            entity.Property(e => e.CarId).HasColumnName("car_id");
            entity.Property(e => e.Availability).HasColumnName("availability");
            entity.Property(e => e.CarTypeId).HasColumnName("car_type_id");
            entity.Property(e => e.Color)
                .HasMaxLength(30)
                .HasColumnName("color");
            entity.Property(e => e.Condition)
                .HasMaxLength(255)
                .HasColumnName("condition");
            entity.Property(e => e.Model)
                .HasMaxLength(50)
                .HasColumnName("model");
            entity.Property(e => e.PricePerDay)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price_per_day");
            entity.Property(e => e.YearOfManufacture).HasColumnName("year_of_manufacture");

            entity.HasOne(d => d.CarType).WithMany(p => p.Cars)
                .HasForeignKey(d => d.CarTypeId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__cars__car_type_i__3B75D760");
        });

        modelBuilder.Entity<CarType>(entity =>
        {
            entity.HasKey(e => e.CarTypeId).HasName("PK__car_type__019EDE8B8A441543");

            entity.ToTable("car_types");

            entity.Property(e => e.CarTypeId).HasColumnName("car_type_id");
            entity.Property(e => e.BodyType)
                .HasMaxLength(50)
                .HasColumnName("body_type");
            entity.Property(e => e.Brand)
                .HasMaxLength(50)
                .HasColumnName("brand");
            entity.Property(e => e.Category)
                .HasMaxLength(50)
                .HasColumnName("category");
            entity.Property(e => e.SeatingCapacity).HasColumnName("seating_capacity");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.ClientId).HasName("PK__clients__BF21A424AF5AF819");

            entity.ToTable("clients");

            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.Adress)
                .HasMaxLength(255)
                .HasColumnName("adress");
            entity.Property(e => e.BirthDate).HasColumnName("birth_date");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .HasColumnName("phone_number");
        });

        modelBuilder.Entity<ClientPaymentsTotalView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ClientPaymentsTotalView");

            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
            entity.Property(e => e.TotalPayments)
                .HasColumnType("decimal(38, 2)")
                .HasColumnName("total_payments");
        });

        modelBuilder.Entity<ConcludingContractsView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ConcludingContractsView");

            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasColumnName("status");
            entity.Property(e => e.TotalAmount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total_amount");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__payments__ED1FC9EA361BA4AB");

            entity.ToTable("payments");

            entity.HasIndex(e => e.ContractId, "UQ__payments__F8D66422A1E10E8C").IsUnique();

            entity.Property(e => e.PaymentId).HasColumnName("payment_id");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.ContractId).HasColumnName("contract_id");
            entity.Property(e => e.PaymentDate).HasColumnName("payment_date");
            entity.Property(e => e.PaymentType)
                .HasMaxLength(20)
                .HasColumnName("payment_type");

            entity.HasOne(d => d.Contract).WithOne(p => p.Payment)
                .HasForeignKey<Payment>(d => d.ContractId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__payments__contra__4AB81AF0");
        });

        modelBuilder.Entity<RentalContract>(entity =>
        {
            entity.HasKey(e => e.ContractId).HasName("PK__rental_c__F8D664236A62C155");

            entity.ToTable("rental_contracts", tb => tb.HasTrigger("tr_CheckRentalLimit"));

            entity.Property(e => e.ContractId).HasColumnName("contract_id");
            entity.Property(e => e.CarId).HasColumnName("car_id");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasColumnName("status");
            entity.Property(e => e.TotalAmount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total_amount");

            entity.HasOne(d => d.Car).WithMany(p => p.RentalContracts)
                .HasForeignKey(d => d.CarId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__rental_co__car_i__3F466844");

            entity.HasOne(d => d.Client).WithMany(p => p.RentalContracts)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__rental_co__clien__3E52440B");
        });

        modelBuilder.Entity<RentalCountByModelView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("RentalCountByModelView");

            entity.Property(e => e.Model).HasMaxLength(50);
            entity.Property(e => e.RentalCount).HasColumnName("Rental_Count");
        });

        modelBuilder.Entity<ServicesContract>(entity =>
        {
            entity.HasKey(e => e.ServiceContractId).HasName("PK__services__2B703C1D968EE999");

            entity.ToTable("services_contracts");

            entity.Property(e => e.ServiceContractId).HasColumnName("service_contract_id");
            entity.Property(e => e.ContractId).HasColumnName("contract_id");
            entity.Property(e => e.ServiceId).HasColumnName("service_id");

            entity.HasOne(d => d.Contract).WithMany(p => p.ServicesContracts)
                .HasForeignKey(d => d.ContractId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__services___contr__5EBF139D");

            entity.HasOne(d => d.Service).WithMany(p => p.ServicesContracts)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__services___servi__5FB337D6");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
