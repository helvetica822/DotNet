using ED.VersatilityExtensions.CollectionExtensions.Mapper;

namespace VL.BrowserCredentials.Tables
{

    public record class Logins
    {

        [PropertyMapper("origin_url")]
        public string OriginUrl { get; init; }

        [PropertyMapper("username_value")]
        public string UserNameValue { get; init; }

        [PropertyMapper("password_value")]
        public byte[]? PasswordValue { get; init; }

        [PropertyMapper(true)]
        public string Password { get; set; }

        public Logins()
        {
            // 警告回避のため PasswordValue 以外は空文字で初期化
            this.OriginUrl = string.Empty;
            this.UserNameValue = string.Empty;
            this.PasswordValue = null;
            this.Password = string.Empty;
        }
    }

}
