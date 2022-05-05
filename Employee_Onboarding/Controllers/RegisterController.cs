using Employee_Onboarding.Models;
using Employee_Onboarding.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Employee_Onboarding.Controllers
{
    public class RegisterController : Controller
    {
        private readonly ILRService<Register, int> regserv;

        public RegisterController(ILRService<Register, int> regserv)
        {
            this.regserv = regserv;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            var res = new User();
            return View(res);
        }
     

        public async Task<string> EncryptAsync(string message)
        {
            var textToEncrypt = message;
            string toReturn = string.Empty;
            string publicKey = "12345678";
            string secretKey = "87654321";
            byte[] secretkeyByte = { };
            secretkeyByte = System.Text.Encoding.UTF8.GetBytes(secretKey);
            byte[] publickeybyte = { };
            publickeybyte = System.Text.Encoding.UTF8.GetBytes(publicKey);
            MemoryStream ms = null;
            CryptoStream cs = null;
            byte[] inputbyteArray = System.Text.Encoding.UTF8.GetBytes(textToEncrypt);
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                ms = new MemoryStream();
                cs = new CryptoStream(ms, des.CreateEncryptor(publickeybyte, secretkeyByte), CryptoStreamMode.Write);
                cs.Write(inputbyteArray, 0, inputbyteArray.Length);
                cs.FlushFinalBlock();
                toReturn = Convert.ToBase64String(ms.ToArray());
            }
            return toReturn;

        }

    }
}

