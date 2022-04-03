using Models.Entities;
using Services.Contracts;
using System.Threading.Tasks;

namespace Services.Book
{
    public interface IBookRepository : IRepositoryBase<Models.Entities.Book>
    {
        public Task<Page> PageByBookAndPageNo(int bookId, int pageNumber);
        public Task<string> PageByBookAndPageNoHtml(int bookId, int pageNumber, string formatType);
    }
}
