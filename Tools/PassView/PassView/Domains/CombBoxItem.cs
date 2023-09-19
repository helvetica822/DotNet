namespace PassView.Domains
{

    public class CombBoxItem
    {

        public string DisplayName { get; }

        public string Value { get; }

        public CombBoxItem(string displayName, string value)
        {
            this.DisplayName = displayName;
            this.Value = value;
        }

    }

}
