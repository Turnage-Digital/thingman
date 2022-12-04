using System.Reflection;

namespace ThingMan.Core;

public abstract class Enumeration
{
    protected Enumeration(int id, string name)
    {
        (Id, Name) = (id, name);
    }

    public string Name { get; }

    public int Id { get; }
    
    public static T FromValue<T>(int value) where T : Enumeration
    {
        var retval = Parse<T, int>(value, "value", item => item.Id == value);
        return retval;
    }

    public static T FromValue<T>(string value) where T : Enumeration
    {
        var isInt = int.TryParse(value, out var parsedInt);
        if (!isInt)
            return FromValue<T>(0);

        var retval = Parse<T, int>(parsedInt, "value", item => item.Id == parsedInt);
        return retval;
    }

    public static T FromDisplayName<T>(string displayName) where T : Enumeration
    {
        var retval = Parse<T, string>(displayName, "display name", item => item.Name == displayName);
        return retval;
    }

    private static T Parse<T, TK>(TK value, string description, Func<T, bool> predicate) where T : Enumeration
    {
        var retval = GetAll<T>().FirstOrDefault(predicate);

        if (retval == null)
            throw new InvalidOperationException($"'{value}' is not a valid {description} in {typeof(T)}");

        return retval;
    }

    public static IEnumerable<T> GetAll<T>()
        where T : Enumeration
    {
        return typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
            .Select(f => f.GetValue(null))
            .Cast<T>();
    }
}