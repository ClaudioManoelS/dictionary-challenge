namespace Dictionary.Application.DTOs;

public class EntriesRequestDTO
{
  public string Search { get; set; } = "";
  public int Limit { get; set; } = 5;
  public int Page { get; set; } = 1;

  public EntriesRequestDTO() { }
  public EntriesRequestDTO(string search, int limit, int page)
  {
    Search = search;
    Limit = limit;
    Page = page;
  }
}