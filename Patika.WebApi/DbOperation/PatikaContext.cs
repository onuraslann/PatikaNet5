using Microsoft.EntityFrameworkCore;
using System;
namespace Patika.WebApi.DbOperation
{
    public class PatikaContext:DbContext
    {

        public PatikaContext(DbContextOptions<PatikaContext> options):base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
    }
}
