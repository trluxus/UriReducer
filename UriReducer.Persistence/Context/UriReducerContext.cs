using Microsoft.EntityFrameworkCore;
using UriReducer.Domain;
using UriReducer.Domain.Entities;

namespace UriReducer.Persistence.Context;

public class UriReducerContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<ReducedUri> ReducedUris { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ReducedUri>(builder =>
        {
            builder
                .Property(shortenedUrl => shortenedUrl.UriCode)
                .HasMaxLength(UriRecucerSettings.Length);

            builder
                .HasIndex(shortenedUrl => shortenedUrl.UriCode)
                .IsUnique();
        });
    }
}
