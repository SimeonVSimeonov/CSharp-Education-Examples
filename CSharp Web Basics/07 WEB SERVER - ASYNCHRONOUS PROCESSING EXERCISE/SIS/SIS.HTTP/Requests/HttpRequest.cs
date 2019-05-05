using SIS.HTTP.Common;
using SIS.HTTP.Enums;
using SIS.HTTP.Exceptions;
using SIS.HTTP.Headers;
using SIS.HTTP.Headers.Contracts;
using SIS.HTTP.Requests.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SIS.HTTP.Requests
{
    public class HttpRequest : IHttpRequest
    {
        public HttpRequest(string requestString)
        {
            this.FormData = new Dictionary<string, object>();
            this.QueryData = new Dictionary<string, object>();
            this.Headers = new HttpHeaderCollection();

            this.ParseRequest(requestString);
        }

        public string Path { get; private set; }

        public string Url { get; private set; }

        public Dictionary<string, object> FormData { get; }

        public Dictionary<string, object> QueryData { get; }

        public IHttpHeaderCollection Headers { get; }

        public HttpRequestMethod RequestMethod { get; private set; }

        private void ParseRequest(string requestString)
        {
            string[] splitRequestContent = requestString
                .Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            string[] requestLine = splitRequestContent[0].Trim()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (!this.IsValidRequestLine(requestLine))
            {
                throw new BadRequestException();
            }

            this.ParseRequestMethod(requestLine);
            
            this.ParseRequestUrl(requestLine);
            
            this.ParseRequestPath();
            
            this.ParseHeaders(splitRequestContent.Skip(1).ToArray());
            
            bool requestHasBody = splitRequestContent.Length > 1;
            
            this.ParseRequestParameters(splitRequestContent[splitRequestContent.Length - 1], requestHasBody);
            
        }

        private bool IsValidRequestLine(string[] requestLine)
        {
            return requestLine.Length == 3 && requestLine[2] == GlobalConstants.HttpOneProtocolFragment;
        }

        private bool IsValidRequestQueryString(string queryString, string[] queryParams)
        {
            return !(string.IsNullOrEmpty(queryString) || queryParams.Length < 1);
        }

        private void ParseRequestMethod(string[] requestLine)
        {
            var isValidMethod = Enum
                .TryParse(typeof(HttpRequestMethod), requestLine[0], true, out object requestMethod);
            if (!isValidMethod)
            {
                throw new BadRequestException();
            }

            this.RequestMethod = (HttpRequestMethod)requestMethod;

        }

        private void ParseRequestUrl(string[] requestLine)
        {
            var url = requestLine[1];
            if (string.IsNullOrEmpty(url))
            {
                throw new BadRequestException();
            }

            this.Url = url;
        }

        private void ParseRequestPath()
        {
            var path = this.Url.Split('?')[0];
            if (string.IsNullOrEmpty(path))
            {
                throw new BadRequestException();
            }

            this.Path = path;
        }

        private void ParseHeaders(string[] requestContent)
        {
            if (!requestContent.Any())
            {
                throw new BadRequestException();
            }

            foreach (var content in requestContent)
            {
                if (string.IsNullOrEmpty(content))
                {
                    return;
                }

                var splitContent = content
                    .Split(": ", StringSplitOptions.RemoveEmptyEntries);
                var requestHeaderKey = splitContent[0];
                var requestHeaderValue = splitContent[1];

                this.Headers.Add(new HttpHeader(requestHeaderKey, requestHeaderValue));
            }
        }

        private void ParseRequestParameters(string formData, bool requestHasBody)
        {
            this.ParseQueryParameters(this.Url);
            if (requestHasBody)
            {
                this.ParseFormDataParameters(formData);
            }
        }

        private void ParseQueryParameters(string url)
        {

            if (!this.Url.Contains('?'))
            {
                return;
            }

            var queryParams = this.Url?
                .Split(new[] { '?', '#' })
                .Skip(1)
                .ToArray()[0];
            
            if (string.IsNullOrEmpty(queryParams))
            {
                throw new BadRequestException();
            }

            var queryKeyValuePairs = queryParams
                .Split('&', StringSplitOptions.RemoveEmptyEntries);

            //TODO check if we need this
            if (!this.IsValidRequestQueryString(queryParams, queryKeyValuePairs))
            {
                throw new BadRequestException();
            }

            foreach (var queryKvp in queryKeyValuePairs)
            {
                var kvp = queryKvp.Split('=', StringSplitOptions.RemoveEmptyEntries);

                if (kvp.Length != 2)
                {
                    throw new BadRequestException();
                }

                var queryKey = kvp[0];
                var queryValue = kvp[1];

                //key -> {key, value}
                //should we overwrite
                this.QueryData[queryKey] = queryValue;
            }
        }

        private void ParseFormDataParameters(string formData)
        {
            //if (string.IsNullOrEmpty(formData))
            //{
            //    return;
            //}

            var formDataKeyValuePairs = formData
                .Split('&', StringSplitOptions.RemoveEmptyEntries);

            foreach (var formDataKvp in formDataKeyValuePairs)
            {
                var kvp = formDataKvp.Split('=', StringSplitOptions.RemoveEmptyEntries);

                if (kvp.Length != 2)
                {
                    throw new BadRequestException();
                }

                var formDataKey = kvp[0];
                var formDataValue = kvp[1];

                //key -> {key, value}
                //should we overwrite
                this.FormData[formDataKey] = formDataValue;
            }
        }
    }
}
