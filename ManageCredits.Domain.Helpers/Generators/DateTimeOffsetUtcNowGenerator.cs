using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace ManageCredits.Domain.Helpers.Generators;

public class DateTimeOffsetUtcNowGenerator : ValueGenerator<DateTimeOffset>
{
  public override bool GeneratesTemporaryValues { get; }

  public override DateTimeOffset Next(EntityEntry entry) => entry == null ? throw new ArgumentNullException(nameof(entry)) : DateTimeOffset.UtcNow;

  public override ValueTask<DateTimeOffset> NextAsync(EntityEntry entry, CancellationToken cancellationToken = default) => ValueTask.FromResult(Next(entry));
}
