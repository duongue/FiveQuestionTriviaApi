using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Data.Configuration
{
    public class LevelConfiguration : EntityTypeConfiguration<Level>
    {
        public override void Map(EntityTypeBuilder<Level> builder)
        {
            builder.ToTable("Level");

            builder.Property(t => t.LevelId)
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.Property(t => t.Description)
                .IsRequired();
        }
    }
}
