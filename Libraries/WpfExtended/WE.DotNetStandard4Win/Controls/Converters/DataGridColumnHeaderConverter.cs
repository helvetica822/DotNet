using WE.DotNetStandard4Win.Controls.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace WE.DotNetStandard4Win.Controls.Converters
{

    public class DataGridColumnHeaderConverter
    {

        public static void ConvertDataGridHeaders(DataGridColumn column, IDictionary<string, DataGridColumnHeaderAttribute> headers)
        {
            var attribute = headers[column.Header.ToString()];

            column.Header = attribute.Text;
            if (attribute.Width != null) column.Width = (int)attribute.Width;
        }

        public static IDictionary<string, DataGridColumnHeaderAttribute> CollectDataGridHeadersAttributes(Type t)
        {
            var dic = new Dictionary<string, DataGridColumnHeaderAttribute>();

            foreach (var pro in t.GetProperties())
            {
                var attributes = pro.GetCustomAttributes(typeof(DataGridColumnHeaderAttribute), false);
                if (!attributes.Any()) throw new Exception($"プロパティ '{pro.Name}' に {nameof(DataGridColumnHeaderAttribute)} 属性がありません。");
                var attribute = attributes.First() as DataGridColumnHeaderAttribute;

                dic.Add(pro.Name, attribute);
            }

            return dic;
        }

    }

}
