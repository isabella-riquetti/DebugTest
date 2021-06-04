using System;

namespace Core.Course.Delegate
{
    public class Search
    {
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
