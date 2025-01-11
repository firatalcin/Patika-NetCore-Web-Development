using AutoMapper;
using BookStore.API.BookOperations.CreateBook;

namespace BookStore.API.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, CreateBookModel>().ReverseMap();
        }
    }
}
