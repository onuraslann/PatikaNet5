using Patika.WebApi.DbOperation;
using System;
using System.Linq;

namespace Patika.WebApi.GenreOperations.UpdateGenre
{
    public class UpdateGenreCommand
    {
        private readonly PatikaContext _context;
        public int Id { get; set; }

        public UpdateVm Model { get; set; }

        public UpdateGenreCommand(PatikaContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var updatedModel = _context.Genres.SingleOrDefault(x=>x.Id==Id);
            if (updatedModel == null)
            {
                throw new Exception("Id not found");
            }
            updatedModel.Name = Model.Name;
            _context.Update(updatedModel);
            _context.SaveChanges();
        }
    }
    public class UpdateVm
    {

        public string Name { get; set; }
    }
}
