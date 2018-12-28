using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Business.Abstract
{
    public abstract class Requests
    {
        private HttpWebRequest request { get; set; }
        private HttpWebResponse response { get; set; }
        private byte[] bytes { get; set; }
        private StreamReader reader { get; set; }
        private Stream stream { get; set; }
        protected string USER_AGENT = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/71.0.3578.98 Safari/537.36";
        protected string source { get; set; }
        protected string postString { get; set; }
        protected CookieContainer container = new CookieContainer();

        private string getResponse(bool returnSource)
        {
            using (response = request.GetResponse() as HttpWebResponse)
            {
                if (returnSource)
                    using (reader = new StreamReader(response.GetResponseStream()))
                        source = reader.ReadToEnd();

                return response.ResponseUri.AbsoluteUri;
            }
        }
        private void addDefaultHeaders()
        {
            request.CookieContainer = container;
            request.UserAgent = USER_AGENT;
            request.KeepAlive = true;
            request.Timeout = 10000;
            request.Accept = "*/*";
        }
        protected string Get(string url, string referer = "", string proxy = "", bool returnSource = true, params string[] header)
        {
            request = WebRequest.Create(url) as HttpWebRequest;
            addDefaultHeaders();

            if (!string.IsNullOrEmpty(referer))
            {
                request.Referer = referer;
            }

            if (!string.IsNullOrEmpty(proxy))
            {
                string proxyAddress = string.Empty;
                string proxyUser = string.Empty;
                string proxyPassword = string.Empty;

                proxyAddress = proxy.Split(':')[0] + ":" + proxy.Split(':')[1];
                if (proxy.Split(':').Length == 4)
                {
                    proxyUser = proxy.Split(':')[2];
                    proxyPassword = proxy.Split(':')[3];
                }

                WebProxy webProxy = new WebProxy();
                webProxy.Address = new Uri("http://" + proxyAddress);
                if (!string.IsNullOrEmpty(proxyUser)) webProxy.Credentials = new NetworkCredential(proxyUser, proxyPassword);

                request.Proxy = webProxy;
            }

            for (int i = 0; i < header.Length; i++)
            {
                string headerName = header[i].Split(':')[0];
                string headerValue = header[i].Split(':')[1];

                request.Headers.Add(headerName, headerValue);
            }

            return getResponse(returnSource);
        }
        protected string Post(string url, string referer = "", string proxy = "", string contentType = "application/x-www-form-urlencoded; charset=UTF-8", bool returnSource = true, params string[] header)
        {
            request = WebRequest.Create(url) as HttpWebRequest;
            addDefaultHeaders();
            request.Method = WebRequestMethods.Http.Post;
            request.ContentType = contentType;

            if (!string.IsNullOrEmpty(referer))
            {
                request.Referer = referer;
            }

            if (!string.IsNullOrEmpty(proxy))
            {
                string proxyAddress = string.Empty;
                string proxyUser = string.Empty;
                string proxyPassword = string.Empty;

                proxyAddress = proxy.Split(':')[0] + ":" + proxy.Split(':')[1];
                if (proxy.Split(':').Length == 4)
                {
                    proxyUser = proxy.Split(':')[2];
                    proxyPassword = proxy.Split(':')[3];
                }

                WebProxy webProxy = new WebProxy();
                webProxy.Address = new Uri("http://" + proxyAddress);
                if (!string.IsNullOrEmpty(proxyUser)) webProxy.Credentials = new NetworkCredential(proxyUser, proxyPassword);

                request.Proxy = webProxy;
            }

            for (int i = 0; i < header.Length; i++)
            {
                string headerName = header[i].Split(':')[0];
                string headerValue = header[i].Split(':')[1];

                request.Headers.Add(headerName, headerValue);
            }

            bytes = Encoding.UTF8.GetBytes(postString);
            request.ContentLength = bytes.Length;

            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(bytes, 0, bytes.Length);
            }

            return getResponse(returnSource);
        }
        protected void PostWithForm(string url, MultipartFormDataContent form, string referer = "", string proxy = "", bool returnSource = true, params string[] header)
        {
            request = WebRequest.Create(url) as HttpWebRequest;
            addDefaultHeaders();
            request.Method = WebRequestMethods.Http.Post;
            request.ContentType = form.Headers.ContentType.ToString();
            request.ContentLength = form.Headers.ContentLength.Value;

            if (!string.IsNullOrEmpty(referer))
            {
                request.Referer = referer;
            }

            if (!string.IsNullOrEmpty(proxy))
            {
                string proxyAddress = string.Empty;
                string proxyUser = string.Empty;
                string proxyPassword = string.Empty;

                proxyAddress = proxy.Split(':')[0] + ":" + proxy.Split(':')[1];
                if (proxy.Split(':').Length == 4)
                {
                    proxyUser = proxy.Split(':')[2];
                    proxyPassword = proxy.Split(':')[3];
                }

                WebProxy webProxy = new WebProxy();
                webProxy.Address = new Uri("http://" + proxyAddress);
                if (!string.IsNullOrEmpty(proxyUser)) webProxy.Credentials = new NetworkCredential(proxyUser, proxyPassword);

                request.Proxy = webProxy;
            }

            for (int i = 0; i < header.Length; i++)
            {
                string headerName = header[i].Split(':')[0];
                string headerValue = header[i].Split(':')[1];

                request.Headers.Add(headerName, headerValue);
            }

            bytes = form.ReadAsByteArrayAsync().Result;

            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(bytes, 0, bytes.Length);
            }

            getResponse(returnSource);
        }
    }
}
