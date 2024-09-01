using WE.DotNetStandard4Win.Controls.Attributes;

namespace vs4w.Domains
{

    public class UsedLibrary
    {

        [DataGridColumnHeader("ライブラリ", 300)]
        public string LibraryName { get; }

        [DataGridColumnHeader("バージョン", 100)]
        public string Version { get; }

        [DataGridColumnHeader("ライセンス", 100)]
        public string License { get; }

        public UsedLibrary(string libraryName, string version, string license)
        {
            this.LibraryName = libraryName;
            this.Version = version;
            this.License = license;
        }

    }

}
