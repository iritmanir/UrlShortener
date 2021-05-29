using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UrlShortener.DomainModels.UrlAgg.Entities;

namespace UrlShortener.Infrastructure.DataAccess.UrlAgg
{
    public class UrlConfig : IEntityTypeConfiguration<Url>
    {
        public void Configure(EntityTypeBuilder<Url> builder)
        {
            builder.HasKey(s => s.Id);

            builder
                .Property(b => b.ShortKey)
                .IsRequired();

            builder
                .Property(b => b.LongUrl)
                .IsRequired();

            builder.HasIndex(url => url.LongUrl).IsUnique();
            builder.HasIndex(url => url.ShortKey).IsUnique();
        }
    }
}