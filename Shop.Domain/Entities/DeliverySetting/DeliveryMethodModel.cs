﻿using Shop.Domain.Entities.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities.DeliverySetting
{
    public class DeliveryMethodModel : BaseEntity
    {
        public DeliveryMethodModel(string title, long inventoryId, int? sendingCapasity, string? description) 
        {
            Title = title;
            InventoryId = inventoryId;
            SendingCapasity = sendingCapasity;
            Description = description;
        }

        public void Edit(string title, long inventoryId, int? sendingCapasity, string? description)
        {
            Title = title;
            InventoryId = inventoryId;
            SendingCapasity = sendingCapasity;
            Description = description;
        }

        public string Title { get; set; }
        public long InventoryId { get; set; }
        public List<InventoryModel> Inventories { get; set; }
        public int? SendingCapasity { get; set; }
        public string? Description { get; set; }
    }
}
