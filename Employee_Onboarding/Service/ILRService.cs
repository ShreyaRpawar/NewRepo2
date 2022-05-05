using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employee_Onboarding.Service
{
   
        public interface ILRService<TEntity, in TPk> where TEntity : class
        {
            Task<IEnumerable<TEntity>> Get();
            Task<TEntity> GetAsync(TPk id);
            Task<TEntity> CreateAsync(TEntity entity);
             Task Create();
        }
    
}
