using System;

namespace HtmlFormHandlePost
{
    class Program
    {
        static void Main(string[] args)
        {
            // get post data length
            var requestMethod = Environment.GetEnvironmentVariable("REQUEST_METHOD");
            var dataLen = int.Parse(Environment.GetEnvironmentVariable("CONTENT_LENGTH"));

            //get post data
            var rowPostData = new char[dataLen + 1];
            for(int i = 0; i<dataLen; ++i)
            {
                rowPostData[i] = (char)Console.Read();
            }

            // get form fields
            var fields = new String(rowPostData).Split("&");

            // show form data
            Console.WriteLine("Content-Type: text/html \n\n");
            Console.WriteLine("<html><head><title> Current Time</title></head>");
            Console.WriteLine("<body>");

            Console.WriteLine($"<p>{requestMethod}, Data Length:{dataLen}</p>");

            foreach (var field in fields)
            {
                Console.WriteLine($"<p>{field}</p>");
            }

            Console.WriteLine("</body></html>");
        }
    }
}
