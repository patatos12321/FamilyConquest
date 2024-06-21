using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;

public static class HttpClientHelper {
    private static string _baseUrl = "https://localhost:7015";
    private static string _token;
    public static HttpResponseMessage Post(string url, object data) { 
        
        var client = new HttpClient();
        var myContent = JsonConvert.SerializeObject(data);
        var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
        var byteContent = new ByteArrayContent(buffer);
        byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        var postedThing = client.PostAsync(_baseUrl + url, byteContent).GetAwaiter().GetResult();
        if (postedThing != null)
        {
            if (!postedThing.IsSuccessStatusCode)
            {
                throw new System.Exception(postedThing.Content.ReadAsStringAsync().GetAwaiter().GetResult());
            }
            return postedThing;
        }
        throw new System.Exception($"No Response to post on {url} with {myContent}");
    }

    public static void SetToken(string token) { _token = token; }
}
