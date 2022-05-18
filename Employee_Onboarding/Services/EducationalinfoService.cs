using Employee_Onboarding.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employee_Onboarding.Services
{
    public class EducationalinfoService : IService<Educationinfo, int>
    {
        private readonly OnboardingContext ctx;

        public EducationalinfoService(OnboardingContext ctx)
        {
            this.ctx = ctx; 
        }

        async Task<Educationinfo> IService<Educationinfo, int>.CreateAsync(Educationinfo entity)
        {
            var res =  ctx.Educationinfos.Add(entity);
            await ctx.SaveChangesAsync();
            return res.Entity;

        }

        async Task<Educationinfo> IService<Educationinfo, int>.DeleteAsync(int id)
        {
            var res = await ctx.Educationinfos.FindAsync(id);
             if (res == null) return null;
            ctx.Educationinfos.Remove(res);
            await ctx.SaveChangesAsync();
            return res;
        }


        async Task<Educationinfo> IService<Educationinfo, int>.GetAsync(int id)
        {
            var res = await ctx.Educationinfos.FindAsync(id);
            return res;
        }

        async Task<IEnumerable<Educationinfo>> IService<Educationinfo, int>.GetAsync()
        {
            var res = await ctx.Educationinfos.ToListAsync();
            return res;
        }

        async Task<Educationinfo> IService<Educationinfo, int>.GetByIdAsync(int id)
        {

            var res = await ctx.Educationinfos.FindAsync(id);
            return res;
        }

        async Task<Educationinfo>IService<Educationinfo, int>.UpdateAsync(int id, Educationinfo entity)
        {
            var res= await ctx.Educationinfos.FindAsync(id);
            if  (id != null)
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