using Db.Benchmark.Domain.Models.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Db.Benchmark.Infrastructure.EntityFramework.EntityConfiguration.Products;

public class ProductTypeEfConfig : IEntityTypeConfiguration<ProductType>
{
	public void Configure(EntityTypeBuilder<ProductType> builder)
	{
		builder.HasKey(x => x.ProductTypeId);
		builder.HasIndex(x => x.Name).IsUnique();

		builder.Property(x => x.ProductTypeId).IsRequired().ValueGeneratedNever();//.HasMaxLength(26);

		builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
		builder.Property(x => x.Description).IsRequired().HasMaxLength(1000);
	}
}
