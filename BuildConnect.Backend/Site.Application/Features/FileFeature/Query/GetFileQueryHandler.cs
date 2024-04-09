using MediatR;
using Microsoft.EntityFrameworkCore;
using Site.Application.Common.Interface;
using Site.Domain.Common.Exceptions;
using Site.Domain.Entity;

namespace Site.Application.Features.FileFeature.Query
{
    public class GetFileQueryHandler : IRequestHandler<GetFileQuery, FileModelDTO>
    {
        private readonly IApplicationDbContext _context;

        public GetFileQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<FileModelDTO> Handle(GetFileQuery request, CancellationToken cancellationToken)
        {
            var file = await _context.FileModels.FindAsync(request.Id);
            if (file == null)
            {
                throw new NotFoundException(nameof(FileModel), request.Id);
            }

            var fileDetails = await _context.FileDetails
                                         .Where(fd => fd.FileId == request.Id)
                                         .ToListAsync(cancellationToken);

            return new FileModelDTO
            {
                Id = file.Id,
                File = file.File,
                FileName = file.FileName,
            };
        }
    }
}
