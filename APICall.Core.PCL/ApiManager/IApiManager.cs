using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace RefitXFSample.Services
{
    // In this interface, we are going to add all our request definitions
    public interface IApiManager
    {
       Task<HttpResponseMessage> GetMakeUps(string brand);
    }
}
