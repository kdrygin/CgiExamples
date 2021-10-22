using System;
using System.IO;
using System.Configuration;

namespace HtmlForm
{
    class Program
    {
        static void Main(string[] args)
        {
            //string path = @"/home/user/form.html";
            string path = ConfigurationManager.AppSettings["formPath"].ToString();
            string html;

            Console.WriteLine("Content-Type: text/html \n\n");
            try
            {
                using (StreamReader s = new StreamReader(path))
                {
                    html = s.ReadToEnd();
                    Console.WriteLine(html);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
