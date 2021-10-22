using System;

namespace HtmlFormHandleGet
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Content-Type: text/html \n\n");
            var queryStr = Environment.GetEnvironmentVariable("QUERY_STRING");
            var requestMethod = Environment.GetEnvironmentVariable("REQUEST_METHOD");
            Console.WriteLine($"{queryStr} {requestMethod}");
        }
    }
}
