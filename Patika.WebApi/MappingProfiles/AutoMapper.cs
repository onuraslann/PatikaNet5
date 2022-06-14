using AutoMapper;
using Patika.WebApi.BookOperations.GetBooks;
using static Patika.WebApi.BookOperations.GetBooks.CreateBookCommand;
using static Patika.WebApi.BookOperations.UpdateBook.UpdateBookCommand;

namespace Patika.WebApi.MappingProfiles
{
    public class AutoMapper:Profile
    {

        public AutoMapper()
        {
            CreateMap<CreateBookVm, Book>().ReverseMap();
            CreateMap<Book, BookVm>().ReverseMap();
            
        }

    }
}
