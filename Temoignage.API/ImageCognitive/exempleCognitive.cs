
    using System;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Net.Http;
    using System.Web;

namespace Temoignage.API.ImageCognitive
{
        public static class ExempleCognitive
        {
            public static void Execute()
            {
                MakeRequest();
                Console.WriteLine("Hit ENTER to exit...");
                Console.ReadLine();
            }

            static async void MakeRequest()
            {
                var client = new HttpClient();
                var queryString = HttpUtility.ParseQueryString(string.Empty);

                // Request headers
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "{subscription key}");

                // Request parameters
                queryString["visualFeatures"] = "Categories";
                queryString["details"] = "{string}";
                queryString["language"] = "en";
                var uri = "https://westus.api.cognitive.microsoft.com/vision/v1.0/analyze?" + queryString;

                HttpResponseMessage response;

                // Request body
                byte[] byteData = Encoding.UTF8.GetBytes("{body}");

                using (var content = new ByteArrayContent(byteData))
                {
                    content.Headers.ContentType = new MediaTypeHeaderValue("< your content type, i.e. application/json >");
                    response = await client.PostAsync(uri, content);
                }

            }
        }
    }
