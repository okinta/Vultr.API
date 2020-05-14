namespace Vultr.Clients
{
    public abstract class BaseClient
    {
        protected string ApiKey { get; }
        protected string ApiURL { get; }

        protected BaseClient(string apiKey, string apiURL)
        {
            ApiKey = apiKey;
            ApiURL = apiURL;
        }
    }
}
