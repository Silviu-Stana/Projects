using System;

[AttributeUsage(AttributeTargets.Property, Inherited = false)]
public class ColumnNameAttribute : Attribute
{
    public string Name { get; }

    public ColumnNameAttribute(string name)
    {
        Name = name;
    }
}
