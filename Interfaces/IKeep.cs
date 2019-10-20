namespace Keepr.Interfaces
{
  public interface IKeep
  {
    int Id { get; set; }
    string Name { get; set; }
    string Description { get; set; }
    string Img { get; set; }
    bool IsPrivate { get; set; }
    string UserId { get; set; }
  }
}