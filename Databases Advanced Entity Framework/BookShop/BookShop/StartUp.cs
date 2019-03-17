namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new BookShopContext())
            {
                //DbInitializer.ResetDatabase(db);

                var result = 
                RemoveBooks(db);
                Console.WriteLine(result);
            }
        }

        //01. Age Restriction
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var ageRestriction = Enum.Parse<AgeRestriction>(command, true);

            var books = context.Books
                .Where(a => a.AgeRestriction == ageRestriction)
                .Select(t => t.Title)
                .OrderBy(x => x)
                .ToList();

            var result = string.Join(Environment.NewLine, books);

            return result;
        }

        //02. Golden Books
        public static string GetGoldenBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            context.Books
                .Where(e => e.EditionType == EditionType.Gold && e.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(t => t.Title)
                .ToList()
                .ForEach(b => sb.AppendLine(b));

            return sb.ToString().Trim();
        }

        //03. Books by Price
        public static string GetBooksByPrice(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            context.Books
                .Where(p => p.Price > 40)
                .Select(b => new
                {
                    b.Title,
                    b.Price
                })
                .OrderByDescending(p => p.Price)
                .ToList()
                .ForEach(b => sb.AppendLine($"{b.Title} - ${b.Price:F2}"));

            return sb.ToString().TrimEnd();
        }

        //04. Not Released In
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            return string.Join(Environment.NewLine, context.Books
                .Where(b => b.ReleaseDate.HasValue && b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(t => t.Title)
                .ToList());
        }

        //05. Book Titles by Category
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var categories = input.ToLower().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var books = context.Books
                .Where(bc => bc.BookCategories.Any(c => categories.Contains(c.Category.Name.ToLower())))
                .Select(t => t.Title)
                .OrderBy(t => t)
                .ToList();

            string result = string.Join(Environment.NewLine, books);

            return result;
        }

        //06. Released Before Date
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var targetDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context.Books
                .Where(d => d.ReleaseDate.Value < targetDate)
                .OrderByDescending(r => r.ReleaseDate.Value)
                .Select(x => new
                {
                    x.Title,
                    x.EditionType,
                    x.Price
                })
                .ToList();

            string result = string.Join(Environment.NewLine, books
                .Select(x => $"{x.Title} - {x.EditionType} - ${x.Price:F2}"));

            return result;
        }

        //07. Author Search 
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            return string.Join(Environment.NewLine, context.Authors
                .Where(a => EF.Functions.Like(a.FirstName, "%" + input))
                .Select(a => a.FirstName + " " + a.LastName)
                .OrderBy(a => a)
                .ToList());
        }

        //08. Book Search 
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            return string.Join(Environment.NewLine, context.Books
                .Where(b => EF.Functions.Like(b.Title, $"%{input}%"))
                .Select(b => b.Title)
                .OrderBy(x => x));
        }

        //09. Book Search by Author 
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(a => EF.Functions.Like(a.Author.LastName, $"{input}%"))
                .OrderBy(b => b.BookId)
                .Select(x => new
                {
                    x.Title,
                    x.Author.FirstName,
                    x.Author.LastName
                })
                .ToList();

            string result = string.Join(Environment.NewLine, books
                .Select(x => $"{x.Title} ({x.FirstName} {x.LastName})"));

            return result;
        }

        //10. Count Books 
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            return context.Books
                .Count(t => t.Title.Length > lengthCheck);
        }

        //11. Total Book Copies
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authors = context.Authors
                .Select(x => new
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    BooksCount = x.Books.Sum(c => c.Copies)
                })
                .OrderByDescending(b => b.BooksCount)
                .ToList();

            string result = string.Join(Environment.NewLine, authors
                .Select(x => $"{x.FirstName} {x.LastName} - {x.BooksCount}"));

            return result;
        }

        //12. Profit by Category 
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categories = context.Categories
                .Select(x => new
                {
                    CategoryName = x.Name,
                    TotalProfit = x.CategoryBooks.Sum(e => e.Book.Price * e.Book.Copies)
                })
                .OrderByDescending(t => t.TotalProfit)
                .ThenBy(c => c.CategoryName)
                .ToList();

            string result = string.Join(Environment.NewLine, categories
                .Select(x => $"{x.CategoryName} ${x.TotalProfit:F2}"));

            return result;
        }

        //13. Most Recent Books 
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var categories = context.Categories
                .Select(x => new
                {
                    CategoryName = x.Name,
                    Books = x.CategoryBooks.Select(e => new
                    {
                        e.Book.Title,
                        e.Book.ReleaseDate
                    })
                    .OrderByDescending(e => e.ReleaseDate)
                    .Take(3) //TODO ???? can without Take(3)
                    .ToList()
                })
                .OrderBy(c => c.CategoryName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var category in categories)
            {
                sb.AppendLine($"--{category.CategoryName}");

                foreach (var book in category.Books)
                {
                    sb.AppendLine($"{book.Title} ({book.ReleaseDate.Value.Year})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        //14. Increase Prices 
        public static void IncreasePrices(BookShopContext context)
        {
            context.Books
                .Where(b => b.ReleaseDate.Value.Year < 2010)
                .ToList()
                .ForEach(b => b.Price += 5);

            context.SaveChanges();
        }

        //15. Remove Books
        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books
               .Where(b => b.Copies < 4200)
               .ToList();

            context.RemoveRange(books);
            context.SaveChanges();

            return books.Count;
        }

    }
}
