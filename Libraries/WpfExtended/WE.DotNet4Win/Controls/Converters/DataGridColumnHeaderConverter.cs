using System.Windows.Controls;
using WE.DotNet4Win.Controls.Attributes;

namespace WE.DotNet4Win.Controls.Converters
{

    public class DataGridColumnHeaderConverter
    {

        public static void ConvertDataGridHeaders(DataGridColumn column, IDictionary<string, DataGridColumnHeaderAttribute> headers)
        {
            if (column is null) throw new Exception($"{nameof(column)} が NULL です。");

            var header = column.Header.ToString() ?? throw new Exception($"{nameof(column.Header)} が NULL です。");
            var attribute = headers[header];

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
                var attribute = (DataGridColumnHeaderAttribute)attributes.First();

                dic.Add(pro.Name, attribute);
            }

            return dic;
        }

    }

}
