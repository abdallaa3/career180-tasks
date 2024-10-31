using EFDay2c180.models;
using System;
using System.Linq;

namespace NewsDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new NewsContext())
            {
                var newsWithAuthors = context.News
                                             .Select(n => new
                                             {
                                                 n.Title,
                                                 n.Bref,
                                                 n.DateTime,
                                                 AuthorName = n.Author.Name
                                             })
                                             .ToList();

                foreach (var news in newsWithAuthors)
                {
                    Console.WriteLine($"Title: {news.Title}, Brief: {news.Bref}, Date: {news.DateTime}, Author: {news.AuthorName}");
                }
            }
        }
    }
}
