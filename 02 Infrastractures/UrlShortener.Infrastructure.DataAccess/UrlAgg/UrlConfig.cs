using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UrlShortener.DomainModels.UrlAgg.Entities;
using UrlShortener.DomainModels.UrlAgg.ValueObjects;

namespace UrlShortener.Infrastructure.DataAccess.UrlAgg
{
    public class UrlConfig : IEntityTypeConfiguration<Url>
    {
        public void Configure(EntityTypeBuilder<Url> builder)
        {
            builder.HasKey(s => s.Id);

            builder
                .Property(b => b.ShortKey)
                .HasConversion(s => s, s => new UrlShortKey(s))
                .IsRequired();

            builder
                .Property(b => b.LongUrl)
                .HasConversion(s => s, s => new UrlLongUrl(s))
                .IsRequired();

            builder.HasIndex(url => url.LongUrl).IsUnique();
            builder.HasIndex(url => url.ShortKey).IsUnique();
        }
    }
}