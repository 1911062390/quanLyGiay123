using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace quanLyGiay.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=quanLyGiayDBContext")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Category> Categorys { get; set; }
        public virtual DbSet<Orderdetail> Orderdetails { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Category)
                .HasForeignKey(e => e.CatId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Orderdetails)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Orderdetails)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
