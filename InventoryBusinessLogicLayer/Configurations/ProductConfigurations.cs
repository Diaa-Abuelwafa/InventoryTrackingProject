using InventoryDataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryBusinessLogicLayer.Configurations
{
    public class ProductConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasOne(x => x.Warehouse)
                   .WithMany(x => x.Products)
                   .HasForeignKey(x => x.WarehouseId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
