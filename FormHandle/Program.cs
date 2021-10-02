using System;

namespace HtmlFormHandle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Content-Type: text/html \n\n");
            var queryStr = Environment.GetEnvironmentVariable("QUERY_STRING");
            Console.WriteLine(queryStr);
        }
    }
}
