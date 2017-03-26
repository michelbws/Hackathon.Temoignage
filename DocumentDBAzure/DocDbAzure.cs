using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Temoignage.API.DocumentDBAzure
{
    public static class DocDbAzure
    {
        static Uri docAccountUri = new Uri("https://temoignagedb.documents.azure.com:443/");
        static DocumentClient docClient = new DocumentClient(docAccountUri, "2WxpSk5O18zS0dkvcBZrG6OFncEjWffMmnQhr84J2rfvZADVnNHEI1fX1XOGbnp4oCQEHG1zHHuULFMe9Ui1ZQ==");
        static string dbId = "Temoingnage";
        static string collId = "TemoingnageCollection";
        static Uri dbUri = new Uri($"dbs/{dbId}", UriKind.Relative);
        static Uri collUri = new Uri($"dbs/{dbId}/colls/{collId}", UriKind.Relative);

        public static void UpsertDocument(TemoingnageJsn temoignage)
        {
            var response = docClient.UpsertDocumentAsync(collUri, temoignage, disableAutomaticIdGeneration: true).Result;
        }

        public static void InsertDocument(TemoingnageJsn temoignage)
        {
            var reponse = docClient.CreateDocumentAsync(collUri, temoignage).Result;

        }

    }
}