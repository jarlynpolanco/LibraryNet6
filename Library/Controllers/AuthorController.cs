using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Models.ViewModels;
using Services.Author;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public AuthorController(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Authors()
        {
            var response = _mapper.Map<IList<AuthorDto>>(await _authorRepository.FindAll());
            return Ok(response);
        }

        [HttpGet("{authorId}")]
        public async Task<IActionResult> Author(int authorId)
        {
            var response = _mapper.Map<AuthorDto>(await _authorRepository.FindById(authorId));
            return Ok(response);
        }

        [HttpGet("{authorId}/books")]
        public async Task<IActionResult> AuthorBooks(int authorId)
        {
            var author = await _authorRepository.FindById(authorId);
            var response = _mapper.Map<IList<BookDto>>(author.Books);
            return Ok(response);
        }
    }
}
