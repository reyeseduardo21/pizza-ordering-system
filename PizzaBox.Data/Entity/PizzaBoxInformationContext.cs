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

        public virtual DbSet<PizzaOrder> PizzaOrders { get; set; }
        public virtual DbSet<PizzaType> PizzaTypes { get; set; }
        public virtual DbSet<Store> Stores { get; set; }

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

            modelBuilder.Entity<PizzaOrder>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CustomerId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CustomerID");

                entity.Property(e => e.DateOrdered)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PizzaCrust)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PizzaPrice).HasColumnType("decimal(4, 2)");

                entity.Property(e => e.PizzaSize)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PizzaToppings)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PizzaType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Store)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PizzaType>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Pizza)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(5, 2)");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.StoreName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StoreState)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
