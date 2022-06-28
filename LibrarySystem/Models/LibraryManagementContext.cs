using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace LibrarySystem.Models
{
    public partial class LibraryManagementContext : DbContext
    {
        public LibraryManagementContext()
        {
        }

        public LibraryManagementContext(DbContextOptions<LibraryManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccountsInfo> AccountsInfo { get; set; }
        public virtual DbSet<BooksInfo> BooksInfo { get; set; }
        public virtual DbSet<LendRequest> LendRequest { get; set; }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=LibraryManagement;User=sa;Password=<YourStrong@Passw0rd>");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountsInfo>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Accounts__1788CCAC9406702C");

                entity.ToTable("AccountsInfo");

                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("UserID");

                entity.Property(e => e.AccountType)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Psd)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("psd");

                entity.Property(e => e.Username)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BooksInfo>(entity =>
            {
                entity.HasKey(e => e.BookId)
                    .HasName("PK__BooksInf__3DE0C2275AE9C5CD");

                entity.ToTable("BooksInfo");

                entity.Property(e => e.BookId)
                    .ValueGeneratedNever()
                    .HasColumnName("BookID");

                entity.Property(e => e.Author)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.BookTitle)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Genre)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LendRequest>(entity =>
            {
                entity.HasKey(e => e.LendId)
                    .HasName("PK__LendRequ__FA11BC1E2B3FE6AE");

                entity.ToTable("LendRequest");

                entity.Property(e => e.LendId)
                    .ValueGeneratedNever()
                    .HasColumnName("LendID");

                entity.Property(e => e.BookId).HasColumnName("BookID");

                entity.Property(e => e.ReqStatus)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.LendRequests)
                    .HasForeignKey(d => d.BookId)
                    .HasConstraintName("FK__LendReque__BookI__3A81B327");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.LendRequests)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__LendReque__UserI__3B75D760");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);*/
    }
}
