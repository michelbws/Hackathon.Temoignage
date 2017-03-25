//using Microsoft.Azure.Documents;
//using Microsoft.Azure.Documents.Client;
//using Newtonsoft.Json.Linq;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Http;
//using System.Threading.Tasks;

//namespace NeuroParser
//{
//    public class Program
//    {
//        static string neuroBaseURL = "https://services.radio-canada.ca/neuro/v1";
//        static HttpClient httpClient = new HttpClient();
//        static Uri docAccountUri = new Uri("https://neurocontentprocessor.documents.azure.com:443/");
//        static DocumentClient docClient = new DocumentClient(docAccountUri, "W97uoHWem1QKYILtNsXd0EAW5DmDHExsUX7AaYaZMZAcyhtOaLVjv0eIDNUDsySy6EjxthwR9mRo7x3iIq3PRw==");
//        static string dbId = "NeuroContentProcessor";
//        static string collId = "NeuroImagesUnique";
//        static Uri dbUri = new Uri($"dbs/{dbId}", UriKind.Relative);
//        static Uri collUri = new Uri($"dbs/{dbId}/colls/{collId}", UriKind.Relative);

//        public static void Main(string[] args)
//        {
//            if (args.Length > 0)
//            {
//                Process(int.Parse(args[0])).Wait();
//            }
//            else
//            {
//                Process().Wait();
//            }
//        }

//        public static async Task Process(int startAt = -1)
//        {
//            var db = await docClient.CreateDatabaseIfNotExistsAsync(new Database { Id = dbId });

//            await docClient.CreateDocumentCollectionIfNotExistsAsync(dbUri,
//                new DocumentCollection
//                {
//                    Id = collId,
//                    PartitionKey = new PartitionKeyDefinition
//                    {
//                        Paths = { "/url" },
//                    },
//                });

//            int count = 0;
//            int countInLoop = 0;
//            int pageNumber = 1;
//            while (true)
//            {
//                var pageValue = await GetPage(pageNumber);
//                dynamic pageJson = JObject.Parse(pageValue);

//                int pageSize = pageJson.pageSize;
//                int total = pageJson.totalNumOfItems;

//                if (total == 0)
//                {
//                    break;
//                }

//                var found = false;
//                foreach (dynamic lineupSummaryJson in pageJson.items)
//                {
//                    var lineupid = (int)lineupSummaryJson.id;
//                    if (startAt != -1 && !found)
//                    {
//                        if (lineupid != startAt)
//                        {
//                            continue;
//                        }
//                        else
//                        {
//                            found = true;
//                        }
//                    }
//                    Console.WriteLine($"Procesing lineup {lineupid}, which is {countInLoop} of {total}");
//                    countInLoop++;
//                    await ProcessLineup(lineupid);
//                }

//                count += pageSize;
//                if (count >= total)
//                {
//                    break;
//                }
//                pageNumber++;
//            }
//        }

//        private static async Task ProcessLineup(int lineupId)
//        {
//            int lineupItemsPageNumber = 1;
//            int count = 0;
//            int pageNumber = 1;
//            while (true)
//            {
//                string lineupValue;
//                try
//                {
//                    lineupValue = await GetLineup(lineupId, lineupItemsPageNumber);
//                }
//                catch (Exception ex)
//                {
//                    Console.WriteLine($"Lineupid {lineupId} and page {lineupItemsPageNumber} failed with error {ex}");
//                    return;
//                }

//                dynamic lineupJson = JObject.Parse(lineupValue);

//                int pageSize = lineupJson.pagedList.pageSize;
//                int total = lineupJson.pagedList.totalNumOfItems;

//                if (total == 0)
//                {
//                    break;
//                }

//                Console.WriteLine($"Processing page {count} of {total}");
//                foreach (dynamic contentItemJson in lineupJson.pagedList.items)
//                {
//                    try
//                    {
//                        dynamic multimediaItem = contentItemJson.summaryMultimediaItem;
//                        string contentTypeName = multimediaItem.contentType.name;
//                        if (!contentTypeName.StartsWith("Image"))
//                        {
//                            continue;
//                        }

//                        var jobs = new List<Task>();
//                        foreach (dynamic concreteImage in multimediaItem.concreteImages)
//                        {
//                            Console.WriteLine($"Procesing image {concreteImage.mediaLink.href}");
//                            var neuroImage = new NeuroImage
//                            {
//                                url = concreteImage.mediaLink.href,
//                                height = concreteImage.height,
//                                ratio = concreteImage.dimensionRatio,
//                                width = concreteImage.width
//                            };
//                            jobs.Add(UpsertDocument(neuroImage));
//                        }

//                        Task.WaitAll(jobs.ToArray());
//                    }
//                    catch (Exception ex)
//                    {
//                        Console.WriteLine($"Error while inserting {contentItemJson}, failed with error {ex}");
//                    }
//                }

//                count += pageSize;
//                if (count >= total)
//                {
//                    break;
//                }
//                pageNumber++;
//            }

//        }


//        private async static Task UpsertDocument(NeuroImage image)
//        {
//            var url = image.url.Replace("http://", string.Empty);
//            url = image.url.Replace("https://", string.Empty);
//            image.id = System.Net.WebUtility.UrlEncode(url);
//            var response = await docClient.UpsertDocumentAsync(collUri, image, disableAutomaticIdGeneration: true);
//        }

//        public static async Task<string> GetPage(int pageNumber)
//        {
//            return await httpClient.GetStringAsync($"{neuroBaseURL}/future/lineups?pageNumber={pageNumber}");
//        }

//        public static async Task<string> GetLineup(int lineupId, int pageNumber)
//        {
//            return await httpClient.GetStringAsync($"{neuroBaseURL}/future/lineups/{lineupId}?pageNumber={pageNumber}");
//        }
//    }
//}
