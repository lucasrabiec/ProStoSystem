﻿namespace ProStoSystem.Database.EntitiesConfigurations
{
    using System.Data.Entity.ModelConfiguration;
    using Entities;

    public class ProductEntityConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductEntityConfiguration()
        {
            HasMany(p => p.OrderDetails)
                .WithMany(od => od.Products)
                .Map(pod =>
                {
                    pod.ToTable("ProductOrder");
                    pod.MapLeftKey("ProductId");
                    pod.MapRightKey("OrderDetailId");
                });

            HasRequired(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);

            Property(p => p.Name).IsRequired();
            Property(p => p.SellingPrice).IsRequired();
            Property(p => p.PurchasePrice).IsRequired();
            Property(p => p.Amount).IsRequired();
        }
    }
}
