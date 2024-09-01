namespace PE.DotRasExtended.Results
{

    public class CreateEntryResult
    {

        public bool IsSuccess { get; private set; }

        public string Message { get; private set; }

        internal CreateEntryResult() : this(true, Properties.Resources.InfoMessage001) { }

        internal CreateEntryResult(string message) : this(false, message) { }

        private CreateEntryResult(bool isSuccess, string message)
        {
            this.IsSuccess = isSuccess;
            this.Message = message;
        }

    }
}
