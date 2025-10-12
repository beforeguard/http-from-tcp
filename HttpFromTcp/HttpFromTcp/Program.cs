using System.Text;

using var fileStream = File.OpenRead("messages.txt");

static async Task<string?> ReadStringFromStream(Stream stream, int length)
{
    var buffer = new byte[length];
    var read = await stream.ReadAsync(buffer, 0, buffer.Length);
    if (read > 0)
    {
        return Encoding.UTF8.GetString(buffer, 0, read).Replace("\r", string.Empty);
    }
    else
    {
        return null;
    }
}

var stringBuilder = new StringBuilder();
while (await ReadStringFromStream(fileStream, length: 8) is string streamText)
{
    var newlineIndex = streamText.IndexOf('\n', 0);
    if (newlineIndex != -1)
    {
        stringBuilder.Append(streamText, 0, newlineIndex + 1);
        Console.Out.Write($"read: {stringBuilder.ToString()}");
        stringBuilder.Clear();
        stringBuilder.Append(streamText.Substring(newlineIndex + 1));
    }
    else
    {
        stringBuilder.Append(streamText);
    }
}

Console.Out.Write($"read: {stringBuilder.ToString()}");
