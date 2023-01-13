namespace Dictionary.Domain.DictionaryContext.Entities;

public class Favorite : Entity
{
  public string Word { get; set; } = "";
  public DateTime Added { get; set; } = DateTime.Now;
}