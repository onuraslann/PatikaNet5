using AutoMapper;
using Patika.WebApi.AuthorOperations.CreateAuthor;
using Patika.WebApi.AuthorOperations.GetAuthor;
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
            CreateMap<Book, BookVm>().ForMember(dest=>dest.Genre,opt=>opt.MapFrom(src=>src.Genre.Name));
            CreateMap<Genre, GenreVm>().ReverseMap();
            CreateMap<GenreCreateVm, Genre>().ReverseMap();

            CreateMap<Author, GetAuthorVm>().ReverseMap();
            CreateMap<AuthorCreateVm, Author>().ReverseMap();
        }

    }
}
