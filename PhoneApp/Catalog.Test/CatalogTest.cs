using Catalog.API.Controllers;
using Catalog.Domain.ControllerWorkers;
using Catalog.Infrastructure.DTO;
using Catalog.Infrastructure.Models;
using Catalog.Infrastructure.Models.Catalog.Infrastructure.Models;
using Catalog.Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Catalog.Test
{
    [TestClass]
    public class CatalogTest
    {
        [TestMethod]
        public void getPhones()
        {
            var mock = new Mock<IRepository<Phone>>();
            Phone phone1 = new Phone { Id = 1, Name = "Samsung S9", Price = 200 };
            mock.Setup(m => m.FindAll()).Returns(new List<Phone> { phone1 });
            IPhoneCW _phoneWorker = new PhoneControllerWorker(mock.Object);

            List<PhoneDto> phones = _phoneWorker.obtenerTelefonos();

            Assert.AreNotEqual(0, phones.Count);
        }

        [TestMethod]
        public void getPhoneById()
        {
            var mock = new Mock<IRepository<Phone>>();
            Phone phone1 = new Phone { Id = 1, Name = "Samsung S9", Price = 200 };
            mock.Setup(m => m.FindById(1)).Returns(phone1);
            IPhoneCW _phoneWorker = new PhoneControllerWorker(mock.Object);

           
            Assert.IsNotNull(_phoneWorker.obtenerTelefonoPorId(1)); //Returns phone
            Assert.IsNull(_phoneWorker.obtenerTelefonoPorId(0)); //Returns null
        }

        [TestMethod]
        public void getPricesByIdsSuccess()
        {
            var mock = new Mock<IRepository<Phone>>();
            Phone phone1 = new Phone { Id = 1, Name = "Samsung S9", Price = 200 };
            Phone phone2= new Phone { Id = 2, Name = "Samsung S8", Price = 150 };
            List<Phone> mockResult = new List<Phone> { phone1, phone2 };
            List<int> ids = new List<int> { 1, 2 };
            mock.Setup(m => m.FindAll(It.IsAny<Expression<Func<Phone,bool>>>())).Returns(mockResult);

            IPhoneCW _phoneWorker = new PhoneControllerWorker(mock.Object);
            var result = _phoneWorker.obtenerPrecioPorId(ids);

            Assert.IsFalse(result.Any(x=> x.PhonePrice == 0));
        }

        [TestMethod]
        public void getPricesByIdsWithZeroPrice()
        {
            var mock = new Mock<IRepository<Phone>>();
            Phone phone1 = new Phone { Id = 1, Name = "Samsung S9", Price = 0 };
            Phone phone2 = new Phone { Id = 2, Name = "Samsung S8", Price = 150 };
            List<Phone> mockResult = new List<Phone> { phone1, phone2 };
            List<int> ids = new List<int> { 1, 2 };
            mock.Setup(m => m.FindAll(It.IsAny<Expression<Func<Phone, bool>>>())).Returns(mockResult);

            IPhoneCW _phoneWorker = new PhoneControllerWorker(mock.Object);
            var result = _phoneWorker.obtenerPrecioPorId(ids);

            Assert.IsTrue(result.Any(x => x.PhonePrice == 0));
        }

        [TestMethod]
        public void getPricesByIdsNotFound()
        {
            var mock = new Mock<IRepository<Phone>>();
            List<int> ids = new List<int> { 1, 2 };
            mock.Setup(m => m.FindAll(It.IsAny<Expression<Func<Phone, bool>>>())).Returns(new List<Phone>());

            IPhoneCW _phoneWorker = new PhoneControllerWorker(mock.Object);
            var result = _phoneWorker.obtenerPrecioPorId(ids);

            Assert.IsFalse(result.Any());
        }


    }
}
