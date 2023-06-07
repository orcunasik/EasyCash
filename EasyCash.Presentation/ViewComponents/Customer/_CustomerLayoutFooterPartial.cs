using Microsoft.AspNetCore.Mvc;

namespace EasyCash.Presentation.ViewComponents.Customer
{
    public class _CustomerLayoutFooterPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
