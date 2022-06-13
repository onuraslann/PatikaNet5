using Patika.WebApi.DbOperation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Patika.WebApi.BookOperations.GetBooks
{
    public class GetBooksQuery
    {
        private readonly PatikaContext _context;

        public GetBooksQuery(PatikaContext context)
        {
            _context = context;
        }

        public List<BookVm> Handle()
        {

            var bookList = _context.Books.OrderBy(x => x.Id).ToList<Book>();
            List<BookVm> Vm = new List<BookVm>();
            foreach (var item in bookList)
            {
                Vm.Add(new BookVm
                {
                    Title=item.Title,
                     PageCount=item.PageCount,
                      PublishDate=item.PublishDate.Date.ToString("dd-MM-yyyy")
                    
                });
            }

            return Vm;
        }
     

        

    }
    public class BookVm
    {
       

        public string Title { get; set; }

    
        public int PageCount { get; set; }

        public string PublishDate { get; set; }


    }
}
