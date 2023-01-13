using Dictionary.Domain.DictionaryContext.Entities;
using Dictionary.Infra.Interfaces.Repositories;

namespace Dictionary.Infra.Data.Repositories;

public class EntryRepository : IEntryRepository
{
  private DictionaryDbContext _context;

  public EntryRepository(DictionaryDbContext context)
  {
    _context = context;
  }

  public (List<string> entries, long totalRegisters) GetPagedList(string search, int limit, int page)
  {
    List<string> unpagedEntries = _context.Entries!.Select(x => x.Word).Where(word => word.StartsWith(search)).ToList();
    return (unpagedEntries.Skip(GetSkip(limit, page)).Take(limit).ToList(), unpagedEntries.Count());
  }

  private int GetSkip(int limit, int page)
  {
    return (page - 1) * limit;
  }
}