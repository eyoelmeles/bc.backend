using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Site.Application.Common.Interface;
using Site.Domain.Entity;

namespace Site.Application.Features.FileFeature.Query;

public class GetFileDetailQueryHandler : IRequestHandler<GetFileDetailQuery, FileDetailDTO>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;


    public GetFileDetailQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<FileDetailDTO> Handle(GetFileDetailQuery request, CancellationToken cancellationToken)
    {
        var fileDetails = await _context.FileDetails.FirstOrDefaultAsync(fd => fd.Id == request.Id);
        return _mapper.Map<FileDetailDTO>(fileDetails);
    }
}