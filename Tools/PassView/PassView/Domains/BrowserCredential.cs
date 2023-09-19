using WE.DotNet4Win.Controls.Attributes;

namespace PassView.Domains
{

    public class BrowserCredential
    {

        [DataGridColumnHeader("URL", 450)]
        public string Url { get; }

        [DataGridColumnHeader("ユーザ名", 300)]
        public string UserName { get; }

        [DataGridColumnHeader("パスワード", 150)]
        public string Password { get; }

        public BrowserCredential(string url, string userName, string password)
        {
            this.Url = url;
            this.UserName = userName;
            this.Password = password;
        }

    }

}
