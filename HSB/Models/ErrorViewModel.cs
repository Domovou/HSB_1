using System;
using System.Net;

namespace HSB.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public ErrorViewModel(int statusCode)
        {
            StatusCode = statusCode;
            GetMessage();
        }

        private void GetMessage()
        {
            switch (StatusCode)
            {
                case 404:
                    Message = "Not Found";
                    break;
                case 423:
                    Message = "Locked";
                    break;
                case 401:
                    Message = "Unauthorized";
                    break;
                default:
                    Message = "Internal Server error";
                    break;
            }
        }
    }

}