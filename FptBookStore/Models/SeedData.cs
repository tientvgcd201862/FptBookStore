using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FptBookStore.Data; // Đảm bảo thêm namespace tương ứng

namespace FptBookStore.Models
{
    public class SeedData : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public SeedData(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<FptBookStoreContext>();

                if (!dbContext.Books.Any())
                {
                    dbContext.Books.AddRange(
                        new Book
                        {
                            Title = "Bröderna Lejonhjärta",
                            Description = "aa",
                            Language = "Swedish",
                            ISBN = "9789129688313",
                            DatePublished = DateTime.Parse("2013-09-26"),
                            Price = 139,
                            Author = "Astrid Lindgren",
                            ImageUrl = "/images/lejonhjärta.jpg"

                        },
                        new Book
                        {
                            Title = "The Fellowship of the Ring",
                            Description = "bb",
                            Language = "English",
                            ISBN = "9780261102354",
                            DatePublished = DateTime.Parse("1991-7-4"),
                            Price = 100,
                            Author = "J. R. R. Tolkien",
                            ImageUrl = "/images/lotr.jpg"
                        },

                    new Book
                    {
                        Title = "Mystic River",
                        Description = "cc",
                        Language = "English",
                        ISBN = "9780062068408",
                        DatePublished = DateTime.Parse("2011-6-1"),
                        Price = 91,
                        Author = "Dennis Lehane",
                        ImageUrl = "/images/mystic-river.jpg"
                    },

                    new Book
                    {
                        Title = "Of Mice and Men",
                        Description = "dd",
                        Language = "English",
                        ISBN = "9780062068408",
                        DatePublished = DateTime.Parse("1994-1-2"),
                        Price = 166,
                        Author = "John Steinbeck",
                        ImageUrl = "/images/of-mice-and-men.jpg"
                    },

                    new Book
                    {
                        Title = "The Old Man and the Sea",
                        Description = "ee",
                        Language = "English",
                        ISBN = "9780062068408",
                        DatePublished = DateTime.Parse("1994-8-18"),
                        Price = 84,
                        Author = "Ernest Hemingway",
                        ImageUrl = "/images/old-man-and-the-sea.jpg"
                    },

                    new Book
                    {
                        Title = "The Road",
                        Description = "ff",
                        Language = "English",
                        ISBN = "9780307386458",
                        DatePublished = DateTime.Parse("2007-5-1"),
                        Price = 95,
                        Author = "Cormac McCarthy",
                        ImageUrl = "/images/the-road.jpg"
                    }
                    );

                    await dbContext.SaveChangesAsync(stoppingToken);
                }
            }
        }
    }
}
