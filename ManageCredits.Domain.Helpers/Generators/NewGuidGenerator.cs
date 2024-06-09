using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace ManageCredits.Domain.Helpers.Generators;

public class NewGuidGenerator : ValueGenerator<Guid>
{
  public override bool GeneratesTemporaryValues { get; }

  public override Guid Next(EntityEntry entry) => entry == null ? throw new ArgumentNullException(nameof(entry)) : Guid.NewGuid();

  public override ValueTask<Guid> NextAsync(EntityEntry entry, CancellationToken cancellationToken = default) => ValueTask.FromResult(Next(entry));
}
