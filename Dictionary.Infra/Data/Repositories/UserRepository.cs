using Dictionary.Domain.DictionaryContext.Entities;
using Dictionary.Infra.Interfaces.Repositories;

namespace Dictionary.Infra.Data.Repositories;

public class UserRepository : IUserRepository
{
  private DictionaryDbContext _context;

  public UserRepository(DictionaryDbContext context)
  {
    _context = context;
  }

  public void Add(User user)
  {
    _context.Users!.Add(user);
  }

  public User? GetUserByEmail(string email)
  {
    return _context.Users!.Where((user) => user.EMail! == email!).FirstOrDefault();
  }
}