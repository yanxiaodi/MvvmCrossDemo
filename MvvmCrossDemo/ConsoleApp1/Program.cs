using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCrossDemo.Core.Services;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var postService = new PostService();
            var response = postService.GetPostList().Result;
            if (response.IsSuccess)
            {
                response.Result.ForEach(x => Console.WriteLine(x.Title));
            }
            Console.ReadKey();
        }
    }
}
