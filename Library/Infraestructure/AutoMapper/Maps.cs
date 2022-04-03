using AutoMapper;
using Models.Entities;
using Models.ViewModels;

namespace Library.Infraestructure.AutoMapper
{
    public class Maps : Profile
    {
        public Maps() 
        {
            CreateMap<Author, AuthorDto>();
            CreateMap<Book, BookDto>();
            CreateMap<Page, PageDto>();
        }
    }
}
