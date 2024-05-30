namespace ManageCredits.Contracts.DTO.SeedData;

public interface ISeedDataCollection<K, out T> where T : class
{
  K this[int index] { get; }
  int Length { get; }
  IEnumerable<T> GetAll();
}
