namespace API.Errors
{
    public class ApiValidacionErrorResponse : ApiErrorsResponse
    {
        public ApiValidacionErrorResponse()
            : base(400) { }

        public IEnumerable<string> Errors { get; set; }
    }
}
