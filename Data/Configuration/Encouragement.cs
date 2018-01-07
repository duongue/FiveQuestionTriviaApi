using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain;

namespace Data.Configuration
{
    public class EncouragementConfiguration : EntityTypeConfiguration<Encouragement>
    {
        public override void Map(EntityTypeBuilder<Encouragement> builder)
        {
            builder.ToTable("Encouragement");

            builder.Property(t => t.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.Property(t => t.Text)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(t => t.SaysOnCorrectAnswer)
                .IsRequired();
        }
    }
}
