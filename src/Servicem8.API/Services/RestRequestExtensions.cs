using System;
using RestSharp;
using System.ComponentModel;
using Servicem8.API.Models;

namespace Servicem8.API.Services
{
    public static class RestRequestExtensions
    {
        public static void AddParameters(this IRestRequest request, object source)
        {
            if (source == null)
                return;

            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(source))
            {
                var value = property.GetValue(source);
                if (value != null)
                    request.AddParameter(property.Name, FormatString(value));
            }
        }

        private static string FormatString(object value)
        {
            if (value is DateTime)
                return ((DateTime)value).ToString("yyyy-MM-dd");
            return value.ToString();
        }

    }
}
