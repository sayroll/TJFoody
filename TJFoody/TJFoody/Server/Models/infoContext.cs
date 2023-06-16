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

        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<Cuisine> Cuisines { get; set; } = null!;
        public virtual DbSet<CuisineReview> CuisineReviews { get; set; } = null!;
        public virtual DbSet<Post> Posts { get; set; } = null!;
        public virtual DbSet<Seller> Sellers { get; set; } = null!;
        public virtual DbSet<SellerReview> SellerReviews { get; set; } = null!;
        public virtual DbSet<Team> Teams { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserJoinTeam> UserJoinTeams { get; set; } = null!;

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

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("comments");

                entity.HasIndex(e => e.PostId, "post_id");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Content)
                    .HasMaxLength(255)
                    .HasColumnName("content");

                entity.Property(e => e.Phone)
                    .HasMaxLength(255)
                    .HasColumnName("phone");

                entity.Property(e => e.PostId)
                    .HasColumnType("int(11)")
                    .HasColumnName("post_id");

                entity.Property(e => e.ReplyId)
                    .HasColumnType("int(11)")
                    .HasColumnName("reply_id");

                entity.Property(e => e.Time)
                    .HasMaxLength(255)
                    .HasColumnName("time");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.PostId)
                    .HasConstraintName("comments_ibfk_1");
            });

            modelBuilder.Entity<Cuisine>(entity =>
            {
                entity.ToTable("cuisine");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
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
                    .HasMaxLength(11)
                    .HasColumnName("user_ID");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("posts");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Content)
                    .HasMaxLength(255)
                    .HasColumnName("content");

                entity.Property(e => e.Phone)
                    .HasMaxLength(255)
                    .HasColumnName("phone");

                entity.Property(e => e.Postname)
                    .HasMaxLength(255)
                    .HasColumnName("postname");

                entity.Property(e => e.Time)
                    .HasMaxLength(255)
                    .HasColumnName("time");
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

                entity.Property(e => e.Poi)
                    .HasMaxLength(255)
                    .HasColumnName("poi");
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
                    .HasMaxLength(11)
                    .HasColumnName("user_ID");
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.ToTable("team");

                entity.Property(e => e.TeamId)
                    .HasColumnType("int(11)")
                    .HasColumnName("team_id");

                entity.Property(e => e.Count)
                    .HasColumnType("int(11)")
                    .HasColumnName("count")
                    .HasComment("人数");

                entity.Property(e => e.DeadLine)
                    .HasMaxLength(255)
                    .HasColumnName("dead_line");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");

                entity.Property(e => e.LeaderId)
                    .HasMaxLength(255)
                    .HasColumnName("leader_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Tag)
                    .HasMaxLength(255)
                    .HasColumnName("tag");
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

            modelBuilder.Entity<UserJoinTeam>(entity =>
            {
                entity.ToTable("user_join_team");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.TeamId)
                    .HasColumnType("int(11)")
                    .HasColumnName("team_id");

                entity.Property(e => e.Time)
                    .HasMaxLength(255)
                    .HasColumnName("time");

                entity.Property(e => e.UserId)
                    .HasMaxLength(255)
                    .HasColumnName("user_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
