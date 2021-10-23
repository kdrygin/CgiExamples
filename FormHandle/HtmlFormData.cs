using System;
using System.Collections;
using System.Collections.Generic;

namespace HtmlFormHandle
{
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

            switch (requestMethod)
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

        private void ParseRawFormData(bool decode = true)
        {
            var str = decode ? System.Uri.UnescapeDataString(rawFormData) : rawFormData;
            var fields = new String(str).Split("&");
            foreach (var field in fields)
            {
                var fieldData = field.Split("=");
                formData.Add(fieldData[0], fieldData[1]);
            }
        }
    }

}

