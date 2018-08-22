using System;
using System.Text;

namespace PayFacMpSDK
{

    [Serializable]
    public class PayFacException: Exception
    {
        public string ErrorMessage;

        public PayFacException(string  errorMessage) : base(errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }

    [Serializable]
    public class PayFacWebException: Exception
    {
        public readonly string ErrorMessage;
        public readonly string RawResponse;
        public readonly int HttpStatusCode;
        public errorResponse errorResponse;

        public PayFacWebException(string errorMessage, int httpStatusCode, string rawResponse) : base(errorMessage)
        {
            ErrorMessage = errorMessage;
            HttpStatusCode = httpStatusCode;
            RawResponse = rawResponse;
        }

        public PayFacWebException(string errorMessage, int httpStatusCode, string rawResponse, errorResponse errorResponse)
            : base(errorMessage + ExtractErrorMessages(errorResponse))
        {
            ErrorMessage = errorMessage;
            HttpStatusCode = httpStatusCode;
            RawResponse = rawResponse;
            this.errorResponse = errorResponse;
        }

        public static string ExtractErrorMessages(errorResponse errorResponse)
        {
            var errorMessages = errorResponse.errors;
            StringBuilder errorBuilder = new StringBuilder();
            foreach(var err in errorMessages)
            {
                errorBuilder.AppendLine(err);
            }
            return errorBuilder.ToString();
        }
    }
}