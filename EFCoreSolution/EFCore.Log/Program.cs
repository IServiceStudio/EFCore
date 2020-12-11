using EFCore.Log.Entity;
using System;

namespace EFCore.Log
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var dbContext = new BloggingContext())
            {
                dbContext.Add(new Blog { Url = "www.google.com" });
                dbContext.SaveChanges();

                var blog = dbContext.Find<Blog>(1);
                Console.WriteLine($"Id:{blog.Id},Url={blog.Url}");
            }
        }
    }
}
