using Microsoft.AspNetCore.Mvc;

namespace EasyCash.Presentation.ViewComponents.Customer
{
    public class _CustomerLayoutJsPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
