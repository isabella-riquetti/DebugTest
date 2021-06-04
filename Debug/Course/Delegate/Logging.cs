using System;

namespace Core
{
    public static class Logging
    {
        public delegate bool DoRequest(IRequest request);
        public static void Log(DoRequest requestMethod, IRequest requestParameter, string methodName)
        {
            var result = requestMethod.Invoke(requestParameter);

            Console.WriteLine($"Log {methodName}\tResult: {result}");
        }
    }

    public interface IRequest
    {
    }

    public class MyRequest : IRequest
    {
        public bool IsSuccessful { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
    }
}
