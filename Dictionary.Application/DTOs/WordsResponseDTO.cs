namespace Dictionary.Application.DTOs;

public class WordsResponseDTO
{
  public List<WordDTO> Results { get; set; } = new List<WordDTO>();
  public long TotalDocs { get; set; }
  public int Page { get; set; }
  public int TotalPages { get; set; }
  public bool HasNext { get; set; }
  public bool HasPrev { get; set; }
}