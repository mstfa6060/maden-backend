using Common.Services.ErrorCodeGenerator;

var pathsAndTypes = GetPathsAndTypes();
foreach (KeyValuePair<string, Type> pathAndType in pathsAndTypes)
{
    var path = Path.Combine(Directory.GetCurrentDirectory(), pathAndType.Key);
    Console.WriteLine(path);
    var content = await Read(path);

    var output = GetErrorAsTypescriptFiles(content, pathAndType.Value);

    var isWrited = await Write(pathAndType.Key, output);

    Console.WriteLine($"Result: {isWrited}");
}

static Dictionary<string, Type> GetPathsAndTypes()
{
    var pathAndTypes = new Dictionary<string, Type>()
    {
        { "../../webapp/common/hirovo-api/src/errors/locales/modules/common/tr.ts", typeof(Common.Definitions.Domain.Errors.DomainErrors) },
        { "../../webapp/common/hirovo-api/src/errors/locales/modules/workers/tr.ts", typeof(BusinessModules.Hirovo.Domain.Errors.DomainErrors) }
    };

    return pathAndTypes;
}


static string GetErrorAsTypescriptFiles(Dictionary<string, string> lines, Type myType)
{
    try
    {
        Type[] nestType = myType.GetNestedTypes();
        var output = "export const errors = {";

        foreach (Type type in nestType)
        {
            var properties = type.GetProperties().ToList();

            properties.ForEach((property) =>
            {
                if (property.PropertyType == typeof(string))
                {
                    var propertyName = ErrorCodeGenerator.GetFrontendName(property.Name);
                    var propertyValue = property.GetValue(null, null);

                    var line = lines.FirstOrDefault(l => l.Key == propertyName);

                    if (!line.Equals(new KeyValuePair<string, string>()))
                        output += Environment.NewLine + $"\t{propertyName}: {line.Value},";
                    else
                        output += Environment.NewLine + $"\t{propertyName}: '{propertyValue}',";
                }
            });
        }

        output += Environment.NewLine + "};";
        return output;
    }
    catch (Exception e)
    {
        return $"Error: {e.Message}";
    }
}

static async Task<Dictionary<string, string>> Read(string path)
{
    if (!File.Exists(path))
        return new Dictionary<string, string>();

    var content = new Dictionary<string, string>();
    var streamReader = new StreamReader(path);
    var templateContent = await streamReader.ReadToEndAsync();
    streamReader.Close();

    var templateContentKeyAndValue = templateContent
        .Replace("export const errors = {", "")
        .Replace("};", "")
        .Replace("\n", "")
        .Split(',');

    foreach (var line in templateContentKeyAndValue)
    {
        if (string.IsNullOrWhiteSpace(line) || !line.Contains(':'))
            continue;

        var parts = line.Split(':');

        var key = parts[0].Trim();
        var value = parts[1].Trim();

        if (!content.ContainsKey(key))
            content.Add(key, value);
    }

    return content;
}

static async Task<bool> Write(string path, string template)
{
    try
    {
        var streamWriter = new StreamWriter(path);
        await streamWriter.WriteAsync(template);
        streamWriter.Close();
        return true;
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
        return false;
    }
}
