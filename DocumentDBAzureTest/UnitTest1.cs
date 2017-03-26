using System;
using System.Net.Mime;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Temoignage.API.DocumentDBAzure;

namespace DocumentDBAzureTest
{
    [TestClass]
    public class UnitTest1
    {
        private TemoingnageJsn _temoignagejsn;

        [TestInitialize]
        public void TestInitialize()
        {
            
            _temoignagejsn = new TemoingnageJsn { ClientId = "12345", Description = "NomClient", UrlImage = "url", UrlVideo = "url", RatioImportance = 1 };


        }

        [TestMethod]
        public void TestMethod1()
        {
            DocDbAzure.InsertDocument(_temoignagejsn);
            
            
        }
    }
}
