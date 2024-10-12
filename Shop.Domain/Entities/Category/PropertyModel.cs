using Shop.Domain.Entities.Product;
using Shop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities.Category
{
    public class PropertyModel : BaseEntity
    {
        public PropertyModel(string name, MeasurmentsUnit measurmentUnit)
        {
            Name = name;
            MeasurmentUnit = measurmentUnit;
        }

        public void Edit(string name, MeasurmentsUnit measurmentUnit)
        {
            Name = name;
            MeasurmentUnit = measurmentUnit;
        }


    public string Name {  get; private set; }
    public MeasurmentsUnit MeasurmentUnit {  get; private set; }
    public List<CategoryPropertyModel> CategoryProperties { get; private set; }
    public List<ProductPropertyModel> ProductProperties { get; private set; }
    }

}
