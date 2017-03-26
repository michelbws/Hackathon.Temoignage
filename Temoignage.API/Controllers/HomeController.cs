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
    public class HomeController : ApiController
    {
         
        public ImageUpload Get(string Id, string gps, string url, string alt, string metaData, 
                                        string textDescription, Int32 ratio)
        {
            ImageUpload imgInfoObj = new ImageUpload(Id, gps, url, alt, metaData, textDescription, ratio);
            TemoingnageJsn infoImg = new TemoingnageJsn { ClientId = Id, Description = textDescription, Gps = gps,
            ImageData = metaData, AltDescription = alt, RatioImportance = ratio, UrlImage = url};

            DocDbAzure.InsertDocument(infoImg);
            
            ImageUpload descErreur = new ImageUpload();
            //descErreur = ValidateDataInfo(infoImg);

            return imgInfoObj;
           
        }
        

        //private ImageUpload ValidateDataInfo(TemoingnageJsn infoImg)
        //{
        //    throw new NotImplementedException();

        //}

        public class ImageUpload
        {
            public string clientId;
                        
            public string imageURL;
            
            public string alt;
            
            public Int32 ratioImportance;
            
            public string metaData;
                       
            public string textDescription;
            
            public string gps;

            public ImageUpload() { }
           
            public ImageUpload( string Id, string gps, string url, string alt, string metaData,
                                        string textDescription, Int32 ratio)
            {
                this.clientId = Id;
                this.textDescription = textDescription;
                this.gps = gps;
                this.metaData = metaData;
                this.alt = alt;
                this.ratioImportance = ratio;
                this.imageURL = url;
            }

            public Boolean ValidateEmpty(ImageUpload descErreur)
            {
                string errorMsg = "";
                Boolean valide = true;
                if (String.IsNullOrEmpty(descErreur.clientId))
                {
                    errorMsg = "ID client null ou vide";
                    valide = false;
                }
                return valide;
            }

        }
    }
}
