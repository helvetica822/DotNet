using ClosedXML.Excel;
using PassView.Domains;
using Prism.Mvvm;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using VL.BrowserCredentials.Browsers;
using VL.BrowserCredentials.EncryptionDecryption;
using WE.DotNet4Win.Controls.Attributes;

namespace PassView.Models
{

    public class MainWindowModel : BindableBase
    {

        private IEnumerable<BrowserCredential> _BrowserCredentials = new List<BrowserCredential>();

        public IEnumerable<BrowserCredential> BrowserCredentials
        {
            get => this._BrowserCredentials;
            set => this.SetProperty(ref this._BrowserCredentials, value);
        }

        public IDictionary<string, string> FindUsableBrowsers()
        {
            return UsableBrowserProvider.FindUsableBrowsers();
        }

        public IDictionary<string, string> FindProfiles(string browserName)
        {
            return UsableBrowserProvider.FindProfiles(browserName);
        }

        public void SelectBrowserCredentials(string browser, string profile)
        {
            var logins = SqliteRecordsProvider.SelectLoginsRecordsFrom(browser, profile);

            this.BrowserCredentials = logins is null
                ? Enumerable.Empty<BrowserCredential>()
                : logins.Select(l => new BrowserCredential(l.OriginUrl, l.UserNameValue, l.Password));
        }

        public void WriteBrowserCredentialsToExcel(string filePath)
        {
            var properties = typeof(BrowserCredential).GetProperties();
            var rows = this.CreateExcelOutputRows(properties);

            this.WriteToExcel(filePath, rows, properties.Length);
        }

        private IEnumerable<IEnumerable<string>> CreateExcelOutputRows(PropertyInfo[] properties)
        {
            var headerRow = new List<string>();

            foreach (var pro in properties)
            {
                var attribute = pro.GetCustomAttribute(typeof(DataGridColumnHeaderAttribute));

                if (attribute is not null)
                {
                    var header = ((DataGridColumnHeaderAttribute)attribute).Text;
                    headerRow.Add(header);
                }
            }

            var rows = new List<List<string>>() { headerRow };

            foreach (var record in this.BrowserCredentials)
            {
                var row = new List<string>();

                foreach (var pro in properties)
                {
                    var value = pro.GetValue(record);
                    row.Add((value is null) ? string.Empty : value.ToString()!);
                }

                rows.Add(row);
            }

            return rows;
        }

        private void WriteToExcel(string filePath, IEnumerable<IEnumerable<string>> rows, int columnCount)
        {
            using var book = new XLWorkbook();
            book.Style.Font.FontName = "Meiryo UI";
            book.Style.Font.FontSize = 10;

            var sheet = book.AddWorksheet("ブラウザ認証情報");

            sheet.Cell("A1").InsertData(rows);

            sheet.Range(1, 1, rows.Count(), columnCount).Style.Border.InsideBorder = XLBorderStyleValues.Thin;
            sheet.Range(1, 1, rows.Count(), columnCount).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            sheet.Range(1, 1, 1, columnCount).Style.Fill.BackgroundColor = XLColor.AliceBlue;

            sheet.ColumnsUsed().AdjustToContents();

            for (var i = 1; i < columnCount; i++)
            {
                sheet.Column(i).Width = sheet.Column(i).Width * 1.5;
            }

            book.SaveAs(filePath);
        }

    }

}
