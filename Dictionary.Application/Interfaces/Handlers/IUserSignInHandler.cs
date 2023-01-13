using Dictionary.Application.DTOs;

namespace Dictionary.Application.Interfaces.Handlers;

public interface IUserSignInHandler
{
  SignInResponseDTO Handler(SignInRequestDTO request);
}