using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PizzaBox.Data.Entity
{
    public partial class PizzaBoxInformationContext : DbContext
    {
        public PizzaBoxInformationContext()
        {
        }

        public PizzaBoxInformationContext(DbContextOptions<PizzaBoxInformationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Crust> Crusts { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Pizza> Pizzas { get; set; }
        public virtual DbSet<PizzaSize> PizzaSizes { get; set; }
        public virtual DbSet<PizzaTopping> PizzaToppings { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<Topping> Toppings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:pizzasavinginformation.database.windows.net,1433;Initial Catalog=PizzaBoxInformation;Persist Security Info=False;User ID=dev;Password=Password1!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Crust>(entity =>
            {
                entity.ToTable("Crust");

                entity.HasIndex(e => e.CrustName, "UQ__Crust__C2369FD2656AC1E0")
                    .IsUnique();

                entity.Property(e => e.CrustId).HasColumnName("CrustID");

                entity.Property(e => e.CrustName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CrustPrice).HasColumnType("smallmoney");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.HasIndex(e => e.Username, "UQ__Customer__536C85E445FEBE28")
                    .IsUnique();

                entity.Property(e => e.CustomerId)
                    .ValueGeneratedNever()
                    .HasColumnName("CustomerID");

                entity.Property(e => e.CustomerAddress)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerCardCvv).HasColumnName("CustomerCardCVV");

                entity.Property(e => e.CustomerCardNumber).HasColumnType("decimal(16, 0)");

                entity.Property(e => e.CustomerFirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerLastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerPhone).HasColumnType("decimal(10, 0)");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.OrderId)
                    .ValueGeneratedNever()
                    .HasColumnName("OrderID");

                entity.Property(e => e.Cost).HasColumnType("smallmoney");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Order__CustomerI__2739D489");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK__Order__StoreID__282DF8C2");
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.ToTable("Pizza");

                entity.Property(e => e.PizzaId)
                    .ValueGeneratedNever()
                    .HasColumnName("PizzaID");

                entity.Property(e => e.CrustId).HasColumnName("CrustID");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.PizzaPrice).HasColumnType("smallmoney");

                entity.Property(e => e.PizzaSizeId).HasColumnName("PizzaSizeID");

                entity.HasOne(d => d.Crust)
                    .WithMany(p => p.Pizzas)
                    .HasForeignKey(d => d.CrustId)
                    .HasConstraintName("FK__Pizza__CrustID__32AB8735");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Pizzas)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__Pizza__OrderID__31B762FC");

                entity.HasOne(d => d.PizzaSize)
                    .WithMany(p => p.Pizzas)
                    .HasForeignKey(d => d.PizzaSizeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Pizza__PizzaSize__339FAB6E");
            });

            modelBuilder.Entity<PizzaSize>(entity =>
            {
                entity.ToTable("PizzaSize");

                entity.HasIndex(e => e.PizzaSizeName, "UQ__PizzaSiz__F84F0608919357E8")
                    .IsUnique();

                entity.Property(e => e.PizzaSizeId).HasColumnName("PizzaSizeID");

                entity.Property(e => e.PizzaSizeName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PizzaSizePrice).HasColumnType("smallmoney");
            });

            modelBuilder.Entity<PizzaTopping>(entity =>
            {
                entity.ToTable("PizzaTopping");

                entity.Property(e => e.PizzaToppingId)
                    .ValueGeneratedNever()
                    .HasColumnName("PizzaToppingID");

                entity.Property(e => e.PizzaId).HasColumnName("PizzaID");

                entity.Property(e => e.ToppingId).HasColumnName("ToppingID");

                entity.HasOne(d => d.Pizza)
                    .WithMany(p => p.PizzaToppings)
                    .HasForeignKey(d => d.PizzaId)
                    .HasConstraintName("FK__PizzaTopp__Pizza__3A4CA8FD");

                entity.HasOne(d => d.Topping)
                    .WithMany(p => p.PizzaToppings)
                    .HasForeignKey(d => d.ToppingId)
                    .HasConstraintName("FK__PizzaTopp__Toppi__3B40CD36");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("Store");

                entity.HasIndex(e => e.StoreLocation, "UQ__Store__AB9F35EF5ACC35C9")
                    .IsUnique();

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.StoreLocation)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Topping>(entity =>
            {
                entity.ToTable("Topping");

                entity.HasIndex(e => e.ToppingName, "UQ__Topping__612DF4CD30FA0FD4")
                    .IsUnique();

                entity.Property(e => e.ToppingId).HasColumnName("ToppingID");

                entity.Property(e => e.ToppingName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ToppingPrice).HasColumnType("smallmoney");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
