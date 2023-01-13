using Dictionary.Application.DTOs;

namespace Dictionary.Application.Interfaces.Handlers;

public interface IUserSignUpHandler
{
  SignUpResponseDTO Handler(SignUpRequestDTO request);
}