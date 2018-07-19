using System;
namespace Servicem8.API
{
    public interface IApiSettings
    {
        string ApiUsername { get; }
        string ApiPassword { get; }
        string Url { get; }
    }
}
