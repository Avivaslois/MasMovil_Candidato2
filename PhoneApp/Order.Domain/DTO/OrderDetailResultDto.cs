using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Domain.DTO
{
    public class OrderDetailResultDto
    {
        public decimal PhonePrice { get; set; }
        public int PhoneId { get; set; }
        public int Quantity { get; set; }    
        public string PhoneName { get; set; }
        public decimal OrderDetailAmount { get { return Quantity * PhonePrice; } set { } }
    }
}
