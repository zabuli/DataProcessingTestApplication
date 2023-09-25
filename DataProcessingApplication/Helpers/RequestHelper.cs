namespace DataProcessingApplication.Helpers
{
	public static class RequestHelper
	{
        private const string AUTHORIZATION = "Authorization";
        private const string BEARER = "Bearer ";

        public static string GetToken(HttpRequest httpRequest)
        {
            if (httpRequest.Headers.ContainsKey(AUTHORIZATION) && httpRequest.Headers[AUTHORIZATION][0].StartsWith(BEARER))
            {
                return httpRequest.Headers[AUTHORIZATION][0].Substring(BEARER.Length);
            }

            return "";
        }
    }
}