using AutoMapper;
using Patika.WebApi.DbOperation;
using Patika.WebApi.Entities;
using System.Linq;

namespace Patika.WebApi.GenreOperations.CreateGenre
{
    public class CreateGenreCommand
    {
        private readonly PatikaContext _context;
        private readonly IMapper _mapper;
        public GenreCreateVm Model { get; set; }

        public CreateGenreCommand(PatikaContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
      
        }

        public void Handle()
        {

            var AddedGenre = _context.Genres.FirstOrDefault(x => x.Name == Model.Name);
            if (AddedGenre == null)
            {
                AddedGenre = _mapper.Map<Genre>(Model);

            }
            _context.Add(AddedGenre);
            _context.SaveChanges();
        }
    }
    public class GenreCreateVm
    {

        public string Name { get; set; }
    }
}
