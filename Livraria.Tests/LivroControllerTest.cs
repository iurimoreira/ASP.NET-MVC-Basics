using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Livraria.Repository;
using Moq;
using Livraria.Controllers;
using Livraria.Domain;
using System.Web.Mvc;
using Livraria.Models;
using System.Linq;

namespace Livraria.Tests
{
    /// <summary>
    /// Summary description for LivroControllerTest
    /// </summary>
    [TestClass]
    public class LivroControllerTest
    {
        public LivroControllerTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void IndexTestMethod()
        {
            var mockRepository = new Mock<ILivroRepository>();
            mockRepository.Setup(repository => repository.GetAllLivros())
            .Returns(new List<Livro>()
            {
                new Livro()
                {
                    id =1,
                    autor="Machado de Assis",
                    editora="Brasil",
                    titulo="Dom Casmurro",
                    ano=1888
                },
                new Livro()
                {
                    id =2,
                    autor="Machado de Assis",
                    editora="Brasil",
                    titulo="Memórias Póstumas de Brás Cubas",
                    ano=1888
                }
            });

            var controller = new LivroController(mockRepository.Object);

            var result = controller.Index();

            Assert.IsInstanceOfType(result, typeof(ViewResult));

            var viewResult = result as ViewResult;
            var model = viewResult.ViewData.Model;
            Assert.IsInstanceOfType(model, typeof(IEnumerable<LivroViewModel>));

            var livros = model as IEnumerable<LivroViewModel>;
            Assert.AreEqual(2, livros.Count());
        }

        
    }
}
