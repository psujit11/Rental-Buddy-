using Microsoft.EntityFrameworkCore;
using Rental.Models;

namespace Rental.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            {
                using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
                {
                    var context = serviceScope.ServiceProvider.GetService<RentalContext>();
                    context.Database.EnsureCreated();

                    if (context.Products.Any())    // Check if database contains any products
                    {
                        return;     // Database contains products already
                    }

                    context.Products.AddRange(
                        new Product
                        {
                            Name = "Bröderna Lejonhjärta",
                            Description="this is it",
                            Skuid = "9789129688313",
                            ManufactureDate = DateTime.Parse("2013-9-26"),
                            Price = 139,
                            Owner = "Astrid Lindgren",
                            ImageUrl = "/images/lejonhjärta.jpg"
                        },

                        new Product
                        {
                            Name = "The Fellowship of the Ring",
                            Description = "this is it",
                            Skuid = "9780261102354",
                            ManufactureDate = DateTime.Parse("1991-7-4"),
                            Price = 100,
                            Owner = "J. R. R. Tolkien",
                            ImageUrl = "/images/lotr.jpg"
                        },

                        new Product
                        {
                            Name = "Mystic River",
                            Description = "this is it",
                            Skuid = "9780062068408",
                            ManufactureDate = DateTime.Parse("2011-6-1"),
                            Price = 91,
                            Owner = "Dennis Lehane",
                            ImageUrl = "/images/mystic-river.jpg"
                        },

                        new Product
                        {
                            Name = "Of Mice and Men",
                            Description = "this is it",
                            Skuid = "9780062068408",
                            ManufactureDate = DateTime.Parse("1994-1-2"),
                            Price = 166,
                            Owner = "John Steinbeck",
                            ImageUrl = "/images/of-mice-and-men.jpg"
                        },

                        new Product
                        {
                            Name = "The Old Man and the Sea",
                            Description = "this is it",
                            Skuid = "9780062068408",
                            ManufactureDate = DateTime.Parse("1994-8-18"),
                            Price = 84,
                            Owner = "Ernest Hemingway",
                            ImageUrl = "/images/old-man-and-the-sea.jpg"
                        },

                        new Product
                        {
                            Name = "The Road",
                            Description = "this is it",
                            Skuid = "9780307386458",
                            ManufactureDate = DateTime.Parse("2007-5-1"),
                            Price = 95,
                            Owner = "Cormac McCarthy",
                            ImageUrl = "/images/the-road.jpg"
                        }
                    );

                    context.SaveChanges();

                }
            }
        }
    }
}
