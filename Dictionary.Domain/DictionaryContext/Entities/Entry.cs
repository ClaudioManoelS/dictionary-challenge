
using System.ComponentModel.DataAnnotations;

namespace Dictionary.Domain.DictionaryContext.Entities;

public class Entry
{
  [MaxLength(200)]
  [Key]
  public string Word { get; set; } = "";
}