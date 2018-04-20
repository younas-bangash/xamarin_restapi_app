ModerHttpClient		// ModernHttpClient helps us to do our requests faster (It is faster than HttpClient because uses platform native apis).
Fusillade			// An HttpClient implementation for mobile apps that efficiently schedules and prioritizes requests and can also use for offline cache
Polly 				// Polly will help us to handle Retry, timeout, Circuit Breaker, etc.
Connectivity Plugn  // Get network connectivity information such as network type, speeds, and if connection is available.
Acr.UserDialogs		// call for standard user dialogs from a shared/portable library.

In our Services folder, we are going to add another class called ApiManager and an interface IApiManager,
  ApiManager :  we are going to do all the api requests implementation 
  IApiManager : we are going to use the interface to interact with it.