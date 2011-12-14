using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace PhoneApp85
{
    public static class EnumExtensions
    {
        public static T[] GetValues<T>(this T value)
        {
            Type type = value.GetType();

            if (!type.IsEnum)
            {
                string stringFormat = String.Format("Type '{0}' is not an enum", type.Name);
                throw new ArgumentException(stringFormat);
            }

            List<T> values = new List<T>();

            var fields = from field in type.GetFields()
                         where field.IsLiteral
                         select field;

            foreach (FieldInfo field in fields)
            {
                object val = field.GetValue(type);
                values.Add((T)val);
            }

            return values.ToArray();
        }
    }
}