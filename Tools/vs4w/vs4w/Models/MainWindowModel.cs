using PE.DotRasExtended;
using PE.DotRasExtended.Configuration;
using PE.DotRasExtended.Results;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using vs4w.Domains;

namespace vs4w.Models
{

    public class MainWindowModel : BindableBase, IMainWindowModel
    {

        private IEnumerable<UsedLibrary> _Libraries;
        private DialResult _TestResult;
        private CreateEntryResult _RegisterResult;
        private bool _LoadedConfiguration;

        public IEnumerable<UsedLibrary> Libraries
        {
            get => this._Libraries;
            set => this.SetProperty(ref this._Libraries, value);
        }

        public DialResult TestResult
        {
            get => this._TestResult;
            set => this.SetProperty(ref this._TestResult, value);
        }

        public CreateEntryResult RegisterResult
        {
            get => this._RegisterResult;
            set => this.SetProperty(ref this._RegisterResult, value);
        }

        public bool LoadedConfiguration
        {
            get => this._LoadedConfiguration;
            set => this.SetProperty(ref this._LoadedConfiguration, value);
        }

        public void LoadUsedLibraries()
        {
            var libraries = new List<UsedLibrary>
            {
                new UsedLibrary("Costura.Fody", "5.7.0", "MIT"),
                new UsedLibrary("DotRas.for.Win8", "1.3.0", "GPL v3"),
                new UsedLibrary("MahApps.Metro", "2.4.9", "MIT"),
                new UsedLibrary("MaterialDesignThemes.MahApps", "0.3.0", "MIT"),
                new UsedLibrary("Nett", "0.15.0", "MIT"),
                new UsedLibrary("Prism.Unity", "8.1.97", "MIT"),
                new UsedLibrary("ReactiveProperty.WPF", "9.3.1", "MIT"),
                new UsedLibrary("System.ComponentModel.Annotations", "5.0.0", "MIT"),
                new UsedLibrary("System.Reactive", "6.0.0", "MIT")
            };

            this.Libraries = libraries;
        }

        public void ConnectTestAsync(string userName, string password)
        {
            var entryName = DateTime.Now.ToString("yyyyMMddHHmmss");
            this.TestResult = RasPhoneEntry.ConnectTestAsync($"VpnTest{entryName}", userName, password);
        }

        public void RegisterVpnAsync(string entryName, string userName, string password)
        {
            this.RegisterResult = RasPhoneEntry.CreateVpnL2TPAsync(entryName, userName, password);
        }

        public void LoadVpnConfiguration()
        {
            this._LoadedConfiguration = TomlConfigurationLoader.LoadVpnConfiguration();
        }

    }

}
