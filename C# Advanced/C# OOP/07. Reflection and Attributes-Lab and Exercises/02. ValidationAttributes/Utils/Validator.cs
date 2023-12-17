using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ValidationAttributes.Attributes;

namespace ValidationAttributes.Utils
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            Type objectType = obj.GetType();
            PropertyInfo[] properties = objectType
                .GetProperties()
                .Where(p => p.CustomAttributes
                .Any(x => typeof(MyValidationAttribute)
                .IsAssignableFrom(x.AttributeType)))
                .ToArray();

            foreach (PropertyInfo property in properties)
            {
                IEnumerable<MyValidationAttribute> attributes = property
                    .GetCustomAttributes()
                    .Where(x => typeof(MyValidationAttribute)
                    .IsAssignableFrom(x.GetType()))
                    .Cast<MyValidationAttribute>();

                foreach (MyValidationAttribute attribute in attributes)
                {
                    if (!attribute.IsValid(property.GetValue(obj)))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
