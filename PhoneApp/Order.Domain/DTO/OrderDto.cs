using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Domain.DTO
{
    public class OrderDto
    {
        public CustomerDto Customer { get; set; }
        public List<OrderDetailDto> OrderDetails { get; set; }
    }
}
