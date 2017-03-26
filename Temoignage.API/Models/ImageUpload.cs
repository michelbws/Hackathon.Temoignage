using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Temoignage.API.Models
{
    public class DescriptionErreur
    {

        public string typeErreur { get; set; }
        public string messageErreur { get; set; }
    }
}

//    [Key]
    //    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //    public string clientId
    //    {
    //        get;
    //        set;
    //    }
        
    //    public string imageURL
    //    {
    //        get;
    //        set;
    //    }
    //    public string alt
    //    {
    //        get;
    //        set;
    //    }
    //    public Int32 ratioImportance 
    //    {
    //        get;
    //        set;
    //    }
    //    public string metaData
    //    {
    //        get;
    //        set;
    //    }
    //    public string textDescription
    //    {
    //        get;
    //        set;
    //    }
    //    public string gps
    //    {
    //        get;
    //        set;
    //    }

    //}
//}