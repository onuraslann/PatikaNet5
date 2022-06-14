
using AutoMapper;
using Patika.WebApi.DbOperation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Patika.WebApi.BookOperations.UpdateBook
{
    public class UpdateBookCommand
    {
        public int Id { get; set; }
        public UpdateBookVm Model { get; set; }
        private readonly PatikaContext _context;


        public UpdateBookCommand(PatikaContext context)
        {
            _context = context;
         
        }

        public void  Handle()
        {
            var isExistEntity = _context.Books.SingleOrDefault(x => x.Id == Id);
            if(isExistEntity == null)
            {

                throw new Exception("Id bulunamadı");
            }

              isExistEntity.Title = Model.Title;
            isExistEntity.PageCount = Model.PageCount;
         
            _context.Update(isExistEntity);
            _context.SaveChanges();

        }

        public class UpdateBookVm
        {
    
            public string Title { get; set; }

        
            public int PageCount { get; set; }


        }
    }
}
