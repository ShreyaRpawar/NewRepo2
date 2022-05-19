using Employee_Onboarding.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employee_Onboarding.Services
{
    public class ProfessionalinfoService : IService<Professionalinfo, int>
    {
        private readonly OnboardingContext ctx;

        public ProfessionalinfoService(OnboardingContext ctx)
        {
            this.ctx = ctx;
        }

        async Task<Professionalinfo> IService<Professionalinfo, int>.CreateAsync(Professionalinfo entity)
        {
            var res = ctx.Professionalinfos.Add(entity);
            await ctx.SaveChangesAsync();
            return res.Entity;
        }

        async Task<Professionalinfo> IService<Professionalinfo, int>.DeleteAsync(int id)
        {
            var res = await ctx.Professionalinfos.FindAsync(id);
            if (id == null) return null;
            ctx.Professionalinfos.Remove(res);
            await ctx.SaveChangesAsync();
            return res;

        }


        async Task<Professionalinfo> IService<Professionalinfo, int>.GetAsync(int id)
        {
            var res = await ctx.Professionalinfos.FindAsync(id);
            return res;
        }

        async Task<IEnumerable<Professionalinfo>> IService<Professionalinfo, int>.GetAsync()
        {
            var res = await ctx.Professionalinfos.ToListAsync();
            return res;
        }

        async Task<Professionalinfo> IService<Professionalinfo, int>.GetByIdAsync(int id)
        {
            var res = await ctx.Professionalinfos.FindAsync(id);
            return res;
        }

        async Task<Professionalinfo> IService<Professionalinfo, int>.UpdateAsync(int id, Professionalinfo entity)
        {
            var res = await ctx.Professionalinfos.FindAsync(id);
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
