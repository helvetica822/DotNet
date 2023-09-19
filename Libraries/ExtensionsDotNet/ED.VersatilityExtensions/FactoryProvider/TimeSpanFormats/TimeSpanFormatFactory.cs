namespace ED.VersatilityExtensions.FactoryProvider.TimeSpanFormats
{

    /// <summary>
    /// 時間間隔フォーマットを提供します。
    /// </summary>
    public static class TimeSpanFormatFactory
    {

        #region Public Override ReadOnly Property

        /// <summary>
        /// 「hh:mm:ss.fff」の時間間隔フォーマットを取得します。
        /// </summary>
        public static AbstractTimeSpanFormat HhMmSsFff => new HhMmSsFff();

        /// <summary>
        /// 「hh:mm:ss」の時間間隔フォーマットを取得します。
        /// </summary>
        public static AbstractTimeSpanFormat HhMmSs => new HhMmSs();

        /// <summary>
        /// 「hh:mm」の時間間隔フォーマットを取得します。
        /// </summary>
        public static AbstractTimeSpanFormat HhMm => new HhMm();

        /// <summary>
        /// 「mm:ss.fff」の時間間隔フォーマットを取得します。
        /// </summary>
        public static AbstractTimeSpanFormat MmSsFff => new MmSsFff();

        /// <summary>
        /// 「mm:ss」の時間間隔フォーマットを取得します。
        /// </summary>
        public static AbstractTimeSpanFormat MmSs => new MmSs();

        /// <summary>
        /// 「ss.fff」の時間間隔フォーマットを取得します。
        /// </summary>
        public static AbstractTimeSpanFormat SsFff => new SsFff();

        /// <summary>
        /// 「hh」の時間間隔フォーマットを取得します。
        /// </summary>
        public static AbstractTimeSpanFormat Hh => new Hh();

        /// <summary>
        /// 「mm」の時間間隔フォーマットを取得します。
        /// </summary>
        public static AbstractTimeSpanFormat Mm => new Mm();

        /// <summary>
        /// 「ss」の時間間隔フォーマットを取得します。
        /// </summary>
        public static AbstractTimeSpanFormat Ss => new Ss();

        /// <summary>
        /// 「fff」の時間間隔フォーマットを取得します。
        /// </summary>
        public static AbstractTimeSpanFormat Fff => new Fff();

        #endregion

    }
}
