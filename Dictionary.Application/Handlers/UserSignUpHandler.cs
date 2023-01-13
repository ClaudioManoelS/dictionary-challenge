using Dictionary.Application.DTOs;
using Dictionary.Application.Interfaces.Handlers;
using Dictionary.Domain.DictionaryContext.Entities;
using Dictionary.Infra.Interfaces;
using Dictionary.Infra.Interfaces.Services;

namespace Dictionary.Application.Handlers;

public class UserSignUpHandler : IUserSignUpHandler
{
  private IUnitOfWork _uow;
  private ITokenService _token;
  private IHashService _hash;

  public UserSignUpHandler(IUnitOfWork uow, ITokenService token, IHashService hash)
  {
    _uow = uow;
    _token = token;
    _hash = hash;
  }


  public SignUpResponseDTO Handler(SignUpRequestDTO request)
  {
    var existed_user = _uow.Users.GetUserByEmail(request.Email!);
    if (existed_user != null && existed_user?.Name.Trim() != "")
      throw new Exception("Já existe um usuário com este e-mail");

    var user = GetUserFromRequest(request);
    _uow.Users.Add(user);
    _uow.Commit();
    return GetResponseFromUser(user);
  }

  private User GetUserFromRequest(SignUpRequestDTO request)
  {
    return new User()
    {
      EMail = request.Email!,
      Name = request.Name!,
      PasswordHash = _hash.Generate(request.Password!)
    };
  }

  private SignUpResponseDTO GetResponseFromUser(User user)
  {
    return new SignUpResponseDTO()
    {
      Id = user.ShortId,
      Name = user.Name,
      Token = _token.GenerateToken(user)
    };
  }
}