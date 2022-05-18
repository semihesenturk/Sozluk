using AutoMapper;
using MediatR;
using Sozluk.Application.Interfaces.Repositories;
using Sozluk.Common.Models.RequestModels;

namespace Sozluk.Application.Features.Commands.EntryComment.Create;
public class CreateEntryCommentCommandHandler : IRequestHandler<CreateEntryCommentCommand, Guid>
{
    #region Variables
    private readonly IEntryCommentRepository _entryCommentRepository;
    private readonly IMapper _mapper;
    #endregion

    #region Constructor
    public CreateEntryCommentCommandHandler(IEntryCommentRepository entryCommentRepository, IMapper mapper)
    {
        _entryCommentRepository = entryCommentRepository;
        _mapper = mapper;
    }
    #endregion


    public async Task<Guid> Handle(CreateEntryCommentCommand request, CancellationToken cancellationToken)
    {
        var dbEntryComment = _mapper.Map<Api.Domain.Models.EntryComment>(request);

        await _entryCommentRepository.AddAsync(dbEntryComment);

        return dbEntryComment.Id;
    }
}
