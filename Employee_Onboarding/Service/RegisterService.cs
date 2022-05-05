using Employee_Onboarding.Models;
using Employee_Onboarding.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employee_Onboarding.Service
{
    public class RegisterService : ILRService<Register, int>
    {

        private readonly OnboardingContext ctx;

        public RegisterService(OnboardingContext ctx)
        {
            this.ctx = ctx;
        }

        public Task Create()
        {
            throw new System.NotImplementedException();
        }

        async Task<Register> ILRService<Register, int>.CreateAsync(Register entity)
        {
            var res = await ctx.Registers.AddAsync(entity);
            await ctx.SaveChangesAsync();
            return res.Entity;
        }

        Task<IEnumerable<Register>> ILRService<Register, int>.Get()
        {
            throw new System.NotImplementedException();
        }

        Task<Register> ILRService<Register, int>.GetAsync(int id)
        {
            throw new System.NotImplementedException();
        }

       

    }
}