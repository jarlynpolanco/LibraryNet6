using Microsoft.EntityFrameworkCore;
using Models.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Author
{
    public class AuthorService : IAuthorRepository
    {
        private readonly LibraryContext _dbContext;

        public AuthorService(LibraryContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<IList<Models.Entities.Author>> FindAll()
        {
            var authors = await _dbContext.Authors.Include(x => x.Books).ToListAsync();
            return authors;
        }

        public async Task<Models.Entities.Author> FindById(int id)
        {
            var author = await _dbContext.Authors.Include(x => x.Books)
                .FirstOrDefaultAsync(x => x.ID == id);
            return author;
        }
    }
}
