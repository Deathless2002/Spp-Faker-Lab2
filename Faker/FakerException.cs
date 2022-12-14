namespace FakerLib 
{
    public class FakerException : Exception
    {
        public override string Message { get; }

        public FakerException(string message) => Message = $"FakerException: {message}";
    }
}
