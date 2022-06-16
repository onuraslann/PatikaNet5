using AutoMapper;
using Patika.WebApi.BookOperations.GetBooks;
using Patika.WebApi.Entities;
using Patika.WebApi.GenreOperations.CreateGenre;
using Patika.WebApi.GenreOperations.GetGenre;
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
            CreateMap<Genre, GenreVm>().ReverseMap();
            CreateMap<GenreCreateVm, Genre>().ReverseMap();
        }

    }
}
