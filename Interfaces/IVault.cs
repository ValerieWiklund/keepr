namespace keepr.Interfaces
{
  public interface IVault
  {
    int Id { get; set; }
    string Name { get; set; }
    string Description { get; set; }
    string UserId { get; set; }
  }
}