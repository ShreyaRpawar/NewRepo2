using Employee_Onboarding.Models;
using Employee_Onboarding.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Onboarding.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILRService<User, int> userserv;

        public LoginController(ILRService<User, int> userserv)
        {
            this.userserv = userserv;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult userlogin()
        {
            User user = new User();
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> User(User user)
        {
            var LoginCheck = userserv.Get().Result;
            var res = LoginCheck.Where(x => x.Email == user.Email).FirstOrDefault();
            var passdecrypt = DecryptAsync(user.UserPassword);
            return RedirectToAction("Index", "Login");
        }
        public async Task<string> DecryptAsync(string text)
        {
            var textToDecrypt = text;
            string toReturn = "";
            string publickey = "12345678";
            string secretkey = "87654321";
            byte[] privatekeyByte = { };
            privatekeyByte = System.Text.Encoding.UTF8.GetBytes(secretkey);
            byte[] publickeybyte = { };
            publickeybyte = System.Text.Encoding.UTF8.GetBytes(publickey);
            MemoryStream ms = null;
            CryptoStream cs = null;
            byte[] inputbyteArray = new byte[textToDecrypt.Replace(" ", "+").Length];
            inputbyteArray = Convert.FromBase64String(textToDecrypt.Replace(" ", "+"));
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                ms = new MemoryStream();
                cs = new CryptoStream(ms, des.CreateDecryptor(publickeybyte, privatekeyByte), CryptoStreamMode.Write);
                cs.Write(inputbyteArray, 0, inputbyteArray.Length);
                cs.FlushFinalBlock();
                Encoding encoding = Encoding.UTF8;
                toReturn = encoding.GetString(ms.ToArray());
            }
            return toReturn;
        }

    }

}


