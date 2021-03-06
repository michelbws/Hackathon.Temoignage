﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Temoignage.API.DocumentDBAzure
{
    public class TemoingnageJsn
    {
        [JsonProperty(PropertyName = "temoinID")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "gps")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "urlImage")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "urlVideo")]
        public bool Completed { get; set; }

        [JsonProperty(PropertyName = "poidImportance")]
        public Int32 PoidImportance { get; set; }
    }
}