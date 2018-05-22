using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SE.Model.Entity;
using SE.Repository;
using SE.Repository.Infrastructure;
using SE.Service;

namespace SE.Test.Services
{
    [TestClass]
    public class ProverServiceTest
    {
        private List<SearchProvider> _list;
        private Mock<IProviderRepository> _mockRepository;
        private Mock<IUnitOfWork> _mockUnitWork;
        private IProviderService _service;

        [TestInitialize]
        public void Initialize()
        {
            _mockRepository = new Mock<IProviderRepository>();
            _mockUnitWork = new Mock<IUnitOfWork>();
            _service = new ProviderService(_mockUnitWork.Object, _mockRepository.Object);
            _list = new List<SearchProvider>
            {
                new SearchProvider {Id = 1, Name = "Google"},
                new SearchProvider {Id = 2, Name = "Bing"},
                new SearchProvider {Id = 3, Name = "Yandex"}
            };
        }

        [TestMethod]
        public void Provider_Get_All()
        {
            //Arrange
            _mockRepository.Setup(x => x.GetAll()).Returns(_list);

            //Act
            var results = _service.GetAll() as List<SearchProvider>;

            //Assert
            Assert.IsNotNull(results);
            Assert.AreEqual(3, results.Count);
        }


        [TestMethod]
        public void Can_Add_Provider()
        {
            //Arrange
            var Id = 1;
            var emp = new SearchProvider {Name = "Google"};
            _mockRepository.Setup(m => m.Add(emp)).Returns((SearchProvider e) =>
            {
                e.Id = Id;
                return e;
            });

            //Act
            _service.Create(emp);

            //Assert
            Assert.AreEqual(Id, emp.Id);
            _mockUnitWork.Verify(m => m.Commit(), Times.Once);
        }
    }
}