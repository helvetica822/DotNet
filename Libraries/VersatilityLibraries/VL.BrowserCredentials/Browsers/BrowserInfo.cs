namespace VL.BrowserCredentials.Browsers
{

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class BrowserInfo : Attribute
    {

        public string BrowserKey { get; init; }

        public string BrowserName { get; init; }

        public BrowserInfo(string browserKey) : this(browserKey, browserKey) { }

        public BrowserInfo(string browserKey, string browserName)
        {
            this.BrowserKey = browserKey;
            this.BrowserName = browserName;
        }

    }

}
