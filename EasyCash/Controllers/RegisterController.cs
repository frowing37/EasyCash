using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using EasyCash_EntityLayer.Concrete;
using EasyCash_DtoLayer.Dtos.AppUserDtos;
using MimeKit;
using MailKit.Net.Smtp;
//using System.Net.Mail;

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
            //Gerekli validasyonlar sağlanıyorsa
            if(ModelState.IsValid)
            {
                //Doğrulama kodunun rastgele üretilmesi
                Random rnd = new Random();
                int code = rnd.Next(100000, 1000000);

                AppUser appUser = new AppUser()
                {
                    UserName = appUserRegisterDto.Username,
                    Name = appUserRegisterDto.Name,
                    Surname = appUserRegisterDto.Surname,
                    Email = appUserRegisterDto.Email,
                    City = "Los Angaras",
                    District = "defaultDistrict",
                    ImageURL = "defaultImageurl",
                    ConfirmedCod = code
                };

                var result = await _userManager.CreateAsync(appUser, appUserRegisterDto.Password);

                if(result.Succeeded)
                {
                    //Kullanılıcak epostra için hazırlıklar
                    MimeMessage mimeMessage = new MimeMessage();
                    MailboxAddress mailboxAddressFrom = new MailboxAddress("Easy Cash Admin", "emrecan8mece@gmail.com");
                    MailboxAddress mailboxAddressTo = new MailboxAddress("User", appUser.Email);

                    mimeMessage.From.Add(mailboxAddressFrom);
                    mimeMessage.To.Add(mailboxAddressTo);

                    var bodyBuilder = new BodyBuilder();
                    bodyBuilder.TextBody = "Kayıt işlemini tamamlamak için gerekli kod : " + code;

                    mimeMessage.Body = bodyBuilder.ToMessageBody();
                    mimeMessage.Subject = "Easy Cash Onay Kodu";

                    TempData["Mail"] = appUserRegisterDto.Email;

                    SmtpClient client = new SmtpClient();
                    //Türkiye için geçerli TSL port numarası : 587, SSL port numarası : 465
                    //Bu methodun 3.parametresi için 0 = TSL / 1 = SSL
                    client.Connect("smtp.gmail.com", 587,false);
                    //Google hesabının uygulama tarafından kullanılabilmesi için gerekli key
                    client.Authenticate("emrecan8mece@gmail.com", "ywjrdiljpqwqrrhh");
                    client.Send(mimeMessage);
                    //İşi bittikten sonra çıkış
                    client.Disconnect(true);

                    return RedirectToAction("Index", "ConfirmMail", new {mail=appUser.Email});
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

