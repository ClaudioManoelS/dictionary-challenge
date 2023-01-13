using Dictionary.Application.DTOs;

namespace Dictionary.Application.Interfaces.Handlers;

public interface IEntriesGetListHandler
{
  EntriesResponseDTO Handler(EntriesRequestDTO request);
}