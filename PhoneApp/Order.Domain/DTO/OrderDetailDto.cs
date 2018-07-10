using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Domain.DTO
{
    public class OrderDetailDto
    {
        public int PhoneId { get; set; }

        public string PhoneName { get; set; }
        public int Quantity { get; set; }

    }
}
