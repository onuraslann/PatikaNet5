using Patika.WebApi.DbOperation;
using System;
using System.Linq;
using static Patika.WebApi.BookOperations.DeleteBook.DeleteBookCommand;

namespace Patika.WebApi.GenreOperations.DeleteGenre
{
    public class DeleteGenreCommand
    {
        private readonly PatikaContext _context;
        public KeyVm Model { get; set; }
        public DeleteGenreCommand(PatikaContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var deletedModel = _context.Genres.SingleOrDefault(x => x.Id == Model.Id);
            if (deletedModel == null)
            {
                throw new Exception("Id not found");
            }
            _context.Remove(deletedModel);
            _context.SaveChanges();
        }
    }
}
