using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;

namespace DatEx.Cropio.BaseAPI
{
    internal static class HttpClientHelper
    {
        const String indent = "    ";

        internal static String Indent(Int32 indentLevel)
        {
            String currentIndent = "\n";
            for(Int32 i = 0; i < indentLevel; i++) currentIndent += indent;
            return currentIndent;
        }

        internal static HttpClient ConstructHttpClient(String userApiToken, Uri baseAddress)
        {
            HttpClientHandler handler = new HttpClientHandler()
            {
                AutomaticDecompression = System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.Deflate
            };

            HttpClient client = new HttpClient(handler);
            client.BaseAddress = baseAddress;
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
            client.DefaultRequestHeaders.Add("X-User-Api-Token", userApiToken);
            return client;
        }

        internal static String RemoveBackSlashFromJson(this String responseData)
        {
            return Regex.Replace(responseData, @"(?<![\\])\\(?![bfnrt""\\])", @"\\");
        }
    }
}
