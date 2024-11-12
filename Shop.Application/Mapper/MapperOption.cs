using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Mapper
{
    public sealed class MapperOption
    {
        public MapperOption(string sourceFieldName, string destinationFieldName)
        {
            SourceFieldName = sourceFieldName;
            DestinationFieldName = destinationFieldName;
        }

        public string SourceFieldName { get; set; }
        public string DestinationFieldName { get; set; }

    }
}
