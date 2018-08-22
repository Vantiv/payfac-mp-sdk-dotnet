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
            var settings = (NameValueCollection) ConfigurationManager.GetSection("worldpay/PayFacMpSDKSettings");
            InitializeConfig();
            foreach (var key in settings.AllKeys)
            {
                AddSettingToConfigDictionary(key, settings[key]); 
            }
            ValidateConfigDictionary();
        }

        private void InitializeConfig()
        {
            _configDictionary = new Dictionary<string, string>();
            _configDictionary["username"] = null;
            _configDictionary["password"] = null;
            _configDictionary["url"] = null;
            _configDictionary["printXml"] = null;
            _configDictionary["timeout"] = null;
            _configDictionary["neuterAccountNums"] = null;
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
            foreach (var key in _configDictionary.Keys)
            {
                if (_configDictionary[key] == null)
                {
                    throw new PayFacException(string.Format("Missing value for {0} in config", key));
                }
            }
        }
    }
}