using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Servicem8.API.Models;

namespace Servicem8.API.Services
{
    public interface IClientExecutionService
    {
        Task<List<T>> ExecuteList<T>(string resource, object parameters = null);
        Task<T> ExecuteSingle<T>(string resource, Guid id) where T : new();
        Task ExecutePayload<T>(string resource, T model) where T : class, IKey, new();
    }
}
