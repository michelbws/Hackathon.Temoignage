using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Newtonsoft.Json;
namespace Temoignage.API.DocumentDBAzure
{
    public class TemoingnageJsn
    {
        [JsonProperty(PropertyName = "clientID")]
        public string ClientId { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "altDescription")]
        public string AltDescription { get; set; }

        [JsonProperty(PropertyName = "gps")]
        public string Gps { get; set; }

        [JsonProperty(PropertyName = "urlImage")]
        public string UrlImage { get; set; }

        [JsonProperty(PropertyName = "urlVideo")]
        public string UrlVideo{ get; set; }

        [JsonProperty(PropertyName = "ratioImportance")]
        public Int32 RatioImportance { get; set; }

        [JsonProperty(PropertyName = "imageData")]
        public string ImageData { get; set; }

    }

}