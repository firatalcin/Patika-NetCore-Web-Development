﻿using Microsoft.EntityFrameworkCore;

namespace BookStore.API.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }

                context.Books.AddRange(
                     new Book
                     {
                         Id = 1,
                         Title = "1984",
                         GenreId = 1, // Örn: 1 = Bilim Kurgu
                         PageCount = 328,
                         PublishDate = new DateTime(1949, 6, 8)
                     },
                     new Book
                     {
                         Id = 2,
                         Title = "Savaş ve Barış",
                         GenreId = 2, // Örn: 2 = Tarihsel Roman
                         PageCount = 1225,
                         PublishDate = new DateTime(1869, 1, 1)
                     },
                     new Book
                     {
                         Id = 3,
                         Title = "Küçük Prens",
                         GenreId = 3, // Örn: 3 = Çocuk Kitabı
                         PageCount = 96,
                         PublishDate = new DateTime(1943, 4, 6)
                     },
                     new Book
                     {
                         Id = 4,
                         Title = "Yüzüklerin Efendisi",
                         GenreId = 4, // Örn: 4 = Fantastik
                         PageCount = 1178,
                         PublishDate = new DateTime(1954, 7, 29)
                     },
                     new Book
                     {
                         Id = 5,
                         Title = "Suç ve Ceza",
                         GenreId = 5, // Örn: 5 = Klasik
                         PageCount = 671,
                         PublishDate = new DateTime(1866, 1, 1)
                     });

                context.SaveChanges();
            }
        }
    }
}
