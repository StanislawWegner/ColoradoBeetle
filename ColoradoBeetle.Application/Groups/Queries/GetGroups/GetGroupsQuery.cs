using ColoradoBeetle.Domain.Entities;
using MediatR;

namespace ColoradoBeetle.Application.Groups.Queries.GetGroups; 
public class GetGroupsQuery : IRequest<IEnumerable<GroupDto>>{


}
