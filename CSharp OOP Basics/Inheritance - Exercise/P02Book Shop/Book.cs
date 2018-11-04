using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace P02Book_Shop
{
    public class Book
    {
        private string title;
        private string author;
        private decimal price;

        public Book(string author, string title, decimal price)
        {
            this.Title = title;
            this.Author = author;
            this.Price = price;
        }

        public virtual string Title
        {
            get => title;

            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Title not valid!");
                }
                title = value;
            }
        }

        public virtual string Author
        {
            get => author;

            set
            {
                string[] names = value.Split();
                if (names.Length > 1)
                {
                    var authorSecondName = names[1];
                    if (Char.IsDigit(authorSecondName[0]))
                    {
                        throw new ArgumentException("Author not valid!");
                    }
                }
                author = value;
            }
        }

        public virtual decimal Price
        {
            get => price;

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price not valid!");
                }
                price = value;
            }
        }

        public override string ToString()
        {
            var resultBuilder = new StringBuilder();
            resultBuilder.AppendLine($"Type: {this.GetType().Name}")
                .AppendLine($"Title: {this.Title}")
                .AppendLine($"Author: {this.Author}")
                .AppendLine($"Price: {this.Price:F2}");

            string result = resultBuilder.ToString().TrimEnd();
            return result;
        }
    }
}
