namespace vs4w.Models
{

    interface IMainWindowModel
    {

        void LoadUsedLibraries();

        void ConnectTestAsync(string userName, string password);

        void RegisterVpnAsync(string entryName, string userName, string password);

        void LoadVpnConfiguration();

    }

}
