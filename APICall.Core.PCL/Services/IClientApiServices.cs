using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using APICall.Core.PCL.ModelClasses;
using Refit;

namespace RefitXFSample
{
    /*
     * we are going to return an HttpResponseMessage. Why? Because using it we can know if there was an error 
     * in the server before deserializing the JSON into an object. 
     * Also helps to show different messages according to the http response status code.
     * 
     */
    [Headers("Content-Type: application/json")]
    public interface IClientApiServices
    {
        [Get("/api/v1/products.json?brand={brand}")]
        Task<HttpResponseMessage> GetMakeUps(string brand);

        [Post("/api/v1/addMakeUp")]
        Task<MakeUp> CreateMakeUp([Body] MakeUp makeUp, [Header("Authorization")] string token);
    }
}
