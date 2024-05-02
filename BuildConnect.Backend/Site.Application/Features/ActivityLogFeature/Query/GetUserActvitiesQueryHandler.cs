// using MediatR;
// using Microsoft.EntityFrameworkCore;
// using Site.Application.Common.Interface;
// using Site.Domain.Common;
// using Site.Domain.Entity;

// namespace Site.Application.Features.ActivityLogFeature.Query;

// public class GetUserActivitiesHandler : IRequestHandler<GetUserActivitiesQuery, PaginatedResult<ActivityLog>>
// {
//     private readonly IApplicationDbContext _context;

//     public GetUserActivitiesHandler(IApplicationDbContext context)
//     {
//         _context = context;
//     }

//     public async Task<PaginatedResult<ActivityLog>> Handle(GetUserActivitiesQuery request, CancellationToken cancellationToken)
//     {
//         var queryable = _context.ActivityLogs.Where(a => a.UserId == request.UserId);

//         var totalCount = await queryable.CountAsync(cancellationToken);

//         var items = await queryable
//                              .OrderByDescending(a => a.Timestamp)
//                              .Skip((request.Page - 1) * request.PageSize)
//                              .Take(request.PageSize)
//                              .ToListAsync(cancellationToken);

//         return new PaginatedResult<ActivityLog>
//         {
//             Items = items,
//             TotalCount = totalCount,
//             CurrentPage = request.Page
//         };
//     }
// }

