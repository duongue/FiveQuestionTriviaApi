using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data
{
    public abstract class EntityTypeConfiguration<T> where T : class
    {
        public abstract void Map(EntityTypeBuilder<T> builder);
    }

    public static class ModelBuilderExtensions
    {
        public static void AddConfiguration<T>(this ModelBuilder modelBuilder, EntityTypeConfiguration<T> configuration)
            where T : class
        {
            configuration.Map(modelBuilder.Entity<T>());
        }
    }
}
