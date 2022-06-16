using Microsoft.EntityFrameworkCore;
using Patika.WebApi.Entities;
using System;
namespace Patika.WebApi.DbOperation
{
    public class PatikaContext:DbContext
    {

        public PatikaContext(DbContextOptions<PatikaContext> options):base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}
