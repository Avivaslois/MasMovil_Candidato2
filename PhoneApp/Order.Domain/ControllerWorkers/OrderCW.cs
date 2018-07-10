using System;
using System.Collections.Generic;
using System.Text;
using Order.Domain.DTO;
using System.Linq;
using Order.Infrastructure.APIHelper;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace Order.Domain.ControllerWorkers
{
    public class OrderCW : IOrderCW
    {
        private IOptions<PhoneApiConfiguration> settings;
        private APIHelper apiCommunication;

        public OrderCW(IOptions<PhoneApiConfiguration> settings)
        {
            //Settings loaded by DI on Order.API startup file
            this.settings = settings;
            var url = settings.Value.url;
            if(string.IsNullOrEmpty(url))
            {
                url = "http://127.0.0.1:8081/api/";
            }
            
            
            apiCommunication = new APIHelper(url);
        }
        public OrderCW(APIHelper mockedAPI)
        {
            apiCommunication = mockedAPI;
        }

        public OrderCW() { }


        public async Task<List<OrderDetailResultDto>> obtenerPrecios(List<OrderDetailDto> details)
        {
            List<int> telefonosIdS = details.Select(x => x.PhoneId).Distinct().ToList();
            
            var response = await apiCommunication.Post<List<OrderDetailResultDto>>("phones", telefonosIdS);

            return response;
        }

        public async Task<bool> procesarPedido(OrderDto pedido)
        {
            var precios = await obtenerPrecios(pedido.OrderDetails);

            precios = completarInformacion(pedido, precios);

            var mensaje = componerMensaje(pedido.Customer, precios);

            Console.Write(mensaje);

            return true;
        }
        public string componerMensaje(CustomerDto customer, List<OrderDetailResultDto> detailsResults)
        {
            string message = string.Empty;

            message += $@"{Environment.NewLine}{Environment.NewLine}{Environment.NewLine}
                          Customer Info: {customer.Name} {customer.Surname} ({customer.Email} 
                          {Environment.NewLine})
                          ------------------------------------------------
                          {Environment.NewLine}";

            foreach (var item in detailsResults)
            {

                message += $@"Order Detail: 
                                Phone Name: {item.PhoneName}
                                Quantity:   {item.Quantity}
                                Price:      {item.PhonePrice}
                                Subtotal:   {item.OrderDetailAmount} {Environment.NewLine}";
            }

            message += $"TOTAL AMOUNT: {detailsResults.Sum(x => x.OrderDetailAmount)}";

            return message;
        }



        public List<OrderDetailResultDto> completarInformacion(OrderDto order, List<OrderDetailResultDto> detalles)
        {
            try
            {
                detalles.ForEach(x => {
                    var originalOD = order.OrderDetails.FirstOrDefault(y => y.PhoneId == x.PhoneId);
                    x.Quantity = originalOD.Quantity;
                    x.PhoneName = originalOD.PhoneName;
                });

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return detalles;
        }

    }
}
