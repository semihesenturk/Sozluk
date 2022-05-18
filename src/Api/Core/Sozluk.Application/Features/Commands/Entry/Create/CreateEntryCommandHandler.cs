using AutoMapper;
using MediatR;
using Sozluk.Application.Interfaces.Repositories;
using Sozluk.Common.Models.RequestModels;

namespace Sozluk.Application.Features.Commands.Entry.Create;
public class CreateEntryCommandHandler : IRequestHandler<CreateEntryCommand, Guid>
{
    #region Variables
    private readonly IEntryRepository _entryRepository;
    private readonly IMapper _mapper;
    #endregion

    #region Constructor
    public CreateEntryCommandHandler(IEntryRepository entryRepository, IMapper mapper)
    {
        _entryRepository = entryRepository;
        _mapper = mapper;
    }
    #endregion

    public async Task<Guid> Handle(CreateEntryCommand request, CancellationToken cancellationToken)
    {
        var dbEntry = _mapper.Map<Api.Domain.Models.Entry>(request);

        await _entryRepository.AddAsync(dbEntry);

        return dbEntry.Id;
    }
}
