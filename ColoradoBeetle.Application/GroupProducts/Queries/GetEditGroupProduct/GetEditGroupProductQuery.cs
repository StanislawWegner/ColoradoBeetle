using ColoradoBeetle.Application.GroupProducts.Commands.EditGroupProduct;
using MediatR;

namespace ColoradoBeetle.Application.GroupProducts.Queries.GetEditGroupProduct; 
public class GetEditGroupProductQuery : IRequest<EditGroupProductCommand>{
    public int Id { get; set; }
    public int GroupId { get; set; }
    public string UserId { get; set; }
}
