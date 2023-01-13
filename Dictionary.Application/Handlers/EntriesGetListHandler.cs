using Dictionary.Application.DTOs;
using Dictionary.Application.Interfaces.Handlers;
using Dictionary.Infra.Interfaces;

namespace Dictionary.Application.Handlers;

public class EntriesGetListHandler : IEntriesGetListHandler
{
  private IUnitOfWork _uow;

  public EntriesGetListHandler(IUnitOfWork uow)
  {
    _uow = uow;
  }


  public EntriesResponseDTO Handler(EntriesRequestDTO request)
  {
    List<string> entries;
    long totalRegisters;

    (entries, totalRegisters) = _uow.Entries.GetPagedList(request.Search, request.Limit, request.Page);

    return new EntriesResponseDTO(entries, totalRegisters, request.Page, request.Limit);
  }
}