using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Site.Application.Common.Interface;
using Site.Domain.Entity;


namespace Site.Application.Features.FileFeature.Query;

public class GetFileByFolderIdQueryHandler : IRequestHandler<GetFileByFolderIdQuery, IEnumerable<FileModelDTO>>
{
    private readonly IApplicationDbContext _context;
    
    private readonly IFileService _fileService;

    public GetFileByFolderIdQueryHandler(IApplicationDbContext context, IFileService fileService)
    {
        _context = context;
        _fileService = fileService;
    }

    public async Task<IEnumerable<FileModelDTO>> Handle(GetFileByFolderIdQuery request, CancellationToken cancellationToken)
    {
        var files = await _context.FileModels
                                  .Where(f => f.FolderId == request.FolderId)
                                  .ToListAsync(cancellationToken);

        var fileIds = files.Select(f => f.Id).ToList();

        var fileDetails = await _context.FileDetails
                                        .Where(fd => fileIds.Contains(fd.FileId))
                                        .ToListAsync(cancellationToken);

        var fileModelDtos = new List<FileModelDTO>();

        foreach (var file in files)
        {
            var fileModelDto = new FileModelDTO
            {
                Id = file.Id,
                File = _fileService.GetFileUrl(file.File, "SharedFiles"),
                FileName = file.FileName,
            };

            fileModelDtos.Add(fileModelDto);
        }

        return fileModelDtos;

    }
}
