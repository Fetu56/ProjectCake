using Microsoft.EntityFrameworkCore;

namespace CSVtoMSSQL.Models;

public partial class MainContext : DbContext
{
    public MainContext()
    {
    }

    public MainContext(DbContextOptions<MainContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cab> Cabs { get; set; }

    //Because of usage of local SQL server - ConnectionString is public in this file. Consider add this file to .gitingnore on using cloud server.
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=CSVtoSQL;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cab>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Cab");

            entity.Property(e => e.DOLocationId).HasColumnName("DOLocationID");
            entity.Property(e => e.FareAmount)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("fare_amount");
            entity.Property(e => e.PassengerCount).HasColumnName("passenger_count");
            entity.Property(e => e.PULocationId).HasColumnName("PULocationID");
            entity.Property(e => e.StoreAndFwdFlag)
                .HasColumnType("char(3)")
                .HasColumnName("store_and_fwd_flag");
            entity.Property(e => e.TipAmount)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("tip_amount");
            entity.Property(e => e.TpepDropoffDatetime)
                .HasColumnType("datetime")
                .HasColumnName("tpep_dropoff_datetime");
            entity.Property(e => e.TpepPickupDatetime)
                .HasColumnType("datetime")
                .HasColumnName("tpep_pickup_datetime");
            entity.Property(e => e.TripDistance)
                .HasColumnType("decimal(4, 2)")
                .HasColumnName("trip_distance");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}