using System.Data.Common;
using System.Linq;
using Effort;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NMemory;
using SE.Model;
using SE.Model.Entity;
using SE.Repository;

namespace SE.Test.Repositories
{
    [TestClass]
    public class ProviderRepositoryTest
    {
        private DbConnection _connection;
        private StorageDbContext _databaseDbContext;
        private ProviderRepository _repository;

        [TestInitialize]
        public void Initialize()
        {
            _connection =  DbConnectionFactory.CreateTransient();
            _databaseDbContext = new StorageDbContext(_connection);

            TestDbMigration.Seed(_databaseDbContext);

            _repository = new ProviderRepository(_databaseDbContext);
        }

        [TestMethod]
        public void Provider_Repository_Get_All()
        {
            //Act
            var result = _repository.GetAll().ToList();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);
            Assert.AreEqual("Google", result[0].Name);
            Assert.AreEqual("Bing", result[1].Name);
            Assert.AreEqual("Yandex", result[2].Name);
        }

        [TestMethod]
        public void Provider_Repository_Create()
        {
            //Arrange
            var c = new SearchProvider { Name = "Yahoo" };

            //Act
            var result = _repository.Add(c);
            _databaseDbContext.SaveChanges();

            var lst = _repository.GetAll().ToList();

            //Assert
            Assert.AreEqual(4, lst.Count);
            Assert.AreEqual("Yahoo", lst.Last().Name);
        }
    }
}
