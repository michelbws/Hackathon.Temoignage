using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Azure.Documents.Client;

namespace Temoignage.API.DocumentDBAzure
{
    public static class DocDbAzure
    {
        static Uri docAccountUri = new Uri("https://temoignagedb.documents.azure.com:443/");
        static DocumentClient docClient = new DocumentClient(docAccountUri, "2WxpSk5O18zS0dkvcBZrG6OFncEjWffMmnQhr84J2rfvZADVnNHEI1fX1XOGbnp4oCQEHG1zHHuULFMe9Ui1ZQ==");
        static string dbId = "Temoingnage";
        static string collIdTemoignage = "TemoingnageCollection";
         static string collIdClient = "clientCollection";
        static Uri dbUri = new Uri($"dbs/{dbId}", UriKind.Relative);
        static Uri collTemoignageUri = new Uri($"dbs/{dbId}/colls/{collIdTemoignage}", UriKind.Relative);
        static Uri collClientUri = new Uri($"dbs/{dbId}/colls/{collIdClient}", UriKind.Relative);

        public static void UpsertDocument(TemoingnageJsn temoignage)
        {
            var response = docClient.UpsertDocumentAsync(collTemoignageUri, temoignage, disableAutomaticIdGeneration: true).Result;
        }

        public static void InsertDocument(TemoingnageJsn temoignage)
        {
            try
            {
                var reponse = docClient.CreateDocumentAsync(collTemoignageUri, temoignage).Result;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public static void InsertDocument(ClientJsn client)
        {
            try
            {
                var reponse = docClient.CreateDocumentAsync(collClientUri, client).Result;
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }
    }
}