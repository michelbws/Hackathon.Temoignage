using System;
using System.Net.Mime;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Temoignage.API.DocumentDBAzure;
using Temoignage.API.ImageCognitive;

namespace DocumentDBAzureTest
{
    [TestClass]
    public class UnitTest1
    {
        private TemoingnageJsn _temoignagejsn;
        private ClientJsn _clientJsn;

        [TestInitialize]
        public void TestInitialize()
        {
            
            _temoignagejsn = new TemoingnageJsn { ClientId = "12345", Description = "NomClient", UrlImage = "url", UrlVideo = "url", RatioImportance = 1 };

            _clientJsn = new ClientJsn
            {
                Id = "14",
                Nom = "NomCLient",
                Prenom = "prenomClient",
                Email = "email@email.com",
                Telphone = "4505553232"
            };

        }

        [TestMethod]
        public void InsertDocument_TemoignageJsn()
        {
            DocDbAzure.InsertDocument(_temoignagejsn);
        }

        [TestMethod]
        public void InsertDocument_Client()
        {
            DocDbAzure.InsertDocument(_clientJsn);
        }

        [TestMethod]
        public void TestCognitive()
        {
            ExempleCognitive.Execute();
        }
    }
}
