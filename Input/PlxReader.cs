using System.Xml;
using System.Xml.Linq;

namespace PlxConverter.Input;

public static class PlxReader
{
    public static async Task ReadAsync(Stream input, CancellationToken cancellationToken = default)
    {
        using var reader = CreateSafeReader(input);
        var document = await XDocument.LoadAsync(reader, LoadOptions.SetLineInfo, cancellationToken);

        Console.WriteLine(document);
    }

    private static XmlReader CreateSafeReader(Stream input)
    {
        var reader = XmlReader.Create(input, new XmlReaderSettings
        {
            Async = true,
            IgnoreComments = true,
            IgnoreWhitespace = true,
            DtdProcessing = DtdProcessing.Prohibit,
            XmlResolver = null
        });

        return reader;
    }
}