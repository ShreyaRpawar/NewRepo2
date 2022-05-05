using Employee_Onboarding.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Onboarding.Service
{
    public class LoginService : ILRService<User, int>
    {

        private readonly OnboardingContext ctx;
        private readonly ILRService<User, int> userserv;


        public LoginService(OnboardingContext ctx, ILRService<User, int> userserv)
        {
            this.ctx = ctx;
            this.userserv = userserv;

        }

        async Task<User> ILRService<User, int>.CreateAsync(User entity)
        {
            var res = await ctx.Users.AddAsync(entity);
            await ctx.SaveChangesAsync();
            return res.Entity;
        }

        async Task<IEnumerable<User>> ILRService<User, int>.Get()
        {
            return await ctx.Users.ToListAsync();
        }

        async Task<User> ILRService<User, int>.GetAsync(int id)
        {
            throw new NotImplementedException();
        }
       

        public Task Create(User user)
        {
            var LoginCheck = userserv.Get().Result;
            var res = LoginCheck.Where(x => x.Email == user.Email).FirstOrDefault();
            return null;

        }

        public Task Create()
        {
            throw new NotImplementedException();
        }
    }
}
