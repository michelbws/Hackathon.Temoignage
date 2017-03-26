using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Temoignage.API.DocumentDBAzure;

namespace Temoignage.API.Controllers
{
    public class ClientController : ApiController
    {
        public ClientInfo Get(string lastName, string firstName, string email, string phone, string id)
        {
            ClientInfo newClientInfo = new ClientInfo(lastName, firstName, email, phone, id);
            ClientJsn infoClient = new ClientJsn { Nom = lastName, Prenom = firstName, Email = email, Telphone = phone, Id = id };

            DocDbAzure.InsertDocument(infoClient);

            return newClientInfo;
        }



        public class ClientInfo
        {
            public string lastName;
            public string firstName;
            public string email;
            public string phone;
            public string id;

            public ClientInfo() { }

            public ClientInfo(string lastName, string firstName, string email, string phone, string id)
            {
                this.lastName = lastName;
                this.firstName = firstName;
                this.email = email;
                this.phone = phone;
                this.id = id;
            }
        }
       

    }
}


