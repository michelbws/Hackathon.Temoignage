using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Temoignage.API.DocumentDBAzure;
using Temoignage.API.Models;

namespace Temoignage.API.Controllers
{
    public class VideoUploadController : ApiController
    {
        public VideoUpload Get(string Id, string gps, string url, string alt, string metaData,
                                        string textDescription, Int32 ratio)
        {
            VideoUpload imgInfoObj = new VideoUpload(Id, gps, url, alt, metaData, textDescription, ratio);
            TemoingnageJsn infoImg = new TemoingnageJsn
            {
                ClientId = Id,
                Description = textDescription,
                Gps = gps,
                ImageData = metaData,
                AltDescription = alt,
                RatioImportance = ratio,
                UrlVideo = url
            };

            DocDbAzure.InsertDocument(infoImg);

            VideoUpload descErreur = new VideoUpload();

            return imgInfoObj;

        }

        

        public class VideoUpload
        {
            public string clientId;

            public string videoURL;

            public string alt;

            public Int32 ratioImportance;

            public string metaData;

            public string textDescription;

            public string gps;

            public VideoUpload() { }

            public VideoUpload(string Id, string gps, string url, string alt, string metaData,
                                        string textDescription, Int32 ratio)
            {
                this.clientId = Id;
                this.textDescription = textDescription;
                this.gps = gps;
                this.metaData = metaData;
                this.alt = alt;
                this.ratioImportance = ratio;
                this.videoURL = url;
            }
        }
    }
}
