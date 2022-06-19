using Patika.WebApi.DbOperation;
using System;
using System.Linq;

namespace Patika.WebApi.AuthorOperations.UpdateAuthor
{
    public class UpdateAuthorCommand
    {
        public int AuthorId { get; set; }
        public AuthorUpdateVm Model { get; set; }

        private readonly PatikaContext _context;

        public UpdateAuthorCommand(PatikaContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var updatedModel = _context.Authors.SingleOrDefault(x => x.Id == AuthorId);
            if(updatedModel == null)
            {
                throw new Exception("Id not Found");
            }
            updatedModel.Name = string.IsNullOrEmpty( Model.Name.Trim())  ? updatedModel.Name : Model.Name;
            updatedModel.Surname = string.IsNullOrEmpty(Model.Surname.Trim()) ? updatedModel.Surname : Model.Surname;
            updatedModel.Date = Model.Date;
            _context.Update(updatedModel);
            _context.SaveChanges();
        }
    }


    public class AuthorUpdateVm
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public DateTime Date { get; set; }
    }
}
