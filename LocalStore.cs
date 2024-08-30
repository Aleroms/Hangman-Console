public class LocalStore : IStorage
{


    public string Read(string filePath)
    {
        if (File.Exists(filePath))
        {
            var fileContents = File.ReadAllText(filePath);
            return fileContents;
        }
        return "0";
    }

    public void Write(string filePath, string data)
    {
        File.WriteAllText(filePath, data);
    }
}