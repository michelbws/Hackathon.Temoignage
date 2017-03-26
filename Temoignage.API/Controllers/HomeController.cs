using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Temoignage.API.Controllers
{
    public class HomeController : ApiController
    {
        public Media get(string clientId, int id, string username )
        
        {
            
            //ViewBag.Title = "Home Page";
            Media tMedia = new Media(clientId, id, username);
            tMedia.insert ou create 
            return tMedia;
        }
    }
    public class Media
    {
        public string file;

        public int id;

        public string username;


        public Media()
        {
            this.file = "astring";
        }

        public Media(string file, int id, string username)
        {
            this.file = file;
            this.id = id;
            this.username = username;
        }

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
