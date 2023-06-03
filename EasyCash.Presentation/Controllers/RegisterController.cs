using EasyCash.Dtos.Dtos.AppUserDtos;
using EasyCash.Entities.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace EasyCash.Presentation.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(AppUserRegisterDto appUserDto)
        {
            if (ModelState.IsValid)
            {
                Random rnd = new();
                AppUser appUser = new()
                {
                    UserName = appUserDto.UserName,
                    Name = appUserDto.Name,
                    Surname = appUserDto.SurName,
                    Email = appUserDto.Email,
                    ConfirmCode = rnd.Next(100000,1000000)
                };
                IdentityResult result = await userManager.CreateAsync(appUser, appUserDto.Password);
                if (result.Succeeded)
                {
                    MimeMessage mimeMessage = new();
                    MailboxAddress mailboxAddressFrom = new("Easy Cash Admin", "asikorcun@gmail.com");
                    MailboxAddress mailboxAddressTo = new("User", appUser.Email);

                    mimeMessage.From.Add(mailboxAddressFrom);
                    mimeMessage.To.Add(mailboxAddressTo);

                    BodyBuilder bodyBuilder = new();
                    bodyBuilder.TextBody = $"Kayıt İşlemini Gerçekleştirmek için ONAY KODUNUZ:{appUser.ConfirmCode}";
                    mimeMessage.Body = bodyBuilder.ToMessageBody();

                    mimeMessage.Subject = "Easy Cash Email Onay Kodu";

                    SmtpClient client = new();
                    client.Connect("smtp.gmail.com", 587, false);
                    client.Authenticate("asikorcun@gmail.com", "glnlnzxzwepicdge");
                    client.Send(mimeMessage);
                    client.Disconnect(true);

                    TempData["Email"] = appUserDto.Email;
					return RedirectToAction("Index", "ConfirmMail");
				}
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View();
        }
    }
}
