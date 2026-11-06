using System.CommandLine;

namespace PlxConverter.Cli;

public static class Options
{
    public readonly static Option<FileInfo> InputOption = new("--input", "-i")
    {
        Description = "Путь к исходному .plx-файлу.",
        Required = true,
        CustomParser = result =>
        {
            var file = new FileInfo(result.Tokens.Single().Value);

            if (!file.Exists)
                result.AddError("Файл не найден.");

            if (file.Extension != ".plx")
                result.AddError("Файл не в формате plx.");

            return file;
        }
    };

    public readonly static Option<FileInfo> OutputOption = new("--output", "-o")
    {
        Description = "Путь к JSON/YAML-файлу результата.",
        Required = true
    };

    public readonly static Option<OutputFormat> OutputFormatsOption = new("--format")
    {
        Description = "Формат результата.",
        Required = true,
        DefaultValueFactory = _ => OutputFormat.Json
    };
}