using Order.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.ControllerWorkers
{
    public interface IOrderCW
    {
        Task<bool> procesarPedido(OrderDto order);
        Task<List<OrderDetailResultDto>> obtenerPrecios(List<OrderDetailDto> details);
        List<OrderDetailResultDto> completarInformacion(OrderDto order, List<OrderDetailResultDto> detailsResults);
        string componerMensaje(CustomerDto customer, List<OrderDetailResultDto> detailsResults);
    }
}
