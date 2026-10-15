try
{
    if (args.Length != 1)
    {
        Console.WriteLine("Usage: name-sorter <input-file-path>");
        return;
    }

    string inputFilePath = args[0];

    if (!File.Exists(inputFilePath))
    {
        Console.WriteLine($"Input file not found: {inputFilePath}");
        return;
    }

    var sortedNames = File.ReadAllLines(inputFilePath)
        .Where(line => !string.IsNullOrWhiteSpace(line))
        .Select(line => new PersonName(line))
        .OrderBy(name => name.LastName)
        .ThenBy(name => name.GivenNames)
        .ToList();

    foreach (var name in sortedNames)
    {
        Console.WriteLine(name);
    }

    File.WriteAllLines(
        "sorted-names-list.txt",
        sortedNames.Select(name => name.ToString()));

    Console.WriteLine();
    Console.WriteLine("Sorted names have been written to sorted-names-list.txt");
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred: {ex.Message}");
}