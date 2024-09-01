namespace ED.VersatilityExtensions.FactoryProvider.DateTimeFormats
{

    /// <summary>
    /// 日時フォーマットを提供します。
    /// </summary>
    public static class DateTimeFormatFactory
    {

        #region Public Override ReadOnly Property

        /// <summary>
        /// 「yyyy/MM/dd HH:mm:ss.fff」の日時フォーマットを取得します。
        /// </summary>
        public static AbstractDateTimeFormat YyyyMmDdHh24MmSsFff => new YyyyMmDdHh24MmSsFff();

        /// <summary>
        /// 「yyyy/MM/dd hh:mm:ss.fff」の日時フォーマットを取得します。
        /// </summary>
        public static AbstractDateTimeFormat YyyyMmDdHhMmSsFff => new YyyyMmDdHhMmSsFff();

        /// <summary>
        /// 「yyyy/MM/dd HH:mm:ss」の日時フォーマットを取得します。
        /// </summary>
        public static AbstractDateTimeFormat YyyyMmDdHh24MmSs => new YyyyMmDdHh24MmSs();

        /// <summary>
        /// 「yyyy/MM/dd hh:mm:ss」の日時フォーマットを取得します。
        /// </summary>
        public static AbstractDateTimeFormat YyyyMmDdHhMmSs => new YyyyMmDdHhMmSs();

        /// <summary>
        /// 「yyyy/MM/dd HH:mm」の日時フォーマットを取得します。
        /// </summary>
        public static AbstractDateTimeFormat YyyyMmDdHh24Mm => new YyyyMmDdHh24Mm();

        /// <summary>
        /// 「yyyy/MM/dd hh:mm」の日時フォーマットを取得します。
        /// </summary>
        public static AbstractDateTimeFormat YyyyMmDdHhMm => new YyyyMmDdHhMm();

        /// <summary>
        /// 「yyyy/MM/dd HH」の日時フォーマットを取得します。
        /// </summary>
        public static AbstractDateTimeFormat YyyyMmDdHh24 => new YyyyMmDdHh24();

        /// <summary>
        /// 「yyyy/MM/dd hh」の日時フォーマットを取得します。
        /// </summary>
        public static AbstractDateTimeFormat YyyyMmDdHh => new YyyyMmDdHh();

        /// <summary>
        /// 「yyyy/MM/dd」の日時フォーマットを取得します。
        /// </summary>
        public static AbstractDateTimeFormat YyyyMmDd => new YyyyMmDd();

        /// <summary>
        /// 「yyyy/MM」の日時フォーマットを取得します。
        /// </summary>
        public static AbstractDateTimeFormat YyyyMm => new YyyyMm();

        /// <summary>
        /// 「MM/dd」の日時フォーマットを取得します。
        /// </summary>
        public static AbstractDateTimeFormat MmDd => new MmDd();

        /// <summary>
        /// 「HH:mm:ss.fff」の日時フォーマットを取得します。
        /// </summary>
        public static AbstractDateTimeFormat Hh24MmSsFff => new Hh24MmSsFff();

        /// <summary>
        /// 「hh:mm:ss.fff」の日時フォーマットを取得します。
        /// </summary>
        public static AbstractDateTimeFormat HhMmSsFff => new HhMmSsFff();

        /// <summary>
        /// 「HH:mm:ss」の日時フォーマットを取得します。
        /// </summary>
        public static AbstractDateTimeFormat Hh24MmSs => new Hh24MmSs();

        /// <summary>
        /// 「hh:mm:ss」の日時フォーマットを取得します。
        /// </summary>
        public static AbstractDateTimeFormat HhMmSs => new HhMmSs();

        /// <summary>
        /// 「HH:mm」の日時フォーマットを取得します。
        /// </summary>
        public static AbstractDateTimeFormat Hh24Mm => new Hh24Mm();

        /// <summary>
        /// 「hh:mm」の日時フォーマットを取得します。
        /// </summary>
        public static AbstractDateTimeFormat HhMm => new HhMm();

        /// <summary>
        /// 「mm:ss.fff」の日時フォーマットを取得します。
        /// </summary>
        public static AbstractDateTimeFormat MmSsFff => new MmSsFff();

        /// <summary>
        /// 「mm:ss」の日時フォーマットを取得します。
        /// </summary>
        public static AbstractDateTimeFormat MmSs => new MmSs();

        /// <summary>
        /// 「ss.fff」の日時フォーマットを取得します。
        /// </summary>
        public static AbstractDateTimeFormat SsFff => new SsFff();

        /// <summary>
        /// 「yyyy」の日時フォーマットを取得します。
        /// </summary>
        public static AbstractDateTimeFormat Yyyy => new Yyyy();

        /// <summary>
        /// 「MM」の日時フォーマットを取得します。
        /// </summary>
        public static AbstractDateTimeFormat Mm => new Mm();

        /// <summary>
        /// 「dd」の日時フォーマットを取得します。
        /// </summary>
        public static AbstractDateTimeFormat Dd => new Dd();

        /// <summary>
        /// 「HH」の日時フォーマットを取得します。
        /// </summary>
        public static AbstractDateTimeFormat Hh24 => new Hh24();

        /// <summary>
        /// 「hh」の日時フォーマットを取得します。
        /// </summary>
        public static AbstractDateTimeFormat Hh => new Hh();

        /// <summary>
        /// 「mm」の日時フォーマットを取得します。
        /// </summary>
        public static AbstractDateTimeFormat Mi => new Mi();

        /// <summary>
        /// 「ss」の日時フォーマットを取得します。
        /// </summary>
        public static AbstractDateTimeFormat Ss => new Ss();

        /// <summary>
        /// 「fff」の日時フォーマットを取得します。
        /// </summary>
        public static AbstractDateTimeFormat Fff => new Fff();

        #endregion

    }
}
