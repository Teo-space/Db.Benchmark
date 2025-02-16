using Db.Benchmark.Domain.Models.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Db.Benchmark.Infrastructure.EntityFramework.EntityConfiguration.Products;

public class MakerEfConfig : IEntityTypeConfiguration<Maker>
{
	public void Configure(EntityTypeBuilder<Maker> builder)
	{
		builder.HasKey(x => x.MakerId);

		builder.Property(x => x.MakerId).IsRequired().ValueGeneratedNever();//.HasMaxLength(26);

		builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
	}
}
