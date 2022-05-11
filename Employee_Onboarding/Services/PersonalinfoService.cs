using Employee_Onboarding.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employee_Onboarding.Services
{
    public class perserv : IService<Personalinfo,int>
    {
        private readonly OnboardingContext ctx;

        public perserv(OnboardingContext ctx)
        {
            this.ctx = ctx; 
        }

        async Task<Personalinfo> IService<Personalinfo, int>.CreateAsync(Personalinfo entity)
        {
           var res = ctx.Personalinfos.Add(entity);
          await ctx.SaveChangesAsync();
            return res.Entity;
        }

        async Task<Personalinfo> IService<Personalinfo, int>.DeleteAsync(int id)
        {
            var res =await ctx.Personalinfos.FindAsync(id);
            if (id == null) return null;
            ctx.Personalinfos.Remove(res);
            await ctx.SaveChangesAsync();
            return res;
        }

        async Task<Personalinfo> IService<Personalinfo, int>.GetAsync(int id)
        {
         var res = await ctx.Personalinfos.FindAsync(id);
            return res;
        }

        async Task<IEnumerable<Personalinfo>> IService<Personalinfo, int>.GetAsync()
        {
           var res = await ctx.Personalinfos.ToListAsync();
            return res;
        }

        async Task<Personalinfo> IService<Personalinfo, int>.GetByIdAsync(int id)
        {
           var res = await ctx.Personalinfos.FindAsync(id);
            return res;
        }

        async Task<Personalinfo> IService<Personalinfo, int>.UpdateAsync(int id, Personalinfo entity)
        {
            var res = await ctx.Personalinfos.FindAsync(id);
            if (res != null)
            {
                ctx.Entry(res).CurrentValues.SetValues(entity);
                ctx.SaveChanges();
                return res;
            }
            else
            {
                return null;
            }

        }
    }
}
