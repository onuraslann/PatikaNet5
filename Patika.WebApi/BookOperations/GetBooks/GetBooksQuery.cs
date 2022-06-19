using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Patika.WebApi.DbOperation;
using Patika.WebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Patika.WebApi.BookOperations.GetBooks
{
    public class GetBooksQuery
    {
        private readonly PatikaContext _context;
        private readonly IMapper _mapper;
        public GetBooksQuery(PatikaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<BookVm> Handle()
        {

            var bookList = _context.Books.Include(x=>x.Genre).OrderBy(x => x.Id).ToList<Book>();
            List<BookVm> Vm =_mapper.Map<List<BookVm>>(bookList);
           
            

            return Vm;
        }
     

        

    }
    public class BookVm
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Genre { get; set; }
        public int PageCount { get; set; }

        public string PublishDate { get; set; }


    }
}
