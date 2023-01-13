using Dictionary.Domain.DictionaryContext.Entities;

namespace Dictionary.Infra.Interfaces.Services;

public interface ITokenService
{
  string GenerateToken(User user);
  byte[] GetKey();
}
