namespace PE.DotRasExtended.Results
{

    public class DialResult
    {

        public bool IsSuccess { get; private set; }

        public string Message { get; private set; }

        internal DialResult() : this(true, Properties.Resources.InfoMessage002) { }

        internal DialResult(string message) : this(false, message) { }

        private DialResult(bool isSuccess, string message)
        {
            this.IsSuccess = isSuccess;
            this.Message = message;
        }

    }
}
