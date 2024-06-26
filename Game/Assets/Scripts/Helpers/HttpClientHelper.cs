using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using UnityEngine.SceneManagement;

public static class HttpClientHelper {
    private static string _baseUrl = "https://localhost:7015";
    private static string _token = string.Empty;
    public static T Post<T>(string url, object data)
    {
        var postResponse = GetConfiguredClient().PostAsync(_baseUrl + url, GetContent(data)).GetAwaiter().GetResult();
        HandleResponseCodes(url, data, postResponse);
        return JsonConvert.DeserializeObject<T>(postResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult());
    }

    public static T Put<T>(string url, object data)
    {
        var putResponse = GetConfiguredClient().PutAsync(_baseUrl + url, GetContent(data)).GetAwaiter().GetResult();
        HandleResponseCodes(url, data, putResponse);
        return JsonConvert.DeserializeObject<T>(putResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult());
    }

    public static T Get<T>(string url)
    {
        var getResponse = GetConfiguredClient().GetAsync(_baseUrl + url).GetAwaiter().GetResult();
        HandleResponseCodes(url, null, getResponse);
        return JsonConvert.DeserializeObject<T>(getResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult());
    }

    private static void HandleResponseCodes(string url, object data, HttpResponseMessage response)
    {
        if (response == null) { throw new Exception($"No Response to post on {url} with {JsonConvert.SerializeObject(data)}"); }
        if (!response.IsSuccessStatusCode)
        {
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                SceneManager.LoadSceneAsync("Login");
                throw new UnauthorizedAccessException();
            }
            throw new Exception(response.Content.ReadAsStringAsync().GetAwaiter().GetResult());
        }
    }

    private static HttpClient GetConfiguredClient()
    {
        var client = new HttpClient();
        client.DefaultRequestHeaders.Add("AuthToken", _token);
        return client;
    }

    private static ByteArrayContent GetContent(object data)
    {
        var myContent = JsonConvert.SerializeObject(data);
        var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
        var byteContent = new ByteArrayContent(buffer);
        byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        return byteContent;
    }

    public static void SetToken(string token) { _token = token; }
}
