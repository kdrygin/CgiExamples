using System;
using System.Collections.Generic;

namespace HtmlFormHandle
{
    class Program
    {
        static void Main(string[] args)
        {
            var form = new HtmlFormData();
            form.Handle();
            //form.Handle("q=&w=%D1%8B%D0%B2%D1%8B%D1%84%D0%B2%D1%84%D1%8B+");

            // show form data
            Console.WriteLine("Content-Type: text/html \n\n");
            Console.WriteLine("<html><head><title> Current Time</title></head>");
            Console.WriteLine("<body>");

            Console.WriteLine($"<p>Form has {form.Count} fields</p>");

            foreach (KeyValuePair<string, string> field in form)
            {
                Console.WriteLine($"<p>{field.Key} = {field.Value}</p>");
            }

            Console.WriteLine("</body></html>");
        }
    }

}

