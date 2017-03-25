using System;
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
            _temoignagejsn = new TemoingnageJsn { Id = "12345", Name = "NomClient", Description = "Desc", PoidImportance = 1 };


        }

        [TestMethod]
        public void TestMethod1()
        {
            DocDbAzure.InsertDocument(_temoignagejsn);

        }
    }
}
