using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Site.Application.Common.Interface;
using Site.Domain.Entity;

namespace Site.Application.Features.FileFeature.Query;

public class GetFileDetailByFileIdQueryHandler : IRequestHandler<GetFileDetailByFileIdQuery, IEnumerable<FileDetailDTO>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    

    public GetFileDetailByFileIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<FileDetailDTO>> Handle(GetFileDetailByFileIdQuery request, CancellationToken cancellationToken)
    {
        var fileDetails = await _context.FileDetails.Where(fd => fd.FileId == request.FileId).ToListAsync(cancellationToken);
        return _mapper.Map<IEnumerable<FileDetailDTO>>(fileDetails);
    }
}

