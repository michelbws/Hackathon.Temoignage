using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Temoignage.API.DocumentDBAzure
{
    public class ClientJsn
    {

        [JsonProperty(PropertyName = "Nom")]
        public string Nom { get; set; }

        [JsonProperty(PropertyName = "Prenom")]
        public string Prenom { get; set; }

        [JsonProperty(PropertyName = "Email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "Telephone")]
        public string Telphone { get; set; }

        [JsonProperty(PropertyName = "Id")]
        public string Id { get; set; }
    }
}