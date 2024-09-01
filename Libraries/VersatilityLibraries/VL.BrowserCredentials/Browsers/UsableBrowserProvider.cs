using System.Reflection;

namespace VL.BrowserCredentials.Browsers
{

    public class UsableBrowserProvider
    {

        private UsableBrowserProvider() { }

        private static readonly IDictionary<string, AbstractBrowserSettings> _NameSettingDic = new Dictionary<string, AbstractBrowserSettings>();

        public static IDictionary<string, string> FindUsableBrowsers()
        {
            var usableBrowsers = new Dictionary<string, string>();

            var t = typeof(BrowserSettingsFactory);

            foreach (var pro in t.GetProperties(BindingFlags.Static | BindingFlags.NonPublic))
            {
                var val = pro.GetValue(t, null);

                if (val is not null)
                {
                    var setting = (AbstractBrowserSettings)val;

                    if (setting.ExistsBrowserCommonPath())
                    {
                        var proType = val.GetType();
                        var attribute = proType.GetCustomAttribute<BrowserInfo>();

                        if (attribute is not null)
                        {
                            usableBrowsers.Add(attribute.BrowserKey, attribute.BrowserName);
                            _NameSettingDic.Add(attribute.BrowserKey, setting);
                        }
                    }
                }
            }

            return usableBrowsers;
        }

        public static IDictionary<string, string> FindProfiles(string browserName)
        {
            var setting = _NameSettingDic[browserName];
            return setting.GetProfiles();
        }

    }

}
