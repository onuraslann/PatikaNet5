using AutoMapper;
using Patika.WebApi.DbOperation;
using Patika.WebApi.Entities;
using System;
using System.Linq;

namespace Patika.WebApi.AuthorOperations.CreateAuthor
{
    public class CreateAuthorCommand
    {
        private readonly PatikaContext _context;
        private readonly IMapper _mapper;
        public AuthorCreateVm Model { get; set; }

        public CreateAuthorCommand(PatikaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {

            var createModel = _context.Authors.Where(x => x.Name == Model.Name && x.Surname == Model.Surname).SingleOrDefault();
            if (createModel == null)
            {
                createModel = _mapper.Map<Author>(Model);
            }
            _context.Add(createModel);
            _context.SaveChanges();
        }
    }
    public class AuthorCreateVm
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public DateTime Date { get; set; }
    }
}
