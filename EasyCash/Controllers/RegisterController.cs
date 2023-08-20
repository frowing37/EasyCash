using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using EasyCash_EntityLayer.Concrete;
using EasyCash_DtoLayer.Dtos.AppUserDtos;

namespace EasyCashPresantationLayer.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Register(AppUserRegisterDto appUserRegisterDto)
        {
            if(ModelState.IsValid)
            {
                AppUser appUser = new AppUser()
                {
                    UserName = appUserRegisterDto.Username,
                    Name = appUserRegisterDto.Name,
                    Surname = appUserRegisterDto.Surname,
                    Email = appUserRegisterDto.Email,
                    City = "Los Angaras",
                    District = "defaultDistrict",
                    ImageURL = "defaultImageurl"
                };
                var result = await _userManager.CreateAsync(appUser, appUserRegisterDto.Password);

                if(result.Succeeded)
                {
                    return RedirectToAction("Index", "ConfirmMail");
                }
                else
                {
                    foreach(var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return RedirectToAction("Login","Home",ModelState);
        }
    }
}

