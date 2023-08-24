using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EasyCashPresantationLayer.Models;
using EasyCash_EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;

namespace EasyCashPresantationLayer.Controllers
{
    public class ConfirmMailController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ConfirmMailController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index(string mail)
        {
            ViewBag.Mail = mail;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ConfirmMailViewModel confirmMailViewModel)
        {
            var user = await _userManager.FindByEmailAsync(confirmMailViewModel.Mail);

            if(user != null && user.ConfirmedCod == confirmMailViewModel.ConfirmCode)
            {
                return RedirectToAction("Index","MyProfile");
            }

            return View();
        }
    }
}

