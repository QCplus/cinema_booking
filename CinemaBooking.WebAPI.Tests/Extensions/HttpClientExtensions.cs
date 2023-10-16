using System.Net;
using System.Net.Http.Json;

namespace CinemaBooking.WebAPI.Tests.Extensions;

internal static class HttpClientExtensions
{
    public static HttpResponseMessage EnsureSuccess(this HttpResponseMessage message)
    {
        if (!message.IsSuccessStatusCode)
        {
            Assert.Fail(
                $"Request failed with message: {message.Content.ReadAsStringAsync().Result}");
        }

        return message;
    }

    private static T Parse<T>(string value)
    {
        object parsedValue = typeof(T).Name switch
        {
            nameof(String) => value,
            nameof(Int32) => int.Parse(value),
            _ => throw new NotImplementedException($"Type {typeof(T)} is'n supported")
        };

        return (T)parsedValue;
    }

    public static T? GetContent<T>(this HttpResponseMessage message)
    {
        var contentType = typeof(T);
        if (contentType.IsPrimitive || contentType == typeof(string))
        {
            return Parse<T>(
                message.Content.ReadAsStringAsync().Result);
        }

        return message.Content.ReadFromJsonAsync<T>().Result;
    }

    public static int PostAsJsonGetId<T>(this HttpClient client, string url, T model)
    {
        return client.PostAsJsonAsync(url, model).Result
            .EnsureSuccess()
            .GetContent<int>();
    }
}
