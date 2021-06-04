using Core.Course.Delegate;
using System;

namespace Core
{
    class DelegateProgram
    {
        static void Main(string[] args)
        {
            var search = new Search();
            Logging.Log(search.Search1, new MyRequest(), "Search 1");
            Logging.Log(search.Search2, new MyRequest(), "Search 2");
            Console.ReadKey();
        }
    }
}