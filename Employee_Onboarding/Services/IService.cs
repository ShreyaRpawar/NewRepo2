using Employee_Onboarding.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Employee_Onboarding.Services
{
    public interface IService<TEntity , in TPk> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(TPk id);
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TPk id, TEntity entity);
        Task<TEntity> DeleteAsync(TPk id);
        Task<TEntity> GetAsync(TPk id);
        Task<IEnumerable<TEntity>> GetAsync();
    }
}
