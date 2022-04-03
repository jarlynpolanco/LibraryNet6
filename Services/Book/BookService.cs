using Microsoft.EntityFrameworkCore;
using Models.Context;
using Services.Infraestructure.Exceptions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Book
{
    public class BookService : IBookRepository
    {
        private readonly LibraryContext _dbContext;
        private const string HTML_TEMPLATE = "<div><strong><center>Pagina #{0}</center></strong><br><br><strong><center><p>{1}</p></center></strong></div>";

        public BookService(LibraryContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<Models.Entities.Book>> FindAll()
        {
            var books = await _dbContext.Books.Include(x => x.Author).Include(x => x.Pages).ToListAsync();

            if(books.Count == 0)
                throw new NotFoundException("Ningun libro fue encontrado");

            return books;
        }

        public async Task<Models.Entities.Book> FindById(int id)
        {
            var book = await _dbContext.Books.Include(x => x.Author)
                .Include(x => x.Pages)
                .FirstOrDefaultAsync(x => x.ID == id);

            if (book == null)
                throw new NotFoundException("El libro con el id enviado no fue encontrado");

            return book;
        }

        public async Task<Models.Entities.Page> PageByBookAndPageNo(int bookId, int pageNumber)
        {
            var page = await _dbContext.Pages.FirstOrDefaultAsync(x => x.BookID == bookId && x.PageNumber == pageNumber);

            if (page == null)
                throw new NotFoundException("La pagina con el id de libro enviado no fue encontrada");

            return page;
        }

        public async Task<string> PageByBookAndPageNoHtml(int bookId, int pageNumber, string formatType)
        {
            if (formatType.ToLower() != "html")
                throw new ForbiddenException("El formato solicitado no se encuentra disponible");

            var page = await _dbContext.Pages.FirstOrDefaultAsync(x => x.BookID == bookId && x.PageNumber == pageNumber);

            if (page == null)
                throw new NotFoundException("La pagina con el id de libro enviado no fue encontrada");

            var content = string.Format(HTML_TEMPLATE, page.PageNumber, page.Content);

            return content;
        }
    }
}
