using Dictionary.Domain.DictionaryContext.Entities;

namespace Dictionary.Infra.Interfaces.Repositories;

public interface IEntryRepository
{
  (List<string> entries, long totalRegisters) GetPagedList(string search, int limit, int page);
}
