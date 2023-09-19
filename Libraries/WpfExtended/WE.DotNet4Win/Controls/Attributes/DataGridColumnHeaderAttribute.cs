namespace WE.DotNet4Win.Controls.Attributes
{

    [AttributeUsage(AttributeTargets.Property)]
    public class DataGridColumnHeaderAttribute : Attribute
    {

        public string Text { get; }

        public int? Width { get; }

        public DataGridColumnHeaderAttribute(string text) : this(text, 0) { }

        public DataGridColumnHeaderAttribute(string text, int width)
        {
            this.Text = text;
            if (width > 0) this.Width = width;
        }

    }

}
