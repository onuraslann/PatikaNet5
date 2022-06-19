using Patika.WebApi.DbOperation;
using System;
using System.Linq;
using static Patika.WebApi.BookOperations.DeleteBook.DeleteBookCommand;

namespace Patika.WebApi.AuthorOperations.DeleteAuthor
{
    public class DeleteAuthorCommand
    {
        private readonly PatikaContext _context;

        public KeyVm Model  { get; set; }
        public DeleteAuthorCommand(PatikaContext context)
        {
            _context = context;
        
        }

        public void Handle()
        {
            var deletedModel = _context.Authors.SingleOrDefault(x => x.Id == Model.Id);
            if (deletedModel == null)
            {
                throw new Exception("Id not found");
            }
            _context.Remove(deletedModel);
            _context.SaveChanges();
        }
    }
}
