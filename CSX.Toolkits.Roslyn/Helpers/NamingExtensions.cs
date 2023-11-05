namespace CSX.Toolkits.Roslyn.Helpers;

public static class NamingExtensions
{
    public static bool CanCapitalize(this string name)
    {
        if (name.Length < 1)
            return false;

        // check if first char is lowercase
        if (char.IsLower(name[0]))
            return true;

        // check if first char is _ and second is in lowercase.
        if (name.Length >= 2 &&
            name[0] == '_' &&
            char.IsLower(name[1]))
            return true;

        return false;
    }

    public static bool IsCapitalized(this string name)
        => char.IsUpper(name[0]);

    public static string Capitalize(this string name)
    {
        if (!CanCapitalize(name))
            return name;

        if (name[0] == '_')
            name = name[1..];

        return $"{char.ToUpperInvariant(name[0])}{name[1..]}";
    }
}