using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Models.ViewModels;
using Services.Book;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookController(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;

        }

        [HttpGet]
        public async Task<IActionResult> Books()
        {
            var response = _mapper.Map<IList<BookDto>>(await _bookRepository.FindAll());
            return Ok(response);
        }

        [HttpGet("{bookId}")]
        public async Task<IActionResult> Book(int bookId)
        {
            var response = _mapper.Map<BookDto>(await _bookRepository.FindById(bookId));
            return Ok(response);
        }

        [HttpGet("{bookId}/pages")]
        public async Task<IActionResult> PagesByBook(int bookId)
        {
            var book = await _bookRepository.FindById(bookId);
            var response = _mapper.Map<IList<PageDto>>(book.Pages);
            return Ok(response);
        }

        [HttpGet("{bookId}/page/{pageNumber}")]
        public async Task<IActionResult> PageByBookAndPageNumber(int bookId, int pageNumber)
        {
            var response = _mapper.Map<PageDto>(await _bookRepository.PageByBookAndPageNo(bookId, pageNumber));
            return Ok(response);
        }

        [HttpGet("{bookId}/page/{pageNumber}/{formatType}")]
        public async Task<IActionResult> BookByPageNumberHtml(int bookId, int pageNumber, string formatType)
        {
            var response = await _bookRepository.PageByBookAndPageNoHtml(bookId, pageNumber, formatType);
            return new ContentResult 
            {
                Content = response,
                ContentType = "text/html",
                StatusCode = 200
            };
        }
    }
}
