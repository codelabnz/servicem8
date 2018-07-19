using Servicem8.API.Services;

namespace Servicem8.API.Resources
{
    public abstract class Resource
    {
        protected readonly IClientExecutionService Client;

        protected Resource(IClientExecutionService client)
        {
            Client = client;
        }
    }
}
