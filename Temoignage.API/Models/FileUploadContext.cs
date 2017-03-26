using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Temoignage.API.Models
{
    public class FileUploadContext : DbContext
    {
        public FileUploadContext() : base("name=DefaultConnection") { }
        public DbSet<ImageUpload> fileUpload
        {
            get;
            set;
        }
    }
}