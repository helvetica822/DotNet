using System;

namespace PE.DotRasExtended.Configuration
{

    internal class VpnSettingsManager
    {

        private VpnSettingsManager() { }

        private static VpnSettings _Settings = null;

        internal static string ServerAddress
        {
            get
            {
                return _Settings.ServerAddress;
            }
        }

        internal static string PreSharedKey
        {
            get
            {
                return _Settings.PreSharedKey;
            }
        }

        internal static void InitializeSettings(string serverAddress, string preSharedKey)
        {
            if (_Settings is null)
            {
                _Settings = new VpnSettings
                {
                    ServerAddress = serverAddress,
                    PreSharedKey = preSharedKey
                };
            }
            else
            {
                throw new Exception(Properties.Resources.ErrorMessage006);
            }
        }

    }

}
