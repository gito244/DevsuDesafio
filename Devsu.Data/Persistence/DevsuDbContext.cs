using Devsu.Domain.Operaciones;
using Microsoft.EntityFrameworkCore;

namespace Devsu.Infrastructure.Persistence
{
    public partial class DevsuDbContext : DbContext
    {
        public DevsuDbContext(DbContextOptions<DevsuDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Cliente");

                entity.Property(e => e.Contrasena)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Cuenta>(entity =>
            {
                entity.ToTable("Cuenta");

                entity.HasKey(e => e.NumeroCuenta);

                entity.Property(e => e.NumeroCuenta).ValueGeneratedNever();

                entity.Property(e => e.SaldoInicial).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TipoCuenta)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Movimientos>(entity =>
            {
                entity.ToTable("Movimientos");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.Saldo).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TipoMovimiento)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Valor).HasColumnType("decimal(18, 2)");


                entity.HasOne(d => d.NumeroCuentaNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.NumeroCuenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Movimientos_Cuenta");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.ToTable("Persona");

                entity.HasIndex(e => e.Identificacion, "UC_Identificacion")
                    .IsUnique();

                entity.Property(e => e.Direccion)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Genero)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Identificacion)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public virtual DbSet<Cliente>? Clientes { get; set; }
        public virtual DbSet<Cuenta>? Cuentas { get; set; }
        public virtual DbSet<Movimientos>? Movimientos { get; set; }
        public virtual DbSet<Persona>? Personas { get; set; }
    }
}
