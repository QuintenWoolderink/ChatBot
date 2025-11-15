using dotenv.net;
using OpenAI.Chat;

DotEnv.Load();

var apiKey = Environment.GetEnvironmentVariable("OpenAI_API_Key");
if (string.IsNullOrEmpty(apiKey))
    throw new InvalidOperationException("Missing OpenAI_API_Key in environment variables.");

var client = new ChatClient("gpt-5-nano", apiKey);

var messages = new List<ChatMessage>
{
    new AssistantChatMessage("Hello! What do you want to do today?")
};

// Eerste bericht van assistant
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Assistant:");
Console.ResetColor();
Console.WriteLine(messages[0].Content[0].Text);
Console.WriteLine();

while (true)
{
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.Write("You: ");
    Console.ResetColor();

    var input = Console.ReadLine();
    if (input == null || input.Trim().ToLower() == "exit")
        break;

    Console.WriteLine();

    messages.Add(new UserChatMessage(input));

    ChatCompletion completion = await client.CompleteChatAsync(messages);
    var response = completion.Content[0].Text;

    messages.Add(new AssistantChatMessage(response));

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Assistant:");
    Console.ResetColor();
    Console.WriteLine(response);
    Console.WriteLine();
}
