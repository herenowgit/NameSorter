public class PersonName
{
    public string FullName { get; }

    public string LastName { get; }

    public string GivenNames { get; }

    public PersonName(string fullName)
    {
        FullName = fullName;

        var parts = fullName.Split(
            ' ',
            StringSplitOptions.RemoveEmptyEntries);

        if (parts.Length < 2)
            throw new ArgumentException(
                "A name must contain at least one given name and one surname.");

        LastName = parts[parts.Length - 1];//LastName = parts[^1];

        GivenNames = string.Join(" ", parts.Take(parts.Length - 1));//GivenNames = string.Join(" ", parts[..^1]);
    }

    public override string ToString() => FullName;
}