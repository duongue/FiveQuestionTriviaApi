using Microsoft.EntityFrameworkCore;
using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration
{
    class CategoryConfiguration : EntityTypeConfiguration<Category>
    {
        public override void Map(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category");

            builder.Property(t => t.CategoryId)
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.Property(t => t.Description)
                .IsRequired();
        }
    }
}
