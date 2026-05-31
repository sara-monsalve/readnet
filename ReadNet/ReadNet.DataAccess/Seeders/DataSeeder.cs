using ReadNet.DataAccess.Context;
using ReadNet.Domain.Entities;
using ReadNet.Domain.Enums;

namespace ReadNet.DataAccess.Seeders;

public static class DataSeeder
{
    public static void Seed(LibraryDbContext context)
    {
        // Authors
        if (!context.Authors.Any())
        {
            var author1 = new Author
            {
                Name = "Gabriel García Márquez",
                Country = "Colombia"
            };

            var author2 = new Author
            {
                Name = "Julio Verne",
                Country = "Francia"
            };

            context.Authors.AddRange(author1, author2);
            context.SaveChanges();
        }

        // Categories
        if (!context.Categories.Any())
        {
            context.Categories.AddRange(
                new Category { Name = "Novela" },
                new Category { Name = "Ciencia Ficción" }
            );

            context.SaveChanges();
        }

        // Members
        if (!context.Members.Any())
        {
            context.Members.AddRange(
                new Member
                {
                    FullName = "Juan Pérez",
                    Email = "juan@email.com",
                    Phone = "3001234567"
                },
                new Member
                {
                    FullName = "María Gómez",
                    Email = "maria@email.com",
                    Phone = "3007654321"
                }
            );

            context.SaveChanges();
        }

        // Books
        if (!context.Books.Any())
        {
            var author1 = context.Authors.First();
            var author2 = context.Authors.Skip(1).FirstOrDefault();

            var category1 = context.Categories.First();
            var category2 = context.Categories.Skip(1).FirstOrDefault();

            if (author2 != null && category2 != null)
            {
                context.Books.AddRange(
                    new Book
                    {
                        Title = "Cien Años de Soledad",
                        ISBN = "9780307474728",
                        PublishYear = 1967,
                        AuthorId = author1.Id,
                        CategoryId = category1.Id
                    },
                    new Book
                    {
                        Title = "Viaje al Centro de la Tierra",
                        ISBN = "9788420667412",
                        PublishYear = 1864,
                        AuthorId = author2.Id,
                        CategoryId = category2.Id
                    }
                );

                context.SaveChanges();
            }
        }

        // Loans
        if (!context.Loans.Any())
        {
            var member = context.Members.First();

            context.Loans.Add(
                new Loan
                {
                    LoanDate = DateTime.Now,
                    ReturnDate = DateTime.Now.AddDays(15),
                    Status = LoanStatus.Active,
                    MemberId = member.Id
                }
            );

            context.SaveChanges();
        }

        // LoanDetails
        if (!context.LoanDetails.Any())
        {
            var loan = context.Loans.First();
            var book = context.Books.First();

            context.LoanDetails.Add(
                new LoanDetail
                {
                    LoanId = loan.Id,
                    BookId = book.Id
                }
            );

            context.SaveChanges();
        }
    }
}