using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Mapper
{
    public class GeneralMapper
    {
        public static TDestination Map<TSource, TDestination>(TSource source) where TDestination : new()
        {
            TDestination destination = new TDestination();

            PropertyInfo[] sourceProperties = typeof(TSource).GetProperties();
            PropertyInfo[] destinationProperties = typeof(TDestination).GetProperties();

            foreach (var sourceProperty in sourceProperties)
            {
                foreach (var destinationProperty in destinationProperties)
                {
                    if (sourceProperty.Name == destinationProperty.Name &&
                        destinationProperty.CanWrite &&
                        destinationProperty.PropertyType == sourceProperty.PropertyType)
                    {
                        var value = sourceProperty.GetValue(source);
                        destinationProperty.SetValue(destination, value);
                    }
                }
            }

            return destination;
        }
    }
}
