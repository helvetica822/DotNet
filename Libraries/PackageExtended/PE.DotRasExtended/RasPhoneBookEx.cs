using DotRas;
using PE.DotRasExtended.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace PE.DotRasExtended
{

    internal class RasPhoneBookEx : IDisposable
    {

        private bool disposedValue;

        internal RasPhoneBook Book { get; }

        internal RasPhoneBookEx()
        {
            this.Book = new RasPhoneBook();
            this.Open();
        }

        private void Open()
        {
            this.Book.Open(RasPhoneBook.GetPhoneBookPath(RasPhoneBookType.User));
        }

        internal bool UsableL2TP()
        {
            return this.FindL2TPDevices().Any();
        }

        private IEnumerable<RasDevice> FindL2TPDevices()
        {
            return RasDevice.GetDevices().Where(d => d.Name.Contains("(L2TP)") && d.DeviceType == RasDeviceType.Vpn);
        }

        internal bool Contains(string entryName)
        {
            return this.Book.Entries.Contains(entryName);
        }

        internal void CreateL2TP(string entryName, string userName, string password)
        {
            // VPNのエントリ作成
            var device = this.FindL2TPDevices().First();
            var entry = RasEntry.CreateVpnEntry(entryName, VpnSettingsManager.ServerAddress, RasVpnStrategy.L2tpOnly, device);

            // 切断するまでの待ち時間(秒)
            // Windows標準
            entry.IdleDisconnectSeconds = 0;

            // 接続再試行回数
            // Windows標準
            entry.RedialCount = 3;

            // 接続再試行間隔(秒)
            // Windows標準
            entry.RedialPause = 60;

            // LCP拡張の無効化
            entry.Options.DisableLcpExtensions = false;

            // ソフトウェア圧縮の無効化
            entry.Options.SoftwareCompression = false;

            // 暗号化の有効化
            entry.EncryptionType = RasEncryptionType.Require;
            entry.Options.RequireEncryptedPassword = true;
            entry.Options.RequireDataEncryption = false;

            // マルチリンクの無効化
            entry.Options.DoNotNegotiateMultilink = true;

            // 使用しない認証プロトコルの無効化
            entry.Options.RequireChap = false;
            entry.Options.RequireEap = false;
            entry.Options.RequirePap = false;
            entry.Options.RequireMSChap = false;
            entry.Options.RequireMSChap2 = false;
            entry.Options.RequireMSEncryptedPassword = false;
            entry.Options.RequireSpap = false;
            entry.Options.RequireWin95MSChap = false;

            // 自動再接続の無効化
            entry.Options.ReconnectIfDropped = true;

            // 事前共有鍵を使用
            entry.Options.UsePreSharedKey = true;

            // VPN先のゲートウェイをデフォルトゲートウェイとして使用しない
            entry.Options.RemoteDefaultGateway = false;

            // 資格情報を保存
            entry.Options.CacheCredentials = true;

            this.Book.Entries.Add(entry);

            // 事前共有鍵を登録
            entry.UpdateCredentials(RasPreSharedKey.Client, VpnSettingsManager.PreSharedKey);

            // ユーザ名とパスワードを登録
            entry.UpdateCredentials(new NetworkCredential(userName, password));
        }

        internal void RemoveEntry(string entryName)
        {
            this.Book.Entries.Remove(entryName);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: マネージド状態を破棄します (マネージド オブジェクト)
                    this.Book.Dispose();
                }

                // TODO: アンマネージド リソース (アンマネージド オブジェクト) を解放し、ファイナライザーをオーバーライドします
                // TODO: 大きなフィールドを null に設定します
                disposedValue = true;
            }
        }

        // // TODO: 'Dispose(bool disposing)' にアンマネージド リソースを解放するコードが含まれる場合にのみ、ファイナライザーをオーバーライドします
        // ~RasPhoneBookEntry()
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
