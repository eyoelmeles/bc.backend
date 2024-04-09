using MediatR;
using Site.Application.Common.Interface;
using Site.Application.Features.MaterialFeatures.Query;
using Site.Application.Features.RoleFeatures.Query;
using Site.Application.Features.UserFeature.Query;
using Site.Domain.Common.Exceptions;
using Site.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.Application.Features.MaterialFeature.Query
{
    public class GetMaterialByIdQueryHandler : IRequestHandler<GetMaterialQuery, MaterialDTO>
    {
        private readonly IApplicationDbContext _context;

        public GetMaterialByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<MaterialDTO> Handle(GetMaterialQuery request, CancellationToken cancellationToken)
        {
            var material = await _context.Materials.FindAsync(request.Id);
            if (material == null)
            {
                throw new NotFoundException(nameof(Material), request.Id);
            }

            return new MaterialDTO
            {
                Id = material.Id,
                Name = material.Name,
                UnitOfMeasure = material.UnitOfMeasure
            };
        }
    }
}
