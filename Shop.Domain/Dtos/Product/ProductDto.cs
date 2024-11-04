using Shop.Domain.Dtos.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Dtos.Product
{
    public record ProductDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long CategoryId {  get; set; }
        public string ExteraDescription { get; set; }
        public string MainPicture { get; set; }
        public double Amount { get; set; }
        public bool IsAvaiable { get; set; }
        public List<ColorDto> Colors { get; set; }
    }
}
