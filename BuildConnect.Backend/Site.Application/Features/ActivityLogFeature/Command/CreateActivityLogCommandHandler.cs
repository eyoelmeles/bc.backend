// using MediatR;
// using Site.Application.Common.Interface;
// using Site.Domain.Entity;

// namespace Site.Application.Features.ActivityLogFeature.Command;

// public class CreateActivityLogCommandHandler : IRequestHandler<CreateActivityLogCommand, Guid>
// {
//     private readonly IApplicationDbContext _context;

//     public CreateActivityLogCommandHandler(IApplicationDbContext context)
//     {
//         _context = context;
//     }

//     public async Task<Guid> Handle(CreateActivityLogCommand request, CancellationToken cancellationToken)
//     {
//         var log = new ActivityLog
//         {
//             UserId = request.UserId,
//             Timestamp = DateTime.UtcNow,
//             ActionType = request.ActionType,
//             Entity = request.Entity,
//             Description = request.Description
//         };

//         _context.ActivityLogs.Add(log);
//         await _context.SaveChangesAsync(cancellationToken);

//         return log.Id;
//     }
// }
