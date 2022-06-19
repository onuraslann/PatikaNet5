using AutoMapper;
using Patika.WebApi.DbOperation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Patika.WebApi.AuthorOperations.GetAuthor
{
    public class GetAuthorQuery
    {
        private readonly PatikaContext _context;
        private readonly IMapper _mapper;
        public GetAuthorQuery(PatikaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<GetAuthorVm> Handle()
        {
            var listModel = _context.Authors.OrderBy(x => x.Id).ToList();
            List<GetAuthorVm> vm = _mapper.Map<List<GetAuthorVm>>(listModel);
            return vm;
        }
    }
    public class GetAuthorVm
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }

        public DateTime Date { get; set; }
    }
}
