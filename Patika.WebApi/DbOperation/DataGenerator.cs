using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Patika.WebApi.Entities;
using System;
using System.Linq;

namespace Patika.WebApi.DbOperation
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {


            using (var context = new PatikaContext(serviceProvider.GetRequiredService<DbContextOptions<PatikaContext>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }
                context.Books.AddRange(new Book
                {
                    Id = 1,
                    Title = "Lean Startup",
                    GenreId = 1,
                    PageCount = 250,
                    PublishDate = new DateTime(2021, 05, 15)
                },

                 new Book
                 {
                     Id = 2,
                     Title = "Herland",
                     GenreId = 2,
                     PageCount = 250,
                     PublishDate = new DateTime(2021, 05, 15)
                 }

                );
                context.Genres.AddRange(new Genre
                {

                  
                    Name = "Personal Growth"    
                },
                
                new Genre
                {
                    Name="Science Fiction"
                }
                
                );
                context.SaveChanges();
            }
        }


    }
}
