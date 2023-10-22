using EasyCash.Business.Abstract;
using EasyCash.DataAccess.Concrete;
using EasyCash.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EasyCash.Presentation.Controllers
{
    public class MyLastProcessController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ICustomerAccountProcessService _customerAccountProcessService;

        public MyLastProcessController(UserManager<AppUser> userManager, ICustomerAccountProcessService customerAccountProcessService)
        {
            _userManager = userManager;
            _customerAccountProcessService = customerAccountProcessService;
        }

        public async Task<IActionResult> Index()
        {
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            EasyCashDbContext context = new EasyCashDbContext();
            int id = await context.CustomerAccounts.Where(c => c.AppUserId == user.Id && c.Currency == "TL").Select(x => x.Id).FirstOrDefaultAsync();
            var datas = _customerAccountProcessService.MyLastProcess(id);
            return View(datas);
        }
    }
}
