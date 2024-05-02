using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace Temp.Configuration
{
    public class JsonConfiguration : IJsonConfiguration
    {
        private Dictionary<string, string> _configValues = new Dictionary<string, string>();

        public string this[string key] 
        {
            get
            {
                if (!_configValues.ContainsKey(key))
                {
                    throw new KeyNotFoundException(key);
                }

                return _configValues[key];
            }
            set
            {
                if (!_configValues.ContainsKey(key))
                {
                    throw new KeyNotFoundException(key);
                }

                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(value));
                }

                _configValues[key] = value;
            }
        }

        public void AddJsonFile(string path, bool append = false)
        {
            if (!append)
            {
                _configValues = new Dictionary<string, string>();
            }

            var projectPath = (Directory.GetParent(Application.ExecutablePath)?.Parent?.Parent?.FullName)
                ?? throw new InvalidOperationException();

            var fullPath = Path.Combine(projectPath, path);

            if (File.Exists(fullPath)) 
            {
                var jsonFile = File.ReadAllText(fullPath);

                var json = JsonDocument.Parse(jsonFile);

                var pairs = JsonSerializer.Deserialize<Dictionary<string, string>>(json);

                if (pairs != null)
                {
                    foreach (var pair in pairs)
                    {
                        try
                        {
                            _configValues.Add(pair.Key, pair.Value);
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
            }
        }
    }
}
