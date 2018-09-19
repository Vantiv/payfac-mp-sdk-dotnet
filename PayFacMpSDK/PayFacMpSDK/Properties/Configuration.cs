using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;

namespace PayFacMpSDK.Properties
{
    public class Configuration
    {
        private Dictionary<string, string> _configDictionary;

        public Configuration()
        {
            InitializeConfig();

            var settings = (NameValueCollection)ConfigurationManager.GetSection("userSettings/PayFacMpSDK.Properties.Settings");
            if (settings != null)
            {
                foreach (var key in settings.AllKeys)
                {
                    AddSettingToConfigDictionary(key, settings[key]);
                }
            }
        }

        private void InitializeConfig()
        {
            _configDictionary = new Dictionary<string, string>();
            _configDictionary["username"] = "user";
            _configDictionary["password"] = "pass";
            _configDictionary["url"] = "https://www.testvantivcnp.com/sandbox/payfac";
            _configDictionary["printxml"] = "true";
            _configDictionary["neuterXml"] = "true";
            _configDictionary["proxyHost"] = null;
            _configDictionary["proxyPort"] = null;
        }

        private void AddSettingToConfigDictionary(string key, string value)
        {
            if (!_configDictionary.ContainsKey(key))
            {
                Console.WriteLine("Warning: '{0}' is not a valid key[skipped]", key);
                return;
            }
            _configDictionary[key] = value;
        }

        public string Get(string key)
        {
            return _configDictionary[key];
        }

        public void Set(string key, string value)
        {
            _configDictionary[key] = value;
        }

        private void ValidateConfigDictionary()
        {

            if(_configDictionary["username"] == null || _configDictionary["password"] == null)
            {
                throw new PayFacException(string.Format("Missing value for username or password in config"));
            }

            if(_configDictionary["proxyHost"] != null && _configDictionary["proxyPort"] == null || _configDictionary["proxyHost"] != "" && _configDictionary["proxyPort"] == "")
            {
                throw new PayFacException(string.Format("ProxyHost is present but proxyPort npt provided"));
            }

            if(_configDictionary["url"] == null || _configDictionary["url"] == "")
            {
                throw new PayFacException(string.Format("url is not provided in the configuration setup"));
            }
         
        }
    }
}