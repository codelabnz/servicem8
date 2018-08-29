using System;
namespace Servicem8.API.Tests
{
    public abstract class IntegrationTestsAbstract
    {
        //Add your own API credentials here
        protected readonly string _apiUsername = "sales@pandl.co.nz";
        protected readonly string _apiPassword = "South$4wark";

        public IntegrationTestsAbstract()
        {
        }
    }
}
