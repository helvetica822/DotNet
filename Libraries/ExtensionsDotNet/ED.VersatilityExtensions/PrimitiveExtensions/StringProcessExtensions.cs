using System.Diagnostics;

namespace ED.VersatilityExtensions.PrimitiveExtensions
{

    /// <summary>
    /// プロセスに関する <see cref="string"/> の拡張機能を提供します。
    /// </summary>
    public static class StringProcessExtensions
    {

        #region Start

        /// <summary>
        /// この文字列の名称を持つ外部アプリケーションを起動します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="args">コマンドライン引数の配列。</param>
        public static void StartProcess(this string value, params string[] args) => _ = value.StartProcess(null, args);

        /// <summary>
        /// この文字列の名称を持つ外部アプリケーションを起動します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="createNoWindow">ウィンドウを表示しない場合は true。それ以外の場合は false。</param>
        /// <param name="args">コマンドライン引数の配列。</param>
        public static void StartProcess(this string value, bool createNoWindow, params string[] args) => _ = value.StartProcess(null, createNoWindow, args);

        /// <summary>
        /// この文字列の名称を持つ外部アプリケーションを起動します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="milliseconds">終了を待機する秒数(ミリ秒)。</param>
        /// <returns>外部アプリケーションの終了コード。</returns>
        public static int? StartProcess(this string value, int? milliseconds) => value.StartProcess(milliseconds, null);

        /// <summary>
        /// この文字列の名称を持つ外部アプリケーションを起動します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="milliseconds">終了を待機する秒数(ミリ秒)。</param>
        /// <param name="args">コマンドライン引数の配列。</param>
        /// <returns>外部アプリケーションの終了コード。</returns>
        public static int? StartProcess(this string value, int? milliseconds, params string[]? args) => value.StartProcess(milliseconds, false, args);

        /// <summary>
        /// この文字列の名称を持つ外部アプリケーションを起動します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="milliseconds">終了を待機する秒数(ミリ秒)。</param>
        /// <param name="createNoWindow">ウィンドウを表示しない場合は true。それ以外の場合は false。</param>
        /// <param name="args">コマンドライン引数の配列。</param>
        /// <returns>外部アプリケーションの終了コード。</returns>
        public static int? StartProcess(this string value, int? milliseconds, bool createNoWindow, params string[]? args)
        {
            var psi = new ProcessStartInfo
            {
                FileName = value,
                CreateNoWindow = createNoWindow,
                Arguments = CreateCommandLineArgsString(args)
            };

            int? exitCode = null;

            using var p = Process.Start(psi);
            if (milliseconds is not null)
            {
                _ = p?.WaitForExit((int)milliseconds);
                if (p is not null)
                {
                    if (p.HasExited) exitCode = p.ExitCode;
                }
            }

            return exitCode;
        }

        #endregion

        #region Get

        /// <summary>
        /// この文字列のプロセス名を共有するローカルコンピューター上のすべてのプロセスリソースを取得します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <returns>プロセスリソースの配列。</returns>
        public static Process[] GetProcessesByName(this string value) => Process.GetProcessesByName(value);

        /// <summary>
        /// この文字列のプロセス名を共有するリモートコンピューター上のすべてのプロセスリソースを取得します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="machineName">リモートコンピューター名。</param>
        /// <returns>プロセスリソースの配列。</returns>
        public static Process[] GetProcessesByName(this string value, string machineName) => Process.GetProcessesByName(value, machineName);

        #endregion

        #region Kill

        /// <summary>
        /// この文字列のプロセス名を共有するローカルコンピューターからすべてのプロセスリソースを終了します。
        /// </summary>
        /// <param name="value">文字列。</param>
        public static void KillSameNameProcesses(this string value)
        {
            foreach (Process pro in Process.GetProcessesByName(value))
            {
                pro.Kill();
            }
        }

        #endregion

        #region Exists

        /// <summary>
        /// この文字列のプロセス名がローカルコンピューターに存在するか判断します。
        /// </summary>
        /// <param name="value">文字列。</param>
        public static bool ExistsProcessesByName(this string value)
        {
            var p = value.GetProcessesByName();
            return p.Length > 0;
        }

        /// <summary>
        /// この文字列のプロセス名がリモートコンピューターに存在するか判断します。
        /// </summary>
        /// <param name="value">文字列。</param>
        /// <param name="machineName">リモートコンピューター名。</param>
        public static bool ExistsProcessesByName(this string value, string machineName)
        {
            var p = value.GetProcessesByName(machineName);
            return p.Length > 0;
        }

        #endregion

        // ↓ Private method↓

        #region Arguments

        /// <summary>
        /// コマンドライン引数文字列を生成します。
        /// </summary>
        /// <param name="args">コマンドライン引数の配列。</param>
        /// <returns>コマンドライン引数文字列。</returns>
        private static string CreateCommandLineArgsString(string[]? args)
        {
            var arguments = string.Empty;

            if (args is null) return arguments;

            foreach (var a in args)
            {
                if (arguments != string.Empty) arguments += " ";
                arguments += a.EncloseInDoubleQuotes();
            }

            return arguments;
        }

        #endregion

    }
}
