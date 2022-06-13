using Patika.WebApi.DbOperation;
using System;
using System.Linq;

namespace Patika.WebApi.BookOperations.DeleteBook
{
    public class DeleteBookCommand
    {

        private readonly PatikaContext _context;
        public KeyVm Model { get; set; }
        public DeleteBookCommand(PatikaContext context)
        {
            _context = context;
        }
        public void Handle(  )
        {
            var deletedBook = _context.Books.SingleOrDefault(x=>x.Id==Model.Id);
            if(deletedBook == null)
            {
                throw new Exception("Id bulunamadı");
            }
            _context.Remove(deletedBook);
            _context.SaveChanges();
        } 

        public class KeyVm
        {
            public int Id { get; set; }
        }

    }
}
