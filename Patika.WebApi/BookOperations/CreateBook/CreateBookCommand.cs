
using AutoMapper;
using Patika.WebApi.BookOperations.GetBooks;
using Patika.WebApi.DbOperation;
using System;
using System.Linq;

namespace Patika.WebApi.BookOperations.GetBooks
{
    public class CreateBookCommand
    {
        public CreateBookVm  Model { get; set; }
        private readonly PatikaContext _context;
        private readonly IMapper _mapper;
        public CreateBookCommand(PatikaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var createModel = _context.Books.SingleOrDefault(x => x.Title == Model.Title);
            if(createModel == null)
            {
                createModel = _mapper.Map<Book>(Model);
                
            }
            _context.Books.Add(createModel);
            _context.SaveChanges();
        }

        public class CreateBookVm
        {

         

            public string Title { get; set; }

            public int GenreId { get; set; }

            public int PageCount { get; set; }

            public DateTime PublishDate { get; set; }
        }
    }
}
