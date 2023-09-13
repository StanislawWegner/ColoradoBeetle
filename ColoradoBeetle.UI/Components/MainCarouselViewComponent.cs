using Microsoft.AspNetCore.Mvc;

namespace ColoradoBeetle.UI.Components; 
public class MainCarouselViewComponent : ViewComponent{
    public async Task<IViewComponentResult> InvokeAsync(string testComponents) {
        //logic
        return View();
    }
}
