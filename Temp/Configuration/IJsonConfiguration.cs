namespace Temp.Configuration
{
    public interface IJsonConfiguration
    {
        string this[string key] { get; set; }
        void AddJsonFile(string path, bool append = false);
    }
}
