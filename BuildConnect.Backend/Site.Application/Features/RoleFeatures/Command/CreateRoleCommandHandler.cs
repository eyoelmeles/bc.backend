// using MediatR;
// using Site.Application.Common.Interface;
// using Site.Domain.Entity;


// namespace Site.Application.Features.RoleFeatures.Command;

// public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, Guid>
// {
//     private readonly IApplicationDbContext _context;

//     public CreateRoleCommandHandler(IApplicationDbContext context)
//     {
//         _context = context;
//     }

//     public async Task<Guid> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
//     {
//         var role = new Role
//         {
//             Name = request.Name
//         };

//         _context.Roles.Add(role);

//         await _context.SaveChangesAsync(cancellationToken);

//         return role.Id;
//     }
// }
