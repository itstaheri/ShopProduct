﻿using Shop.Domain.Entities.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Repositories.Product
{
    public interface IProductInventoryRepository : IGenericRepository<ProductInventoryModel>
    {
    }
}