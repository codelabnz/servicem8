using System.Net;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Linq;
using System.Collections.Generic;
using Servicem8.API.Models;
using Servicem8.API.Exceptions;

namespace Servicem8.API.Services
{
    public class ClientExecutionService : IClientExecutionService
    {
        private readonly RestClient _client;

        public ClientExecutionService(IApiSettings settings)
        {
            _client = BuildClient(settings);
        }

        private RestClient BuildClient(IApiSettings settings)
        {
            return new RestClient(settings.Url)
            {
                Authenticator = new HttpBasicAuthenticator(settings.ApiUsername, settings.ApiPassword),
                UserAgent = "Servicem8 API"
            };
        }

        public Task<List<T>> ExecuteList<T>(string resource, object parameters = null)
        {
            var request = new RestRequest(resource, Method.GET);
            request.AddParameters(parameters);
            request.RequestFormat = DataFormat.Json;

            return ExecuteRequest<List<T>>(request);
        }

        public Task<T> ExecuteSingle<T>(string resource, Guid id) where T : new()
        {
            var request = new RestRequest(resource, Method.GET);
            request.AddUrlSegment("id", id.ToString());
            request.RequestFormat = DataFormat.Json;

            //Because the way ServiceM8 does it filtering, need to get the first one from the array in the response.
            return ExecuteRequest<List<T>>(request).ContinueWith<T>(x => x.Result.FirstOrDefault());
        }

        public Task ExecutePayload<T>(string resource, T model) where T : class, IKey, new()
        {
            if (model == null)
                throw new ArgumentNullException("model");

            if (model.uuid == Guid.Empty)
                model.uuid = Guid.NewGuid();

            var serializer = new RestSharp.Serializers.JsonSerializer();
            var request = new RestRequest(resource, Method.POST);

            request.AddParameter("application/json", serializer.Serialize(model), ParameterType.RequestBody);
           
            return ExecuteRequest(request);
        }

        private Task ExecuteRequest(IRestRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("request");

            //Optimize for small http requests
            ServicePointManager.UseNagleAlgorithm = false;

            var taskCompletionSource = new TaskCompletionSource<string>();
            _client.ExecuteAsync(request, (response) =>
            {
                if (response.ErrorException != null)
                {
                    taskCompletionSource.SetException(new RequestException("There was a problem processing the request, see inner exception for details", response.ErrorException));
                    return;
                }

                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    taskCompletionSource.SetException(new NotFoundException(string.Format("Resource With Uri '{0}' Couldn't Be Found", response.ResponseUri)));
                    return;
                }

                if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    taskCompletionSource.SetException(new InvalidRequestException(string.Format("BadRequest {0}", response.Content)));
                    return;
                }

                if (response.StatusCode == HttpStatusCode.Forbidden)
                {
                    taskCompletionSource.SetException(new AuthenticationException(string.Format("Request ApiId/Signature Invalid, {0}", response.Content)));
                    return;
                }

                if (response.StatusCode == HttpStatusCode.InternalServerError)
                {
                    taskCompletionSource.SetException(new RequestException(string.Format("There was a problem processing the request {0}", response.Content)));
                    return;
                }

                taskCompletionSource.SetResult(response.Content);
            });

            return taskCompletionSource.Task;
        }

        private Task<T> ExecuteRequest<T>(IRestRequest request) where T : new()
        {
            if (request == null)
                throw new ArgumentNullException("request");

            //Optimize for small http requests
            ServicePointManager.UseNagleAlgorithm = false;

            var taskCompletionSource = new TaskCompletionSource<T>();
            _client.ExecuteAsync<T>(request, (response) =>
            {
                if (response.ErrorException != null)
                {
                    taskCompletionSource.SetException(new RequestException("There was a problem processing the request, see inner exception for details", response.ErrorException));
                    return;
                }

                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    taskCompletionSource.SetException(new NotFoundException(string.Format("Resource With Uri '{0}' Couldn't Be Found", response.ResponseUri)));
                    return;
                }

                if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    taskCompletionSource.SetException(new InvalidRequestException(string.Format("BadRequest {0}", response.Content)));
                    return;
                }

                if (response.StatusCode == HttpStatusCode.Forbidden)
                {
                    taskCompletionSource.SetException(new AuthenticationException(string.Format("Request ApiId/Signature Invalid, {0}", response.Content)));
                    return;
                }

                if (response.StatusCode == HttpStatusCode.InternalServerError)
                {
                    taskCompletionSource.SetException(new RequestException(string.Format("There was a problem processing the request {0}", response.Content)));
                    return;
                }

                taskCompletionSource.SetResult(response.Data);
            });

            return taskCompletionSource.Task;
        }

    }
}
