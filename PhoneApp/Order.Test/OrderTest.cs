using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Order.Domain.ControllerWorkers;
using Order.Domain.DTO;
using Order.Infrastructure.APIHelper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.Test
{
    [TestClass]
    public class OrderTest
    {
        [TestMethod]
        public void getPhonePrices()
        {
            var mock = new Mock<APIHelper>();
            List<int> ids = new List<int> { 1, 2 };
            List<OrderDetailDto> parameter = new List<OrderDetailDto>
            {
                new OrderDetailDto { PhoneId = 1, PhoneName = "Samsung", Quantity = 2 },
                new OrderDetailDto { PhoneId = 2, PhoneName = "IPhone", Quantity = 1 },
            };
            OrderDetailResultDto odrd1 = new OrderDetailResultDto { PhoneId = 1, PhonePrice = 100 };
            OrderDetailResultDto odrd2 = new OrderDetailResultDto { PhoneId = 2, PhonePrice = 200 };
            List<OrderDetailResultDto> mockResult = new List<OrderDetailResultDto> { odrd1, odrd2 };
            mock.Setup(m=> m.Post<List<OrderDetailResultDto>>("Phones", ids)).Returns(Task.FromResult(mockResult));
            IOrderCW _phoneWorker = new OrderCW(mock.Object);

            var result = _phoneWorker.obtenerPrecios(parameter).Result;

            Assert.IsTrue(result.Any());
        }

        [TestMethod]
        public void setOrderPrices()
        {
            OrderDto order = new OrderDto
            {
                Customer = new CustomerDto { Name = "Test", Surname = "Surname", Email = "test@mail.com" },
                OrderDetails = new List<OrderDetailDto>
                {
                    new OrderDetailDto {PhoneId = 1, PhoneName ="Samsung", Quantity = 1},
                }
            };
            List<OrderDetailResultDto> detailResult = new List<OrderDetailResultDto>
            {
                new OrderDetailResultDto {PhoneId = 1, PhonePrice = 900}
            };
            IOrderCW _phoneWorker = new OrderCW();

            var result = _phoneWorker.completarInformacion(order, detailResult);

            Assert.IsFalse(result.Any(x=> x.Quantity == 0 || string.IsNullOrEmpty(x.PhoneName)));
        }
    }
}
