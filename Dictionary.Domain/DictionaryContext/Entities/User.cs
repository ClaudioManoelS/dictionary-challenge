namespace Dictionary.Domain.DictionaryContext.Entities;

public class User : Entity
{
  public string Name { get; set; } = "";
  public string EMail { get; set; } = "";
  public string PasswordHash { get; set; } = "";
}