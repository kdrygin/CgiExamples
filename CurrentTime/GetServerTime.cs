using System;

namespace GetServerTime
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Content-Type: text/html \n\n");
            Console.WriteLine("<html><head><title> Current Time</title></head>");
            Console.WriteLine("<body>");
            Console.WriteLine($"<h1>{DateTime.Now}</h1>");
            Console.WriteLine("</body></html>");
        }
    }
}

