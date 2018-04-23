using System;
using Fusillade;

namespace RefitXFSample.Services
{
    public interface IApiService<T>
    {
        // UserInitiated : Use for network requests that are fetching data that the user is waiting on *right now*
        // Background : Use for network requests that are running in the background
        // Speculative : Marking requests as speculative will allow requests until a certain data limit is reached, then cancel future requests (i.e. "Keep downloading data in the background until we've got 5MB of cached data")
        // Explicit : default

        T GetApi(Priority priority);
    }
}

