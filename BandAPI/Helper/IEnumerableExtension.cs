using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace BandAPI.Helper
{
    public static class IEnumerableExtension
    {
        public static IEnumerable<ExpandoObject> ShapeData<T>(this IEnumerable<T> source,string fields)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            var objectList = new List<ExpandoObject>();
            var propertyInfoList = new List<PropertyInfo>();
            if(string.IsNullOrWhiteSpace(fields))
            {
                var propertyInfos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

                propertyInfoList.AddRange(propertyInfos);
            }
            else
            {
                var fieldsAfterSplit = fields.Split(",");
                foreach(var f in fieldsAfterSplit)
                {
                    var propertyName = fields.Trim();
                    var propertyInfo= typeof(T).GetProperty(propertyName,BindingFlags.Public | BindingFlags.Instance);
                    if (propertyInfo == null)
                        throw new Exception(propertyName.ToString() + "Không tìm thấy");
                    propertyInfoList.Add(propertyInfo);
                }
            }
            foreach (T sourceObject in source)
            {
                var dataShapedObject = new ExpandoObject();

                foreach (var propertyInfo in propertyInfoList)
                {
                    var propertyValue = propertyInfo.GetValue(sourceObject);

                    ((IDictionary<string, object>)dataShapedObject)
                                    .Add(propertyInfo.Name, propertyValue);
                }

                objectList.Add(dataShapedObject);
            }

            return objectList;
        }
    }
}
