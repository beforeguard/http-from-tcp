using System.Text;

var fileStream = File.OpenRead("messages.txt");
var buffer = new byte[8];
var read = await fileStream.ReadAsync(buffer, 0, buffer.Length);

while (read != 0)
{
    Console.Out.WriteLine($"read: {Encoding.UTF8.GetString(buffer)}");
    buffer = new byte[8];
    read = await fileStream.ReadAsync(buffer, 0, buffer.Length);
}
