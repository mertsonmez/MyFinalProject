namespace Core.Utilities.Results
{
    public class ErrorResult : Result
    {
        public ErrorResult(string message) : base(false, message)
        {
            //true yu default vermek için bu yapıyı kurduk!!
        }

        public ErrorResult() : base(false)
        {

        }

    }
}
