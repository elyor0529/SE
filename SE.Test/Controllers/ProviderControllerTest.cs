using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SE.Demo.Controllers;
using SE.Model.Entity;
using SE.Service;

namespace SE.Test.Controllers
{
    [TestClass]
    public class ProviderControllerTest
    {
        private ProviderController _controller;
        private List<SearchProvider> _listCountry;
        private Mock<IProviderService> _serviceMock;

        [TestInitialize]
        public void Initialize()
        {
            _serviceMock = new Mock<IProviderService>();
            _controller = new ProviderController(_serviceMock.Object);
            _listCountry = new List<SearchProvider>
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
            _serviceMock.Setup(x => x.GetAll()).Returns(_listCountry);

            //Act
            var result = ((ViewResult) _controller.Index()).Model as List<SearchProvider>;

            //Assert
            Assert.AreEqual(result.Count, 3);
            Assert.AreEqual("Google", result[0].Name);
            Assert.AreEqual("Bing", result[1].Name);
            Assert.AreEqual("Yandex", result[2].Name);
        }

        [TestMethod]
        public void Valid_Provider_Create()
        {
            //Arrange
            var c = new SearchProvider {Name = "Google"};

            //Act
            var result = (RedirectToRouteResult) _controller.Create(c);

            //Assert 
            _serviceMock.Verify(m => m.Create(c), Times.Once);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [TestMethod]
        public void Invalid_Provider_Create()
        {
            // Arrange
            var c = new SearchProvider {Name = ""};
            _controller.ModelState.AddModelError("Error", "Something went wrong");

            //Act
            var result = (ViewResult) _controller.Create(c);

            //Assert
            _serviceMock.Verify(m => m.Create(c), Times.Never);
            Assert.AreEqual("", result.ViewName);
        }
    }
}