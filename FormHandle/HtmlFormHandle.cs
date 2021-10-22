using System;
using System.Collections;
using System.Collections.Generic;

namespace HtmlFormHandle
{
    class Program
    {
        static void Main(string[] args)
        {
            var form = new HtmlFormData();
            form.Handle();
            //form.Handle("q=1&w=2");

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

    public class HtmlFormData : IEnumerable
    {
        private string rawFormData;
        private string requestMethod;
        private Dictionary<string, string> formData;

        public int Count
        {
            get => formData.Count;
        }

        public string this[string key]
        {
            get => formData[key];
        }

        public HtmlFormData()
        {
            formData = new Dictionary<string, string>();
        }

        public void HandlePost()
        {
            GetMethodPostData();
            ParseRawFormData();
        }

        public void HandleGet()
        {
            GetMethodGetData();
            ParseRawFormData();
        }

        public void Handle(string data)
        {
            rawFormData = data;
            ParseRawFormData();
        }

        public void Handle()
        {
            requestMethod = Environment.GetEnvironmentVariable("REQUEST_METHOD");

            switch(requestMethod)
            {
                case "GET":
                    HandleGet();
                    break;

                case "POST":
                    HandlePost();
                    break;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return formData.GetEnumerator();
        }

        private void GetMethodPostData()
        {
            // get post data length
            var dataLen = int.Parse(Environment.GetEnvironmentVariable("CONTENT_LENGTH"));

            //get post data
            var data = new char[dataLen + 1];
            for (int i = 0; i < dataLen; ++i)
            {
                data[i] = (char)Console.Read();
            }

            rawFormData = new String(data);
        }

        private void GetMethodGetData()
        {
            rawFormData = Environment.GetEnvironmentVariable("QUERY_STRING");
        }

        private void ParseRawFormData()
        {
            var fields = new String(rawFormData).Split("&");
            foreach (var field in fields)
            {
                var fieldData = field.Split("=");
                formData.Add(fieldData[0], fieldData[1]);
            }
        }
    }

}

