using System.ClientModel;
using OpenAI.Chat;

namespace CometeAPI.Application.Service;

public class OpenAiService
{
    private readonly ChatClient _client;

    public OpenAiService(IConfiguration configuration)
    {
        var apiKey = configuration["OpenAI:ApiKey"];
        if (string.IsNullOrEmpty(apiKey))
        {
            throw new InvalidOperationException("OpenAI API key is not configured properly.");
        }

        _client = new ChatClient("gpt-4o", new ApiKeyCredential(apiKey));
    }

    public async Task<string> GetResumeAsync(string prompt)
    {
        ChatCompletion completion = await _client.CompleteChatAsync(prompt);

        // On extrait uniquement le texte de la réponse
        var textParts = completion.Content
            .Where(part => !string.IsNullOrEmpty(part.Text))
            .Select(part => part.Text)
            .ToList();

        return string.Join("\n", textParts);
    }
}
