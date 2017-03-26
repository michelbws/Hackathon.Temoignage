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
         
        public DescriptionErreur Get(string Id, string gps, string url, string alt, string metaData, 
                                        string textDescription, Int32 ratio)
        {
            
            TemoingnageJsn infoImg = new TemoingnageJsn { ClientId = Id, Description = textDescription, Gps = gps,
            ImageData = metaData, AltDescription = alt, RatioImportance = ratio, UrlImage = url};

            
            DescriptionErreur descErreur = new DescriptionErreur();
            descErreur = ValidateDataInfo(infoImg);
            try
            {
                
            }
            catch(Exception e) {

                return e.Message;
            }
        }

        private DescriptionErreur ValidateDataInfo(TemoingnageJsn infoImg)
        {
            throw new NotImplementedException();

        }




        //    public Media get(string clientId, int id, string username )

        //    {

        //        //ViewBag.Title = "Home Page";
        //        Media tMedia = new Media(clientId, id, username);
        //        tMedia.insert ou create 
        //        return tMedia;
        //    }
        //}
        //public class Media
        //{
        //    public string file;

        //    public int id;

        //    public string username;


        //    public Media()
        //    {
        //        this.file = "astring";
        //    }

        //    public Media(string file, int id, string username)
        //    {
        //        this.file = file;
        //        this.id = id;
        //        this.username = username;
        //    }

    }
    //private void uploadwholefile(httprequestbase request)
    //{
    //    for (int i = 0; i < request.files.count; i++)
    //    {
    //        var file = request.files[i];

    //        var ext = new fileinfo(file.filename).extension;
    //        var fullpath = path.combine(storageroot, path.getfilename(guid.newguid() + ext));

    //        file.saveas(fullpath);
    //    }
    //}
}
