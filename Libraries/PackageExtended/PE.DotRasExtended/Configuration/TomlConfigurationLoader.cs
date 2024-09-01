using Nett;
using System.IO;
using System.Reflection;

namespace PE.DotRasExtended.Configuration
{

    public class TomlConfigurationLoader
    {

        private TomlConfigurationLoader() { }

        public static bool LoadVpnConfiguration()
        {
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), Properties.Resources.ConfigTomlFileName);

            if (File.Exists(path))
            {
                var toml = Toml.ReadFile(path);

                var vpnSettings = toml.Get<TomlTable>(nameof(VpnSettings));
                var serverAddress = vpnSettings.Get<string>(nameof(VpnSettings.ServerAddress));
                var preSharedKey = vpnSettings.Get<string>(nameof(VpnSettings.PreSharedKey));

                if (!(string.IsNullOrWhiteSpace(serverAddress) || string.IsNullOrWhiteSpace(preSharedKey)))
                {
                    VpnSettingsManager.InitializeSettings(serverAddress, preSharedKey);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                CreateInitialConfigFile(path);

                return false;
            }
        }

        private static void CreateInitialConfigFile(string path)
        {
            var toml = Toml.Create();

            var vpnSettings = Toml.Create();
            vpnSettings.Add(nameof(VpnSettings.ServerAddress), string.Empty);
            vpnSettings.Add(nameof(VpnSettings.PreSharedKey), string.Empty);

            toml.Add(nameof(VpnSettings), vpnSettings);

            Toml.WriteFile(toml, path);
        }

    }

}
