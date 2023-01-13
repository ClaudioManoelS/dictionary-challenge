using Dictionary.Infra.Data.Repositories;
using Dictionary.Infra.Interfaces;
using Dictionary.Infra.Interfaces.Repositories;

namespace Dictionary.Infra.Data;

public class UnitOfWork : IUnitOfWork
{
  private DictionaryDbContext _context;
  private IUserRepository? _users;
  private IEntryRepository? _entries;

  public UnitOfWork(DictionaryDbContext context)
  {
    _context = context;
  }

  public IUserRepository Users
  {
    get
    {
      if (_users == null) _users = new UserRepository(_context);
      return _users;
    }
  }

  public IEntryRepository Entries
  {
    get
    {
      if (_entries == null) _entries = new EntryRepository(_context);
      return _entries;
    }
  }

  public void Commit()
  {
    _context.SaveChanges();
  }

  public void Dispose()
  {
  }
}