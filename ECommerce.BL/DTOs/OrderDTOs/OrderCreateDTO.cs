using ECommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BL.DTOs.OrderDTOs
{
    public class OrderCreateDTO
    {
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
