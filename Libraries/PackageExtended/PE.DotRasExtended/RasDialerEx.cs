using DotRas;
using System;
using System.Linq;
using System.Net;

namespace PE.DotRasExtended
{

    public class RasDialerEx : IDisposable
    {

        private bool disposedValue;

        internal RasDialer Dialer { get; }

        internal bool Opend { get; private set; }

        internal bool Closed { get; private set; }

        internal string EntryName { get; private set; }

        private RasHandle Handler;

        internal RasDialerEx(string entryName) : this(entryName, null, null) { }

        internal RasDialerEx(string entryName, string userName, string password)
        {
            this.EntryName = entryName;

            this.Dialer = new RasDialer
            {
                EntryName = entryName,
                PhoneBookPath = RasPhoneBook.GetPhoneBookPath(RasPhoneBookType.User),
                AllowUseStoredCredentials = true
            };

            if (userName is null && password is null)
            {
                this.Dialer.AllowUseStoredCredentials = true;
            }
            else
            {
                this.Dialer.Credentials = new NetworkCredential(userName, password);
            }
        }

        internal void Dial()
        {
            // ReactiveCommandAsyncで呼び出す前提とし、DialAsyncは使用しない
            this.Handler = this.Dialer.Dial();

            this.Opend = true;
            this.Closed = !this.Opend;
        }

        internal void HangUp()
        {
            var conn = RasConnection.GetActiveConnections().FirstOrDefault(c => c.EntryName == this.EntryName);
            conn?.HangUp();

            this.Opend = false;
            this.Closed = !this.Opend;
        }

        private void Close()
        {
            this.Handler?.Close();

            this.Dialer?.Dispose();
            this.Handler?.Dispose();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: マネージド状態を破棄します (マネージド オブジェクト)
                    this.Close();
                }

                // TODO: アンマネージド リソース (アンマネージド オブジェクト) を解放し、ファイナライザーをオーバーライドします
                // TODO: 大きなフィールドを null に設定します
                disposedValue = true;
            }
        }

        // // TODO: 'Dispose(bool disposing)' にアンマネージド リソースを解放するコードが含まれる場合にのみ、ファイナライザーをオーバーライドします
        // ~RasDialerEx()
        // {
        //     // このコードを変更しないでください。クリーンアップ コードを 'Dispose(bool disposing)' メソッドに記述します
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // このコードを変更しないでください。クリーンアップ コードを 'Dispose(bool disposing)' メソッドに記述します
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

    }
}
