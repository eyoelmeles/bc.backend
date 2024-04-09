using MediatR;
using Site.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.Application.Features.ChatFeature.Query;

public class GetMessageByIdQuery
{
    public Guid MessageId { get; set; }
}


public class GetChatsForUserQuery : IRequest<List<ChatDto>>
{
    public Guid UserId { get; set; }
    public Guid SiteId { get; set; }
}