using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TJFoody.Server.Models
{
    public partial class infoContext : DbContext
    {
        public infoContext()
        {
        }

        public infoContext(DbContextOptions<infoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cuisine> Cuisines { get; set; } = null!;
        public virtual DbSet<CuisineReview> CuisineReviews { get; set; } = null!;
        public virtual DbSet<Seller> Sellers { get; set; } = null!;
        public virtual DbSet<SellerReview> SellerReviews { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=sh-cynosdbmysql-grp-1cebab18.sql.tencentcdb.com;port=27601;database=info;uid=root;pwd=hssSB748;charset=utf8", Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.7.18-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8_general_ci")
                .HasCharSet("utf8");

            modelBuilder.Entity<Cuisine>(entity =>
            {
                entity.ToTable("cuisine");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(255)
                    .HasColumnName("image_url");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.SellerId)
                    .HasColumnType("int(11)")
                    .HasColumnName("seller_id");
            });

            modelBuilder.Entity<CuisineReview>(entity =>
            {
                entity.ToTable("cuisine_review");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Content)
                    .HasColumnType("text")
                    .HasColumnName("content");

                entity.Property(e => e.CuisineId)
                    .HasColumnType("int(11)")
                    .HasColumnName("cuisine_ID");

                entity.Property(e => e.Date)
                    .HasMaxLength(255)
                    .HasColumnName("date");

                entity.Property(e => e.Rate)
                    .HasColumnType("int(11)")
                    .HasColumnName("rate");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(11)")
                    .HasColumnName("user_ID");
            });

            modelBuilder.Entity<Seller>(entity =>
            {
                entity.ToTable("seller");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(255)
                    .HasColumnName("image_url");

                entity.Property(e => e.Location)
                    .HasMaxLength(255)
                    .HasColumnName("location");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<SellerReview>(entity =>
            {
                entity.ToTable("seller_review");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Content)
                    .HasColumnType("text")
                    .HasColumnName("content");

                entity.Property(e => e.Date)
                    .HasMaxLength(255)
                    .HasColumnName("date");

                entity.Property(e => e.Rate)
                    .HasColumnType("int(11)")
                    .HasColumnName("rate");

                entity.Property(e => e.SellerId)
                    .HasColumnType("int(11)")
                    .HasColumnName("seller_ID");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(11)")
                    .HasColumnName("user_ID");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Phone)
                    .HasName("PRIMARY");

                entity.ToTable("user");

                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.Property(e => e.Avartar)
                    .HasMaxLength(255)
                    .HasColumnName("avartar");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .HasColumnName("password");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
