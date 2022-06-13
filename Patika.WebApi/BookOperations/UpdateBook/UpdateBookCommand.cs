
using Patika.WebApi.DbOperation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Patika.WebApi.BookOperations.UpdateBook
{
    public class UpdateBookCommand
    {
        private readonly PatikaContext _context;
        public UpdateBookVm Model { get; set; }

        public UpdateBookCommand(PatikaContext context)
        {
            _context = context;
        }

        public void  Handle()
        {
            var updatebook = _context.Books.SingleOrDefault(x => x.Id == Model.Id);
            if(updatebook == null)
            {

                throw new Exception("Id bulunamadı");
            }
            updatebook = new Book();
            updatebook.Title = Model.Title;
            updatebook.PageCount = Model.PageCount;
            updatebook.PublishDate = Model.PublishDate;
            _context.Update(updatebook);
            _context.SaveChanges();

        }

        public class UpdateBookVm
        {


            public int Id { get; set; }
            public string Title { get; set; }

         

            public int PageCount { get; set; }

            public DateTime PublishDate { get; set; }
        }
    }
}
