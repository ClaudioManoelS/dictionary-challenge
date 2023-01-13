using Dictionary.Application.DTOs;
using Dictionary.Application.Interfaces.Handlers;
using Dictionary.Domain.DictionaryContext.Entities;
using Dictionary.Infra.Interfaces;
using Dictionary.Infra.Interfaces.Services;
using Dictionary.Infra.Services;

namespace Dictionary.Application.Handlers;

public class UserSignInHandler : IUserSignInHandler
{
  private IUnitOfWork _uow;
  private ITokenService _token;
  private IHashService _hash;

  public UserSignInHandler(IUnitOfWork uow, ITokenService token, IHashService hash)
  {
    _uow = uow;
    _token = token;
    _hash = hash;
  }

  public SignInResponseDTO Handler(SignInRequestDTO request)
  {
    var user = _uow.Users.GetUserByEmail(request.Email!);
    if (user == null || user?.Name.Trim() == "")
      throw new Exception("Usuário e/ou senha inválidos");

    if (!_hash.Compare(request.Password!, user?.PasswordHash!))
      throw new Exception("Usuário e/ou senha inválidos");

    return GetResponseFromUser(user!);
  }

  private SignInResponseDTO GetResponseFromUser(User user)
  {
    return new SignInResponseDTO()
    {
      Id = user.ShortId,
      Name = user.Name,
      Token = _token.GenerateToken(user)
    };
  }
}