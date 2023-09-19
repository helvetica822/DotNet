namespace VL.BrowserCredentials.Browsers
{

    internal static class BrowserSettingsFactory
    {

        internal static AbstractBrowserSettings GoogleChromeSettings => new GoogleChromeSettings();

        internal static AbstractBrowserSettings MicrosoftEdgeSettings => new MicrosoftEdgeSettings();

        internal static AbstractBrowserSettings OperaSettings => new OperaSettings();

    }

}
