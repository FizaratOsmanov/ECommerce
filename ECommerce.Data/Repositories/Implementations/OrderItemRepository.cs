﻿using ECommerce.Core.Entities;
using ECommerce.Data.DAL;
using ECommerce.Data.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data.Repositories.Implementations
{
    public class OrderItemRepository:Repository<OrderItem> ,IOrderItemRepository
    {
        public OrderItemRepository(AppDbContext appDbContext) : base(appDbContext) { }
    }
}
