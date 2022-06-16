using AutoMapper;
using Patika.WebApi.DbOperation;
using System.Collections.Generic;
using System.Linq;

namespace Patika.WebApi.GenreOperations.GetGenre
{
    public class GenreGetQuery
    {
        public GenreVm Model { get; set; }
        private readonly PatikaContext _context;
        private readonly IMapper _mapper;
        public GenreGetQuery(PatikaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

      

   

        public List<GenreVm> Handle()
        {
            var genreList = _context.Genres.OrderBy(x=>x.Id).ToList();
            List<GenreVm> vm = _mapper.Map<List<GenreVm>>(genreList);
            return vm;
        }
    }

    public class GenreVm
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
