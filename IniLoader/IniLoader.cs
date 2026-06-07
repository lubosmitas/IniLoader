namespace IniLoader
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;

    public class IniLoader
    {
        private Dictionary<string, Dictionary<string, string>> data
            = new Dictionary<string, Dictionary<string, string>>();

        //public IniLoader(string filePath)
        public IniLoader()
        {
            //Load(filePath);
            
        }

        private void Load(string filePath)
        {
            string currentSection = "";

            foreach (var rawLine in File.ReadAllLines(filePath))
            {
                string line = rawLine.Trim();

                // prázdný řádek
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                // komentář celý řádek
                if (line.StartsWith(";"))
                    continue;

                // odstranění inline komentářů
                int commentIndex = line.IndexOf(';');
                if (commentIndex >= 0)
                    line = line.Substring(0, commentIndex).Trim();

                // sekce [config]
                if (line.StartsWith("[") && line.EndsWith("]"))
                {
                    currentSection = line.Substring(1, line.Length - 2).Trim();

                    if (!data.ContainsKey(currentSection))
                        data[currentSection] = new Dictionary<string, string>();

                    continue;
                }

                // key=value
                var parts = line.Split('=', 2);

                if (parts.Length != 2)
                    continue;

                string key = parts[0].Trim();
                string value = parts[1].Trim();

                if (!data.ContainsKey(currentSection))
                    data[currentSection] = new Dictionary<string, string>();

                data[currentSection][key] = value;
            }
        }

        // základní čtení
        public string Get(string section, string key, string defaultValue = "")
        {
            if (data.ContainsKey(section) &&
                data[section].ContainsKey(key))
            {
                return data[section][key];
            }

            return defaultValue;
        }


        public void LoadObjects(string filePath, params object[] objects)
            {
                Load(filePath);

                foreach (var obj in objects)
                {
                    Type type = obj.GetType();

                    // properties
                    foreach (var prop in type.GetProperties())
                    {
                        var attr = prop.GetCustomAttribute<IniItemAttribute>();
                        if (attr == null) continue;

                        string value = GetValue(attr.Key);
                        if (value == null) continue;

                        object converted = ConvertValue(value, prop.PropertyType);
                        prop.SetValue(obj, converted);
                    }

                    // fields
                    foreach (var field in type.GetFields())
                    {
                        var attr = field.GetCustomAttribute<IniItemAttribute>();
                        if (attr == null) continue;

                        string value = GetValue(attr.Key);
                        if (value == null) continue;

                        object converted = ConvertValue(value, field.FieldType);
                        field.SetValue(obj, converted);
                    }
                }
            }

        private string GetValue(string key)
        {
            foreach (var section in data.Values)
            {
                if (section.ContainsKey(key))
                    return section[key];
            }

            return null;
        }

        private object ConvertValue(string value, Type type)
        {
            if (type == typeof(string))
                return value;

            if (type == typeof(int))
            {
                value = value.Trim();

                if (value.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
                    return Convert.ToInt32(value, 16);

                return int.Parse(value);
            }
            if (type == typeof(bool))
                return bool.Parse(value);

            
            if (type == typeof(double))
                return double.Parse(value, System.Globalization.CultureInfo.InvariantCulture);

            if (type == typeof(float))
                return float.Parse(value, System.Globalization.CultureInfo.InvariantCulture);

            if (type == typeof(long))
            {
                if (value.StartsWith("0x"))
                    return Convert.ToInt64(value, 16);

                return long.Parse(value);
            }
            if (type == typeof(long))
            {
                value = value.Trim();

                if (value.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
                    return Convert.ToInt64(value, 16);

                return long.Parse(value);
            }
            if (type == typeof(double))
                return double.Parse(value, System.Globalization.CultureInfo.InvariantCulture);

            return null;
        }


    }




}


