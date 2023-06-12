﻿using EasyCash.Business.Abstract;
using EasyCash.DataAccess.Concrete;
using EasyCash.Dtos.Dtos.CustomerAccountProcessDtos;
using EasyCash.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EasyCash.Presentation.Controllers
{
    public class SendMoneyController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ICustomerAccountProcessService _customerAccountProcessService;

        public SendMoneyController(UserManager<AppUser> userManager, ICustomerAccountProcessService customerAccountProcessService)
        {
            _userManager = userManager;
            _customerAccountProcessService = customerAccountProcessService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(SendMoneyForCustomerAccountProcessDto sendMoneyForCustomerAccountProcessDto)
        {
            EasyCashDbContext context = new EasyCashDbContext();

            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            int receiverAccountNumberId = await context.CustomerAccounts.Where(ca => ca.AccountNumber == sendMoneyForCustomerAccountProcessDto.ReceiverAccountNumber).Select(c => c.Id).FirstOrDefaultAsync();
            int senderAccountNumberId = await context.CustomerAccounts.Where(ca => ca.AccountNumber == sendMoneyForCustomerAccountProcessDto.SenderAccountNumber).Select(c => c.Id).FirstOrDefaultAsync();

            //sendMoneyForCustomerAccountProcessDto.SenderId = user.Id;
            //sendMoneyForCustomerAccountProcessDto.ProcessDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            //sendMoneyForCustomerAccountProcessDto.ProcessType = "Havale";
            //sendMoneyForCustomerAccountProcessDto.ReceiverId = receiverAccountNumberId;

            CustomerAccountProcess customerAccountProcess = new(); 
            customerAccountProcess.ProcessDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            customerAccountProcess.SenderId = senderAccountNumberId;
            customerAccountProcess.ProcessType = "Havale";
            customerAccountProcess.ReceiverId = receiverAccountNumberId;
            customerAccountProcess.Amount = sendMoneyForCustomerAccountProcessDto.Amount;
            _customerAccountProcessService.Insert(customerAccountProcess);

            return RedirectToAction("Index", "Test");
        }
    }
}
