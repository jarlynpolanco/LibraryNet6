using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<IList<T>> FindAll();
        Task<T> FindById(int id);
    }
}
