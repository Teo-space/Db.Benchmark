using Db.Benchmark.Domain.Models.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Db.Benchmark.Infrastructure.EntityFramework.EntityConfiguration.Products;

public class ProductEfConfig : IEntityTypeConfiguration<Product>
{
	public void Configure(EntityTypeBuilder<Product> builder)
	{
		builder.HasKey(x => x.ProductId);

		builder.HasIndex(x => x.ProductTypeId);
		builder.HasIndex(x => x.Name).IsUnique();


		builder.Property(x => x.ProductId).IsRequired().ValueGeneratedNever();//.HasMaxLength(26);
		builder.Property(x => x.ProductTypeId).IsRequired();//.HasMaxLength(26);

		builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
		builder.Property(x => x.Description).IsRequired().HasMaxLength(1000);
		builder.Property(x => x.Price).IsRequired().HasPrecision(15, 6);

	}
}

