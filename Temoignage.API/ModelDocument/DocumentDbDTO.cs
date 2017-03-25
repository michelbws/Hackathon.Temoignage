using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Temoignage.API.ModelDocument
{
    public class DocumentDbDTO
    {
        public string Id { get; set; }
        public string Gps { get; set; }
        public   List<InfoImage> ListInfoImage { get; set; }

        public List<InfoVideo> ListInfoVideo { get; set; }
        public Int32 ratioImportante { get; set; }
    }
}