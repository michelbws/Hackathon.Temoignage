using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Temoignage.API.Models
{
    public class Alert
    {
        
        public List<PagedList> pagedList
        {
            get;
            set;
        }
    
    }
    public class PagedList
    {
        public List<Items> items
        {
            get;
            set;
        }

    }
    public class Items
    {
        public string id
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;
        }

        public CanonicalWebLink canonicalWebLink
        {
            get;
            set;
        }
        public string summary
        {
            get;
            set;
        }
        public string publishedLastTimeAt
        {
            get;
            set;
        }


    }
    public class CanonicalWebLink
    {
        public string href
        {
            get;
            set;
        }
    }

}