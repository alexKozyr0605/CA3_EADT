//FixerResponse.cs (shared folder)
using Microsoft.VisualBasic;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;
//using System.Net.Http;
//using System.Net.Http.Json;

namespace Shared
{
    public class FixerResponse
    {
        public bool Success { get; set; }
        public string Base { get; set; }
        public Dictionary<string, decimal> Rates { get; set; }
    }
}