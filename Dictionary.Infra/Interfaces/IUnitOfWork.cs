using Dictionary.Infra.Interfaces.Repositories;

namespace Dictionary.Infra.Interfaces;

public interface IUnitOfWork
{
  IUserRepository Users { get; }
  IEntryRepository Entries { get; }

  void Commit();
  void Dispose();
}
