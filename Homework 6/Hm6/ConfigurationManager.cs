using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hm6
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;

    public class ConfigurationManager
    {
        private static ConfigurationManager _instance;
        private static readonly object _syncLock = new object();
        private readonly Dictionary<string, string> _settings;

        private ConfigurationManager()
        {
            _settings = new Dictionary<string, string>();
        }

        public static ConfigurationManager Instance()
        {
            if (_instance == null)
            {
                lock (_syncLock)
                {
                    if (_instance == null)
                    {
                        _instance = new ConfigurationManager();
                    }
                }
            }
            return _instance;
        }

        public void LoadSettings(string filePath)
        {
            try
            {
                foreach (var line in File.ReadLines(filePath))
                {
                    var parts = line.Split('=');
                    if (parts.Length == 2)
                    {
                        _settings[parts[0].Trim()] = parts[1].Trim();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to load settings: {ex.Message}");
            }
        }

        public void SaveSettings(string filePath)
        {
            try
            {
                using (var writer = new StreamWriter(filePath))
                {
                    foreach (var setting in _settings)
                    {
                        writer.WriteLine($"{setting.Key}={setting.Value}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to save settings: {ex.Message}");
            }
        }

        public string GetSetting(string key)
        {
            if (_settings.TryGetValue(key, out var value))
            {
                return value;
            }
            throw new KeyNotFoundException($"Setting '{key}' not found.");
        }

        public void UpdateSetting(string key, string value)
        {
            _settings[key] = value;
        }
    }

}
