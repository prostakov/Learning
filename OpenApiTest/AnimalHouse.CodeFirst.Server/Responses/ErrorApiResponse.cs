using System.Collections.Generic;

namespace AnimalHouse.CodeFirst.Server.Responses
{
    public class ErrorApiResponse
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public Dictionary<string, string> Errors { get; set; }
    }
}