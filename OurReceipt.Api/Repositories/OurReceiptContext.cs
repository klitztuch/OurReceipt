using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OurReceipt.Api.Entities;

namespace OurReceipt.Api.Repositories
{
    public class OurReceiptContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public OurReceiptContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public OurReceiptContext(DbContextOptions<OurReceiptContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Receipt> Receipt { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                // #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlite($"DataSource={_configuration["Database"]}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Receipt>(entity =>
            {
                entity.ToTable("receipt");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasViewColumnName("id")
                    .HasColumnType("int")
                    .ValueGeneratedNever();

                entity.Property(e => e.Date)
                    .IsRequired()
                    .HasColumnName("date")
                    .HasViewColumnName("date");

                entity.Property(e => e.Origin)
                    .IsRequired()
                    .HasColumnName("origin")
                    .HasViewColumnName("origin");

                entity.Property(e => e.User)
                    .HasColumnName("user")
                    .HasViewColumnName("user")
                    .HasColumnType("int");

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasViewColumnName("value")
                    .HasColumnType("int");

                entity.HasOne(d => d.UserNavigation)
                    .WithMany(p => p.Receipt)
                    .HasForeignKey(x => x.User)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasViewColumnName("id")
                    .HasColumnType("int")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasViewColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        private void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            throw new NotImplementedException();
        }
    }
}