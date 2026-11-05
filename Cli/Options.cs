using System.CommandLine;

namespace PlxConverter.Cli;

public static class Options
{
    public readonly static Option<FileInfo> InputFileOption = new("--input-file")
    {
        Description = "Файл для конвертации.",
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

    public readonly static Option<string[]> OutputFormatsOption = new("--output-formats")
    {
        Description = "Форматы выходного файла.",
        AllowMultipleArgumentsPerToken = true,
        Required = true
    };

    static Options()
    {
        OutputFormatsOption.Validators.Add(result =>
        {
            foreach (var token in result.Tokens)
            {
                var value = token.Value;

                if (value != "json" && value != "yaml")
                    result.AddError($"Недопустимый формат: {value}. Допустимые значения: json, yaml.");
            }
        });
    }
}