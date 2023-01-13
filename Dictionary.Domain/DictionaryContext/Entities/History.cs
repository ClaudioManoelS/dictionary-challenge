namespace Dictionary.Domain.DictionaryContext.Entities;

public class History : Entity
{
  public string Word { get; set; } = "";
  public DateTime Added { get; set; } = DateTime.Now;
}