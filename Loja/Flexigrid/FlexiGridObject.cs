using System;
using System.Collections.Generic;
using System.Reflection;

namespace Loja.Flexigrid
{
    public class FlexiGridObject
    {
        public int page;
        public int total;
        public List<FlexiGridRow> rows = new List<FlexiGridRow>();

        protected Dictionary<string, string> GetPropertyList(object obj)
        {
            Dictionary<string, string> propertyList = new Dictionary<string, string>();
            Type type = obj.GetType();
            PropertyInfo[] properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach (PropertyInfo property in properties)
            {                
                object o = property;
                propertyList.Add(property.Name, o == null ? "" : o.ToString().ToUpper());
            }
            return propertyList;
        }
    }
}