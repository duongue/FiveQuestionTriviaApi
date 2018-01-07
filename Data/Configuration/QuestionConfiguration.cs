using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Data.Configuration
{
    public class QuestionConfiguration : EntityTypeConfiguration<Question>
    {
        public override void Map(EntityTypeBuilder<Question> builder)
        {
            builder.ToTable("Question");

            builder.Property(t => t.QuestionId)
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.Property(t => t.Level)
                .IsRequired();
            builder.Property(t => t.Category)
                .IsRequired();
            builder.Property(t => t.Text)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(t => t.Answer)
                .IsRequired()
                .HasMaxLength(20);
            builder.Property(t => t.AdditionalInfo)
                .HasMaxLength(100);
            builder.Property(t => t.Choices)
                .HasMaxLength(100);
        }
    }
}
