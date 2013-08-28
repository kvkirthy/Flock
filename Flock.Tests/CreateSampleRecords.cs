using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Flock.Models;
using Raven.Client.Document;

namespace Flock.Tests
{
    [TestClass]
    public class CreateSampleRecords
    {
        DocumentStore _documentStore;
    
        [TestInitialize]
        public void InitializeTest()
        {
             _documentStore = new DocumentStore { Url="http://localhost:8082" };
             _documentStore.Initialize();
        }

        [TestMethod]
        public void CreateMessageDocuments()
        {
            var flockMessage = new FlockMessage()
            {
                Id="flockMessage/2",
                Message = "sample message 1 from unit test",
                CreateDateTime = DateTime.Now,
                CreateUserId = "User 1",
                IsLiked = false 
            };

            using (var session = _documentStore.OpenSession("Flock"))
            {
                session.Store(flockMessage);
                session.SaveChanges();
            }
        }
    }
}
