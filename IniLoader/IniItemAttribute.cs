using System;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
public class IniItemAttribute : Attribute
{
    public string Key { get; }

    public IniItemAttribute(string key)
    {
        Key = key;
    }
}