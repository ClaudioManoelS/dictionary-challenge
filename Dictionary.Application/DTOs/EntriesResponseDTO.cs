namespace Dictionary.Application.DTOs;

public class EntriesResponseDTO
{
  public EntriesResponseDTO(List<string> entries, long totalRegisters, int page, int limit)
  {
    this.Results = entries;
    this.TotalDocs = totalRegisters;
    this.Page = page;
    this.TotalPages = (int)Math.Ceiling(totalRegisters / (double)limit);
    this.HasNext = Page < TotalPages;
    this.HasPrev = Page > 1;
  }

  public List<string> Results { get; set; }
  public long TotalDocs { get; set; }
  public int Page { get; set; }
  public int TotalPages { get; set; }
  public bool HasNext { get; set; }
  public bool HasPrev { get; set; }
}