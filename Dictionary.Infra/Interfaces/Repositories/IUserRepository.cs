using Dictionary.Domain.DictionaryContext.Entities;

namespace Dictionary.Infra.Interfaces.Repositories;

public interface IUserRepository
{
  void Add(User user);
  User? GetUserByEmail(string email);
}
