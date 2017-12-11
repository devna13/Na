using Na.Extentions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Na.TextConfig
{
    public static class Parser<T> where T : class, new()
    {
        const string DefaultKeyValueSplitter = "|";

        public static T ParseFile(string filepath = null, string keyValueSplitter = null)
        {
            return File.Exists(filepath) ? Parse(File.ReadAllLines(filepath), keyValueSplitter) : null;
        }

        public static T Parse(IList<string> configLines = null, string keyValueSplitter = null)
        {
            if (configLines == null)
                return null;

            var lines = configLines.Where(row => row != String.Empty).ToList();
            if (lines.Count == 0)
                return null;

            var settings = new T();

            var dic = new Dictionary<String, object>();
            string lastKey = String.Empty;

            keyValueSplitter = keyValueSplitter ?? DefaultKeyValueSplitter;

            foreach (var row in lines)
            {
                if (row.Contains(DefaultKeyValueSplitter))
                {
                    var splited = row.Split(new[] { DefaultKeyValueSplitter }, StringSplitOptions.RemoveEmptyEntries);

                    string key = splited[0].Trim();
                    string value = splited[1].Trim();

                    if (dic.ContainsKey(key))
                        dic[key] = value;
                    else
                        dic.Add(key, value);
                    lastKey = key;
                }
                else
                {
                    // multiline value
                    dic[lastKey] += "\n" + row.Trim();
                }
            }

            // foreach (var item in dic)
            // {
            //     Console.WriteLine($"***{item.Key}={item.Value}");
            // }

            settings = dic.ToObject<T>();

            return settings;
        }
    }
}
