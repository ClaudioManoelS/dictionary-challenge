using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.WebUtilities;

namespace Dictionary.Domain.DictionaryContext.Entities;

public class Entity
{
  [Key]
  public Guid Id { get; set; } = Guid.NewGuid();

  [NotMapped]
  public string ShortId
  {
    get
    {
      return GetShortGuid(Id);
    }
    set
    {
      Id = GetGuidFromShortGuid(value);
    }
  }

  private string GetShortGuid(Guid guid)
  {
    return WebEncoders.Base64UrlEncode(guid.ToByteArray());
  }

  private Guid GetGuidFromShortGuid(string shortGuid)
  {
    return new Guid(WebEncoders.Base64UrlDecode(shortGuid));
  }
}