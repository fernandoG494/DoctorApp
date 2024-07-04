namespace API.Errors
{
    public class ApiErrorsResponse
    {
        public int statusCode { get; set; }
        public string message { get; set; }

        public ApiErrorsResponse(int statusCode, string message = null)
        {
            this.statusCode = statusCode;
            this.message = message ?? GetMessageStatusCode(statusCode);
        }

        private string GetMessageStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "Request not valid",
                401 => "Authorization not valid",
                404 => "Resource not located",
                500 => "Internal server error",
                _ => null,
            };
        }
    }
}
