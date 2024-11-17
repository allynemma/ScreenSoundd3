using RestSharp;
using System.Text.Json.Nodes;

namespace ScreenSound.API;

public class OpenAIClient
{
    private readonly string apiKey;

    public OpenAIClient(string apiKey)
    {
        this.apiKey = apiKey;
    }

    public async Task<string> SendRequest(string prompt)
    {
        var client = new RestClient("https://api.openai.com/v1/completions");
        var request = new RestRequest("https://api.openai.com/v1/completions", Method.Post);

        request.AddHeader("Authorization", $"Bearer {apiKey}");
        request.AddHeader("Content-Type", "application/json");

        var body = new
        {
            model = "text-davinci-003",
            prompt,
            max_tokens = 50
        };

        request.AddJsonBody(body);

        var respone = await client.ExecuteAsync(request);
        if (respone.IsSuccessful)
        {
            var jsonResponse = JsonNode.Parse(respone.Content);
            return jsonResponse["choices"][0]["text"].ToString().Trim();
        }
        else
        {
            throw new Exception($"Erro: {respone.StatusCode} - {respone.Content}");
        }
    }
}
