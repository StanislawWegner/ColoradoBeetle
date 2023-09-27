using MediatR;

namespace ColoradoBeetle.Application.GroupShopLists.Command.DeleteGroupShopList; 
public class DeleteGroupShopListCommand : IRequest{
    public int Id { get; set; }
    public string UserId { get; set; }
}
