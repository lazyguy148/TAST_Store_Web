using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TAST_Store.Models
{
    public partial class TAST_STOREContext : DbContext
    {
        public TAST_STOREContext()
        {
        }

        public TAST_STOREContext(DbContextOptions<TAST_STOREContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Blog> Blogs { get; set; } = null!;
        public virtual DbSet<Cart> Carts { get; set; } = null!;
        public virtual DbSet<CartDetail> CartDetails { get; set; } = null!;
        public virtual DbSet<Catology> Catologies { get; set; } = null!;
        public virtual DbSet<Menu> Menus { get; set; } = null!;
        public virtual DbSet<Permission> Permissions { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Slider> Sliders { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=LAPTOP-5K30TST1\\SQLEXPRESS;Database=TAST_STORE;Trusted_Connection=True;TrustServerCertificate=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>(entity =>
            {
                entity.HasKey(e => e.IdBlog)
                    .HasName("PK__BLOG__75519326BD7DB911");

                entity.ToTable("BLOG");

                entity.Property(e => e.IdBlog).HasColumnName("ID_BLOG");

                entity.Property(e => e.Datebegin)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("DATEBEGIN");

                entity.Property(e => e.Detail)
                    .HasColumnType("ntext")
                    .HasColumnName("DETAIL");

                entity.Property(e => e.Hide).HasColumnName("HIDE");

                entity.Property(e => e.IdUsers).HasColumnName("ID_USERS");

                entity.Property(e => e.Img)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("IMG");

                entity.Property(e => e.Link)
                    .HasMaxLength(255)
                    .HasColumnName("LINK");

                entity.Property(e => e.Meta)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("META");

                entity.Property(e => e.Order).HasColumnName("ORDER");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .HasColumnName("TITLE");

                entity.HasOne(d => d.IdUsersNavigation)
                    .WithMany(p => p.Blogs)
                    .HasForeignKey(d => d.IdUsers)
                    .HasConstraintName("FK__BLOG__ID_USERS__31EC6D26");
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.HasKey(e => e.IdCart)
                    .HasName("PK__CART__7A1680A5A1B60353");

                entity.ToTable("CART");

                entity.Property(e => e.IdCart).HasColumnName("ID_CART");

                entity.Property(e => e.Datebegin)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("DATEBEGIN");

                entity.Property(e => e.Hide).HasColumnName("HIDE");

                entity.Property(e => e.IdUsers).HasColumnName("ID_USERS");

                entity.Property(e => e.Link)
                    .HasMaxLength(255)
                    .HasColumnName("LINK");

                entity.Property(e => e.Meta)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("META");

                entity.Property(e => e.Order).HasColumnName("ORDER");

                entity.HasOne(d => d.IdUsersNavigation)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.IdUsers)
                    .HasConstraintName("FK__CART__ID_USERS__32E0915F");
            });

            modelBuilder.Entity<CartDetail>(entity =>
            {
                entity.HasKey(e => e.IdCd)
                    .HasName("PK__CART_DET__8B622F8FF8FA1C85");

                entity.ToTable("CART_DETAIL");

                entity.Property(e => e.IdCd).HasColumnName("ID_CD");

                entity.Property(e => e.Hide).HasColumnName("HIDE");

                entity.Property(e => e.IdCart).HasColumnName("ID_CART");

                entity.Property(e => e.IdPro).HasColumnName("ID_PRO");

                entity.Property(e => e.Link)
                    .HasMaxLength(255)
                    .HasColumnName("LINK");

                entity.Property(e => e.Meta)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("META");

                entity.Property(e => e.Order).HasColumnName("ORDER");

                entity.Property(e => e.SoldNum).HasColumnName("SOLD_NUM");

                entity.HasOne(d => d.IdCartNavigation)
                    .WithMany(p => p.CartDetails)
                    .HasForeignKey(d => d.IdCart)
                    .HasConstraintName("FK__CART_DETA__ID_CA__35BCFE0A");

                entity.HasOne(d => d.IdProNavigation)
                    .WithMany(p => p.CartDetails)
                    .HasForeignKey(d => d.IdPro)
                    .HasConstraintName("FK__CART_DETA__ID_PR__33D4B598");
            });

            modelBuilder.Entity<Catology>(entity =>
            {
                entity.HasKey(e => e.IdCat)
                    .HasName("PK__CATOLOGY__2BF8FA1CBA9A2E5B");

                entity.ToTable("CATOLOGY");

                entity.Property(e => e.IdCat).HasColumnName("ID_CAT");

                entity.Property(e => e.Hide).HasColumnName("HIDE");

                entity.Property(e => e.Link)
                    .HasMaxLength(255)
                    .HasColumnName("LINK");

                entity.Property(e => e.Meta)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("META");

                entity.Property(e => e.NameCat)
                    .HasMaxLength(50)
                    .HasColumnName("NAME_CAT");

                entity.Property(e => e.Order).HasColumnName("ORDER");
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.HasKey(e => e.IdMenu)
                    .HasName("PK__MENU__4728FC60DE9BA532");

                entity.ToTable("MENU");

                entity.Property(e => e.IdMenu).HasColumnName("ID_MENU");

                entity.Property(e => e.Datebegin)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("DATEBEGIN");

                entity.Property(e => e.Hide).HasColumnName("HIDE");

                entity.Property(e => e.Link)
                    .HasMaxLength(255)
                    .HasColumnName("LINK");

                entity.Property(e => e.Meta)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("META");

                entity.Property(e => e.Order).HasColumnName("ORDER");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .HasColumnName("TITLE");
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.HasKey(e => e.IdPermission);

                entity.ToTable("PERMISSIONS");

                entity.Property(e => e.IdPermission)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_PERMISSION");

                entity.Property(e => e.Permission1)
                    .HasMaxLength(50)
                    .HasColumnName("PERMISSION");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.IdPro)
                    .HasName("PK__PRODUCTS__20AF98FD4A428510");

                entity.ToTable("PRODUCTS");

                entity.Property(e => e.IdPro).HasColumnName("ID_PRO");

                entity.Property(e => e.Detail)
                    .HasColumnType("ntext")
                    .HasColumnName("DETAIL");

                entity.Property(e => e.Hide).HasColumnName("HIDE");

                entity.Property(e => e.IdCat).HasColumnName("ID_CAT");

                entity.Property(e => e.Img1)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("IMG1");

                entity.Property(e => e.Img2)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("IMG2");

                entity.Property(e => e.Img3)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("IMG3");

                entity.Property(e => e.Link)
                    .HasMaxLength(255)
                    .HasColumnName("LINK");

                entity.Property(e => e.Meta)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("META");

                entity.Property(e => e.NamePro)
                    .HasMaxLength(50)
                    .HasColumnName("NAME_PRO");

                entity.Property(e => e.Nums).HasColumnName("NUMS");

                entity.Property(e => e.Order).HasColumnName("ORDER");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("PRICE");

                entity.HasOne(d => d.IdCatNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.IdCat)
                    .HasConstraintName("FK__PRODUCTS__ID_CAT__34C8D9D1");
            });

            modelBuilder.Entity<Slider>(entity =>
            {
                entity.HasKey(e => e.IdSlide)
                    .HasName("PK__SLIDER__22D1BB105547F98F");

                entity.ToTable("SLIDER");

                entity.Property(e => e.IdSlide).HasColumnName("ID_SLIDE");

                entity.Property(e => e.Datebegin)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("DATEBEGIN");

                entity.Property(e => e.Hide).HasColumnName("HIDE");

                entity.Property(e => e.Img)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("IMG");

                entity.Property(e => e.Link)
                    .HasMaxLength(255)
                    .HasColumnName("LINK");

                entity.Property(e => e.Meta)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("META");

                entity.Property(e => e.Order).HasColumnName("ORDER");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .HasColumnName("TITLE");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUsers)
                    .HasName("PK__USERS__1DDB35C39D9574E9");

                entity.ToTable("USERS");

                entity.Property(e => e.IdUsers).HasColumnName("ID_USERS");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .HasColumnName("ADDRESS");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Hide).HasColumnName("HIDE");

                entity.Property(e => e.Link)
                    .HasMaxLength(255)
                    .HasColumnName("LINK");

                entity.Property(e => e.Meta)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("META");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("NAME");

                entity.Property(e => e.Order).HasColumnName("ORDER");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Permission).HasColumnName("PERMISSION");

                entity.Property(e => e.Phone)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("PHONE");

                entity.Property(e => e.Username)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("USERNAME");

                entity.HasOne(d => d.PermissionNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.Permission)
                    .HasConstraintName("FK_USERS_PERMISSIONS");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
