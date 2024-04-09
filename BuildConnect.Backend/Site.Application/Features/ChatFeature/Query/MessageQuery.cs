using MediatR;
using Site.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.Application.Features.ChatFeature.Query;

public class GetMessagesForChatQuery : IRequest<List<Message>>
{
    public Guid ChatId { get; set; }
}