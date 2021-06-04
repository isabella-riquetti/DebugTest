using Core.Course.Delegate;
using System;

namespace Core
{
    class Program
    {
        static void Main(string[] args)
        {
            var search = new Search();
            Logging.Log(search.Search1, new MyRequest(), "Search 1");
            Logging.Log(search.Search2, new MyRequest(), "Search 2");
            Console.ReadKey();
        }

        public bool Search1(IRequest request)
        {
            Console.WriteLine("Search 1");
            return true;
        }

        public bool Search2(IRequest request)
        {
            Console.WriteLine("Search 2");
            return false;
        }
    }
}