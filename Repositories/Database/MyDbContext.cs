using Application.Contract.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Database;

public class MyDbContext : DbContext
{ 
    public DbSet<IndicatorDto>? Indicator { get; set; }
    public DbSet<ParameterDto>? Parameter { get; set; }
    public DbSet<SymbolDto>? Symbol { get; set; }
    public DbSet<UserDto>? User { get; set; }

    public MyDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IndicatorDto>()
            .HasMany(e => e.Parameters)
            .WithOne(e => e.Indicator)
            .HasForeignKey(e => e.IndicatorId)
            .HasPrincipalKey(e => e.Id);
        modelBuilder.Entity<SymbolDto>()
            .HasNoKey();

        var decimalProps = modelBuilder.Model
        .GetEntityTypes()
        .SelectMany(t => t.GetProperties())
        .Where(p => (Nullable.GetUnderlyingType(p.ClrType) ?? p.ClrType) == typeof(decimal));

        foreach (var property in decimalProps)
        {
            property.SetPrecision(18);
            property.SetScale(2);
        }
    }
}