﻿using System;
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
using FluentAssertions;

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
        public void Metodo_Create_Retorna_View_Quando_Model_Is_Invalid()
        {
            // Arrange
            var mockRepository = new Mock<ILivroRepository>();
            var controller = new LivroController(mockRepository.Object);
            controller.ModelState.AddModelError("", "Erro de validação.");

            // Act
            var actionResult = controller.Create(new LivroViewModel());

            // Assert
            actionResult.Should().BeOfType<ViewResult>();
        }
    }
}
